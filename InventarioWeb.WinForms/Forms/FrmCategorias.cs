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

public partial class FrmCategorias : Form
{
    private readonly ICategoriaService _categoriaService;
    private List<CategoriaDto> _categorias = new();

    public FrmCategorias(ICategoriaService categoriaService)
    {
        InitializeComponent();
        _categoriaService = categoriaService;
    }

    private async void FrmCategorias_Load(object sender, EventArgs e)
    {
        await CargarCategoriasAsync();
    }

    private async Task CargarCategoriasAsync(string? buscar = null)
    {
        dgvCategorias.Rows.Clear();

        var result = await _categoriaService.GetCategoriasAsync();

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar categorías",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var categorias = result.Data.ToList();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            categorias = categorias.Where(c =>
                c.Nombre.Contains(buscar, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        _categorias = categorias;

        foreach (var c in _categorias)
        {
            int index = dgvCategorias.Rows.Add(
                c.Id,
                c.Nombre,
                c.Descripcion ?? "",
                c.TotalProductos,
                c.Activo ? "Activo" : "Inactivo"
            );

            if (!c.Activo)
                dgvCategorias.Rows[index].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
        }

        lblTotal.Text = $"Total: {_categorias.Count} categoría(s)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarCategoriasAsync(txtBuscar.Text.Trim());
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        await CargarCategoriasAsync();
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmCategoriaEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarCategoriasAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvCategorias.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una categoría para editar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmCategoriaEdit>();
        frm.Modo = ModoEdicion.Editar;
        frm.CategoriaId = id;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarCategoriasAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvCategorias.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una categoría para eliminar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!SessionManager.IsAdmin)
        {
            MessageBox.Show("Solo el administrador puede eliminar categorías", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["colId"].Value);
        string nombre = dgvCategorias.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";

        var confirm = MessageBox.Show($"¿Eliminar la categoría '{nombre}'?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        var result = await _categoriaService.DeleteCategoriaAsync(id);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.SuccessMessage ?? "Categoría eliminada", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarCategoriasAsync(txtBuscar.Text.Trim());
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

    private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnEditar_Click(sender, EventArgs.Empty);
    }
}