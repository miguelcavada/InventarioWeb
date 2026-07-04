using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;
using InventarioWeb.Core.Constants;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class UnidadesMedidaController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public UnidadesMedidaController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var unidades = await _unitOfWork.UnidadesMedida.GetUnidadesConProductosAsync();
        var unidadesDto = unidades.Select(u => u.ToDto());
        return View(unidadesDto);
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public IActionResult Create()
    {
        return View(new UnidadMedidaDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Create(UnidadMedidaDto model)
    {
        if (ModelState.IsValid)
        {
            var unidad = model.ToEntity();
            unidad.Activo = true;
            unidad.FechaCreacion = DateTime.Now;

            await _unitOfWork.UnidadesMedida.AddAsync(unidad);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Unidad de medida creada exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id)
    {
        var unidad = await _unitOfWork.UnidadesMedida.GetByIdAsync(id);
        if (unidad == null) return NotFound();

        return View(unidad.ToDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminOrGerente)]
    public async Task<IActionResult> Edit(int id, UnidadMedidaDto model)
    {
        if (id != model.Id) return NotFound();

        if (ModelState.IsValid)
        {
            var unidad = await _unitOfWork.UnidadesMedida.GetByIdAsync(id);
            if (unidad == null) return NotFound();

            model.UpdateEntity(unidad);
            await _unitOfWork.UnidadesMedida.UpdateAsync(unidad);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Unidad de medida actualizada exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
}