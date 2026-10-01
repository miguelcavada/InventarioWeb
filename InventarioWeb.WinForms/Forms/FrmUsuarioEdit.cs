using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Helpers;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmUsuarioEdit : Form
{
    private readonly IAuthService _authService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;
    public string UsuarioId { get; set; } = string.Empty;

    private UsuarioDto? _usuario;

    public FrmUsuarioEdit(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void FrmUsuarioEdit_Load(object sender, EventArgs e)
    {
        CargarComboRoles();

        switch (Modo)
        {
            case ModoEdicion.Nuevo:
                Text = "Nuevo Usuario";
                lblTitulo.Text = "➕ Nuevo Usuario";
                panelPassword.Visible = true;
                break;

            case ModoEdicion.Editar:
                Text = "Editar Usuario";
                lblTitulo.Text = "✏️ Editar Usuario";
                panelPassword.Visible = false;
                await CargarUsuarioAsync();
                break;
        }
    }

    private void CargarComboRoles()
    {
        var roles = new List<ComboItem>
        {
            new ComboItem { Id = 1, Nombre = "Admin" },
            new ComboItem { Id = 2, Nombre = "Gerente" },
            new ComboItem { Id = 3, Nombre = "Operador" },
            new ComboItem { Id = 4, Nombre = "Consulta" }
        };

        cmbRol.DataSource = roles;
        cmbRol.DisplayMember = "Nombre";
        cmbRol.ValueMember = "Nombre";
        cmbRol.SelectedIndex = 3; // Consulta por defecto
    }

    private async Task CargarUsuarioAsync()
    {
        var usuario = await _authService.GetUsuarioByIdAsync(UsuarioId);

        if (usuario == null)
        {
            MessageBox.Show("Usuario no encontrado",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _usuario = usuario;

        txtNombre.Text = _usuario.NombreCompleto;
        txtEmail.Text = _usuario.Email;
        txtTelefono.Text = _usuario.PhoneNumber ?? "";
        cmbRol.SelectedValue = _usuario.Rol;
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var rolItem = cmbRol.SelectedItem as ComboItem;
        string rol = rolItem?.Nombre ?? "Consulta";

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        if (Modo == ModoEdicion.Nuevo)
        {
            var dto = new RegistroDto
            {
                NombreCompleto = txtNombre.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text,
                Rol = rol
            };

            var result = await _authService.RegistrarAsync(dto);

            if (result.Success)
            {
                MessageBox.Show(result.Mensaje ?? "Usuario creado exitosamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblMensaje.Text = result.Mensaje ?? "Error al guardar";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                btnGuardar.Enabled = true;
            }
        }
        else
        {
            var dto = new EditarUsuarioDto
            {
                Id = _usuario!.Id,
                NombreCompleto = txtNombre.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                Rol = rol
            };

            var success = await _authService.EditarUsuarioAsync(dto);

            if (success)
            {
                MessageBox.Show("Usuario actualizado exitosamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblMensaje.Text = "Error al guardar";
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

        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("El email es obligatorio", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            return false;
        }

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

        if (cmbRol.SelectedIndex < 0)
        {
            MessageBox.Show("Debe seleccionar un rol", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbRol.Focus();
            return false;
        }

        if (Modo == ModoEdicion.Nuevo)
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

            // Validar requisitos de contraseña
            bool hasUpper = txtPassword.Text.Any(char.IsUpper);
            bool hasLower = txtPassword.Text.Any(char.IsLower);
            bool hasDigit = txtPassword.Text.Any(char.IsDigit);

            if (!hasUpper || !hasLower || !hasDigit)
            {
                MessageBox.Show("La contraseña debe contener al menos una mayúscula, " +
                    "una minúscula y un número", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
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

    private void chkMostrarPassword_CheckedChanged(object sender, EventArgs e)
    {
        char c = chkMostrarPassword.Checked ? '\0' : '●';
        txtPassword.PasswordChar = c;
        txtConfirmPassword.PasswordChar = c;
    }
}