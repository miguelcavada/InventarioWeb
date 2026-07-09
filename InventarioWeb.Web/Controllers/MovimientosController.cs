using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AdminGerenteOperador)]
public class MovimientosController : Controller
{
    private readonly IMovimientoService _movimientoService;
    private readonly IUnitOfWork _unitOfWork;

    public MovimientosController(IMovimientoService movimientoService, IUnitOfWork unitOfWork)
    {
        _movimientoService = movimientoService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(string tipo = "TODOS", DateTime? desde = null, DateTime? hasta = null)
    {
        var result = await _movimientoService.GetMovimientosAsync(tipo, desde, hasta);
        return View(result.IsSuccess ? result.Data : Enumerable.Empty<MovimientoDto>());
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _movimientoService.GetMovimientoByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    public async Task<IActionResult> Create(string tipo)
    {
        await CargarListasAsync();
        return View(new MovimientoDto
        {
            Tipo = tipo,
            FechaMovimiento = DateTime.Now,
            Detalles = new List<MovimientoDetalleDto> { new() }
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovimientoDto movimientoDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _movimientoService.CreateMovimientoAsync(movimientoDto);

            if (result.IsSuccess)
            {
                TempData["Mensaje"] = result.SuccessMessage;
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", result.ErrorMessage!);
        }

        await CargarListasAsync();
        return View(movimientoDto);
    }

    private async Task CargarListasAsync()
    {
        var productos = await _unitOfWork.Productos.FindAsync(p => p.Activo);
        ViewBag.Productos = new SelectList(productos, "Id", "Nombre");

        var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();
        ViewBag.Almacenes = new SelectList(almacenes, "Id", "Nombre");
    }

    [HttpGet]
    public async Task<JsonResult> ObtenerPrecioProducto(int productoId, string tipo, string tipoPrecio = "MINORISTA")
    {
        var result = await _movimientoService.ObtenerPrecioProductoAsync(productoId, tipo, tipoPrecio);

        if (result.IsFailure)
        {
            return Json(new { success = false, message = result.ErrorMessage });
        }

        return Json(new
        {
            success = true,
            precio = result.Data!.Precio,
            unidad = result.Data.Unidad,
            stockActual = result.Data.StockActual
        });
    }
}