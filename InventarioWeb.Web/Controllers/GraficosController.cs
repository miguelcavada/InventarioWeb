using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.Interfaces;

namespace InventarioWeb.Web.Controllers;

[Authorize]
public class GraficosController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public GraficosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    // Datos para gráfico de productos por categoría
    [HttpGet]
    public async Task<JsonResult> ProductosPorCategoria()
    {
        var categorias = await _unitOfWork.Categorias.GetCategoriasConProductosAsync();

        var data = categorias
            .Where(c => c.Activo)
            .Select(c => new
            {
                categoria = c.Nombre,
                cantidad = c.Productos.Count(p => p.Activo),
                valor = c.Productos.Where(p => p.Activo && p.PrecioCosto.HasValue)
                                   .Sum(p => p.Stocks.Sum(s => s.StockActual) * (p.PrecioCosto ?? 0))
            })
            .OrderByDescending(x => x.cantidad)
            .ToList();

        return Json(data);
    }

    // Datos para gráfico de movimientos por mes
    [HttpGet]
    public async Task<JsonResult> MovimientosPorMes(int año = 0)
    {
        if (año == 0) año = DateTime.Now.Year;

        var movimientos = await _unitOfWork.Movimientos.GetAllAsync();

        var entradas = movimientos
            .Where(m => m.Tipo == "ENTRADA" && m.FechaMovimiento.Year == año)
            .GroupBy(m => m.FechaMovimiento.Month)
            .Select(g => new
            {
                mes = g.Key,
                total = g.Sum(m => m.Detalles?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0)
            });

        var salidas = movimientos
            .Where(m => m.Tipo == "SALIDA" && m.FechaMovimiento.Year == año)
            .GroupBy(m => m.FechaMovimiento.Month)
            .Select(g => new
            {
                mes = g.Key,
                total = g.Sum(m => m.Detalles?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0)
            });

        var meses = new[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

        var data = new
        {
            labels = meses,
            entradas = Enumerable.Range(1, 12).Select(m =>
                entradas.FirstOrDefault(e => e.mes == m)?.total ?? 0),
            salidas = Enumerable.Range(1, 12).Select(m =>
                salidas.FirstOrDefault(s => s.mes == m)?.total ?? 0)
        };

        return Json(data);
    }

    // Datos para stock por almacén
    [HttpGet]
    public async Task<JsonResult> StockPorAlmacen()
    {
        var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();

        var data = almacenes.Select(a => new
        {
            almacen = a.Nombre,
            tipo = a.Tipo,
            stockTotal = a.Stocks?.Sum(s => s.StockActual) ?? 0,
            stockBajo = a.Stocks?.Count(s => s.StockActual <= s.StockMinimo && s.StockActual > 0) ?? 0,
            valor = a.Stocks?.Sum(s => s.StockActual * (s.Producto?.PrecioCosto ?? 0)) ?? 0
        });

        return Json(data);
    }

    // Datos para top productos
    [HttpGet]
    public async Task<JsonResult> TopProductosMovidos()
    {
        var movimientos = await _unitOfWork.Movimientos.GetAllAsync();

        var productosMovidos = movimientos
            .Where(m => m.Detalles != null)
            .SelectMany(m => m.Detalles)
            .GroupBy(d => d.ProductoId)
            .Select(g => new
            {
                productoId = g.Key,
                cantidadTotal = g.Sum(d => d.Cantidad),
                vecesMovido = g.Count()
            })
            .OrderByDescending(x => x.cantidadTotal)
            .Take(10)
            .ToList();

        // Cargar nombres de productos por separado
        var resultado = new List<object>();
        foreach (var item in productosMovidos)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(item.productoId);
            resultado.Add(new
            {
                producto = producto?.Nombre ?? "Desconocido",
                codigo = producto?.Codigo ?? "N/A",
                cantidadTotal = item.cantidadTotal,
                vecesMovido = item.vecesMovido
            });
        }

        return Json(resultado);
    }

    // Datos para resumen de inventario
    [HttpGet]
    public async Task<JsonResult> ResumenInventario()
    {
        var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();

        var stockNormal = productos.Count(p => p.Activo && p.Stocks.Sum(s => s.StockActual) > p.Stocks.Sum(s => s.StockMinimo));
        var stockBajo = productos.Count(p => p.Activo && p.Stocks.Sum(s => s.StockActual) <= p.Stocks.Sum(s => s.StockMinimo) && p.Stocks.Sum(s => s.StockActual) > 0);
        var sinStock = productos.Count(p => p.Activo && p.Stocks.Sum(s => s.StockActual) == 0);
        var inactivos = productos.Count(p => !p.Activo);

        return Json(new
        {
            stockNormal,
            stockBajo,
            sinStock,
            inactivos
        });
    }
}