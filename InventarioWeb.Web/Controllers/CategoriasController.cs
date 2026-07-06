using InventarioWeb.Application.Services;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class CategoriasController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _categoriaService.GetCategoriasAsync();
        return View(result.IsSuccess ? result.Data : Enumerable.Empty<CategoriaDto>());
    }

    public async Task<IActionResult> Details(int id)
    {
        var result = await _categoriaService.GetCategoriaByIdAsync(id);
        if (result.IsFailure) return NotFound();

        var productosResult = await _categoriaService.GetProductosPorCategoriaAsync(id);
        ViewBag.Productos = productosResult.IsSuccess ? productosResult.Data : null;

        return View(result.Data);
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public IActionResult Create() => View(new CategoriaDto());

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(CategoriaDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var result = await _categoriaService.CreateCategoriaAsync(dto);
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
        var result = await _categoriaService.GetCategoriaByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, CategoriaDto dto)
    {
        if (id != dto.Id) return NotFound();
        if (!ModelState.IsValid) return View(dto);

        var result = await _categoriaService.UpdateCategoriaAsync(id, dto);
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
        var result = await _categoriaService.GetCategoriaByIdAsync(id);
        if (result.IsFailure) return NotFound();
        return View(result.Data);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _categoriaService.DeleteCategoriaAsync(id);
        if (result.IsFailure)
            TempData["Error"] = result.ErrorMessage;
        else
            TempData["Mensaje"] = result.SuccessMessage;

        return RedirectToAction(nameof(Index));
    }
}