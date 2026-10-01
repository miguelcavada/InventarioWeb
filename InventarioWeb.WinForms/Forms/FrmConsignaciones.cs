using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmConsignaciones : Form
{
    private readonly IConsignacionService _consignacionService;
    private List<ConsignacionDto> _consignaciones = new();

    public FrmConsignaciones(IConsignacionService consignacionService)
    {
        InitializeComponent();
        _consignacionService = consignacionService;
    }

    private async void FrmConsignaciones_Load(object sender, EventArgs e)
    {
        CargarCombosFiltros();
        await CargarConsignacionesAsync();
    }

    private void CargarCombosFiltros()
    {
        var estados = new List<ComboItem>
        {
            new ComboItem { Id = -1, Nombre = "Todos los estados" },
            new ComboItem { Id = 1, Nombre = "Pendientes" },
            new ComboItem { Id = 2, Nombre = "Parciales" },
            new ComboItem { Id = 3, Nombre = "Completadas" }
        };

        cmbFiltroEstado.DataSource = estados;
        cmbFiltroEstado.DisplayMember = "Nombre";
        cmbFiltroEstado.ValueMember = "Id";
        cmbFiltroEstado.SelectedIndex = 0;
    }

    private async Task CargarConsignacionesAsync(string? buscar = null)
    {
        dgvConsignaciones.Rows.Clear();

        var result = await _consignacionService.GetConsignacionesAsync();

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar consignaciones",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var consignaciones = result.Data.ToList();

        // Búsqueda
        if (!string.IsNullOrWhiteSpace(buscar))
        {
            consignaciones = consignaciones.Where(c =>
                c.NumeroConsignacion.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
                c.VendedorNombre.Contains(buscar, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Filtro por estado
        var estadoItem = cmbFiltroEstado.SelectedItem as ComboItem;
        if (estadoItem != null && estadoItem.Id != -1)
        {
            string estado = estadoItem.Id switch
            {
                1 => "PENDIENTE",
                2 => "PARCIAL",
                3 => "COMPLETADA",
                _ => ""
            };
            consignaciones = consignaciones.Where(c => c.Estado == estado).ToList();
        }

        _consignaciones = consignaciones;

        foreach (var c in _consignaciones)
        {
            int index = dgvConsignaciones.Rows.Add(
                c.Id,
                c.NumeroConsignacion,
                c.FechaEntrega.ToString("dd/MM/yyyy"),
                c.VendedorNombre,
                c.AlmacenOrigenNombre ?? "",
                c.TotalProductos,
                c.TotalVendidos,
                c.TotalDevueltos,
                c.TotalProductos - c.TotalVendidos - c.TotalDevueltos,
                c.Estado
            );

            // Colorear según estado
            switch (c.Estado)
            {
                case "PENDIENTE":
                    dgvConsignaciones.Rows[index].Cells["colEstado"].Style.BackColor = System.Drawing.Color.FromArgb(255, 240, 200);
                    dgvConsignaciones.Rows[index].Cells["colEstado"].Style.ForeColor = System.Drawing.Color.DarkOrange;
                    break;
                case "PARCIAL":
                    dgvConsignaciones.Rows[index].Cells["colEstado"].Style.BackColor = System.Drawing.Color.FromArgb(220, 235, 255);
                    dgvConsignaciones.Rows[index].Cells["colEstado"].Style.ForeColor = System.Drawing.Color.DarkBlue;
                    break;
                case "COMPLETADA":
                    dgvConsignaciones.Rows[index].Cells["colEstado"].Style.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                    dgvConsignaciones.Rows[index].Cells["colEstado"].Style.ForeColor = System.Drawing.Color.DarkGreen;
                    break;
            }
        }

        lblTotal.Text = $"Total: {_consignaciones.Count} consignación(es)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarConsignacionesAsync(txtBuscar.Text.Trim());
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        cmbFiltroEstado.SelectedIndex = 0;
        await CargarConsignacionesAsync();
    }

    private async void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsHandleCreated && !DesignMode)
            await CargarConsignacionesAsync(txtBuscar.Text.Trim());
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmConsignacionEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarConsignacionesAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnVerDetalle_Click(object sender, EventArgs e)
    {
        if (dgvConsignaciones.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una consignación para ver el detalle", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvConsignaciones.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmConsignacionDetalle>();
        frm.ConsignacionId = id;
        frm.ShowDialog();

        await CargarConsignacionesAsync(txtBuscar.Text.Trim());
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvConsignaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnVerDetalle_Click(sender, EventArgs.Empty);
    }
}