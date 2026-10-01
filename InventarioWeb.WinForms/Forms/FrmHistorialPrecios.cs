using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmHistorialPrecios : Form
{
    private readonly IProductoService _productoService;

    public int ProductoId { get; set; }

    private List<HistorialPrecioDto> _historial = new();

    public FrmHistorialPrecios(IProductoService productoService)
    {
        InitializeComponent();
        _productoService = productoService;
    }

    private async void FrmHistorialPrecios_Load(object sender, EventArgs e)
    {
        await CargarProductoAsync();
        await CargarHistorialAsync();
    }

    private async Task CargarProductoAsync()
    {
        var result = await _productoService.GetProductoByIdAsync(ProductoId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Producto no encontrado",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        var p = result.Data;
        Text = $"Historial de Precios - {p.Nombre}";
        lblProducto.Text = $"📦 {p.Nombre}";
        lblCodigo.Text = $"Código: {p.Codigo}";
        lblCategoria.Text = $"Categoría: {p.CategoriaNombre}";
        lblPrecioActual.Text = $"Precio actual: {p.PrecioVentaMinorista:C2}";
    }

    private async Task CargarHistorialAsync(DateTime? desde = null, DateTime? hasta = null)
    {
        dgvHistorial.Rows.Clear();

        var result = await _productoService.GetHistorialPreciosAsync(ProductoId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar historial",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var historial = result.Data.ToList();

        // Filtros de fecha
        if (desde.HasValue)
            historial = historial.Where(h => h.FechaCambio >= desde.Value).ToList();

        if (hasta.HasValue)
            historial = historial.Where(h => h.FechaCambio <= hasta.Value.AddDays(1).AddSeconds(-1)).ToList();

        _historial = historial;

        foreach (var h in _historial.OrderByDescending(x => x.FechaCambio))
        {
            int index = dgvHistorial.Rows.Add(
                h.FechaCambio.ToString("dd/MM/yyyy HH:mm"),
                h.PrecioCostoAnterior?.ToString("C2") ?? "-",
                h.PrecioCostoNuevo?.ToString("C2") ?? "-",
                h.PrecioVentaAnterior.ToString("C2"),
                h.PrecioVentaNuevo.ToString("C2"),
                $"{h.PorcentajeVariacion:+0.0;-0.0;0.0}%",
                h.Motivo ?? "-",
                h.UsuarioCambio ?? "-"
            );

            // Colorear según variación
            if (h.PorcentajeVariacion > 0)
            {
                dgvHistorial.Rows[index].Cells["colVariacion"].Style.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                dgvHistorial.Rows[index].Cells["colVariacion"].Style.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (h.PorcentajeVariacion < 0)
            {
                dgvHistorial.Rows[index].Cells["colVariacion"].Style.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                dgvHistorial.Rows[index].Cells["colVariacion"].Style.ForeColor = System.Drawing.Color.DarkGreen;
            }
        }

        // KPIs
        lblTotalCambios.Text = _historial.Count.ToString();
        lblAumentos.Text = _historial.Count(h => h.PorcentajeVariacion > 0).ToString();
        lblDisminuciones.Text = _historial.Count(h => h.PorcentajeVariacion < 0).ToString();
        lblUltimoCambio.Text = _historial.Any()
            ? _historial.OrderByDescending(h => h.FechaCambio).First().FechaCambio.ToString("dd/MM/yyyy HH:mm")
            : "Sin cambios";
    }

    private async void btnFiltrar_Click(object sender, EventArgs e)
    {
        await CargarHistorialAsync(dtpDesde.Value.Date, dtpHasta.Value.Date);
    }

    private async void btnLimpiar_Click(object sender, EventArgs e)
    {
        dtpDesde.Value = DateTime.Today.AddMonths(-6);
        dtpHasta.Value = DateTime.Today;
        await CargarHistorialAsync();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }
}