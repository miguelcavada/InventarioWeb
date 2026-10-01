using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmMovimientoDetalle : Form
{
    private readonly IMovimientoService _movimientoService;

    public int MovimientoId { get; set; }

    private MovimientoDto? _movimiento;

    public FrmMovimientoDetalle(IMovimientoService movimientoService)
    {
        InitializeComponent();
        _movimientoService = movimientoService;
    }

    private async void FrmMovimientoDetalle_Load(object sender, EventArgs e)
    {
        await CargarMovimientoAsync();
    }

    private async Task CargarMovimientoAsync()
    {
        var result = await _movimientoService.GetMovimientoByIdAsync(MovimientoId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Movimiento no encontrado",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        _movimiento = result.Data;

        Text = $"Movimiento - {_movimiento.NumeroDocumento}";
        lblTitulo.Text = $"📋 {_movimiento.Tipo} - {_movimiento.NumeroDocumento}";

        // Colorear el header según tipo
        switch (_movimiento.Tipo)
        {
            case "ENTRADA":
                panelTop.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
                break;
            case "SALIDA":
                panelTop.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
                break;
            case "TRASLADO":
                panelTop.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
                break;
        }

        // Datos generales
        lblTipoValor.Text = _movimiento.Tipo;
        lblDocumentoValor.Text = _movimiento.NumeroDocumento;
        lblFechaValor.Text = _movimiento.FechaMovimiento.ToString("dd/MM/yyyy HH:mm");
        lblOrigenValor.Text = _movimiento.AlmacenOrigenNombre ?? "N/A";
        lblDestinoValor.Text = _movimiento.AlmacenDestinoNombre ?? "-";
        lblObservacionValor.Text = string.IsNullOrEmpty(_movimiento.Observacion) ? "-" : _movimiento.Observacion;

        // Ocultar destino si no es traslado
        if (_movimiento.Tipo != "TRASLADO")
        {
            lblDestinoTitulo.Visible = false;
            lblDestinoValor.Visible = false;
        }

        // Cargar detalles
        dgvDetalles.Rows.Clear();

        foreach (var d in _movimiento.Detalles)
        {
            dgvDetalles.Rows.Add(
                d.ProductoCodigo ?? "",
                d.ProductoNombre ?? "",
                d.Cantidad.ToString("N2"),
                d.PrecioUnitario.ToString("C2"),
                d.Subtotal.ToString("C2")
            );
        }

        lblTotalValor.Text = _movimiento.Total.ToString("C2");
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnExportarPdf_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Exportación a PDF en desarrollo.\n\n" +
            "Se generará un comprobante con los datos del movimiento.",
            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}