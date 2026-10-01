using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReportService _reportService;

    public ReportesController(IUnitOfWork unitOfWork, IReportService reportService)
    {
        _unitOfWork = unitOfWork;
        _reportService = reportService;
    }

    // Exportar productos a Excel
    [HttpGet("productos/excel")]
    public async Task<IActionResult> ExportarProductosExcel()
    {
        var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();
        var bytes = _reportService.GenerarExcelProductos(productos);
        
        return File(bytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Productos_{DateTime.Now:yyyyMMdd}.xlsx");
    }

    // Exportar productos a PDF
    [HttpGet("productos/pdf")]
    public async Task<IActionResult> ExportarProductosPdf()
    {
        var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();
        var bytes = _reportService.GenerarPdfProductos(productos);
        
        return File(bytes, "application/pdf", $"Productos_{DateTime.Now:yyyyMMdd}.pdf");
    }

    // Exportar stock bajo a Excel
    [HttpGet("stock-bajo/excel")]
    public async Task<IActionResult> ExportarStockBajoExcel()
    {
        var productos = await _unitOfWork.Productos.GetProductosStockBajoAsync();
        var bytes = _reportService.GenerarExcelStockBajo(productos);
        
        return File(bytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"StockBajo_{DateTime.Now:yyyyMMdd}.xlsx");
    }

    // Exportar movimientos a Excel con filtros
    [HttpGet("movimientos/excel")]
    public async Task<IActionResult> ExportarMovimientosExcel(
        [FromQuery] string tipo = "TODOS",
        [FromQuery] DateTime? desde = null,
        [FromQuery] DateTime? hasta = null)
    {
        IEnumerable<InventarioWeb.Core.Entities.Movimiento> movimientos;

        if (desde.HasValue && hasta.HasValue)
            movimientos = await _unitOfWork.Movimientos.GetMovimientosPorFechaAsync(desde.Value, hasta.Value);
        else if (tipo != "TODOS")
            movimientos = await _unitOfWork.Movimientos.GetMovimientosPorTipoAsync(tipo);
        else
            movimientos = await _unitOfWork.Movimientos.GetAllAsync();

        var bytes = _reportService.GenerarExcelMovimientos(movimientos);
        
        return File(bytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Movimientos_{DateTime.Now:yyyyMMdd}.xlsx");
    }

    // Exportar comprobante de movimiento a PDF
    [HttpGet("movimientos/{id}/pdf")]
    public async Task<IActionResult> ExportarMovimientoPdf(int id)
    {
        var movimiento = await _unitOfWork.Movimientos.GetMovimientoConDetallesAsync(id);
        if (movimiento == null)
            return NotFound(new { success = false, error = "Movimiento no encontrado" });

        var bytes = _reportService.GenerarPdfMovimiento(movimiento);
        
        return File(bytes, "application/pdf", $"Movimiento_{movimiento.NumeroDocumento}.pdf");
    }

    // Exportar inventario por almacén a Excel
    [HttpGet("almacenes/{id}/inventario/excel")]
    public async Task<IActionResult> ExportarInventarioAlmacenExcel(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
        if (almacen == null)
            return NotFound(new { success = false, error = "Almacén no encontrado" });

        var bytes = _reportService.GenerarExcelInventarioPorAlmacen(almacen);
        
        return File(bytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"Inventario_{almacen.Nombre}_{DateTime.Now:yyyyMMdd}.xlsx");
    }

    // Exportar inventario por almacén a PDF
    [HttpGet("almacenes/{id}/inventario/pdf")]
    public async Task<IActionResult> ExportarInventarioAlmacenPdf(int id)
    {
        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
        if (almacen == null)
            return NotFound(new { success = false, error = "Almacén no encontrado" });

        var bytes = _reportService.GenerarPdfInventarioPorAlmacen(almacen);
        
        return File(bytes, "application/pdf", 
            $"Inventario_{almacen.Nombre}_{DateTime.Now:yyyyMMdd}.pdf");
    }

    // Exportar inventario diario a Excel
    [HttpGet("inventario-diario/excel")]
    public async Task<IActionResult> ExportarInventarioDiarioExcel(
        [FromQuery] int almacenId, 
        [FromQuery] DateTime? fecha = null)
    {
        if (!fecha.HasValue) fecha = DateTime.Today;

        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(almacenId);
        if (almacen == null)
            return NotFound(new { success = false, error = "Almacén no encontrado" });

        var bytes = _reportService.GenerarExcelInventarioDiario(almacen, fecha.Value);
        
        return File(bytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"InventarioDiario_{almacen.Nombre}_{fecha:yyyyMMdd}.xlsx");
    }

    // Exportar inventario diario a PDF
    [HttpGet("inventario-diario/pdf")]
    public async Task<IActionResult> ExportarInventarioDiarioPdf(
        [FromQuery] int almacenId,
        [FromQuery] DateTime? fecha = null)
    {
        if (!fecha.HasValue) fecha = DateTime.Today;

        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(almacenId);
        if (almacen == null)
            return NotFound(new { success = false, error = "Almacén no encontrado" });

        var bytes = _reportService.GenerarPdfInventarioDiario(almacen, fecha.Value);
        
        return File(bytes, "application/pdf",
            $"InventarioDiario_{almacen.Nombre}_{fecha:yyyyMMdd}.pdf");
    }
}