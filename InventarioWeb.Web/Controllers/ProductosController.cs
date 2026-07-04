using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
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
            "precio" => productos.OrderBy(p => p.PrecioVentaMinorista),
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
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create()
    {
        await CargarListasAsync();
        return View(new ProductoDto());
    }

    // POST: Productos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
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

        await CargarListasAsync();
        return View(productoDto);
    }

    // GET: Productos/Edit/5
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) return NotFound();

        await CargarListasAsync(producto.CategoriaId, producto.UnidadMedidaId);
        return View(producto.ToDto());
    }

    // POST: Productos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
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

        await CargarListasAsync(productoDto.CategoriaId, productoDto.UnidadMedidaId);
        return View(productoDto);
    }

    // GET: Productos/Delete/5
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _unitOfWork.Productos.GetProductoConCategoriaAsync(id);
        if (producto == null) return NotFound();

        return View(producto.ToDto());
    }

    // POST: Productos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.Admin)]
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
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> CambioPrecio(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null) return NotFound();

        var model = new CambioPrecioDto
        {
            ProductoId = producto.Id,
            PrecioCostoNuevo = producto.PrecioCosto,
            PrecioVentaMinoristaNuevo = producto.PrecioVentaMinorista,
            PrecioVentaMayoristaNuevo = producto.PrecioVentaMayorista
        };

        ViewBag.Producto = producto;
        return View(model);
    }

    // POST: Productos/CambioPrecio/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> CambioPrecio(CambioPrecioDto model)
    {
        if (ModelState.IsValid)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(model.ProductoId);
            if (producto == null) return NotFound();

            // Verificar si hubo cambios
            bool huboCambio = producto.PrecioCosto != model.PrecioCostoNuevo ||
                             producto.PrecioVentaMinorista != model.PrecioVentaMinoristaNuevo ||
                             producto.PrecioVentaMayorista != model.PrecioVentaMayoristaNuevo;

            if (huboCambio)
            {
                var historial = new HistorialPrecio
                {
                    ProductoId = producto.Id,
                    PrecioCostoAnterior = producto.PrecioCosto,
                    PrecioCostoNuevo = model.PrecioCostoNuevo,
                    PrecioVentaAnterior = producto.PrecioVentaMinorista,
                    PrecioVentaNuevo = model.PrecioVentaMinoristaNuevo,
                    Motivo = model.Motivo,
                    FechaCambio = DateTime.Now,
                    UsuarioCambio = User.FindFirst(ClaimTypes.Name)?.Value ?? User.Identity?.Name ?? "Sistema",
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };

                await _unitOfWork.HistorialPrecios.AddAsync(historial);
            }

            // Actualizar precios
            producto.PrecioCosto = model.PrecioCostoNuevo;
            producto.PrecioVentaMinorista = model.PrecioVentaMinoristaNuevo;
            producto.PrecioVentaMayorista = model.PrecioVentaMayoristaNuevo;
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

    private async Task CargarListasAsync(int? categoriaId = null, int? unidadMedidaId = null)
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        ViewBag.Categorias = new SelectList(categorias.Where(c => c.Activo), "Id", "Nombre", categoriaId);

        var unidades = await _unitOfWork.UnidadesMedida.GetAllAsync();
        ViewBag.UnidadesMedida = new SelectList(unidades.Where(u => u.Activo), "Id", "Abreviatura", unidadMedidaId);
    }
}