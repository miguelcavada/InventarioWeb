using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Web.Controllers;

public class ProveedoresController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProveedoresController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Proveedores
    public async Task<IActionResult> Index(string buscar)
    {
        IEnumerable<Proveedor> proveedores;

        if (!string.IsNullOrEmpty(buscar))
        {
            proveedores = await _unitOfWork.Proveedores.BuscarProveedoresAsync(buscar);
        }
        else
        {
            proveedores = await _unitOfWork.Proveedores.GetProveedoresActivosAsync();
        }

        var proveedoresDto = proveedores.Select(p => p.ToDto());
        return View(proveedoresDto);
    }

    // GET: Proveedores/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetProveedorConMovimientosAsync(id);
        if (proveedor == null) return NotFound();

        return View(proveedor.ToDto());
    }

    // GET: Proveedores/Create
    public IActionResult Create()
    {
        return View(new ProveedorDto());
    }

    // POST: Proveedores/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProveedorDto proveedorDto)
    {
        if (!string.IsNullOrEmpty(proveedorDto.RUC))
        {
            if (await _unitOfWork.Proveedores.RUCExisteAsync(proveedorDto.RUC))
            {
                ModelState.AddModelError("RUC", "Este RUC ya está registrado");
            }
        }

        if (ModelState.IsValid)
        {
            var proveedor = proveedorDto.ToEntity();
            proveedor.FechaCreacion = DateTime.Now;
            proveedor.Activo = true;

            await _unitOfWork.Proveedores.AddAsync(proveedor);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Proveedor creado exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(proveedorDto);
    }

    // GET: Proveedores/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null) return NotFound();

        return View(proveedor.ToDto());
    }

    // POST: Proveedores/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProveedorDto proveedorDto)
    {
        if (id != proveedorDto.Id) return NotFound();

        if (!string.IsNullOrEmpty(proveedorDto.RUC))
        {
            if (await _unitOfWork.Proveedores.RUCExisteAsync(proveedorDto.RUC, id))
            {
                ModelState.AddModelError("RUC", "Este RUC ya está registrado por otro proveedor");
            }
        }

        if (ModelState.IsValid)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (proveedor == null) return NotFound();

            proveedorDto.UpdateEntity(proveedor);

            await _unitOfWork.Proveedores.UpdateAsync(proveedor);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Proveedor actualizado exitosamente";
            return RedirectToAction(nameof(Index));
        }
        return View(proveedorDto);
    }

    // GET: Proveedores/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null) return NotFound();

        return View(proveedor.ToDto());
    }

    // POST: Proveedores/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null) return NotFound();

        proveedor.Activo = false;
        proveedor.FechaModificacion = DateTime.Now;

        await _unitOfWork.Proveedores.UpdateAsync(proveedor);
        await _unitOfWork.CompleteAsync();

        TempData["Mensaje"] = "Proveedor eliminado exitosamente";
        return RedirectToAction(nameof(Index));
    }
}