using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Application.Services;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AdminGerenteOperador)]
public class ConsignacionesController : Controller
{
    private readonly IConsignacionService _consignacionService;
    private readonly IUnitOfWork _unitOfWork;

    public ConsignacionesController(IConsignacionService consignacionService, IUnitOfWork unitOfWork)
    {
        _consignacionService = consignacionService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _consignacionService.GetConsignacionesAsync();
        return View(result.IsSuccess ? result.Data : Enumerable.Empty<ConsignacionDto>());
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _consignacionService.GetConsignacionByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    public async Task<IActionResult> Create()
    {
        await CargarListasAsync();
        return View(new ConsignacionDto
        {
            Detalles = new List<ConsignacionDetalleDto> { new() }
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ConsignacionDto dto)
    {
        if (!ModelState.IsValid)
        {
            await CargarListasAsync();
            return View(dto);
        }

        var result = await _consignacionService.CreateConsignacionAsync(dto);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            await CargarListasAsync();
            return View(dto);
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegistrarVenta(RegistrarVentaDto dto)
    {
        var result = await _consignacionService.RegistrarVentaAsync(dto);
        if (result.IsFailure)
            TempData["Error"] = result.ErrorMessage;
        else
            TempData["Mensaje"] = result.SuccessMessage;

        return RedirectToAction(nameof(Details), new { id = dto.ConsignacionDetalleId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegistrarDevolucion(RegistrarDevolucionDto dto)
    {
        var result = await _consignacionService.RegistrarDevolucionAsync(dto);
        if (result.IsFailure)
            TempData["Error"] = result.ErrorMessage;
        else
            TempData["Mensaje"] = result.SuccessMessage;

        return RedirectToAction(nameof(Details), new { id = dto.ConsignacionDetalleId });
    }

    private async Task CargarListasAsync()
    {
        var productos = await _unitOfWork.Productos.FindAsync(p => p.Activo);
        ViewBag.Productos = new SelectList(productos, "Id", "Nombre");

        var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();
        ViewBag.Almacenes = new SelectList(almacenes, "Id", "Nombre");
    }
}