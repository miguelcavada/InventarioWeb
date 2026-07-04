using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Infrastructure.Services;

public interface IReportService
{
    byte[] GenerarExcelProductos(IEnumerable<Producto> productos);
    byte[] GenerarPdfProductos(IEnumerable<Producto> productos);
    byte[] GenerarExcelMovimientos(IEnumerable<Movimiento> movimientos);
    byte[] GenerarPdfMovimiento(Movimiento movimiento);
    byte[] GenerarExcelStockBajo(IEnumerable<Producto> productos);
    byte[] GenerarExcelInventarioPorAlmacen(Almacen almacen);
    byte[] GenerarPdfInventarioPorAlmacen(Almacen almacen);
}

public class ReportService : IReportService
{
    public ReportService()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public byte[] GenerarExcelProductos(IEnumerable<Producto> productos)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Productos");

        // Encabezados
        worksheet.Cell(1, 1).Value = "CÓDIGO";
        worksheet.Cell(1, 2).Value = "NOMBRE";
        worksheet.Cell(1, 3).Value = "UNIDAD";
        worksheet.Cell(1, 4).Value = "CATEGORÍA";
        worksheet.Cell(1, 5).Value = "PRECIO COSTO";
        worksheet.Cell(1, 6).Value = "PRECIO MINORISTA";
        worksheet.Cell(1, 7).Value = "PRECIO MAYORISTA";
        worksheet.Cell(1, 8).Value = "STOCK TOTAL";
        worksheet.Cell(1, 9).Value = "ESTADO";

        var headerRange = worksheet.Range(1, 1, 1, 9);
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(52, 58, 64);
        headerRange.Style.Font.FontColor = XLColor.White;
        headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        int row = 2;
        foreach (var producto in productos)
        {
            var stockTotal = producto.Stocks?.Sum(s => s.StockActual) ?? 0;
            var stockMinimo = producto.Stocks?.Sum(s => s.StockMinimo) ?? 0;

            worksheet.Cell(row, 1).Value = producto.Codigo ?? "";
            worksheet.Cell(row, 2).Value = producto.Nombre ?? "";
            worksheet.Cell(row, 3).Value = producto.UnidadMedida?.Abreviatura ?? "";
            worksheet.Cell(row, 4).Value = producto.Categoria?.Nombre ?? "Sin categoría";
            worksheet.Cell(row, 5).Value = producto.PrecioCosto ?? 0;
            worksheet.Cell(row, 6).Value = producto.PrecioVentaMinorista;
            worksheet.Cell(row, 7).Value = producto.PrecioVentaMayorista ?? 0;
            worksheet.Cell(row, 8).Value = stockTotal;
            worksheet.Cell(row, 9).Value = producto.Activo ? "Activo" : "Inactivo";

            worksheet.Cell(row, 5).Style.NumberFormat.Format = "$ #,##0.00";
            worksheet.Cell(row, 6).Style.NumberFormat.Format = "$ #,##0.00";
            worksheet.Cell(row, 7).Style.NumberFormat.Format = "$ #,##0.00";

            if (stockTotal <= stockMinimo && stockTotal > 0)
            {
                worksheet.Cell(row, 8).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 200, 200);
            }

