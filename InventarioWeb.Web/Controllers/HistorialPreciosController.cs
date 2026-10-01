using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.Constants;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class HistorialPreciosController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private const int PageSize = 20;

    public HistorialPreciosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(
        DateTime? desde = null,
        DateTime? hasta = null,
        string? usuario = null,
        string? buscar = null,
        int pagina = 1)
    {
        var historial = await _unitOfWork.HistorialPrecios.GetHistorialCompletoAsync(desde, hasta, usuario);
        var historialDto = historial.Select(h => h.ToDto()).ToList();

        // Filtro de búsqueda
        if (!string.IsNullOrEmpty(buscar))
        {
            historialDto = historialDto.Where(h =>
                (h.ProductoNombre != null && h.ProductoNombre.Contains(buscar, StringComparison.OrdinalIgnoreCase)) ||
                (h.ProductoCodigo != null && h.ProductoCodigo.Contains(buscar, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // Estadísticas (sobre el total filtrado)
        ViewBag.TotalCambios = historialDto.Count;
        ViewBag.CambiosHoy = historialDto.Count(h => h.FechaCambio.Date == DateTime.Today);
        ViewBag.CambiosMes = historialDto.Count(h => h.FechaCambio.Month == DateTime.Now.Month && h.FechaCambio.Year == DateTime.Now.Year);
        ViewBag.Aumentos = historialDto.Count(h => h.VariacionVenta > 0);
        ViewBag.Disminuciones = historialDto.Count(h => h.VariacionVenta < 0);

        // Paginación
        var totalRegistros = historialDto.Count;
        var totalPaginas = (int)Math.Ceiling(totalRegistros / (double)PageSize);

        if (pagina < 1) pagina = 1;
        if (pagina > totalPaginas && totalPaginas > 0) pagina = totalPaginas;

        var registrosPaginados = historialDto
            .Skip((pagina - 1) * PageSize)
            .Take(PageSize)
            .ToList();

        // ViewBags para filtros y paginación
        ViewBag.Desde = desde;
        ViewBag.Hasta = hasta;
        ViewBag.Usuario = usuario;
        ViewBag.Buscar = buscar;
        ViewBag.PaginaActual = pagina;
        ViewBag.TotalPaginas = totalPaginas;
        ViewBag.TotalRegistros = totalRegistros;
        ViewBag.PageSize = PageSize;
        ViewBag.TienePaginaAnterior = pagina > 1;
        ViewBag.TienePaginaSiguiente = pagina < totalPaginas;

        return View(registrosPaginados);
    }

    // Endpoint para exportar (opcional)
    public async Task<IActionResult> ExportarExcel(DateTime? desde = null, DateTime? hasta = null)
    {
        var historial = await _unitOfWork.HistorialPrecios.GetHistorialCompletoAsync(desde, hasta);
        var historialDto = historial.Select(h => h.ToDto());

        // Aquí puedes generar Excel con ClosedXML
        // Por simplicidad, retornamos la vista
        TempData["Mensaje"] = "Exportación en desarrollo";
        return RedirectToAction(nameof(Index));
    }
}