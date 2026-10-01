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

public partial class FrmProveedores : Form
{
    private readonly IProveedorService _proveedorService;
    private List<ProveedorDto> _proveedores = new();

    public FrmProveedores(IProveedorService proveedorService)
    {
        InitializeComponent();
        _proveedorService = proveedorService;
    }

    private async void FrmProveedores_Load(object sender, EventArgs e)
    {
        await CargarProveedoresAsync();
    }

    private async Task CargarProveedoresAsync(string? buscar = null)
    {
        dgvProveedores.Rows.Clear();

        var result = await _proveedorService.GetProveedoresAsync(buscar);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar proveedores",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _proveedores = result.Data.ToList();

        foreach (var p in _proveedores)
        {
            int index = dgvProveedores.Rows.Add(
                p.Id,
                p.Nombre,
                p.RUC ?? "",
                p.Direccion ?? "",
                p.Telefono ?? "",
                p.Email ?? "",
                p.Activo ? "Activo" : "Inactivo"
            );

            if (!p.Activo)
                dgvProveedores.Rows[index].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
        }

        lblTotal.Text = $"Total: {_proveedores.Count} proveedor(es)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarProveedoresAsync(txtBuscar.Text.Trim());
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        await CargarProveedoresAsync();
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmProveedorEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarProveedoresAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvProveedores.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un proveedor para editar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmProveedorEdit>();
        frm.Modo = ModoEdicion.Editar;
        frm.ProveedorId = id;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarProveedoresAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvProveedores.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un proveedor para eliminar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!SessionManager.IsAdmin)
        {
            MessageBox.Show("Solo el administrador puede eliminar proveedores", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["colId"].Value);
        string nombre = dgvProveedores.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";

        var confirm = MessageBox.Show($"¿Eliminar el proveedor '{nombre}'?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        var result = await _proveedorService.DeleteProveedorAsync(id);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.SuccessMessage ?? "Proveedor eliminado", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarProveedoresAsync(txtBuscar.Text.Trim());
        }
        else
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al eliminar", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnEditar_Click(sender, EventArgs.Empty);
    }
}