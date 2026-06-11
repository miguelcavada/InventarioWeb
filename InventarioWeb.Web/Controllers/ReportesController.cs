using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Web.Controllers;

public class ReportesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReportService _reportService;

    public ReportesController(IUnitOfWork unitOfWork, IReportService reportService)
    {
        _unitOfWork = unitOfWork;
        _reportService = reportService;
    }

    public async Task<IActionResult> Index()
    {
        var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();
        ViewBag.Almacenes = new SelectList(almacenes, "Id", "Nombre");
        return View();
    }

    public async Task<IActionResult> ProductosExcel()
    {
        var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();
        var excelBytes = _reportService.GenerarExcelProductos(productos);

        return File(
            excelBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Productos_{DateTime.Now:yyyyMMdd}.xlsx"
        );
    }

    public async Task<IActionResult> ProductosPdf()
    {
        var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();
        var pdfBytes = _reportService.GenerarPdfProductos(productos);

        return File(
            pdfBytes,
            "application/pdf",
            $"Productos_{DateTime.Now:yyyyMMdd}.pdf"
        );
    }

    public async Task<IActionResult> MovimientosExcel(string tipo = "TODOS", DateTime? desde = null, DateTime? hasta = null)
    {
        IEnumerable<Core.Entities.Movimiento> movimientos;

        if (desde.HasValue && hasta.HasValue)
        {
            movimientos = await _unitOfWork.Movimientos.GetMovimientosPorFechaAsync(desde.Value, hasta.Value);
        }
        else if (tipo != "TODOS")
        {
            movimientos = await _unitOfWork.Movimientos.GetMovimientosPorTipoAsync(tipo);
        }
        else
        {
            movimientos = await _unitOfWork.Movimientos.GetAllAsync();
        }

        var excelBytes = _reportService.GenerarExcelMovimientos(movimientos);

        return File(
            excelBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Movimientos_{DateTime.Now:yyyyMMdd}.xlsx"
        );
    }

    public async Task<IActionResult> MovimientoPdf(int id)
    {
        var movimiento = await _unitOfWork.Movimientos.GetMovimientoConDetallesAsync(id);
        if (movimiento == null) return NotFound();

        var pdfBytes = _reportService.GenerarPdfMovimiento(movimiento);

        return File(
            pdfBytes,
            "application/pdf",
            $"Movimiento_{movimiento.NumeroDocumento}.pdf"
        );
    }

    public async Task<IActionResult> StockBajoExcel()
    {
        var productos = await _unitOfWork.Productos.GetProductosStockBajoAsync();
        var excelBytes = _reportService.GenerarExcelStockBajo(productos);

        return File(
            excelBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"StockBajo_{DateTime.Now:yyyyMMdd}.xlsx"
        );
    }

    // GET: Reportes/InventarioAlmacen/5
    public async Task<IActionResult> InventarioAlmacen(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
        if (almacen == null) return NotFound();

        ViewBag.AlmacenId = id;
        ViewBag.AlmacenNombre = almacen.Nombre;
        ViewBag.AlmacenTipo = almacen.Tipo;

        return View(almacen.Stocks?.Select(s => s.ToDto()).ToList());
    }

    // GET: Reportes/InventarioAlmacenExcel/5
    public async Task<IActionResult> InventarioAlmacenExcel(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
        if (almacen == null) return NotFound();

        var excelBytes = _reportService.GenerarExcelInventarioPorAlmacen(almacen);

        return File(
            excelBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Inventario_{almacen.Nombre}_{DateTime.Now:yyyyMMdd}.xlsx"
        );
    }

    // GET: Reportes/InventarioAlmacenPdf/5
    public async Task<IActionResult> InventarioAlmacenPdf(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
        if (almacen == null) return NotFound();

        var pdfBytes = _reportService.GenerarPdfInventarioPorAlmacen(almacen);

        return File(
            pdfBytes,
            "application/pdf",
            $"Inventario_{almacen.Nombre}_{DateTime.Now:yyyyMMdd}.pdf"
        );
    }
}