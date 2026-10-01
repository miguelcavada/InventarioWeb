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

public partial class FrmAlmacenes : Form
{
    private readonly IAlmacenService _almacenService;
    private List<AlmacenDto> _almacenes = new();

    public FrmAlmacenes(IAlmacenService almacenService)
    {
        InitializeComponent();
        _almacenService = almacenService;
    }

    private async void FrmAlmacenes_Load(object sender, EventArgs e)
    {
        await CargarCombosFiltrosAsync();
        await CargarAlmacenesAsync();
    }

    private async Task CargarCombosFiltrosAsync()
    {
        // Combo de Tipo
        var tipos = new List<ComboItem>
        {
            new ComboItem { Id = -1, Nombre = "Todos" },
            new ComboItem { Id = 1, Nombre = "Almacenes" },
            new ComboItem { Id = 2, Nombre = "Mercados" }
        };

        cmbFiltroTipo.DataSource = tipos;
        cmbFiltroTipo.DisplayMember = "Nombre";
        cmbFiltroTipo.ValueMember = "Id";
        cmbFiltroTipo.SelectedIndex = 0;

        // Combo de Estado
        var estados = new List<ComboItem>
        {
            new ComboItem { Id = -1, Nombre = "Todos" },
            new ComboItem { Id = 1, Nombre = "Activos" },
            new ComboItem { Id = 0, Nombre = "Inactivos" }
        };

        cmbFiltroEstado.DataSource = estados;
        cmbFiltroEstado.DisplayMember = "Nombre";
        cmbFiltroEstado.ValueMember = "Id";
        cmbFiltroEstado.SelectedIndex = 0;
    }

    private async Task CargarAlmacenesAsync(string? buscar = null)
    {
        dgvAlmacenes.Rows.Clear();

        var result = await _almacenService.GetAlmacenesAsync();

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar almacenes",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var almacenes = result.Data.ToList();

        // Búsqueda
        if (!string.IsNullOrWhiteSpace(buscar))
        {
            almacenes = almacenes.Where(a =>
                a.Nombre.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
                (a.Codigo != null && a.Codigo.Contains(buscar, StringComparison.OrdinalIgnoreCase)) ||
                (a.Encargado != null && a.Encargado.Contains(buscar, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // Filtro por tipo
        var tipoItem = cmbFiltroTipo.SelectedItem as ComboItem;
        if (tipoItem != null && tipoItem.Id != -1)
        {
            string tipoFiltro = tipoItem.Id == 1 ? "ALMACEN" : "MERCADO";
            almacenes = almacenes.Where(a => a.Tipo == tipoFiltro).ToList();
        }

        // Filtro por estado
        var estadoItem = cmbFiltroEstado.SelectedItem as ComboItem;
        if (estadoItem != null)
        {
            if (estadoItem.Id == 1)
                almacenes = almacenes.Where(a => a.Activo).ToList();
            else if (estadoItem.Id == 0)
                almacenes = almacenes.Where(a => !a.Activo).ToList();
        }

        _almacenes = almacenes;

        foreach (var a in _almacenes)
        {
            int index = dgvAlmacenes.Rows.Add(
                a.Id,
                a.Codigo ?? "",
                a.Nombre,
                a.Tipo,
                a.Direccion ?? "",
                a.Encargado ?? "",
                a.Telefono ?? "",
                a.TotalProductos,
                a.Activo ? "Activo" : "Inactivo"
            );

            // Colorear según tipo
            if (a.Tipo == "MERCADO")
            {
                dgvAlmacenes.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(220, 240, 255);
            }
            else
            {
                dgvAlmacenes.Rows[index].Cells["colTipo"].Style.BackColor = System.Drawing.Color.FromArgb(230, 255, 230);
            }

            if (!a.Activo)
                dgvAlmacenes.Rows[index].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
        }

        lblTotal.Text = $"Total: {_almacenes.Count} ubicación(es)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarAlmacenesAsync(txtBuscar.Text.Trim());
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        if (cmbFiltroTipo.Items.Count > 0) cmbFiltroTipo.SelectedIndex = 0;
        if (cmbFiltroEstado.Items.Count > 0) cmbFiltroEstado.SelectedIndex = 0;
        await CargarAlmacenesAsync();
    }

    private async void cmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsHandleCreated && !DesignMode)
            await CargarAlmacenesAsync(txtBuscar.Text.Trim());
    }

    private async void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsHandleCreated && !DesignMode)
            await CargarAlmacenesAsync(txtBuscar.Text.Trim());
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmAlmacenEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarAlmacenesAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvAlmacenes.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un almacén para editar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvAlmacenes.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmAlmacenEdit>();
        frm.Modo = ModoEdicion.Editar;
        frm.AlmacenId = id;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarAlmacenesAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnVerInventario_Click(object sender, EventArgs e)
    {
        if (dgvAlmacenes.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un almacén para ver su inventario", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvAlmacenes.SelectedRows[0].Cells["colId"].Value);
        string nombre = dgvAlmacenes.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";

        using var frm = Program.ServiceProvider.GetRequiredService<FrmAlmacenInventario>();
        frm.AlmacenId = id;
        frm.AlmacenNombre = nombre;
        frm.ShowDialog();
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvAlmacenes.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un almacén para eliminar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!SessionManager.IsAdmin)
        {
            MessageBox.Show("Solo el administrador puede eliminar almacenes", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvAlmacenes.SelectedRows[0].Cells["colId"].Value);
        string nombre = dgvAlmacenes.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";

        var confirm = MessageBox.Show($"¿Eliminar '{nombre}'?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        var result = await _almacenService.DeleteAlmacenAsync(id);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.SuccessMessage ?? "Almacén eliminado", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarAlmacenesAsync(txtBuscar.Text.Trim());
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

    private void dgvAlmacenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnEditar_Click(sender, EventArgs.Empty);
    }
}