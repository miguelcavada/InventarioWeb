using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.Constants;
using InventarioWeb.Application.Services;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AllRoles)]
public class HomeController : Controller
{
    private readonly IDashboardService _dashboardService;

    public HomeController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _dashboardService.GetDashboardDataAsync();

        if (result.IsFailure)
        {
            TempData["Error"] = result.ErrorMessage;
            return View();
        }

        var data = result.Data!;
        ViewBag.TotalProductos = data.TotalProductos;
        ViewBag.ProductosInactivos = data.ProductosInactivos;
        ViewBag.StockBajo = data.StockBajo;
        ViewBag.TotalEntradas = data.TotalEntradas;
        ViewBag.TotalSalidas = data.TotalSalidas;
        ViewBag.TotalTraslados = data.TotalTraslados;
        ViewBag.TotalAlmacenes = data.TotalAlmacenes;
        ViewBag.ValorInventario = data.ValorInventario;
        ViewBag.UltimosMovimientos = data.UltimosMovimientos;

        return View();
    }

    public IActionResult Privacy() => View();
}