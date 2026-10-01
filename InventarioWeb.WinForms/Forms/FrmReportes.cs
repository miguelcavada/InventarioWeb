using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmReportes : Form
{
    private readonly IReportService _reportService;
    private readonly IAlmacenService _almacenService;

    public FrmReportes(IReportService reportService, IAlmacenService almacenService)
    {
        InitializeComponent();
        _reportService = reportService;
        _almacenService = almacenService;
    }

    private async void FrmReportes_Load(object sender, EventArgs e)
    {
        await CargarAlmacenesAsync();
        dtpDesde.Value = DateTime.Today.AddDays(-30);
        dtpHasta.Value = DateTime.Today;
        dtpFechaInventarioDiario.Value = DateTime.Today;
    }

    private async Task CargarAlmacenesAsync()
    {
        var result = await _almacenService.GetAlmacenesAsync();
        if (result.IsSuccess && result.Data != null)
        {
            var almacenes = result.Data.Where(a => a.Activo).ToList();

            // Almacenes para Inventario Actual
            cmbAlmacenInventario.DataSource = almacenes.Select(a => new ComboItem
            {
                Id = a.Id,
                Nombre = a.Nombre
            }).ToList();
            cmbAlmacenInventario.DisplayMember = "Nombre";
            cmbAlmacenInventario.ValueMember = "Id";
            cmbAlmacenInventario.SelectedIndex = -1;

            // Almacenes para Inventario Diario (usar lista independiente)
            cmbAlmacenInventarioDiario.DataSource = almacenes.Select(a => new ComboItem
            {
                Id = a.Id,
                Nombre = a.Nombre
            }).ToList();
            cmbAlmacenInventarioDiario.DisplayMember = "Nombre";
            cmbAlmacenInventarioDiario.ValueMember = "Id";
            cmbAlmacenInventarioDiario.SelectedIndex = -1;
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
                File.WriteAllBytes(sfd.FileName, bytes);

                var result = MessageBox.Show(
                    $"Archivo generado exitosamente:\n{sfd.FileName}\n\n¿Desea abrirlo?",
                    "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = sfd.FileName,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnProductosExcel_Click(object sender, EventArgs e)
    {
        try
        {
            btnProductosExcel.Enabled = false;
            lblEstado.Text = "Generando Excel...";

            // ✅ AHORA: sin parámetro IUnitOfWork
            var bytes = await _reportService.GenerarExcelProductosAsync();

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"Productos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                "Archivos Excel (*.xlsx)|*.xlsx");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnProductosExcel.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnProductosPdf_Click(object sender, EventArgs e)
    {
        try
        {
            btnProductosPdf.Enabled = false;
            lblEstado.Text = "Generando PDF...";

            var bytes = await _reportService.GenerarPdfProductosAsync();

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"Productos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                "Archivos PDF (*.pdf)|*.pdf");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnProductosPdf.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnStockBajoExcel_Click(object sender, EventArgs e)
    {
        try
        {
            btnStockBajoExcel.Enabled = false;
            lblEstado.Text = "Generando Excel...";

            var bytes = await _reportService.GenerarExcelStockBajoAsync();

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"StockBajo_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                "Archivos Excel (*.xlsx)|*.xlsx");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnStockBajoExcel.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnMovimientosExcel_Click(object sender, EventArgs e)
    {
        try
        {
            btnMovimientosExcel.Enabled = false;
            lblEstado.Text = "Generando Excel...";

            string tipo = cmbTipoMovimiento.SelectedIndex switch
            {
                1 => "ENTRADA",
                2 => "SALIDA",
                3 => "TRASLADO",
                _ => "TODOS"
            };

            var bytes = await _reportService.GenerarExcelMovimientosAsync(
                tipo, dtpDesde.Value.Date, dtpHasta.Value.Date);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"Movimientos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                "Archivos Excel (*.xlsx)|*.xlsx");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnMovimientosExcel.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private void btnInventarioVer_Click(object sender, EventArgs e)
    {
        if (cmbAlmacenInventario.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un almacén", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var almacenItem = cmbAlmacenInventario.SelectedItem as ComboItem;

        using var frm = Program.ServiceProvider.GetRequiredService<FrmAlmacenInventario>();
        frm.AlmacenId = almacenItem!.Id;
        frm.AlmacenNombre = almacenItem.Nombre;
        frm.ShowDialog();
    }

    private async void btnInventarioExcel_Click(object sender, EventArgs e)
    {
        if (cmbAlmacenInventario.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un almacén", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            btnInventarioExcel.Enabled = false;
            lblEstado.Text = "Generando Excel...";

            var almacenItem = cmbAlmacenInventario.SelectedItem as ComboItem;
            var bytes = await _reportService.GenerarExcelInventarioAlmacenAsync(almacenItem!.Id);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"Inventario_{almacenItem.Nombre}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                "Archivos Excel (*.xlsx)|*.xlsx");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnInventarioExcel.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnInventarioPdf_Click(object sender, EventArgs e)
    {
        if (cmbAlmacenInventario.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un almacén", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            btnInventarioPdf.Enabled = false;
            lblEstado.Text = "Generando PDF...";

            var almacenItem = cmbAlmacenInventario.SelectedItem as ComboItem;
            var bytes = await _reportService.GenerarPdfInventarioAlmacenAsync(almacenItem!.Id);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"Inventario_{almacenItem.Nombre}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                "Archivos PDF (*.pdf)|*.pdf");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnInventarioPdf.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnStockBajoPdf_Click(object sender, EventArgs e)
    {
        try
        {
            btnStockBajoPdf.Enabled = false;
            lblEstado.Text = "Generando PDF...";

            var bytes = await _reportService.GenerarPdfStockBajoAsync();

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"StockBajo_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                "Archivos PDF (*.pdf)|*.pdf");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnStockBajoPdf.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnMovimientosPdf_Click(object sender, EventArgs e)
    {
        try
        {
            btnMovimientosPdf.Enabled = false;
            lblEstado.Text = "Generando PDF...";

            string tipo = cmbTipoMovimiento.SelectedIndex switch
            {
                1 => "ENTRADA",
                2 => "SALIDA",
                3 => "TRASLADO",
                _ => "TODOS"
            };

            var bytes = await _reportService.GenerarPdfMovimientosAsync(
                tipo, dtpDesde.Value.Date, dtpHasta.Value.Date);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"Movimientos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                "Archivos PDF (*.pdf)|*.pdf");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnMovimientosPdf.Enabled = true;
            lblEstado.Text = "";
        }
    }

    // ===== INVENTARIO DIARIO =====

    private void btnInventarioDiarioVer_Click(object sender, EventArgs e)
    {
        if (cmbAlmacenInventarioDiario.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un almacén o mercado", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var almacenItem = cmbAlmacenInventarioDiario.SelectedItem as ComboItem;

        using var frm = Program.ServiceProvider.GetRequiredService<FrmInventarioDiario>();
        frm.AlmacenId = almacenItem!.Id;
        frm.AlmacenNombre = almacenItem.Nombre;
        frm.Fecha = dtpFechaInventarioDiario.Value.Date;
        frm.ShowDialog();
    }

    private async void btnInventarioDiarioExcel_Click(object sender, EventArgs e)
    {
        if (cmbAlmacenInventarioDiario.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un almacén o mercado", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            btnInventarioDiarioExcel.Enabled = false;
            lblEstado.Text = "Generando Excel de inventario diario...";

            var almacenItem = cmbAlmacenInventarioDiario.SelectedItem as ComboItem;
            var fecha = dtpFechaInventarioDiario.Value.Date;

            var bytes = await _reportService.GenerarExcelInventarioDiarioAsync(almacenItem!.Id, fecha);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"InventarioDiario_{almacenItem.Nombre}_{fecha:yyyyMMdd}.xlsx",
                "Archivos Excel (*.xlsx)|*.xlsx");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnInventarioDiarioExcel.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private async void btnInventarioDiarioPdf_Click(object sender, EventArgs e)
    {
        if (cmbAlmacenInventarioDiario.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un almacén o mercado", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            btnInventarioDiarioPdf.Enabled = false;
            lblEstado.Text = "Generando PDF de inventario diario...";

            var almacenItem = cmbAlmacenInventarioDiario.SelectedItem as ComboItem;
            var fecha = dtpFechaInventarioDiario.Value.Date;

            var bytes = await _reportService.GenerarPdfInventarioDiarioAsync(almacenItem!.Id, fecha);

            lblEstado.Text = "";
            GuardarYAbrirArchivo(bytes,
                $"InventarioDiario_{almacenItem.Nombre}_{fecha:yyyyMMdd}.pdf",
                "Archivos PDF (*.pdf)|*.pdf");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnInventarioDiarioPdf.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }
}