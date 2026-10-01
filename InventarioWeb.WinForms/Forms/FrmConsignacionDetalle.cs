using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmConsignacionDetalle : Form
{
    private readonly IConsignacionService _consignacionService;

    public int ConsignacionId { get; set; }

    private ConsignacionDto? _consignacion;

    public FrmConsignacionDetalle(IConsignacionService consignacionService)
    {
        InitializeComponent();
        _consignacionService = consignacionService;
    }

    private async void FrmConsignacionDetalle_Load(object sender, EventArgs e)
    {
        await CargarConsignacionAsync();
    }

    private async Task CargarConsignacionAsync()
    {
        var result = await _consignacionService.GetConsignacionByIdAsync(ConsignacionId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Consignación no encontrada",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        _consignacion = result.Data;

        Text = $"Consignación - {_consignacion.NumeroConsignacion}";
        lblTitulo.Text = $"📋 Consignación #{_consignacion.NumeroConsignacion}";
        lblVendedor.Text = $"👤 {_consignacion.VendedorNombre}";
        lblFecha.Text = $"📅 {_consignacion.FechaEntrega:dd/MM/yyyy}";
        lblAlmacen.Text = $"🏪 {_consignacion.AlmacenOrigenNombre}";

        // Colorear header según estado
        switch (_consignacion.Estado)
        {
            case "PENDIENTE":
                panelTop.BackColor = System.Drawing.Color.FromArgb(255, 159, 28);
                break;
            case "PARCIAL":
                panelTop.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
                break;
            case "COMPLETADA":
                panelTop.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
                break;
        }

        lblEstado.Text = _consignacion.Estado;
        lblObservacion.Text = string.IsNullOrEmpty(_consignacion.Observaciones) ? "-" : _consignacion.Observaciones;

        await RefrescarDetallesAsync();
    }

    private async Task RefrescarDetallesAsync()
    {
        // Recargar para obtener los datos actualizados
        var result = await _consignacionService.GetConsignacionByIdAsync(ConsignacionId);
        if (!result.IsSuccess || result.Data == null) return;

        _consignacion = result.Data;

        dgvDetalles.Rows.Clear();

        foreach (var d in _consignacion.Detalles)
        {
            int pendiente = d.CantidadEntregada - d.CantidadVendida - d.CantidadDevuelta;

            int index = dgvDetalles.Rows.Add(
                d.Id,
                d.ProductoCodigo,
                d.ProductoNombre,
                d.CantidadEntregada,
                d.CantidadVendida,
                d.CantidadDevuelta,
                pendiente,
                d.PrecioUnitario.ToString("C2"),
                d.SubtotalVendido.ToString("C2")
            );

            // Colorear según pendiente
            if (pendiente == 0)
            {
                dgvDetalles.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
            }
            else if (d.CantidadVendida > 0 || d.CantidadDevuelta > 0)
            {
                dgvDetalles.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            }
        }

        // KPIs
        lblEntregadosValor.Text = _consignacion.TotalProductos.ToString();
        lblVendidosValor.Text = _consignacion.TotalVendidos.ToString();
        lblDevueltosValor.Text = _consignacion.TotalDevueltos.ToString();
        lblPendientesValor.Text = (_consignacion.TotalProductos - _consignacion.TotalVendidos - _consignacion.TotalDevueltos).ToString();
        lblTotalVendido.Text = _consignacion.TotalVendidoValor.ToString("C2");

        // Habilitar/deshabilitar botones
        bool puedeOperar = _consignacion.Estado != "COMPLETADA" && _consignacion.Estado != "CANCELADA";
        btnRegistrarVenta.Enabled = puedeOperar;
        btnRegistrarDevolucion.Enabled = puedeOperar;
    }

    private async void btnRegistrarVenta_Click(object sender, EventArgs e)
    {
        if (dgvDetalles.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto para registrar la venta", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int detalleId = Convert.ToInt32(dgvDetalles.SelectedRows[0].Cells["colDetalleId"].Value);
        int pendiente = Convert.ToInt32(dgvDetalles.SelectedRows[0].Cells["colPendiente"].Value);

        if (pendiente <= 0)
        {
            MessageBox.Show("No hay cantidad pendiente para vender de este producto", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var frm = new FrmCantidadDialog();
        frm.Titulo = "Registrar Venta";
        frm.CantidadMaxima = pendiente;
        frm.Mensaje = $"Cantidad pendiente: {pendiente}";

        if (frm.ShowDialog() == DialogResult.OK)
        {
            var dto = new RegistrarVentaDto
            {
                ConsignacionDetalleId = detalleId,
                CantidadVendida = frm.Cantidad
            };

            var result = await _consignacionService.RegistrarVentaAsync(dto);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Venta registrada",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await RefrescarDetallesAsync();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage ?? "Error al registrar venta",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnRegistrarDevolucion_Click(object sender, EventArgs e)
    {
        if (dgvDetalles.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto para registrar la devolución", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int detalleId = Convert.ToInt32(dgvDetalles.SelectedRows[0].Cells["colDetalleId"].Value);
        int pendiente = Convert.ToInt32(dgvDetalles.SelectedRows[0].Cells["colPendiente"].Value);

        if (pendiente <= 0)
        {
            MessageBox.Show("No hay cantidad pendiente para devolver de este producto", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var frm = new FrmCantidadDialog();
        frm.Titulo = "Registrar Devolución";
        frm.CantidadMaxima = pendiente;
        frm.Mensaje = $"Cantidad pendiente: {pendiente}";

        if (frm.ShowDialog() == DialogResult.OK)
        {
            var dto = new RegistrarDevolucionDto
            {
                ConsignacionDetalleId = detalleId,
                CantidadDevuelta = frm.Cantidad
            };

            var result = await _consignacionService.RegistrarDevolucionAsync(dto);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Devolución registrada",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await RefrescarDetallesAsync();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage ?? "Error al registrar devolución",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }
}