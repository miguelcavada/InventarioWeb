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

public partial class FrmProductos : Form
{
    private readonly IProductoService _productoService;
    private readonly ICategoriaService _categoriaService;
    private readonly IUnidadMedidaService _unidadMedidaService;

    private List<ProductoDto> _productos = new();
    private List<CategoriaDto> _categorias = new();
    private List<UnidadMedidaDto> _unidades = new();

    public FrmProductos(
        IProductoService productoService,
        ICategoriaService categoriaService,
        IUnidadMedidaService unidadMedidaService)
    {
        InitializeComponent();
        _productoService = productoService;
        _categoriaService = categoriaService;
        _unidadMedidaService = unidadMedidaService;
    }

    private async void FrmProductos_Load(object sender, EventArgs e)
    {
        await CargarCombosFiltrosAsync();
        await CargarProductosAsync();
    }

    private async Task CargarCombosFiltrosAsync()
    {
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

        // Combo de Categoría
        var catResult = await _categoriaService.GetCategoriasAsync();
        if (catResult.IsSuccess && catResult.Data != null)
        {
            var categoriasFiltro = new List<ComboItem>
            {
                new ComboItem { Id = -1, Nombre = "Todas las categorías" }
            };

            foreach (var c in catResult.Data.Where(c => c.Activo))
            {
                categoriasFiltro.Add(new ComboItem { Id = c.Id, Nombre = c.Nombre });
            }

            cmbFiltroCategoria.DataSource = categoriasFiltro;
            cmbFiltroCategoria.DisplayMember = "Nombre";
            cmbFiltroCategoria.ValueMember = "Id";
            cmbFiltroCategoria.SelectedIndex = 0;
        }
    }

    private async Task CargarProductosAsync(string? buscar = null)
    {
        dgvProductos.Rows.Clear();

        var result = await _productoService.GetProductosAsync(buscar);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al cargar productos",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var productos = result.Data.ToList();

        // Filtro por categoría
        var catItem = cmbFiltroCategoria.SelectedItem as ComboItem;
        if (catItem != null && catItem.Id != -1)
        {
            productos = productos.Where(p => p.CategoriaId == catItem.Id).ToList();
        }

        // Filtro por estado
        var estadoItem = cmbFiltroEstado.SelectedItem as ComboItem;
        if (estadoItem != null)
        {
            if (estadoItem.Id == 1)
                productos = productos.Where(p => p.Activo).ToList();
            else if (estadoItem.Id == 0)
                productos = productos.Where(p => !p.Activo).ToList();
        }

        _productos = productos;

        foreach (var p in _productos)
        {
            int index = dgvProductos.Rows.Add(
                p.Id,
                p.Codigo,
                p.Nombre,
                p.CategoriaNombre ?? "",
                p.UnidadMedidaAbreviatura ?? "",
                p.PrecioCosto?.ToString("C2") ?? "-",
                p.PrecioVentaMinorista.ToString("C2"),
                p.PrecioVentaMayorista?.ToString("C2") ?? "-",
                p.StockTotal,
                p.Activo ? "Activo" : "Inactivo"
            );

            if (p.StockTotal <= p.StockMinimoTotal && p.StockTotal > 0)
                dgvProductos.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 235, 235);
            else if (p.StockTotal <= 0)
                dgvProductos.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
        }

        lblTotal.Text = $"Total: {_productos.Count} producto(s)";
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarProductosAsync(txtBuscar.Text.Trim());
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        if (cmbFiltroCategoria.Items.Count > 0) cmbFiltroCategoria.SelectedIndex = 0;
        if (cmbFiltroEstado.Items.Count > 0) cmbFiltroEstado.SelectedIndex = 0;
        await CargarProductosAsync();
    }

    private async void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsHandleCreated && !DesignMode)
            await CargarProductosAsync(txtBuscar.Text.Trim());
    }

    private async void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsHandleCreated && !DesignMode)
            await CargarProductosAsync(txtBuscar.Text.Trim());
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmProductoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarProductosAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto para editar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmProductoEdit>();
        frm.Modo = ModoEdicion.Editar;
        frm.ProductoId = id;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarProductosAsync(txtBuscar.Text.Trim());
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto para eliminar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!SessionManager.IsAdmin && !SessionManager.IsGerente)
        {
            MessageBox.Show("No tiene permisos para eliminar productos", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colId"].Value);
        string nombre = dgvProductos.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";

        var confirm = MessageBox.Show($"¿Eliminar el producto '{nombre}'?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        var result = await _productoService.DeleteProductoAsync(id);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.SuccessMessage ?? "Producto eliminado", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarProductosAsync(txtBuscar.Text.Trim());
        }
        else
        {
            MessageBox.Show(result.ErrorMessage ?? "Error al eliminar", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCambioPrecio_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto para cambiar el precio", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!Helpers.SessionManager.IsAdmin && !Helpers.SessionManager.IsGerente)
        {
            MessageBox.Show("No tiene permisos para cambiar precios", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmCambioPrecio>();
        frm.ProductoId = id;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            _ = CargarProductosAsync(txtBuscar.Text.Trim());
        }
    }

    private void btnHistorial_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto para ver su historial", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colId"].Value);

        using var frm = Program.ServiceProvider.GetRequiredService<FrmHistorialPrecios>();
        frm.ProductoId = id;
        frm.ShowDialog();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnEditar_Click(sender, EventArgs.Empty);
    }
}