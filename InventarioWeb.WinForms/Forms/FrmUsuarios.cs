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

public partial class FrmUsuarios : Form
{
    private readonly IAuthService _authService;
    private List<UsuarioDto> _usuarios = new();

    public FrmUsuarios(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void FrmUsuarios_Load(object sender, EventArgs e)
    {
        if (!SessionManager.IsAdmin)
        {
            MessageBox.Show("Solo el administrador puede acceder a esta sección", "Acceso denegado",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
            return;
        }

        await CargarUsuariosAsync();
    }

    private async Task CargarUsuariosAsync()
    {
        dgvUsuarios.Rows.Clear();

        var usuarios = await _authService.GetUsuariosAsync();

        if (usuarios == null)
        {
            MessageBox.Show("Error al cargar usuarios",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _usuarios = usuarios.ToList();

        foreach (var u in _usuarios)
        {
            int index = dgvUsuarios.Rows.Add(
                u.Id,
                u.NombreCompleto,
                u.Email,
                u.Rol,
                u.PhoneNumber ?? "",
                u.Activo ? "Activo" : "Inactivo",
                u.UltimoAcceso?.ToString("dd/MM/yyyy HH:mm") ?? "Nunca",
                u.FechaRegistro.ToString("dd/MM/yyyy")
            );

            if (!u.Activo)
                dgvUsuarios.Rows[index].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;

            // Colorear según rol
            switch (u.Rol)
            {
                case "Admin":
                    dgvUsuarios.Rows[index].Cells["colRol"].Style.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                    dgvUsuarios.Rows[index].Cells["colRol"].Style.ForeColor = System.Drawing.Color.DarkRed;
                    break;
                case "Gerente":
                    dgvUsuarios.Rows[index].Cells["colRol"].Style.BackColor = System.Drawing.Color.FromArgb(255, 240, 200);
                    break;
                case "Operador":
                    dgvUsuarios.Rows[index].Cells["colRol"].Style.BackColor = System.Drawing.Color.FromArgb(220, 235, 255);
                    break;
                case "Consulta":
                    dgvUsuarios.Rows[index].Cells["colRol"].Style.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                    break;
            }
        }

        // KPIs
        lblTotalUsuariosValor.Text = _usuarios.Count.ToString();
        lblActivosValor.Text = _usuarios.Count(u => u.Activo).ToString();
        lblInactivosValor.Text = _usuarios.Count(u => !u.Activo).ToString();
        lblAdminsValor.Text = _usuarios.Count(u => u.Rol == "Admin").ToString();

        lblTotal.Text = $"Mostrando {_usuarios.Count} usuario(s)";
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = Program.ServiceProvider.GetRequiredService<FrmUsuarioEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarUsuariosAsync();
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un usuario para editar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string id = dgvUsuarios.SelectedRows[0].Cells["colId"].Value?.ToString() ?? "";

        using var frm = Program.ServiceProvider.GetRequiredService<FrmUsuarioEdit>();
        frm.Modo = ModoEdicion.Editar;
        frm.UsuarioId = id;
        if (frm.ShowDialog() == DialogResult.OK)
        {
            await CargarUsuariosAsync();
        }
    }

    private async void btnCambiarPassword_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un usuario para cambiar la contraseña", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string id = dgvUsuarios.SelectedRows[0].Cells["colId"].Value?.ToString() ?? "";
        string nombre = dgvUsuarios.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";

        using var frm = new FrmCambiarPasswordDialog(_authService);
        frm.UsuarioId = id;
        frm.UsuarioNombre = nombre;
        frm.ShowDialog();
    }

    private async void btnActivarDesactivar_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un usuario", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string id = dgvUsuarios.SelectedRows[0].Cells["colId"].Value?.ToString() ?? "";
        string nombre = dgvUsuarios.SelectedRows[0].Cells["colNombre"].Value?.ToString() ?? "";
        string estado = dgvUsuarios.SelectedRows[0].Cells["colEstado"].Value?.ToString() ?? "";

        bool activar = estado == "Inactivo";
        string accion = activar ? "activar" : "desactivar";

        var confirm = MessageBox.Show($"¿Desea {accion} al usuario '{nombre}'?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        var success = await _authService.CambiarEstadoUsuarioAsync(id, activar);

        if (success)
        {
            MessageBox.Show($"Usuario {accion}do exitosamente", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarUsuariosAsync();
        }
        else
        {
            MessageBox.Show($"Error al {accion} usuario", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnEditar_Click(sender, EventArgs.Empty);
    }
}