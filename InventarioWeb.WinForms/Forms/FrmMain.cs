using System;
using System.Windows.Forms;
using InventarioWeb.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
        lblUsuario.Text = $"Usuario: {SessionManager.Usuario?.NombreCompleto} ({SessionManager.Usuario?.Rol})";

        if (!SessionManager.IsAdmin)
            btnUsuarios.Visible = false;

        if (!SessionManager.IsOperador)
        {
            btnMovimientos.Visible = false;
            btnConsignaciones.Visible = false;
        }

        // Agregar efectos hover a los botones del menú
        foreach (Control ctrl in panelMenu.Controls)
        {
            if (ctrl is Button btn)
            {
                btn.MouseEnter += (s, ev) => btn.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
                btn.MouseLeave += (s, ev) => btn.BackColor = System.Drawing.Color.Transparent;
            }
        }
    }

    private void btnProductos_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmProductos>();
        frm.ShowDialog();
    }

    private void btnAlmacenes_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmAlmacenes>();
        frm.ShowDialog();
    }

    private void btnMovimientos_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientos>();
        frm.ShowDialog();
    }

    private void btnConsignaciones_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmConsignaciones>();
        frm.ShowDialog();
    }

    private void btnCategorias_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmCategorias>();
        frm.ShowDialog();
    }

    private void btnUnidades_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmUnidadesMedida>();
        frm.ShowDialog();
    }

    private void btnProveedores_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmProveedores>();
        frm.ShowDialog();
    }

    private void btnUsuarios_Click(object sender, EventArgs e)
    {
        if (!SessionManager.IsAdmin)
        {
            MessageBox.Show("Solo el administrador puede gestionar usuarios", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var frm = Program.ServiceProvider.GetRequiredService<FrmUsuarios>();
        frm.ShowDialog();
    }

    private void btnReportes_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmReportes>();
        frm.ShowDialog();
    }

    private void btnGraficos_Click(object sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmGraficos>();
        frm.ShowDialog();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
            System.Windows.Forms.Application.Exit();
    }
}