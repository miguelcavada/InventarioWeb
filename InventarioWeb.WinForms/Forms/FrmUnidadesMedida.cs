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

public partial class FrmUnidadesMedida : Form
{
    private readonly IUnidadMedidaService _unidadService;
    private List<UnidadMedidaDto> _unidades = new();

    public FrmUnidadesMedida(IUnidadMedidaService unidadService)
    {
        InitializeComponent();
        _unidadService = unidadService;
    }

    private async void FrmUnidadesMedida_Load(object sender, EventArgs e)
    {
        await CargarUnidadesAsync();
    }

    private async Task CargarUnidadesAsync(string? buscar = null)
    {
        dgvUnidades.Rows.Clear();

        var result = await _unidadService.GetUnidadesAsync();

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar unidades",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var unidades = result.Data.ToList();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            unidades = unidades.Where(u =>
                u.Nombre.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
                u.Abreviatura.Contains(buscar, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        _unidades = unidades;

        foreach (var u in _unidades)
        {
            int index = dgvUnidades.Rows.Add(
                u.Id,
                u.Abreviatura,
                u.Nombre,
                u.Descripcion ?? "",
                u.TotalProductos,
                u.Activo ? "Activo" : "Inactivo"
            );

            if (!u.Activo)
                dgvUnidades.Rows[index].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
        }

        lblTotal.Text = $"Total: {_unidades.Count} unidad(es)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarUnidadesAsync(txtBuscar.Text.Trim());
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        await CargarUnidadesAsync();
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmUnidadMedidaEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarUnidadesAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvUnidades.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una unidad para editar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvUnidades.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmUnidadMedidaEdit>();
        frm.Modo = ModoEdicion.Editar;
        frm.UnidadId = id;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarUnidadesAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvUnidades.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una unidad para eliminar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!SessionManager.IsAdmin)
        {
            MessageBox.Show("Solo el administrador puede eliminar unidades de medida", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvUnidades.SelectedRows[0].Cells["colId"].Value);
        string nombre = dgvUnidades.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";

        var confirm = MessageBox.Show($"¿Eliminar la unidad '{nombre}'?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        MessageBox.Show("La eliminación de unidades de medida no está permitida desde aquí. " +
            "Puede desactivarla editándola.", "Información",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvUnidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnEditar_Click(sender, EventArgs.Empty);
    }
}