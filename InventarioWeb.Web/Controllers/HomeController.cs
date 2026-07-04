using InventarioWeb.Core.Constants;
using InventarioWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();
        var movimientos = await _unitOfWork.Movimientos.GetAllAsync();
        var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();

        // Total de productos activos
        ViewBag.TotalProductos = productos.Count(p => p.Activo);

        // Productos inactivos
        ViewBag.ProductosInactivos = productos.Count(p => !p.Activo);

        // Total de entradas
        ViewBag.TotalEntradas = movimientos.Count(m => m.Tipo == "ENTRADA");

        // Total de salidas
        ViewBag.TotalSalidas = movimientos.Count(m => m.Tipo == "SALIDA");

        // Total de traslados
        ViewBag.TotalTraslados = movimientos.Count(m => m.Tipo == "TRASLADO");

        // Stock bajo: productos con stock total <= stock mínimo total
        ViewBag.StockBajo = productos.Count(p =>
            p.Activo &&
            p.Stocks.Any() &&
            p.Stocks.Sum(s => s.StockActual) <= p.Stocks.Sum(s => s.StockMinimo) &&
            p.Stocks.Sum(s => s.StockActual) > 0
        );

        // Valor total del inventario
        ViewBag.ValorInventario = productos
            .Where(p => p.Activo && p.PrecioCosto.HasValue)
            .Sum(p => p.Stocks.Sum(s => s.StockActual) * (p.PrecioCosto ?? 0));

        // Total de almacenes
        ViewBag.TotalAlmacenes = almacenes.Count();

        // Últimos movimientos
        ViewBag.UltimosMovimientos = movimientos
            .OrderByDescending(m => m.FechaMovimiento)
            .Take(5)
            .Select(m => new
            {
                m.Id,
                m.Tipo,
                m.NumeroDocumento,
                m.FechaMovimiento,
                Total = m.Detalles?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0
            })
            .ToList();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}