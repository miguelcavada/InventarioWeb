using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmInventarioDiario : Form
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReportService _reportService;

    public int AlmacenId { get; set; }
    public string AlmacenNombre { get; set; } = string.Empty;
    public DateTime Fecha { get; set; } = DateTime.Today;

    private List<InventarioDiarioResumenDto> _resumen = new();

    public FrmInventarioDiario(IUnitOfWork unitOfWork, IReportService reportService)
    {
        InitializeComponent();
        _unitOfWork = unitOfWork;
        _reportService = reportService;
    }

    private async void FrmInventarioDiario_Load(object sender, EventArgs e)
    {
        Text = $"Inventario Diario - {AlmacenNombre} - {Fecha:dd/MM/yyyy}";
        lblTitulo.Text = $"📅 Inventario Diario";
        lblAlmacen.Text = $"🏪 {AlmacenNombre}";
        lblFecha.Text = $"📅 {Fecha:dd/MM/yyyy}";

        // Configurar picker por si cambian la fecha
        dtpFecha.Value = Fecha;

        await CargarInventarioAsync();
    }

    //private async Task CargarInventarioAsync()
    //{
    //    dgvInventario.Rows.Clear();

    //    var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(AlmacenId);

    //    if (almacen == null)
    //    {
    //        MessageBox.Show("Almacén no encontrado", "Error",
    //            MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        Close();
    //        return;
    //    }

    //    var fechaConsulta = dtpFecha.Value.Date;
    //    _resumen.Clear();

    //    if (almacen.Stocks != null)
    //    {
    //        foreach (var stock in almacen.Stocks.OrderBy(s => s.Producto?.Nombre))
    //        {
    //            var producto = stock.Producto;
    //            if (producto == null) continue;

    //            var existenciaFinal = stock.StockActual;

    //            // Movimientos del día
    //            var movimientosDia = producto.MovimientosDetalle?
    //                .Where(d => d.FechaCreacion.Date == fechaConsulta
    //                         && d.Movimiento?.AlmacenOrigenId == almacen.Id)
    //                .ToList() ?? new();

    //            var entradasDia = (int)movimientosDia
    //                .Where(d => d.Movimiento?.Tipo == "ENTRADA")
    //                .Sum(d => d.Cantidad);

    //            var salidasDia = (int)movimientosDia
    //                .Where(d => d.Movimiento?.Tipo == "SALIDA")
    //                .Sum(d => d.Cantidad);

    //            var existenciaInicial = existenciaFinal - entradasDia + salidasDia;
    //            var valorInventario = existenciaFinal * producto.PrecioVentaMinorista;

    //            _resumen.Add(new InventarioDiarioResumenDto
    //            {
    //                ProductoId = producto.Id,
    //                Codigo = producto.Codigo ?? "",
    //                Producto = producto.Nombre ?? "",
    //                Unidad = producto.UnidadMedida?.Abreviatura ?? "",
    //                ExistenciaInicial = existenciaInicial,
    //                Entradas = entradasDia,
    //                Salidas = salidasDia,
    //                ExistenciaFinal = existenciaFinal,
    //                PrecioMinorista = producto.PrecioVentaMinorista,
    //                PrecioMayorista = producto.PrecioVentaMayorista,
    //                ValorInventario = valorInventario
    //            });
    //        }
    //    }

    //    // Llenar grid
    //    foreach (var item in _resumen)
    //    {
    //        int index = dgvInventario.Rows.Add(
    //            item.Codigo,
    //            item.Producto,
    //            item.Unidad,
    //            item.ExistenciaInicial,
    //            item.Entradas,
    //            item.Salidas,
    //            item.ExistenciaFinal,
    //            item.PrecioMinorista.ToString("C2"),
    //            item.PrecioMayorista?.ToString("C2") ?? "N/A",
    //            item.ValorInventario.ToString("C2")
    //        );

    //        // Colorear según estado
    //        if (item.ExistenciaFinal <= 0)
    //        {
    //            dgvInventario.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
    //        }
    //        else if (item.Entradas > 0)
    //        {
    //            dgvInventario.Rows[index].Cells["colEntradas"].Style.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
    //            dgvInventario.Rows[index].Cells["colEntradas"].Style.ForeColor = System.Drawing.Color.DarkGreen;
    //        }

    //        if (item.Salidas > 0)
    //        {
    //            dgvInventario.Rows[index].Cells["colSalidas"].Style.BackColor = System.Drawing.Color.FromArgb(255, 240, 220);
    //            dgvInventario.Rows[index].Cells["colSalidas"].Style.ForeColor = System.Drawing.Color.DarkOrange;
    //        }
    //    }

    //    // KPIs
    //    lblTotalProductos.Text = _resumen.Count.ToString();
    //    lblTotalEntradas.Text = _resumen.Sum(r => r.Entradas).ToString();
    //    lblTotalSalidas.Text = _resumen.Sum(r => r.Salidas).ToString();
    //    lblValorInventario.Text = _resumen.Sum(r => r.ValorInventario).ToString("C2");

    //    lblTotal.Text = $"Mostrando {_resumen.Count} producto(s)";
    //}

    private async Task CargarInventarioAsync()
    {
        dgvInventario.Rows.Clear();

        var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(AlmacenId);

        if (almacen == null)
        {
            MessageBox.Show("Almacén no encontrado", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        var fechaConsulta = dtpFecha.Value.Date;
        _resumen.Clear();

        decimal totalVentas = 0;

        if (almacen.Stocks != null)
        {
            foreach (var stock in almacen.Stocks.OrderBy(s => s.Producto?.Nombre))
            {
                var producto = stock.Producto;
                if (producto == null) continue;

                var existenciaFinal = stock.StockActual;

                var salidasDia = producto.MovimientosDetalle?
                    .Where(d => d.FechaCreacion.Date == fechaConsulta
                             && d.Movimiento?.AlmacenOrigenId == almacen.Id
                             && d.Movimiento?.Tipo == "SALIDA")
                    .ToList() ?? new();

                var entradasDia = (int)(producto.MovimientosDetalle?
                    .Where(d => d.FechaCreacion.Date == fechaConsulta
                             && d.Movimiento?.AlmacenOrigenId == almacen.Id
                             && d.Movimiento?.Tipo == "ENTRADA")
                    .Sum(d => d.Cantidad) ?? 0);

                // Desglose por motivo
                var ventas = (int)salidasDia.Where(d => d.Movimiento?.MotivoSalida == "VENTA").Sum(d => d.Cantidad);
                var mermas = (int)salidasDia.Where(d => d.Movimiento?.MotivoSalida == "MERMA").Sum(d => d.Cantidad);
                var devoluciones = (int)salidasDia.Where(d => d.Movimiento?.MotivoSalida == "DEVOLUCION").Sum(d => d.Cantidad);
                var otrasSalidas = (int)salidasDia.Where(d => d.Movimiento?.MotivoSalida != "VENTA"
                                                           && d.Movimiento?.MotivoSalida != "MERMA"
                                                           && d.Movimiento?.MotivoSalida != "DEVOLUCION").Sum(d => d.Cantidad);

                var totalSalidas = ventas + mermas + devoluciones + otrasSalidas;
                var existenciaInicial = existenciaFinal - entradasDia + totalSalidas;
                var valorVentas = ventas * producto.PrecioVentaMinorista;
                totalVentas += valorVentas;

                _resumen.Add(new InventarioDiarioResumenDto
                {
                    ProductoId = producto.Id,
                    Codigo = producto.Codigo ?? "",
                    Producto = producto.Nombre ?? "",
                    Unidad = producto.UnidadMedida?.Abreviatura ?? "",
                    ExistenciaInicial = existenciaInicial,
                    Entradas = entradasDia,
                    Ventas = ventas,           // ← NUEVO
                    Mermas = mermas,           // ← NUEVO
                    Devoluciones = devoluciones, // ← NUEVO
                    OtrasSalidas = otrasSalidas, // ← NUEVO
                    Salidas = totalSalidas,
                    ExistenciaFinal = existenciaFinal,
                    PrecioMinorista = producto.PrecioVentaMinorista,
                    PrecioMayorista = producto.PrecioVentaMayorista,
                    ValorVentas = valorVentas  // ← NUEVO
                });
            }
        }

        // Llenar grid
        foreach (var item in _resumen)
        {
            int index = dgvInventario.Rows.Add(
                item.Codigo,               // colCodigo
                item.Producto,             // colProducto
                item.Unidad,               // colUnidad
                item.ExistenciaInicial,    // colInicial
                item.Entradas,             // colEntradas
                item.Ventas,               // colVentas
                item.Mermas,               // colMermas
                item.Devoluciones,         // colDevoluciones
                item.OtrasSalidas,         // colOtrasSalidas
                item.ExistenciaFinal,      // colFinal
                item.PrecioMinorista.ToString("C2"),   // colPrecioMinorista
                item.PrecioMayorista?.ToString("C2") ?? "N/A",  // colPrecioMayorista
                item.ValorVentas.ToString("C2")        // colValor
            );

            // Colorear ventas (verde)
            if (item.Ventas > 0)
            {
                dgvInventario.Rows[index].Cells["colVentas"].Style.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                dgvInventario.Rows[index].Cells["colVentas"].Style.ForeColor = System.Drawing.Color.DarkGreen;
            }

            // Colorear mermas (rojo)
            if (item.Mermas > 0)
            {
                dgvInventario.Rows[index].Cells["colMermas"].Style.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                dgvInventario.Rows[index].Cells["colMermas"].Style.ForeColor = System.Drawing.Color.DarkRed;
            }

            // Colorear devoluciones (amarillo)
            if (item.Devoluciones > 0)
            {
                dgvInventario.Rows[index].Cells["colDevoluciones"].Style.BackColor = System.Drawing.Color.FromArgb(255, 245, 220);
                dgvInventario.Rows[index].Cells["colDevoluciones"].Style.ForeColor = System.Drawing.Color.DarkGoldenrod;
            }

            // Colorear otras salidas (azul)
            if (item.OtrasSalidas > 0)
            {
                dgvInventario.Rows[index].Cells["colOtrasSalidas"].Style.BackColor = System.Drawing.Color.FromArgb(220, 240, 255);
                dgvInventario.Rows[index].Cells["colOtrasSalidas"].Style.ForeColor = System.Drawing.Color.DarkBlue;
            }

            // Colorear existencia final si agotado
            if (item.ExistenciaFinal <= 0)
            {
                dgvInventario.Rows[index].Cells["colFinal"].Style.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
                dgvInventario.Rows[index].Cells["colFinal"].Style.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        // KPIs actualizados
        lblTotalProductos.Text = _resumen.Count.ToString();
        lblTotalEntradas.Text = _resumen.Sum(r => r.Entradas).ToString();
        lblTotalVentas.Text = _resumen.Sum(r => r.Ventas).ToString();
        lblTotalMermas.Text = _resumen.Sum(r => r.Mermas).ToString();
        lblTotalDevoluciones.Text = _resumen.Sum(r => r.Devoluciones).ToString();
        lblValorVentas.Text = totalVentas.ToString("C2");

        lblTotal.Text = $"Mostrando {_resumen.Count} producto(s)";
    }

    private async void dtpFecha_ValueChanged(object sender, EventArgs e)
    {
        if (!IsHandleCreated || DesignMode) return;
        Fecha = dtpFecha.Value.Date;
        lblFecha.Text = $"📅 {Fecha:dd/MM/yyyy}";
        await CargarInventarioAsync();
    }

    private void btnRefrescar_Click(object sender, EventArgs e)
    {
        _ = CargarInventarioAsync();
    }

    private async void btnExportarExcel_Click(object sender, EventArgs e)
    {
        try
        {
            btnExportarExcel.Enabled = false;
            lblEstado.Text = "Generando Excel...";

            var bytes = await _reportService.GenerarExcelInventarioDiarioAsync(AlmacenId, dtpFecha.Value.Date);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"InventarioDiario_{AlmacenNombre}_{dtpFecha.Value:yyyyMMdd}.xlsx",
                "Archivos Excel (*.xlsx)|*.xlsx");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnExportarExcel.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnExportarPdf_Click(object sender, EventArgs e)
    {
        try
        {
            btnExportarPdf.Enabled = false;
            lblEstado.Text = "Generando PDF...";

            var bytes = await _reportService.GenerarPdfInventarioDiarioAsync(AlmacenId, dtpFecha.Value.Date);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"InventarioDiario_{AlmacenNombre}_{dtpFecha.Value:yyyyMMdd}.pdf",
                "Archivos PDF (*.pdf)|*.pdf");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnExportarPdf.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private void GuardarYAbrirArchivo(byte[] bytes, string nombreSugerido, string filtro)
    {
        using var sfd = new SaveFileDialog
        {
            FileName = nombreSugerido,
            Filter = filtro,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        };

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                System.IO.File.WriteAllBytes(sfd.FileName, bytes);

                var result = MessageBox.Show(
                    $"Archivo generado exitosamente:\n{sfd.FileName}\n\n¿Desea abrirlo?",
                    "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = sfd.FileName,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }
}