using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmProductoEdit : Form
{
    private readonly IProductoService _productoService;
    private readonly ICategoriaService _categoriaService;
    private readonly IUnidadMedidaService _unidadMedidaService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;
    public int ProductoId { get; set; }

    private ProductoDto _producto = new();
    private List<CategoriaDto> _categorias = new();
    private List<UnidadMedidaDto> _unidades = new();

    public FrmProductoEdit(
        IProductoService productoService,
        ICategoriaService categoriaService,
        IUnidadMedidaService unidadMedidaService)
    {
        InitializeComponent();
        _productoService = productoService;
        _categoriaService = categoriaService;
        _unidadMedidaService = unidadMedidaService;
    }

    private async void FrmProductoEdit_Load(object sender, EventArgs e)
    {
        await CargarCombosAsync();

        // Configurar según modo
        switch (Modo)
        {
            case ModoEdicion.Nuevo:
                Text = "Nuevo Producto";
                lblTitulo.Text = "➕ Nuevo Producto";
                break;

            case ModoEdicion.Editar:
                Text = "Editar Producto";
                lblTitulo.Text = "✏️ Editar Producto";
                await CargarProductoAsync();
                break;

            case ModoEdicion.Ver:
                Text = "Ver Producto";
                lblTitulo.Text = "👁️ Ver Producto";
                await CargarProductoAsync();
                DeshabilitarControles();
                break;
        }
    }

    private async Task CargarCombosAsync()
    {
        // Categorías
        var catResult = await _categoriaService.GetCategoriasAsync();
        if (catResult.IsSuccess && catResult.Data != null)
        {
            _categorias = catResult.Data.Where(c => c.Activo).ToList();
            cmbCategoria.DataSource = _categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.SelectedIndex = -1;
        }

        // Unidades de medida
        var uniResult = await _unidadMedidaService.GetUnidadesAsync();
        if (uniResult.IsSuccess && uniResult.Data != null)
        {
            _unidades = uniResult.Data.Where(u => u.Activo).ToList();
            cmbUnidadMedida.DataSource = _unidades;
            cmbUnidadMedida.DisplayMember = "Nombre";
            cmbUnidadMedida.ValueMember = "Id";
            cmbUnidadMedida.SelectedIndex = -1;
        }
    }

    private async Task CargarProductoAsync()
    {
        var result = await _productoService.GetProductoByIdAsync(ProductoId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Producto no encontrado",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _producto = result.Data;

        txtCodigo.Text = _producto.Codigo;
        txtNombre.Text = _producto.Nombre;
        txtDescripcion.Text = _producto.Descripcion ?? "";
        cmbCategoria.SelectedValue = _producto.CategoriaId;
        cmbUnidadMedida.SelectedValue = _producto.UnidadMedidaId;
        numPrecioCosto.Value = _producto.PrecioCosto ?? 0;
        numPrecioMinorista.Value = _producto.PrecioVentaMinorista;
        numPrecioMayorista.Value = _producto.PrecioVentaMayorista ?? 0;
    }

    private void DeshabilitarControles()
    {
        txtCodigo.ReadOnly = true;
        txtNombre.ReadOnly = true;
        txtDescripcion.ReadOnly = true;
        cmbCategoria.Enabled = false;
        cmbUnidadMedida.Enabled = false;
        numPrecioCosto.Enabled = false;
        numPrecioMinorista.Enabled = false;
        numPrecioMayorista.Enabled = false;
        btnGuardar.Visible = false;
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var dto = new ProductoDto
        {
            Id = _producto.Id,
            Codigo = txtCodigo.Text.Trim(),
            Nombre = txtNombre.Text.Trim(),
            Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
            CategoriaId = (int)(cmbCategoria.SelectedValue ?? 0),
            UnidadMedidaId = (int)(cmbUnidadMedida.SelectedValue ?? 0),
            PrecioCosto = numPrecioCosto.Value > 0 ? numPrecioCosto.Value : null,
            PrecioVentaMinorista = numPrecioMinorista.Value,
            PrecioVentaMayorista = numPrecioMayorista.Value > 0 ? numPrecioMayorista.Value : null,
            Activo = true
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        if (Modo == ModoEdicion.Nuevo)
        {
            var result = await _productoService.CreateProductoAsync(dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Producto creado exitosamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblMensaje.Text = result.ErrorMessage ?? "Error al guardar";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                btnGuardar.Enabled = true;
            }
        }
        else if (Modo == ModoEdicion.Editar)
        {
            var result = await _productoService.UpdateProductoAsync(_producto.Id, dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Producto actualizado exitosamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblMensaje.Text = result.ErrorMessage ?? "Error al guardar";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                btnGuardar.Enabled = true;
            }
        }
    }

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtCodigo.Text))
        {
            MessageBox.Show("El código es obligatorio", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCodigo.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("El nombre es obligatorio", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNombre.Focus();
            return false;
        }

        if (cmbCategoria.SelectedIndex < 0)
        {
            MessageBox.Show("Debe seleccionar una categoría", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbCategoria.Focus();
            return false;
        }

        if (cmbUnidadMedida.SelectedIndex < 0)
        {
            MessageBox.Show("Debe seleccionar una unidad de medida", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbUnidadMedida.Focus();
            return false;
        }

        if (numPrecioMinorista.Value <= 0)
        {
            MessageBox.Show("El precio minorista debe ser mayor a 0", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numPrecioMinorista.Focus();
            return false;
        }

        return true;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}