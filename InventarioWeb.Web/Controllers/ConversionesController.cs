using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AdminOrGerente)]
public class ConversionesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConversionLoaderService _conversionLoader;

    public ConversionesController(IUnitOfWork unitOfWork, IConversionLoaderService conversionLoader = null)
    {
        _unitOfWork = unitOfWork;
        _conversionLoader = conversionLoader;
    }

    public async Task<IActionResult> Index()
    {
        var conversiones = await _unitOfWork.Conversiones.GetConversionesConUnidadesAsync();
        return View(conversiones);
    }

    public async Task<IActionResult> Create()
    {
        await CargarUnidadesAsync();
        return View(new ConversionUnidadDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ConversionUnidadDto dto)
    {
        if (dto.UnidadOrigenId == dto.UnidadDestinoId)
            ModelState.AddModelError("UnidadDestinoId", "Origen y destino no pueden ser iguales");

        if (ModelState.IsValid)
        {
            var conversion = new InventarioWeb.Core.Entities.ConversionUnidad
            {
                UnidadOrigenId = dto.UnidadOrigenId,
                UnidadDestinoId = dto.UnidadDestinoId,
                Factor = dto.Factor,
                Descripcion = dto.Descripcion,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _unitOfWork.Conversiones.AddAsync(conversion);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Conversión creada exitosamente";
            return RedirectToAction(nameof(Index));
        }

        await CargarUnidadesAsync();
        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var conversion = await _unitOfWork.Conversiones.GetByIdAsync(id);
        if (conversion != null)
        {
            await _unitOfWork.Conversiones.DeleteAsync(conversion);
            await _unitOfWork.CompleteAsync();
            TempData["Mensaje"] = "Conversión eliminada";
        }
        return RedirectToAction(nameof(Index));
    }

    // Endpoint para obtener conversiones de una unidad (usado en Create/Edit de Producto)
    [HttpGet]
    public async Task<JsonResult> GetConversiones(int unidadId)
    {
        var conversiones = await _unitOfWork.Conversiones.GetConversionesPorUnidadOrigenAsync(unidadId);

        var result = conversiones.Select(c => new
        {
            id = c.Id,
            unidadDestino = c.UnidadDestino?.Abreviatura,
            unidadDestinoNombre = c.UnidadDestino?.Nombre,
            factor = c.Factor,
            descripcion = $"1 {c.UnidadOrigen?.Abreviatura} = {c.Factor} {c.UnidadDestino?.Abreviatura}"
        });

        return Json(result);
    }

    private async Task CargarUnidadesAsync()
    {
        var unidades = await _unitOfWork.UnidadesMedida.GetAllAsync();
        ViewBag.Unidades = new SelectList(unidades.Where(u => u.Activo), "Id", "Abreviatura");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CargarDesdeJson()
    {
        try
        {
            await _conversionLoader.CargarConversionesDesdeJsonAsync();
            TempData["Mensaje"] = "Conversiones cargadas exitosamente desde el archivo JSON.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al cargar conversiones: {ex.Message}";
        }
        return RedirectToAction(nameof(Index));
    }
}