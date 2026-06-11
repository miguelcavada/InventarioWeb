using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Web.Controllers;

[Authorize]
public class ProductosController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Productos
    public async Task<IActionResult> Index(string buscar, string orden = "nombre")
    {
        var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();

        if (!string.IsNullOrEmpty(buscar))
        {
            productos = productos.Where(p =>
                p.Nombre.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
                p.Codigo.Contains(buscar, StringComparison.OrdinalIgnoreCase));
        }

        productos = orden switch
        {
            "codigo" => productos.OrderBy(p => p.Codigo),
            "stock" => productos.OrderByDescending(p => p.Stocks.Sum(s => s.StockActual)),
            "precio" => productos.OrderBy(p => p.PrecioVenta),
            _ => productos.OrderBy(p => p.Nombre),
        };

        var productosDto = productos.Select(p => p.ToDto()).ToList();
        return View(productosDto);
    }

    // GET: Productos/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var producto = await _unitOfWork.Productos.GetProductoConCategoriaAsync(id);
        if (producto == null) return NotFound();

        return View(producto.ToDto());
    }

    // GET: Productos/Create
    [Authorize(Roles = "Admin,Gerente")]
    public async Task<IActionResult> Create()
    {
        await CargarCategoriasAsync();
        return View(new ProductoDto());
    }

    // POST: Productos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin,Gerente")]
    public async Task<IActionResult> Create(ProductoDto productoDto)
    {
        if (await _unitOfWork.Productos.CodigoExisteAsync(productoDto.Codigo))
            ModelState.AddModelError("Codigo", "El código ya existe");

        if (ModelState.IsValid)
        {
            var producto = productoDto.ToEntity();
            producto.FechaCreacion = DateTime.Now;
            producto.Activo = true;

            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Producto creado exitosamente. Asigne stock en los almacenes.";
            return RedirectToAction(nameof(Index));
        }

        await CargarCategoriasAsync();
        return View(productoDto);
    }

    // GET: Productos/Edit/5
    [Authorize(Roles = "Admin,Gerente")]
    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) return NotFound();

        await CargarCategoriasAsync(producto.CategoriaId);
        return View(producto.ToDto());
    }

    // POST: Productos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin,Gerente")]
    public async Task<IActionResult> Edit(int id, ProductoDto productoDto)
    {
        if (id != productoDto.Id) return NotFound();

        if (await _unitOfWork.Productos.CodigoExisteAsync(productoDto.Codigo, id))
            ModelState.AddModelError("Codigo", "El código ya existe");

        if (ModelState.IsValid)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null) return NotFound();

            productoDto.UpdateEntity(producto);

            await _unitOfWork.Productos.UpdateAsync(producto);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Producto actualizado exitosamente";
            return RedirectToAction(nameof(Index));
        }

        await CargarCategoriasAsync(productoDto.CategoriaId);
        return View(productoDto);
    }

    // GET: Productos/Delete/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _unitOfWork.Productos.GetProductoConCategoriaAsync(id);
        if (producto == null) return NotFound();

        return View(producto.ToDto());
    }

    // POST: Productos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) return NotFound();

        producto.Activo = false;
        producto.FechaModificacion = DateTime.Now;

        await _unitOfWork.Productos.UpdateAsync(producto);
        await _unitOfWork.CompleteAsync();

        TempData["Mensaje"] = "Producto eliminado exitosamente";
        return RedirectToAction(nameof(Index));
    }

    // GET: Productos/CambioPrecio/5
    [Authorize(Roles = "Admin,Gerente")]
    public async Task<IActionResult> CambioPrecio(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) return NotFound();

        var model = new CambioPrecioDto
        {
            ProductoId = producto.Id,
            PrecioCostoNuevo = producto.PrecioCosto,
            PrecioVentaNuevo = producto.PrecioVenta
        };

        ViewBag.Producto = producto;
        return View(model);
    }

    // POST: Productos/CambioPrecio/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin,Gerente")]
    public async Task<IActionResult> CambioPrecio(CambioPrecioDto model)
    {
        if (ModelState.IsValid)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(model.ProductoId);
            if (producto == null) return NotFound();

            if (producto.PrecioCosto != model.PrecioCostoNuevo ||
                producto.PrecioVenta != model.PrecioVentaNuevo)
            {
                var historial = new HistorialPrecio
                {
                    ProductoId = producto.Id,
                    PrecioCostoAnterior = producto.PrecioCosto,
                    PrecioCostoNuevo = model.PrecioCostoNuevo,
                    PrecioVentaAnterior = producto.PrecioVenta,
                    PrecioVentaNuevo = model.PrecioVentaNuevo,
                    Motivo = model.Motivo,
                    FechaCambio = DateTime.Now,
                    UsuarioCambio = User.FindFirst(ClaimTypes.Name)?.Value ?? User.Identity?.Name ?? "Sistema",
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };

                await _unitOfWork.HistorialPrecios.AddAsync(historial);
            }

            producto.PrecioCosto = model.PrecioCostoNuevo;
            producto.PrecioVenta = model.PrecioVentaNuevo;
            producto.FechaModificacion = DateTime.Now;

            await _unitOfWork.Productos.UpdateAsync(producto);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Precios actualizados exitosamente";
            return RedirectToAction(nameof(Index));
        }

        var prod = await _unitOfWork.Productos.GetByIdAsync(model.ProductoId);
        ViewBag.Producto = prod;
        return View(model);
    }

    // GET: Productos/HistorialPrecios/5
    public async Task<IActionResult> HistorialPrecios(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) return NotFound();

        var historial = await _unitOfWork.HistorialPrecios.GetHistorialPorProductoAsync(id);
        var historialDto = historial.Select(h => h.ToDto());

        ViewBag.Producto = producto;
        return View(historialDto);
    }

    // GET: Productos/Stock/5
    [Authorize(Roles = "Admin,Gerente,Operador")]
    public async Task<IActionResult> GestionarStock(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) return NotFound();

        var stocks = await _unitOfWork.StockAlmacenes.GetStocksPorProductoAsync(id);
        var stocksDto = stocks.Select(s => s.ToDto()).ToList();

        ViewBag.Producto = producto;
        return View(stocksDto);
    }

    private async Task CargarCategoriasAsync(int? selectedId = null)
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        ViewBag.Categorias = new SelectList(categorias.Where(c => c.Activo), "Id", "Nombre", selectedId);
    }
}