            row++;
        }

        worksheet.Columns().AdjustToContents();

        int totalRow = row + 1;
        worksheet.Cell(totalRow, 1).Value = "TOTAL PRODUCTOS:";
        worksheet.Cell(totalRow, 2).Value = productos.Count();
        worksheet.Cell(totalRow, 1).Style.Font.Bold = true;

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public byte[] GenerarPdfProductos(IEnumerable<Producto> productos)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(9));

                page.Header()
                    .AlignCenter()
                    .Text("REPORTE DE PRODUCTOS")
                    .SemiBold()
                    .FontSize(18)
                    .FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1.5f); // Código
                            columns.RelativeColumn(2.5f); // Nombre
                            columns.RelativeColumn(1);    // Unidad
                            columns.RelativeColumn(1.5f); // Categoría
                            columns.RelativeColumn(1.5f); // Precio Minorista
                            columns.RelativeColumn(1.5f); // Precio Mayorista
                            columns.RelativeColumn(1);    // Stock
                        });

                        table.Header(header =>
                        {
                            header.Cell().DefaultTextStyle(x => x.SemiBold()).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black).Text("CÓDIGO");
                            header.Cell().DefaultTextStyle(x => x.SemiBold()).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black).Text("NOMBRE");
                            header.Cell().DefaultTextStyle(x => x.SemiBold()).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black).Text("UNI");
                            header.Cell().DefaultTextStyle(x => x.SemiBold()).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black).Text("CATEGORÍA");
                            header.Cell().DefaultTextStyle(x => x.SemiBold()).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black).AlignRight().Text("MINORISTA");
                            header.Cell().DefaultTextStyle(x => x.SemiBold()).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black).AlignRight().Text("MAYORISTA");
                            header.Cell().DefaultTextStyle(x => x.SemiBold()).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black).AlignCenter().Text("STOCK");
                        });

                        foreach (var producto in productos)
                        {
                            var stockTotal = producto.Stocks?.Sum(s => s.StockActual) ?? 0;

                            table.Cell().PaddingVertical(2).Text(producto.Codigo ?? "");
                            table.Cell().PaddingVertical(2).Text(producto.Nombre ?? "");
                            table.Cell().PaddingVertical(2).Text(producto.UnidadMedida?.Abreviatura ?? "");
                            table.Cell().PaddingVertical(2).Text(producto.Categoria?.Nombre ?? "N/A");
                            table.Cell().PaddingVertical(2).AlignRight().Text($"${producto.PrecioVentaMinorista:N2}");
                            table.Cell().PaddingVertical(2).AlignRight().Text(producto.PrecioVentaMayorista.HasValue ? $"${producto.PrecioVentaMayorista:N2}" : "N/A");
                            table.Cell().PaddingVertical(2).AlignCenter().Text(stockTotal.ToString());
                        }
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
            });
        }).GeneratePdf();
    }

    public byte[] GenerarExcelMovimientos(IEnumerable<Movimiento> movimientos)
    {
        using var workbook = new XLWorkbook();

        var movimientosList = movimientos.ToList();

        var wsEntradas = workbook.Worksheets.Add("Entradas");
        var entradas = movimientosList.Where(m => m.Tipo == "ENTRADA").ToList();
        LlenarHojaMovimientos(wsEntradas, entradas, "ENTRADAS");

        var wsSalidas = workbook.Worksheets.Add("Salidas");
        var salidas = movimientosList.Where(m => m.Tipo == "SALIDA").ToList();
        LlenarHojaMovimientos(wsSalidas, salidas, "SALIDAS");

        var wsTraslados = workbook.Worksheets.Add("Traslados");
        var traslados = movimientosList.Where(m => m.Tipo == "TRASLADO").ToList();
        if (traslados.Any())
        {
            LlenarHojaMovimientos(wsTraslados, traslados, "TRASLADOS");
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    private void LlenarHojaMovimientos(IXLWorksheet worksheet, List<Movimiento> movimientos, string titulo)
    {
        worksheet.Cell(1, 1).Value = $"REPORTE DE {titulo}";
        var titleRange = worksheet.Range(1, 1, 1, 6);
        titleRange.Merge();
        titleRange.Style.Font.Bold = true;
        titleRange.Style.Font.FontSize = 14;
        titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        worksheet.Cell(2, 1).Value = "DOCUMENTO";
        worksheet.Cell(2, 2).Value = "FECHA";
        worksheet.Cell(2, 3).Value = "PRODUCTO";
        worksheet.Cell(2, 4).Value = "CANTIDAD";
        worksheet.Cell(2, 5).Value = "PRECIO UNIT.";
        worksheet.Cell(2, 6).Value = "SUBTOTAL";

        var headerRange = worksheet.Range(2, 1, 2, 6);
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(52, 58, 64);
        headerRange.Style.Font.FontColor = XLColor.White;

        int row = 3;
        foreach (var movimiento in movimientos)
        {
            if (movimiento.Detalles == null) continue;

            foreach (var detalle in movimiento.Detalles)
            {
                worksheet.Cell(row, 1).Value = movimiento.NumeroDocumento ?? "";
                worksheet.Cell(row, 2).Value = movimiento.FechaMovimiento.ToString("dd/MM/yyyy");
                worksheet.Cell(row, 3).Value = detalle.Producto?.Nombre ?? "N/A";
                worksheet.Cell(row, 4).Value = detalle.Cantidad;
                worksheet.Cell(row, 5).Value = detalle.PrecioUnitario;
                worksheet.Cell(row, 6).Value = detalle.Subtotal;

                worksheet.Cell(row, 5).Style.NumberFormat.Format = "$ #,##0.00";
                worksheet.Cell(row, 6).Style.NumberFormat.Format = "$ #,##0.00";

                row++;
            }
        }

        worksheet.Columns().AdjustToContents();
    }

    public byte[] GenerarPdfMovimiento(Movimiento movimiento)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);

                page.Header()
                    .AlignCenter()
                    .Text($"COMPROBANTE DE {movimiento.Tipo}")
                    .SemiBold().FontSize(18)
                    .FontColor(movimiento.Tipo == "ENTRADA" ? Colors.Green.Medium :
                               movimiento.Tipo == "SALIDA" ? Colors.Red.Medium : Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(column =>
                    {
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Documento: {movimiento.NumeroDocumento}");
                            row.RelativeItem().Text($"Fecha: {movimiento.FechaMovimiento:dd/MM/yyyy HH:mm}");
                        });

                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Origen: {movimiento.AlmacenOrigen?.Nombre ?? "N/A"}");
                            if (movimiento.Tipo == "TRASLADO")
                            {
                                row.RelativeItem().Text($"Destino: {movimiento.AlmacenDestino?.Nombre ?? "N/A"}");
                            }
                        });

                        if (!string.IsNullOrEmpty(movimiento.Observacion))
                        {
                            column.Item().Text($"Observación: {movimiento.Observacion}");
                        }

                        column.Item().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(4);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("PRODUCTO").SemiBold();
                                header.Cell().Text("CANTIDAD").SemiBold().AlignRight();
                                header.Cell().Text("P. UNITARIO").SemiBold().AlignRight();
                                header.Cell().Text("SUBTOTAL").SemiBold().AlignRight();
                            });

                            if (movimiento.Detalles != null)
                            {
                                foreach (var detalle in movimiento.Detalles)
                                {
                                    table.Cell().Text(detalle.Producto?.Nombre ?? "N/A");
                                    table.Cell().AlignRight().Text(detalle.Cantidad.ToString("N2"));
                                    table.Cell().AlignRight().Text($"${detalle.PrecioUnitario:N2}");
                                    table.Cell().AlignRight().Text($"${detalle.Subtotal:N2}");
                                }
                            }
                        });

                        column.Item().AlignRight()
                            .Text($"TOTAL: ${movimiento.Total:N2}")
                            .SemiBold().FontSize(14);
                    });
            });
        }).GeneratePdf();
    }

    public byte[] GenerarExcelStockBajo(IEnumerable<Producto> productos)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Stock Bajo");

        worksheet.Cell(1, 1).Value = "REPORTE DE PRODUCTOS CON STOCK BAJO";
        var titleRange = worksheet.Range(1, 1, 1, 6);
        titleRange.Merge();
        titleRange.Style.Font.Bold = true;
        titleRange.Style.Font.FontSize = 14;
        titleRange.Style.Fill.BackgroundColor = XLColor.FromArgb(255, 193, 7);
        titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        worksheet.Cell(2, 1).Value = "CÓDIGO";
        worksheet.Cell(2, 2).Value = "PRODUCTO";
        worksheet.Cell(2, 3).Value = "CATEGORÍA";
        worksheet.Cell(2, 4).Value = "STOCK TOTAL";
        worksheet.Cell(2, 5).Value = "STOCK MÍNIMO";
        worksheet.Cell(2, 6).Value = "DIFERENCIA";

        var headerRange = worksheet.Range(2, 1, 2, 6);
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(52, 58, 64);
        headerRange.Style.Font.FontColor = XLColor.White;

        int row = 3;
        foreach (var producto in productos)
        {
            var stockTotal = producto.Stocks?.Sum(s => s.StockActual) ?? 0;
            var stockMinimo = producto.Stocks?.Sum(s => s.StockMinimo) ?? 0;

            if (producto.Activo && stockTotal <= stockMinimo && stockTotal > 0)
            {
                worksheet.Cell(row, 1).Value = producto.Codigo ?? "";
                worksheet.Cell(row, 2).Value = producto.Nombre ?? "";
                worksheet.Cell(row, 3).Value = producto.Categoria?.Nombre ?? "N/A";
                worksheet.Cell(row, 4).Value = stockTotal;
                worksheet.Cell(row, 5).Value = stockMinimo;
                worksheet.Cell(row, 6).Value = stockMinimo - stockTotal;

                worksheet.Cell(row, 4).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 200, 200);

                row++;
            }
        }

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public byte[] GenerarExcelInventarioPorAlmacen(Almacen almacen)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Inventario");

        // Título
        worksheet.Cell(1, 1).Value = $"INVENTARIO ACTUAL - {almacen.Nombre.ToUpper()}";
        var titleRange = worksheet.Range(1, 1, 1, 8);
        titleRange.Merge();
        titleRange.Style.Font.Bold = true;
        titleRange.Style.Font.FontSize = 14;
        titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        // Información del almacén
        worksheet.Cell(2, 1).Value = "Tipo:";
        worksheet.Cell(2, 2).Value = almacen.Tipo;
        worksheet.Cell(2, 3).Value = "Encargado:";
        worksheet.Cell(2, 4).Value = almacen.Encargado ?? "N/A";
        worksheet.Cell(2, 5).Value = "Fecha:";
        worksheet.Cell(2, 6).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        // Encabezados
        worksheet.Cell(4, 1).Value = "CÓDIGO";
        worksheet.Cell(4, 2).Value = "PRODUCTO";
        worksheet.Cell(4, 3).Value = "CATEGORÍA";
        worksheet.Cell(4, 4).Value = "STOCK ACTUAL";
        worksheet.Cell(4, 5).Value = "STOCK MÍNIMO";
        worksheet.Cell(4, 6).Value = "STOCK MÁXIMO";
        worksheet.Cell(4, 7).Value = "UBICACIÓN";
        worksheet.Cell(4, 8).Value = "ESTADO";

        var headerRange = worksheet.Range(4, 1, 4, 8);
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(52, 58, 64);
        headerRange.Style.Font.FontColor = XLColor.White;
        headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        // Datos
        int row = 5;
        if (almacen.Stocks != null && almacen.Stocks.Any())
        {
            foreach (var stock in almacen.Stocks.OrderBy(s => s.Producto?.Nombre))
            {
                worksheet.Cell(row, 1).Value = stock.Producto?.Codigo ?? "";
                worksheet.Cell(row, 2).Value = stock.Producto?.Nombre ?? "";
                worksheet.Cell(row, 3).Value = stock.Producto?.Categoria?.Nombre ?? "N/A";
                worksheet.Cell(row, 4).Value = stock.StockActual;
                worksheet.Cell(row, 5).Value = stock.StockMinimo;
                worksheet.Cell(row, 6).Value = stock.StockMaximo;
                worksheet.Cell(row, 7).Value = stock.Ubicacion ?? "";

                // Estado del stock
                if (stock.StockActual <= 0)
                {
                    worksheet.Cell(row, 8).Value = "AGOTADO";
                    worksheet.Cell(row, 8).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 100, 100);
                    worksheet.Cell(row, 8).Style.Font.FontColor = XLColor.White;
                }
                else if (stock.StockActual <= stock.StockMinimo)
                {
                    worksheet.Cell(row, 8).Value = "STOCK BAJO";
                    worksheet.Cell(row, 8).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 200, 100);
                }
                else
                {
                    worksheet.Cell(row, 8).Value = "NORMAL";
                    worksheet.Cell(row, 8).Style.Fill.BackgroundColor = XLColor.FromArgb(100, 200, 100);
                }

                // Colorear fila según estado
                if (stock.StockActual <= stock.StockMinimo)
                {
                    worksheet.Cell(row, 4).Style.Fill.BackgroundColor = XLColor.FromArgb(255, 200, 200);
                }

                row++;
            }
        }
        else
        {
            worksheet.Cell(row, 1).Value = "No hay productos en este almacén";
            worksheet.Range(row, 1, row, 8).Merge();
        }

        // Totales
        int totalRow = row + 1;
        worksheet.Cell(totalRow, 1).Value = "TOTAL PRODUCTOS:";
        worksheet.Cell(totalRow, 2).Value = almacen.Stocks?.Count ?? 0;
        worksheet.Cell(totalRow, 1).Style.Font.Bold = true;

        worksheet.Cell(totalRow + 1, 1).Value = "TOTAL UNIDADES:";
        worksheet.Cell(totalRow + 1, 2).Value = almacen.Stocks?.Sum(s => s.StockActual) ?? 0;
        worksheet.Cell(totalRow + 1, 1).Style.Font.Bold = true;

        worksheet.Cell(totalRow + 2, 1).Value = "STOCK BAJO:";
        worksheet.Cell(totalRow + 2, 2).Value = almacen.Stocks?.Count(s => s.StockActual <= s.StockMinimo && s.StockActual > 0) ?? 0;
        worksheet.Cell(totalRow + 2, 1).Style.Font.Bold = true;

        worksheet.Cell(totalRow + 3, 1).Value = "AGOTADOS:";
        worksheet.Cell(totalRow + 3, 2).Value = almacen.Stocks?.Count(s => s.StockActual <= 0) ?? 0;
        worksheet.Cell(totalRow + 3, 1).Style.Font.Bold = true;

        // Ajustar columnas
        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public byte[] GenerarPdfInventarioPorAlmacen(Almacen almacen)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header()
                    .AlignCenter()
                    .Text($"INVENTARIO ACTUAL - {almacen.Nombre.ToUpper()}")
                    .SemiBold()
                    .FontSize(18)
                    .FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(column =>
                    {
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Tipo: {almacen.Tipo}");
                            row.RelativeItem().Text($"Encargado: {almacen.Encargado ?? "N/A"}");
                            row.RelativeItem().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        });

                        column.Item().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1.5f);
                            });

                            table.Header(header =>
                            {
                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .Text("CÓDIGO");

                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .Text("PRODUCTO");

                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .Text("CATEGORÍA");

                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .AlignCenter()
                                    .Text("STOCK");

                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .AlignCenter()
                                    .Text("MÍN");

                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .AlignCenter()
                                    .Text("MÁX");

                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .Text("UBICACIÓN");

                                header.Cell()
                                    .DefaultTextStyle(x => x.SemiBold())
                                    .PaddingVertical(3)
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Black)
                                    .AlignCenter()
                                    .Text("ESTADO");
                            });

                            if (almacen.Stocks != null)
                            {
                                foreach (var stock in almacen.Stocks.OrderBy(s => s.Producto?.Nombre))
                                {
                                    var estado = stock.StockActual <= 0 ? "AGOTADO" :
                                                stock.StockActual <= stock.StockMinimo ? "BAJO" : "NORMAL";

                                    table.Cell().PaddingVertical(2).Text(stock.Producto?.Codigo ?? "");
                                    table.Cell().PaddingVertical(2).Text(stock.Producto?.Nombre ?? "");
                                    table.Cell().PaddingVertical(2).Text(stock.Producto?.Categoria?.Nombre ?? "");
                                    table.Cell().PaddingVertical(2).AlignCenter().Text(stock.StockActual.ToString());
                                    table.Cell().PaddingVertical(2).AlignCenter().Text(stock.StockMinimo.ToString());
                                    table.Cell().PaddingVertical(2).AlignCenter().Text(stock.StockMaximo.ToString());
                                    table.Cell().PaddingVertical(2).Text(stock.Ubicacion ?? "");
                                    table.Cell().PaddingVertical(2).AlignCenter().Text(estado);
                                }
                            }
                        });

                        column.Item().PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Text($"Total productos: {almacen.Stocks?.Count ?? 0}");
                            row.RelativeItem().Text($"Total unidades: {almacen.Stocks?.Sum(s => s.StockActual) ?? 0}");
                            row.RelativeItem().Text($"Stock bajo: {almacen.Stocks?.Count(s => s.StockActual <= s.StockMinimo && s.StockActual > 0) ?? 0}");
                        });
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                    });
            });
        }).GeneratePdf();
    }
}