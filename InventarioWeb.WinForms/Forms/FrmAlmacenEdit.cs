using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Helpers;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmAlmacenEdit : Form
{
    private readonly IAlmacenService _almacenService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;
    public int AlmacenId { get; set; }

    private AlmacenDto _almacen = new();

    public FrmAlmacenEdit(IAlmacenService almacenService)
    {
        InitializeComponent();
        _almacenService = almacenService;
    }

    private async void FrmAlmacenEdit_Load(object sender, EventArgs e)
    {
        CargarComboTipo();

        switch (Modo)
        {
            case ModoEdicion.Nuevo:
                Text = "Nuevo Almacén o Mercado";
                lblTitulo.Text = "➕ Nueva Ubicación";
                break;

            case ModoEdicion.Editar:
                Text = "Editar Almacén o Mercado";
                lblTitulo.Text = "✏️ Editar Ubicación";
                await CargarAlmacenAsync();
                break;
        }
    }

    private void CargarComboTipo()
    {
        var tipos = new List<ComboItem>
        {
            new ComboItem { Id = 1, Nombre = "Almacén" },
            new ComboItem { Id = 2, Nombre = "Mercado" }
        };

        cmbTipo.DataSource = tipos;
        cmbTipo.DisplayMember = "Nombre";
        cmbTipo.ValueMember = "Id";
        cmbTipo.SelectedIndex = 0;
    }

    private async Task CargarAlmacenAsync()
    {
        var result = await _almacenService.GetAlmacenByIdAsync(AlmacenId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Almacén no encontrado",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _almacen = result.Data;

        txtNombre.Text = _almacen.Nombre;
        txtCodigo.Text = _almacen.Codigo ?? "";
        txtDireccion.Text = _almacen.Direccion ?? "";
        txtDescripcion.Text = _almacen.Descripcion ?? "";
        txtEncargado.Text = _almacen.Encargado ?? "";
        txtTelefono.Text = _almacen.Telefono ?? "";

        // Seleccionar el tipo correcto
        var tipoItem = _almacen.Tipo == "MERCADO" ? 2 : 1;
        cmbTipo.SelectedValue = tipoItem;
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Id == 2 ? "MERCADO" : "ALMACEN";

        var dto = new AlmacenDto
        {
            Id = _almacen.Id,
            Nombre = txtNombre.Text.Trim(),
            Codigo = string.IsNullOrWhiteSpace(txtCodigo.Text) ? null : txtCodigo.Text.Trim(),
            Tipo = tipo,
            Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
            Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
            Encargado = string.IsNullOrWhiteSpace(txtEncargado.Text) ? null : txtEncargado.Text.Trim(),
            Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
            Activo = true
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        if (Modo == ModoEdicion.Nuevo)
        {
            var result = await _almacenService.CreateAlmacenAsync(dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Ubicación creada exitosamente",
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
            var result = await _almacenService.UpdateAlmacenAsync(_almacen.Id, dto);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.SuccessMessage ?? "Ubicación actualizada exitosamente",
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

        if (cmbTipo.SelectedIndex < 0)
        {
            MessageBox.Show("Debe seleccionar un tipo", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbTipo.Focus();
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