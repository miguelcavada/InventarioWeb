using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmConsignacionEdit : Form
{
    private readonly IConsignacionService _consignacionService;
    private readonly IAlmacenService _almacenService;
    private readonly IProductoService _productoService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;

    private List<AlmacenDto> _almacenes = new();
    private List<ProductoDto> _productos = new();
    private List<ConsignacionDetalleDto> _detalles = new();

    public FrmConsignacionEdit(
        IConsignacionService consignacionService,
        IAlmacenService almacenService,
        IProductoService productoService)
    {
        InitializeComponent();
        _consignacionService = consignacionService;
        _almacenService = almacenService;
        _productoService = productoService;
    }

    private async void FrmConsignacionEdit_Load(object sender, EventArgs e)
    {
        await CargarCombosAsync();

        dtpFecha.Value = DateTime.Now;
        GenerarNumeroConsignacion();
        ConfigurarGridDetalles();
    }

    private async Task CargarCombosAsync()
    {
        // Almacenes
        var almResult = await _almacenService.GetAlmacenesAsync();
        if (almResult.IsSuccess && almResult.Data != null)
        {
            _almacenes = almResult.Data.Where(a => a.Activo).ToList();

            cmbAlmacen.DataSource = _almacenes.Select(a => new ComboItem
            {
                Id = a.Id,
                Nombre = $"{a.Nombre} ({(a.Tipo == "MERCADO" ? "Mercado" : "Almacén")})"
            }).ToList();
            cmbAlmacen.DisplayMember = "Nombre";
            cmbAlmacen.ValueMember = "Id";
            cmbAlmacen.SelectedIndex = -1;
        }

        // Productos
        var prodResult = await _productoService.GetProductosAsync();
        if (prodResult.IsSuccess && prodResult.Data != null)
        {
            _productos = prodResult.Data.Where(p => p.Activo).ToList();

            cmbProducto.DataSource = _productos.Select(p => new ComboItem
            {
                Id = p.Id,
                Nombre = $"{p.Codigo} - {p.Nombre}"
            }).ToList();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            cmbProducto.SelectedIndex = -1;
        }
    }

    private void ConfigurarGridDetalles()
    {
        dgvDetalles.AutoGenerateColumns = false;
        dgvDetalles.Columns.Clear();

        dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colProductoId",
            HeaderText = "ProductoId",
            Visible = false
        });

        dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colProducto",
            HeaderText = "Producto",
            Width = 250
        });

        dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colCantidad",
            HeaderText = "Cantidad",
            Width = 100
        });

        dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colPrecio",
            HeaderText = "Precio Unitario",
            Width = 120
        });

        dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colSubtotal",
            HeaderText = "Subtotal",
            Width = 120
        });

        dgvDetalles.Columns.Add(new DataGridViewButtonColumn
        {
            Name = "colEliminar",
            HeaderText = "",
            Text = "✖",
            UseColumnTextForButtonValue = true,
            Width = 40
        });
    }

    private void GenerarNumeroConsignacion()
    {
        txtNumeroConsignacion.Text = $"CONS-{DateTime.Now:yyyyMMddHHmmss}";
    }

    private void btnAgregarProducto_Click(object sender, EventArgs e)
    {
        if (cmbProducto.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un producto", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (numCantidad.Value <= 0)
        {
            MessageBox.Show("Ingrese una cantidad válida", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var productoItem = cmbProducto.SelectedItem as ComboItem;
        int productoId = productoItem!.Id;
        var producto = _productos.FirstOrDefault(p => p.Id == productoId);

        if (producto == null) return;

        // Verificar si ya existe
        var existente = _detalles.FirstOrDefault(d => d.ProductoId == productoId);
        if (existente != null)
        {
            existente.CantidadEntregada += (int)numCantidad.Value;
        }
        else
        {
            _detalles.Add(new ConsignacionDetalleDto
            {
                ProductoId = productoId,
                ProductoCodigo = producto.Codigo,
                ProductoNombre = producto.Nombre,
                CantidadEntregada = (int)numCantidad.Value,
                CantidadVendida = 0,
                CantidadDevuelta = 0,
                PrecioUnitario = producto.PrecioVentaMinorista
            });
        }

        RefrescarGrid();

        cmbProducto.SelectedIndex = -1;
        numCantidad.Value = 1;
    }

    private void RefrescarGrid()
    {
        dgvDetalles.Rows.Clear();

        decimal total = 0;

        foreach (var d in _detalles)
        {
            var subtotal = d.CantidadEntregada * d.PrecioUnitario;
            total += subtotal;

            dgvDetalles.Rows.Add(
                d.ProductoId,
                $"{d.ProductoCodigo} - {d.ProductoNombre}",
                d.CantidadEntregada,
                d.PrecioUnitario.ToString("C2"),
                subtotal.ToString("C2")
            );
        }

        lblTotal.Text = $"Total: {total:C2}";
    }

    private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == dgvDetalles.Columns["colEliminar"].Index)
        {
            int productoId = Convert.ToInt32(dgvDetalles.Rows[e.RowIndex].Cells["colProductoId"].Value);
            var detalle = _detalles.FirstOrDefault(d => d.ProductoId == productoId);
            if (detalle != null)
            {
                _detalles.Remove(detalle);
                RefrescarGrid();
            }
        }
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var almacenItem = cmbAlmacen.SelectedItem as ComboItem;

        var dto = new ConsignacionDto
        {
            NumeroConsignacion = txtNumeroConsignacion.Text.Trim(),
            FechaEntrega = dtpFecha.Value,
            VendedorNombre = txtVendedorNombre.Text.Trim(),
            VendedorContacto = string.IsNullOrWhiteSpace(txtVendedorContacto.Text) ? null : txtVendedorContacto.Text.Trim(),
            VendedorTelefono = string.IsNullOrWhiteSpace(txtVendedorTelefono.Text) ? null : txtVendedorTelefono.Text.Trim(),
            Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text.Trim(),
            AlmacenOrigenId = almacenItem?.Id ?? 0,
            Estado = "PENDIENTE",
            Detalles = _detalles
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        var result = await _consignacionService.CreateConsignacionAsync(dto);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.SuccessMessage ?? "Consignación creada exitosamente",
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

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtNumeroConsignacion.Text))
        {
            MessageBox.Show("El número de consignación es obligatorio", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNumeroConsignacion.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtVendedorNombre.Text))
        {
            MessageBox.Show("El nombre del vendedor es obligatorio", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtVendedorNombre.Focus();
            return false;
        }

        if (cmbAlmacen.SelectedIndex < 0)
        {
            MessageBox.Show("Debe seleccionar un almacén de origen", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbAlmacen.Focus();
            return false;
        }

        if (_detalles.Count == 0)
        {
            MessageBox.Show("Debe agregar al menos un producto", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        if (_detalles.Count > 0)
        {
            var confirm = MessageBox.Show("¿Cancelar? Se perderán los cambios no guardados.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
        }

        DialogResult = DialogResult.Cancel;
        Close();
    }
}