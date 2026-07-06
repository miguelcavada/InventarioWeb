using InventarioWeb.Application.Services;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class AlmacenesController : Controller
{
    private readonly IAlmacenService _almacenService;

    public AlmacenesController(IAlmacenService almacenService)
    {
        _almacenService = almacenService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _almacenService.GetAlmacenesAsync();
        return View(result.IsSuccess ? result.Data : Enumerable.Empty<AlmacenDto>());
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _almacenService.GetAlmacenByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public IActionResult Create() => View(new AlmacenDto());

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(AlmacenDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var result = await _almacenService.CreateAlmacenAsync(dto);
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
        var result = await _almacenService.GetAlmacenByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, AlmacenDto dto)
    {
        if (id != dto.Id) return NotFound();
        if (!ModelState.IsValid) return View(dto);

        var result = await _almacenService.UpdateAlmacenAsync(id, dto);
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
        var result = await _almacenService.GetAlmacenByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _almacenService.DeleteAlmacenAsync(id);
        if (result.IsFailure)
            TempData["Error"] = result.ErrorMessage;
        else
            TempData["Mensaje"] = result.SuccessMessage;

        return RedirectToAction(nameof(Index));
    }
}