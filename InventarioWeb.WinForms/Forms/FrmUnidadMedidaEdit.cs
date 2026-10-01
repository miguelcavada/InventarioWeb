using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmUnidadMedidaEdit : Form
{
    private readonly IUnidadMedidaService _unidadService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;
    public int UnidadId { get; set; }

    private UnidadMedidaDto _unidad = new();

    public FrmUnidadMedidaEdit(IUnidadMedidaService unidadService)
    {
        InitializeComponent();
        _unidadService = unidadService;
    }

    private async void FrmUnidadMedidaEdit_Load(object sender, EventArgs e)
    {
        switch (Modo)
        {
            case ModoEdicion.Nuevo:
                Text = "Nueva Unidad de Medida";
                lblTitulo.Text = "➕ Nueva Unidad de Medida";
                break;

            case ModoEdicion.Editar:
                Text = "Editar Unidad de Medida";
                lblTitulo.Text = "✏️ Editar Unidad de Medida";
                await CargarUnidadAsync();
                break;
        }
    }

    private async Task CargarUnidadAsync()
    {
        var result = await _unidadService.GetUnidadByIdAsync(UnidadId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Unidad no encontrada",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _unidad = result.Data;

        txtNombre.Text = _unidad.Nombre;
        txtAbreviatura.Text = _unidad.Abreviatura;
        txtDescripcion.Text = _unidad.Descripcion ?? "";
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var dto = new UnidadMedidaDto
        {
            Id = _unidad.Id,
            Nombre = txtNombre.Text.Trim(),
            Abreviatura = txtAbreviatura.Text.Trim(),
            Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
            Activo = true
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        if (Modo == ModoEdicion.Nuevo)
        {
            var result = await _unidadService.CreateUnidadAsync(dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Unidad creada exitosamente",
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
            var result = await _unidadService.UpdateUnidadAsync(_unidad.Id, dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Unidad actualizada exitosamente",
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

        if (string.IsNullOrWhiteSpace(txtAbreviatura.Text))
        {
            MessageBox.Show("La abreviatura es obligatoria", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAbreviatura.Focus();
            return false;
        }

        if (txtAbreviatura.Text.Trim().Length > 10)
        {
            MessageBox.Show("La abreviatura no puede tener más de 10 caracteres", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAbreviatura.Focus();
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