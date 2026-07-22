using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Api.Endpoints;

public static class ReportesEndpoints
{
    public static void MapReportesEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/reportes")
            .RequireAuthorization()
            .WithTags("Reportes")
            .WithOpenApi();

        api.MapGet("/productos/excel", async (
            [FromServices] IUnitOfWork unitOfWork,
            [FromServices] IReportService reportService) =>
        {
            var productos = await unitOfWork.Productos.GetProductosConCategoriaAsync();
            var bytes = reportService.GenerarExcelProductos(productos);
            return Results.File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Productos_{DateTime.Now:yyyyMMdd}.xlsx");
        })
        .WithName("ExportarProductosExcel")
        .WithDescription("Exporta productos a Excel");

        api.MapGet("/productos/pdf", async (
            [FromServices] IUnitOfWork unitOfWork,
            [FromServices] IReportService reportService) =>
        {
            var productos = await unitOfWork.Productos.GetProductosConCategoriaAsync();
            var bytes = reportService.GenerarPdfProductos(productos);
            return Results.File(bytes, "application/pdf", $"Productos_{DateTime.Now:yyyyMMdd}.pdf");
        })
        .WithName("ExportarProductosPdf")
        .WithDescription("Exporta productos a PDF");

        api.MapGet("/stock-bajo/excel", async (
            [FromServices] IUnitOfWork unitOfWork,
            [FromServices] IReportService reportService) =>
        {
            var productos = await unitOfWork.Productos.GetProductosStockBajoAsync();
            var bytes = reportService.GenerarExcelStockBajo(productos);
            return Results.File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"StockBajo_{DateTime.Now:yyyyMMdd}.xlsx");
        })
        .WithName("ExportarStockBajoExcel")
        .WithDescription("Exporta productos con stock bajo a Excel");
    }
}