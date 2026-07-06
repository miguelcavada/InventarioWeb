using InventarioWeb.Application.Common;
using InventarioWeb.Application.Services;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class ProductosController : Controller
{
    private readonly IProductoService _productoService;
    private readonly IUnitOfWork _unitOfWork;

    public ProductosController(IProductoService productoService, IUnitOfWork unitOfWork)
    {
        _productoService = productoService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(string buscar, string orden = "nombre", int pagina = 1)
    {
        var result = await _productoService.GetProductosPaginadosAsync(buscar, orden, pagina);

        if (result.IsFailure)
        {
            TempData["Error"] = result.ErrorMessage;
            return View(new PagedResult<ProductoDto>());
        }

        return View(result.Data);
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _productoService.GetProductoByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create()
    {
        await CargarListasAsync();
        return View(new ProductoDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(ProductoDto dto)
    {
        if (!ModelState.IsValid)
        {
            await CargarListasAsync();
            return View(dto);
        }

        var result = await _productoService.CreateProductoAsync(dto);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            await CargarListasAsync();
            return View(dto);
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _productoService.GetProductoByIdAsync(id);
        if (result.IsFailure) return NotFound();

        await CargarListasAsync(result.Data!.CategoriaId, result.Data.UnidadMedidaId);
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, ProductoDto dto)
    {
        if (id != dto.Id) return NotFound();

        if (!ModelState.IsValid)
        {
            await CargarListasAsync(dto.CategoriaId, dto.UnidadMedidaId);
            return View(dto);
        }

        var result = await _productoService.UpdateProductoAsync(id, dto);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            await CargarListasAsync(dto.CategoriaId, dto.UnidadMedidaId);
            return View(dto);
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productoService.GetProductoByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _productoService.DeleteProductoAsync(id);
        if (result.IsFailure)
        {
            TempData["Error"] = result.ErrorMessage;
            return RedirectToAction(nameof(Index));
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> CambioPrecio(int id)
    {
        var result = await _productoService.GetCambioPrecioAsync(id);
        if (result.IsFailure) return NotFound();

        var prodResult = await _productoService.GetProductoByIdAsync(id);
        ViewBag.Producto = prodResult.Data;
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> CambioPrecio(CambioPrecioDto model)
    {
        if (!ModelState.IsValid)
        {
            var prodResult = await _productoService.GetProductoByIdAsync(model.ProductoId);
            ViewBag.Producto = prodResult.IsSuccess ? prodResult.Data : null;
            return View(model);
        }

        var usuario = User.FindFirst(ClaimTypes.Name)?.Value ?? "Sistema";
        var result = await _productoService.CambiarPrecioAsync(model, usuario);

        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            var prodResult = await _productoService.GetProductoByIdAsync(model.ProductoId);
            ViewBag.Producto = prodResult.IsSuccess ? prodResult.Data : null;
            return View(model);
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> HistorialPrecios(int id)
    {
        var productoResult = await _productoService.GetProductoByIdAsync(id);
        if (productoResult.IsFailure) return NotFound();

        var historialResult = await _productoService.GetHistorialPreciosAsync(id);

        ViewBag.Producto = productoResult.Data;
        return View(historialResult.IsSuccess ? historialResult.Data : Enumerable.Empty<HistorialPrecioDto>());
    }

    private async Task CargarListasAsync(int? categoriaId = null, int? unidadMedidaId = null)
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        ViewBag.Categorias = new SelectList(categorias.Where(c => c.Activo), "Id", "Nombre", categoriaId);

        var unidades = await _unitOfWork.UnidadesMedida.GetAllAsync();
        ViewBag.UnidadesMedida = new SelectList(unidades.Where(u => u.Activo), "Id", "Abreviatura", unidadMedidaId);
    }
}