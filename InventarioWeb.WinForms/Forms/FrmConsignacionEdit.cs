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

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;

    private List<AlmacenDto> _almacenes = new();
    private List<ProductoStockDto> _productosDelAlmacen = new();
    private List<ConsignacionDetalleDto> _detalles = new();

    private bool _cargandoCombos = false;
    private int? _almacenSeleccionado = null;

    public FrmConsignacionEdit(
        IConsignacionService consignacionService,
        IAlmacenService almacenService)
    {
        InitializeComponent();
        _consignacionService = consignacionService;
        _almacenService = almacenService;
    }

    // ============================================================
    // LOAD
    // ============================================================
    private async void FrmConsignacionEdit_Load(object sender, EventArgs e)
    {
        await CargarCombosBaseAsync();

        dtpFecha.Value = DateTime.Now;
        GenerarNumeroConsignacion();
        ConfigurarGridDetalles();

        // Estado inicial
        LimpiarComboProductos();
    }

    // ============================================================
    // CARGA DE COMBOS BASE
    // ============================================================
    private async Task CargarCombosBaseAsync()
    {
        _cargandoCombos = true;

        try
        {
            // Almacenes
            var almResult = await _almacenService.GetAlmacenesAsync();
            if (almResult.IsSuccess && almResult.Data != null)
            {
                _almacenes = almResult.Data.Where(a => a.Activo).ToList();

                var almacenesCombo = _almacenes.Select(a => new ComboItem
                {
                    Id = a.Id,
                    Nombre = $"{a.Nombre} ({(a.Tipo == "MERCADO" ? "Mercado" : "Almacén")})"
                }).ToList();

                cmbAlmacen.DataSource = almacenesCombo;
                cmbAlmacen.DisplayMember = "Nombre";
                cmbAlmacen.ValueMember = "Id";
                cmbAlmacen.SelectedIndex = -1;
            }
        }
        finally
        {
            _cargandoCombos = false;
        }
    }

    // ============================================================
    // GRID DE DETALLES
    // ============================================================
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
            Width = 280
        });

        dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colCantidad",
            HeaderText = "Cantidad",
            Width = 90
        });

        dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colPrecio",
            HeaderText = "Precio Unit.",
            Width = 110
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

    // ============================================================
    // EVENTO: CAMBIO DE ALMACÉN
    // ============================================================
    private async void cmbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Prevenir durante carga inicial
        if (!IsHandleCreated || DesignMode || _cargandoCombos) return;

        var almacenItem = cmbAlmacen.SelectedItem as ComboItem;

        if (almacenItem == null || almacenItem.Id <= 0)
        {
            LimpiarComboProductos();
            return;
        }

        // Si ya hay detalles y cambia el almacén, preguntar
        if (_detalles.Count > 0 && _almacenSeleccionado.HasValue
            && _almacenSeleccionado.Value != almacenItem.Id)
        {
            var result = MessageBox.Show(
                "Ha cambiado el almacén.\n\n" +
                "Los productos ya agregados podrían no tener stock en el nuevo almacén.\n\n" +
                "¿Desea limpiar los detalles agregados?",
                "Cambio de almacén",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _detalles.Clear();
                RefrescarGrid();
            }
        }

        _almacenSeleccionado = almacenItem.Id;
        await CargarProductosDelAlmacenAsync(almacenItem.Id);
    }

    // ============================================================
    // CARGA DE PRODUCTOS DEL ALMACÉN
    // ============================================================
    private async Task CargarProductosDelAlmacenAsync(int almacenId)
    {
        try
        {
            lblEstadoProductos.Text = "⏳ Cargando productos...";
            lblEstadoProductos.ForeColor = System.Drawing.Color.Blue;

            // Limpiar combo
            cmbProducto.DataSource = null;
            cmbProducto.Items.Clear();
            _productosDelAlmacen.Clear();
            cmbProducto.Enabled = false;

            // Consultar servicio
            var result = await _consignacionService.GetProductosPorAlmacenAsync(almacenId);

            if (!result.IsSuccess || result.Data == null)
            {
                lblEstadoProductos.Text = $"⚠️ {result.ErrorMessage}";
                lblEstadoProductos.ForeColor = System.Drawing.Color.OrangeRed;
                return;
            }

            _productosDelAlmacen = result.Data.ToList();

            if (!_productosDelAlmacen.Any())
            {
                lblEstadoProductos.Text = "⚠️ Este almacén no tiene productos con stock";
                lblEstadoProductos.ForeColor = System.Drawing.Color.OrangeRed;
                return;
            }

            // Crear items del combo con stock visible
            var productosCombo = _productosDelAlmacen.Select(p => new ComboItem
            {
                Id = p.ProductoId,
                Nombre = $"{p.Codigo} - {p.Nombre} [Stock: {p.StockActual} {p.UnidadAbreviatura}]"
            }).ToList();

            // BindingSource para asegurar el refresco
            var bindingSource = new BindingSource();
            bindingSource.DataSource = productosCombo;

            cmbProducto.DataSource = bindingSource;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            cmbProducto.SelectedIndex = -1;
            cmbProducto.Enabled = true;
            cmbProducto.Refresh();

            lblEstadoProductos.Text = $"✅ {_productosDelAlmacen.Count} producto(s) con stock disponible";
            lblEstadoProductos.ForeColor = System.Drawing.Color.Green;

            // Habilitar controles
            numCantidad.Enabled = true;
            btnAgregarProducto.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar productos: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstadoProductos.Text = "❌ Error al cargar productos";
            lblEstadoProductos.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void LimpiarComboProductos()
    {
        cmbProducto.DataSource = null;
        cmbProducto.Items.Clear();
        cmbProducto.Items.Add("-- Seleccione primero un almacén --");
        cmbProducto.Enabled = false;
        _productosDelAlmacen.Clear();

        numCantidad.Enabled = false;
        numCantidad.Value = 1;
        txtStockInfo.Text = "";
        btnAgregarProducto.Enabled = false;

        lblEstadoProductos.Text = "Seleccione primero un almacén";
        lblEstadoProductos.ForeColor = System.Drawing.Color.Gray;
    }

    // ============================================================
    // EVENTO: CAMBIO DE PRODUCTO (Mostrar stock)
    // ============================================================
    private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        var productoItem = cmbProducto.SelectedItem as ComboItem;

        if (productoItem == null || productoItem.Id <= 0)
        {
            txtStockInfo.Text = "";
            return;
        }

        var producto = _productosDelAlmacen.FirstOrDefault(p => p.ProductoId == productoItem.Id);
        if (producto != null)
        {
            txtStockInfo.Text = $"{producto.StockActual} {producto.UnidadAbreviatura}";
        }
    }

    // ============================================================
    // AGREGAR PRODUCTO
    // ============================================================
    private void btnAgregarProducto_Click(object sender, EventArgs e)
    {
        if (cmbAlmacen.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione primero un almacén", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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
        var producto = _productosDelAlmacen.FirstOrDefault(p => p.ProductoId == productoId);

        if (producto == null)
        {
            MessageBox.Show("Producto no encontrado", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validar stock disponible
        var cantidadExistente = _detalles
            .Where(d => d.ProductoId == productoId)
            .Sum(d => d.CantidadEntregada);

        var cantidadTotal = cantidadExistente + (int)numCantidad.Value;

        if (cantidadTotal > producto.StockActual)
        {
            MessageBox.Show(
                $"Stock insuficiente para '{producto.Nombre}'.\n\n" +
                $"Stock disponible: {producto.StockActual} {producto.UnidadAbreviatura}\n" +
                $"Cantidad solicitada: {cantidadTotal}",
                "Stock insuficiente",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Agregar o actualizar detalle
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

        // Limpiar campos
        cmbProducto.SelectedIndex = -1;
        numCantidad.Value = 1;
        txtStockInfo.Text = "";
    }

    // ============================================================
    // GRID
    // ============================================================
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

    // ============================================================
    // UTILIDADES
    // ============================================================
    private void GenerarNumeroConsignacion()
    {
        txtNumeroConsignacion.Text = $"CONS-{DateTime.Now:yyyyMMddHHmmss}";
    }

    // ============================================================
    // GUARDAR
    // ============================================================
    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var almacenItem = cmbAlmacen.SelectedItem as ComboItem;

        var dto = new ConsignacionDto
        {
            NumeroConsignacion = txtNumeroConsignacion.Text.Trim(),
            FechaEntrega = dtpFecha.Value,
            VendedorNombre = txtVendedorNombre.Text.Trim(),
            VendedorContacto = string.IsNullOrWhiteSpace(txtVendedorContacto.Text)
                ? null : txtVendedorContacto.Text.Trim(),
            VendedorTelefono = string.IsNullOrWhiteSpace(txtVendedorTelefono.Text)
                ? null : txtVendedorTelefono.Text.Trim(),
            Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text)
                ? null : txtObservaciones.Text.Trim(),
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
            var confirm = MessageBox.Show(
                "¿Cancelar? Se perderán los cambios no guardados.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
        }

        DialogResult = DialogResult.Cancel;
        Close();
    }
}