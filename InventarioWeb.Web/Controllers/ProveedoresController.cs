using InventarioWeb.Application.Services;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class ProveedoresController : Controller
{
    private readonly IProveedorService _proveedorService;

    public ProveedoresController(IProveedorService proveedorService)
    {
        _proveedorService = proveedorService;
    }

    public async Task<IActionResult> Index(string buscar)
    {
        var result = await _proveedorService.GetProveedoresAsync(buscar);
        return View(result.IsSuccess ? result.Data : Enumerable.Empty<ProveedorDto>());
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _proveedorService.GetProveedorByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public IActionResult Create() => View(new ProveedorDto());

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(ProveedorDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var result = await _proveedorService.CreateProveedorAsync(dto);
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
        var result = await _proveedorService.GetProveedorByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, ProveedorDto dto)
    {
        if (id != dto.Id) return NotFound();
        if (!ModelState.IsValid) return View(dto);

        var result = await _proveedorService.UpdateProveedorAsync(id, dto);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.ErrorMessage!);
            return View(dto);
        }

        TempData["Mensaje"] = result.SuccessMessage;
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _proveedorService.GetProveedorByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _proveedorService.DeleteProveedorAsync(id);
        if (result.IsFailure)
            TempData["Error"] = result.ErrorMessage;
        else
            TempData["Mensaje"] = result.SuccessMessage;

        return RedirectToAction(nameof(Index));
    }
}