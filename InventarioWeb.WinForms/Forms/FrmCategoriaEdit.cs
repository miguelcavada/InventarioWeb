using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmCategoriaEdit : Form
{
    private readonly ICategoriaService _categoriaService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;
    public int CategoriaId { get; set; }

    private CategoriaDto _categoria = new();

    public FrmCategoriaEdit(ICategoriaService categoriaService)
    {
        InitializeComponent();
        _categoriaService = categoriaService;
    }

    private async void FrmCategoriaEdit_Load(object sender, EventArgs e)
    {
        switch (Modo)
        {
            case ModoEdicion.Nuevo:
                Text = "Nueva Categoría";
                lblTitulo.Text = "➕ Nueva Categoría";
                break;

            case ModoEdicion.Editar:
                Text = "Editar Categoría";
                lblTitulo.Text = "✏️ Editar Categoría";
                await CargarCategoriaAsync();
                break;
        }
    }

    private async Task CargarCategoriaAsync()
    {
        var result = await _categoriaService.GetCategoriaByIdAsync(CategoriaId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Categoría no encontrada",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _categoria = result.Data;

        txtNombre.Text = _categoria.Nombre;
        txtDescripcion.Text = _categoria.Descripcion ?? "";
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var dto = new CategoriaDto
        {
            Id = _categoria.Id,
            Nombre = txtNombre.Text.Trim(),
            Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
            Activo = true
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        if (Modo == ModoEdicion.Nuevo)
        {
            var result = await _categoriaService.CreateCategoriaAsync(dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Categoría creada exitosamente",
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
        else
        {
            var result = await _categoriaService.UpdateCategoriaAsync(_categoria.Id, dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Categoría actualizada exitosamente",
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
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("El nombre es obligatorio", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNombre.Focus();
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