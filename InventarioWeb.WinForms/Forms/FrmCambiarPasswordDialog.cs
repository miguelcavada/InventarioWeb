using System;
using System.Windows.Forms;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmCambiarPasswordDialog : Form
{
    private readonly IAuthService _authService;

    public string UsuarioId { get; set; } = string.Empty;
    public string UsuarioNombre { get; set; } = string.Empty;

    public FrmCambiarPasswordDialog(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private void FrmCambiarPasswordDialog_Load(object sender, EventArgs e)
    {
        lblUsuario.Text = $"Usuario: {UsuarioNombre}";
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var dto = new InventarioWeb.Core.DTOs.CambiarPasswordDto
        {
            Id = UsuarioId,
            NewPassword = txtPassword.Text,
            ConfirmPassword = txtConfirmPassword.Text
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Cambiando contraseña...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        var success = await _authService.CambiarPasswordAsync(dto);

        if (success)
        {
            MessageBox.Show("Contraseña cambiada exitosamente",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            lblMensaje.Text = "Error al cambiar la contraseña";
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            btnGuardar.Enabled = true;
        }
    }

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("La contraseña es obligatoria", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return false;
        }

        if (txtPassword.Text.Length < 6)
        {
            MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return false;
        }

        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            MessageBox.Show("Las contraseñas no coinciden", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Focus();
            return false;
        }

        bool hasUpper = false, hasLower = false, hasDigit = false;
        foreach (char c in txtPassword.Text)
        {
            if (char.IsUpper(c)) hasUpper = true;
            if (char.IsLower(c)) hasLower = true;
            if (char.IsDigit(c)) hasDigit = true;
        }

        if (!hasUpper || !hasLower || !hasDigit)
        {
            MessageBox.Show("La contraseña debe contener al menos una mayúscula, " +
                "una minúscula y un número", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return false;
        }

        return true;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void chkMostrarPassword_CheckedChanged(object sender, EventArgs e)
    {
        char c = chkMostrarPassword.Checked ? '\0' : '●';
        txtPassword.PasswordChar = c;
        txtConfirmPassword.PasswordChar = c;
    }
}