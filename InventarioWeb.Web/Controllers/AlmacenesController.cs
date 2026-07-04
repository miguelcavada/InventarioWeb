using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class AlmacenesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AlmacenesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Almacenes
    public async Task<IActionResult> Index()
    {
        var almacenes = await _unitOfWork.Almacenes.GetAllAsync();
        return View(almacenes);
    }

    // GET: Almacenes/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
        if (almacen == null) return NotFound();

        return View(almacen);
    }

    // GET: Almacenes/Create
    [Authorize(Roles = Roles.AdminOrGerente)]
    public IActionResult Create()
    {
        return View(new AlmacenDto());
    }

    // POST: Almacenes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(AlmacenDto model)
    {
        if (ModelState.IsValid)
        {
            var almacen = model.ToEntity();
            almacen.Activo = true;
            almacen.FechaCreacion = DateTime.Now;

            await _unitOfWork.Almacenes.AddAsync(almacen);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Almacén creado exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    // GET: Almacenes/Edit/5
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetByIdAsync(id);
        if (almacen == null) return NotFound();

        var model = almacen.ToDto();
        return View(model);
    }

    // POST: Almacenes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, AlmacenDto model)
    {
        if (id != model.Id) return NotFound();

        if (ModelState.IsValid)
        {
            var almacen = await _unitOfWork.Almacenes.GetByIdAsync(id);
            if (almacen == null) return NotFound();

            model.UpdateEntity(almacen);

            await _unitOfWork.Almacenes.UpdateAsync(almacen);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Almacén actualizado exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    // GET: Almacenes/Delete/5
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetByIdAsync(id);
        if (almacen == null) return NotFound();

        return View(almacen.ToDto());
    }

    // POST: Almacenes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetByIdAsync(id);
        if (almacen == null) return NotFound();

        almacen.Activo = false;
        almacen.FechaModificacion = DateTime.Now;

        await _unitOfWork.Almacenes.UpdateAsync(almacen);
        await _unitOfWork.CompleteAsync();

        TempData["Mensaje"] = "Almacén eliminado exitosamente";
        return RedirectToAction(nameof(Index));
    }
}