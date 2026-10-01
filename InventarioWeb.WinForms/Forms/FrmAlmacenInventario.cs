using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmAlmacenInventario : Form
{
    private readonly IAlmacenService _almacenService;

    public int AlmacenId { get; set; }
    public string AlmacenNombre { get; set; } = string.Empty;

    private List<StockAlmacenDto> _stocks = new();

    public FrmAlmacenInventario(IAlmacenService almacenService)
    {
        InitializeComponent();
        _almacenService = almacenService;
    }

    private async void FrmAlmacenInventario_Load(object sender, EventArgs e)
    {
        Text = $"Inventario - {AlmacenNombre}";
        lblTitulo.Text = $"📋 Inventario: {AlmacenNombre}";

        await CargarInventarioAsync();
    }

    private async Task CargarInventarioAsync(string? buscar = null, bool soloStockBajo = false)
    {
        dgvInventario.Rows.Clear();

        var result = await _almacenService.GetInventarioAsync(AlmacenId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar inventario",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var stocks = result.Data.ToList();

        // Búsqueda por nombre o código
        if (!string.IsNullOrWhiteSpace(buscar))
        {
            stocks = stocks.Where(s =>
                (s.ProductoNombre != null && s.ProductoNombre.Contains(buscar, StringComparison.OrdinalIgnoreCase)) ||
                (s.ProductoCodigo != null && s.ProductoCodigo.Contains(buscar, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // Solo stock bajo
        if (soloStockBajo)
        {
            stocks = stocks.Where(s => s.StockActual <= s.StockMinimo && s.StockActual > 0).ToList();
        }

        _stocks = stocks;

        foreach (var s in _stocks)
        {
            int index = dgvInventario.Rows.Add(
                s.ProductoCodigo ?? "",
                s.ProductoNombre ?? "",
                s.StockActual,
                s.StockMinimo,
                s.StockMaximo,
                s.Ubicacion ?? ""
            );

            // Colorear según estado
            if (s.StockActual <= 0)
            {
                dgvInventario.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
                dgvInventario.Rows[index].Cells["colEstado"].Value = "AGOTADO";
                dgvInventario.Rows[index].Cells["colEstado"].Style.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (s.StockActual <= s.StockMinimo)
            {
                dgvInventario.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 200);
                dgvInventario.Rows[index].Cells["colEstado"].Value = "STOCK BAJO";
                dgvInventario.Rows[index].Cells["colEstado"].Style.ForeColor = System.Drawing.Color.DarkOrange;
            }
            else
            {
                dgvInventario.Rows[index].Cells["colEstado"].Value = "NORMAL";
                dgvInventario.Rows[index].Cells["colEstado"].Style.ForeColor = System.Drawing.Color.DarkGreen;
            }
        }

        // Actualizar KPIs
        var totalUnidades = _stocks.Sum(s => s.StockActual);
        var stockBajo = _stocks.Count(s => s.StockActual <= s.StockMinimo && s.StockActual > 0);
        var agotados = _stocks.Count(s => s.StockActual <= 0);

        lblTotalProductosValor.Text = _stocks.Count.ToString();
        lblTotalUnidadesValor.Text = totalUnidades.ToString();
        lblStockBajoValor.Text = stockBajo.ToString();
        lblAgotadosValor.Text = agotados.ToString();
        lblTotal.Text = $"Mostrando {_stocks.Count} producto(s)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarInventarioAsync(txtBuscar.Text.Trim(), chkStockBajo.Checked);
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        chkStockBajo.Checked = false;
        await CargarInventarioAsync();
    }

    private async void chkStockBajo_CheckedChanged(object sender, EventArgs e)
    {
        if (IsHandleCreated && !DesignMode)
            await CargarInventarioAsync(txtBuscar.Text.Trim(), chkStockBajo.Checked);
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }
}