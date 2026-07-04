using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class CategoriasController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriasController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Categorias
    public async Task<IActionResult> Index()
    {
        var categorias = await _unitOfWork.Categorias.GetCategoriasConProductosAsync();
        var categoriasDto = categorias.Select(c => c.ToDto());
        return View(categoriasDto);
    }

    // GET: Categorias/Details/5
    // GET: Categorias/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetCategoriaConProductosAsync(id);
        if (categoria == null) return NotFound();

        var productosDto = categoria.Productos
            .Where(p => p.Activo)
            .Select(p => p.ToDto())
            .ToList();

        ViewBag.Productos = productosDto;
        return View(categoria.ToDto());
    }

    // GET: Categorias/Create
    [Authorize(Roles = Roles.AdminOrGerente)]
    public IActionResult Create()
    {
        return View(new CategoriaDto());
    }

    // POST: Categorias/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(CategoriaDto categoriaDto)
    {
        if (ModelState.IsValid)
        {
            var categoria = categoriaDto.ToEntity();
            categoria.FechaCreacion = DateTime.Now;
            categoria.Activo = true;

            await _unitOfWork.Categorias.AddAsync(categoria);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Categoría creada exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(categoriaDto);
    }

    // GET: Categorias/Edit/5
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
        if (categoria == null) return NotFound();

        return View(categoria.ToDto());
    }

    // POST: Categorias/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, CategoriaDto categoriaDto)
    {
        if (id != categoriaDto.Id) return NotFound();

        if (ModelState.IsValid)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (categoria == null) return NotFound();

            categoriaDto.UpdateEntity(categoria);

            await _unitOfWork.Categorias.UpdateAsync(categoria);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Categoría actualizada exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(categoriaDto);
    }

    // GET: Categorias/Delete/5
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetCategoriaConProductosAsync(id);
        if (categoria == null) return NotFound();

        return View(categoria.ToDto());
    }

    // POST: Categorias/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
        if (categoria == null) return NotFound();

        categoria.Activo = false;
        categoria.FechaModificacion = DateTime.Now;

        await _unitOfWork.Categorias.UpdateAsync(categoria);
        await _unitOfWork.CompleteAsync();

        TempData["Mensaje"] = "Categoría eliminada exitosamente";
        return RedirectToAction(nameof(Index));
    }
}