using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Forms;
using InventarioWeb.WinForms.Helpers;
using InventarioWeb.WinForms.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms
{
    public partial class FrmLogin : Form
    {
        private readonly IWinFormsAuthService _authService;

        public FrmLogin(IWinFormsAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Credenciales de desarrollo (solo en modo Debug)
#if DEBUG
            txtEmail.Text = "admin@inventario.com";
            txtPassword.Text = "Admin123!";
            lblMensaje.Text = "Modo desarrollo: credenciales precargadas";
            lblMensaje.ForeColor = System.Drawing.Color.Gray;

#endif
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese email y contraseña", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            lblMensaje.Text = "Iniciando sesión...";
            lblMensaje.ForeColor = System.Drawing.Color.Blue;

            var loginDto = new InventarioWeb.Core.DTOs.LoginDto
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var result = await _authService.LoginAsync(loginDto);

            if (result.Success)
            {
                SessionManager.Usuario = result.Usuario;
                var main = Program.ServiceProvider.GetRequiredService<FrmMain>();
                main.Show();
                Hide();
            }
            else
            {
                lblMensaje.Text = result.Mensaje ?? "Credenciales incorrectas";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                btnLogin.Enabled = true;
            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SessionManager.Usuario == null)
                System.Windows.Forms.Application.Exit();
        }
    }
}
