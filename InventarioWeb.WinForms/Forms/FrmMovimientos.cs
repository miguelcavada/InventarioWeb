using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmMovimientos : Form
{
    private readonly IMovimientoService _movimientoService;
    private List<MovimientoDto> _movimientos = new();

    public FrmMovimientos(IMovimientoService movimientoService)
    {
        InitializeComponent();
        _movimientoService = movimientoService;
    }

    private async void FrmMovimientos_Load(object sender, EventArgs e)
    {
        CargarCombosFiltros();
        await CargarMovimientosAsync();
    }

    private void CargarCombosFiltros()
    {
        // Combo de Tipo
        var tipos = new List<ComboItem>
        {
            new ComboItem { Id = -1, Nombre = "Todos los tipos" },
            new ComboItem { Id = 1, Nombre = "Entradas" },
            new ComboItem { Id = 2, Nombre = "Salidas" },
            new ComboItem { Id = 3, Nombre = "Traslados" }
        };

        cmbFiltroTipo.DataSource = tipos;
        cmbFiltroTipo.DisplayMember = "Nombre";
        cmbFiltroTipo.ValueMember = "Id";
        cmbFiltroTipo.SelectedIndex = 0;
    }

    //private async Task CargarMovimientosAsync()
    //{
    //    dgvMovimientos.Rows.Clear();

    //    string tipo = "TODOS";
    //    var tipoItem = cmbFiltroTipo.SelectedItem as ComboItem;
    //    if (tipoItem != null)
    //    {
    //        switch (tipoItem.Id)
    //        {
    //            case 1: tipo = "ENTRADA"; break;
    //            case 2: tipo = "SALIDA"; break;
    //            case 3: tipo = "TRASLADO"; break;
    //        }
    //    }

    //    DateTime? desde = chkFecha.Checked ? dtpDesde.Value.Date : null;
    //    DateTime? hasta = chkFecha.Checked ? dtpHasta.Value.Date : null;

    //    var result = await _movimientoService.GetMovimientosAsync(tipo, desde, hasta);

    //    if (!result.IsSuccess || result.Data == null)
    //    {
    //        MessageBox.Show(result.ErrorMessage ?? "Error al cargar movimientos",
    //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        return;
    //    }

    //    var movimientos = result.Data.ToList();

    //    // Filtro por búsqueda
    //    if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
    //    {
    //        var buscar = txtBuscar.Text.Trim();
    //        movimientos = movimientos.Where(m =>
    //            m.NumeroDocumento.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
    //            (m.Observacion != null && m.Observacion.Contains(buscar, StringComparison.OrdinalIgnoreCase)))
    //            .ToList();
    //    }

    //    _movimientos = movimientos;

    //    foreach (var m in _movimientos)
    //    {
    //        int index = dgvMovimientos.Rows.Add(
    //            m.Id,
    //            m.NumeroDocumento,
    //            m.Tipo,
    //            m.FechaMovimiento.ToString("dd/MM/yyyy HH:mm"),
    //            m.AlmacenOrigenNombre ?? "",
    //            m.AlmacenDestinoNombre ?? "",
    //            m.Observacion ?? "",
    //            m.Total.ToString("C2")
    //        );

    //        // Colorear según tipo
    //        switch (m.Tipo)
    //        {
    //            case "ENTRADA":
    //                dgvMovimientos.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
    //                dgvMovimientos.Rows[index].Cells["colTipo"].Style.ForeColor = System.Drawing.Color.DarkGreen;
    //                break;
    //            case "SALIDA":
    //                dgvMovimientos.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
    //                dgvMovimientos.Rows[index].Cells["colTipo"].Style.ForeColor = System.Drawing.Color.DarkRed;
    //                break;
    //            case "TRASLADO":
    //                dgvMovimientos.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(220, 235, 255);
    //                dgvMovimientos.Rows[index].Cells["colTipo"].Style.ForeColor = System.Drawing.Color.DarkBlue;
    //                break;
    //        }
    //    }

    //    lblTotal.Text = $"Total: {_movimientos.Count} movimiento(s)";
    //}

    private async Task CargarMovimientosAsync()
    {
        dgvMovimientos.Rows.Clear();

        string tipo = "TODOS";
        var tipoItem = cmbFiltroTipo.SelectedItem as ComboItem;
        if (tipoItem != null)
        {
            switch (tipoItem.Id)
            {
                case 1: tipo = "ENTRADA"; break;
                case 2: tipo = "SALIDA"; break;
                case 3: tipo = "TRASLADO"; break;
            }
        }

        DateTime? desde = chkFecha.Checked ? dtpDesde.Value.Date : null;
        DateTime? hasta = chkFecha.Checked ? dtpHasta.Value.Date : null;

        var result = await _movimientoService.GetMovimientosAsync(tipo, desde, hasta);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar movimientos",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var movimientos = result.Data.ToList();

        if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
        {
            var buscar = txtBuscar.Text.Trim();
            movimientos = movimientos.Where(m =>
                m.NumeroDocumento.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
                (m.Observacion != null && m.Observacion.Contains(buscar, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        _movimientos = movimientos;

        foreach (var m in _movimientos)
        {
            int index = dgvMovimientos.Rows.Add(
                m.Id,
                m.NumeroDocumento,
                m.Tipo,
                m.MotivoSalida ?? "-",   // ← NUEVO
                m.FechaMovimiento.ToString("dd/MM/yyyy HH:mm"),
                m.AlmacenOrigenNombre ?? "",
                m.AlmacenDestinoNombre ?? "",
                m.Observacion ?? "",
                m.Total.ToString("C2")
            );

            // Colorear según tipo
            switch (m.Tipo)
            {
                case "ENTRADA":
                    dgvMovimientos.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                    dgvMovimientos.Rows[index].Cells["colTipo"].Style.ForeColor = System.Drawing.Color.DarkGreen;
                    break;
                case "SALIDA":
                    dgvMovimientos.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                    dgvMovimientos.Rows[index].Cells["colTipo"].Style.ForeColor = System.Drawing.Color.DarkRed;
                    break;
                case "TRASLADO":
                    dgvMovimientos.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(220, 235, 255);
                    dgvMovimientos.Rows[index].Cells["colTipo"].Style.ForeColor = System.Drawing.Color.DarkBlue;
                    break;
            }

            // NUEVO: Colorear según motivo de salida
            if (m.Tipo == "SALIDA" && !string.IsNullOrEmpty(m.MotivoSalida))
            {
                switch (m.MotivoSalida)
                {
                    case "VENTA":
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.ForeColor = System.Drawing.Color.DarkGreen;
                        break;
                    case "MERMA":
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.ForeColor = System.Drawing.Color.DarkRed;
                        break;
                    case "DEVOLUCION":
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.BackColor = System.Drawing.Color.FromArgb(255, 245, 220);
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.ForeColor = System.Drawing.Color.DarkGoldenrod;
                        break;
                    case "AJUSTE":
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.BackColor = System.Drawing.Color.FromArgb(220, 240, 255);
                        dgvMovimientos.Rows[index].Cells["colMotivo"].Style.ForeColor = System.Drawing.Color.DarkBlue;
                        break;
                }
            }
        }

        lblTotal.Text = $"Total: {_movimientos.Count} movimiento(s)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarMovimientosAsync();
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        cmbFiltroTipo.SelectedIndex = 0;
        chkFecha.Checked = false;
        await CargarMovimientosAsync();
    }

    private async void cmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsHandleCreated && !DesignMode)
            await CargarMovimientosAsync();
    }

    private async void chkFecha_CheckedChanged(object sender, EventArgs e)
    {
        dtpDesde.Enabled = chkFecha.Checked;
        dtpHasta.Enabled = chkFecha.Checked;

        if (IsHandleCreated && !DesignMode)
            await CargarMovimientosAsync();
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarMovimientosAsync();
        }
    }

    private async void btnNuevaEntrada_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        frm.TipoInicial = "ENTRADA";
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarMovimientosAsync();
        }
    }

    private async void btnNuevaSalida_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        frm.TipoInicial = "SALIDA";
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarMovimientosAsync();
        }
    }

    private async void btnNuevoTraslado_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        frm.TipoInicial = "TRASLADO";
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarMovimientosAsync();
        }
    }

    private async void btnVerDetalle_Click(object sender, EventArgs e)
    {
        if (dgvMovimientos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un movimiento para ver el detalle", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvMovimientos.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientoDetalle>();
        frm.MovimientoId = id;
        frm.ShowDialog();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvMovimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnVerDetalle_Click(sender, EventArgs.Empty);
    }
}