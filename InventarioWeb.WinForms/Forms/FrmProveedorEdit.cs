using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using SixLabors.Fonts;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmProveedorEdit : Form
{
    private readonly IProveedorService _proveedorService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;
    public int ProveedorId { get; set; }

    private ProveedorDto _proveedor = new();

    public FrmProveedorEdit(IProveedorService proveedorService)
    {
        InitializeComponent();
        _proveedorService = proveedorService;
    }

    private async void FrmProveedorEdit_Load(object sender, EventArgs e)
    {
        switch (Modo)
        {
            case ModoEdicion.Nuevo:
                Text = "Nuevo Proveedor";
                lblTitulo.Text = "➕ Nuevo Proveedor";
                break;

            case ModoEdicion.Editar:
                Text = "Editar Proveedor";
                lblTitulo.Text = "✏️ Editar Proveedor";
                await CargarProveedorAsync();
                break;
        }
    }

    private async Task CargarProveedorAsync()
    {
        var result = await _proveedorService.GetProveedorByIdAsync(ProveedorId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Proveedor no encontrado",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _proveedor = result.Data;

        txtNombre.Text = _proveedor.Nombre;
        txtRUC.Text = _proveedor.RUC ?? "";
        txtDireccion.Text = _proveedor.Direccion ?? "";
        txtTelefono.Text = _proveedor.Telefono ?? "";
        txtEmail.Text = _proveedor.Email ?? "";
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var dto = new ProveedorDto
        {
            Id = _proveedor.Id,
            Nombre = txtNombre.Text.Trim(),
            RUC = string.IsNullOrWhiteSpace(txtRUC.Text) ? null : txtRUC.Text.Trim(),
            Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
            Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
            Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
            Activo = true
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        if (Modo == ModoEdicion.Nuevo)
        {
            var result = await _proveedorService.CreateProveedorAsync(dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Proveedor creado exitosamente",
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
            var result = await _proveedorService.UpdateProveedorAsync(_proveedor.Id, dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Proveedor actualizado exitosamente",
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

        if (!string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
                if (addr.Address != txtEmail.Text)
                    throw new FormatException();
            }
            catch
            {
                MessageBox.Show("El formato del email no es válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
        }

        return true;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}