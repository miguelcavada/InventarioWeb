using InventarioWeb.Application.Services;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class UnidadesMedidaController : Controller
{
    private readonly IUnidadMedidaService _unidadMedidaService;

    public UnidadesMedidaController(IUnidadMedidaService unidadMedidaService)
    {
        _unidadMedidaService = unidadMedidaService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _unidadMedidaService.GetUnidadesAsync();
        return View(result.IsSuccess ? result.Data : Enumerable.Empty<UnidadMedidaDto>());
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public IActionResult Create() => View(new UnidadMedidaDto());

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(UnidadMedidaDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var result = await _unidadMedidaService.CreateUnidadAsync(dto);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            return View(dto);
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _unidadMedidaService.GetUnidadByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, UnidadMedidaDto dto)
    {
        if (id != dto.Id) return NotFound();
        if (!ModelState.IsValid) return View(dto);

        var result = await _unidadMedidaService.UpdateUnidadAsync(id, dto);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            return View(dto);
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }
}