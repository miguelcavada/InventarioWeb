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

public partial class FrmMovimientoEdit : Form
{
    private readonly IMovimientoService _movimientoService;
    private readonly IAlmacenService _almacenService;
    private readonly IProductoService _productoService;

    public ModoEdicion Modo { get; set; } = ModoEdicion.Nuevo;
    public string TipoInicial { get; set; } = "ENTRADA";

    private List<AlmacenDto> _almacenes = new();
    private List<ProductoStockDto> _productosDelAlmacen = new();
    private List<MovimientoDetalleDto> _detalles = new();
    private int? _almacenOrigenSeleccionado = null;

    public FrmMovimientoEdit(
        IMovimientoService movimientoService,
        IAlmacenService almacenService,
        IProductoService productoService)
    {
        InitializeComponent();
        _movimientoService = movimientoService;
        _almacenService = almacenService;
        _productoService = productoService;
    }

    // ============================================================
    // LOAD
    // ============================================================
    private async void FrmMovimientoEdit_Load(object sender, EventArgs e)
    {
        await CargarCombosBaseAsync();

        // Configurar tipo inicial
        cmbTipo.SelectedValue = TipoInicial;

        // Fecha actual
        dtpFecha.Value = DateTime.Now;
        dtpFecha.Format = DateTimePickerFormat.Custom;
        dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";

        // Generar número de documento
        GenerarNumeroDocumento();

        // Configurar grid
        ConfigurarGridDetalles();

        // Actualizar visibilidad
        ActualizarVisibilidadPorTipo();
    }

    // ============================================================
    // CARGA DE COMBOS BASE
    // ============================================================
    //private async Task CargarCombosBaseAsync()
    //{
    //    // Tipo de movimiento
    //    var tipos = new List<ComboItem>
    //    {
    //        new ComboItem { Id = 1, Nombre = "ENTRADA" },
    //        new ComboItem { Id = 2, Nombre = "SALIDA" },
    //        new ComboItem { Id = 3, Nombre = "TRASLADO" }
    //    };
    //    cmbTipo.DataSource = tipos;
    //    cmbTipo.DisplayMember = "Nombre";
    //    cmbTipo.ValueMember = "Nombre";
    //    cmbTipo.SelectedIndex = 0;

    //    // Motivo de Salida
    //    var motivos = new List<ComboItem>
    //    {
    //        new ComboItem { Id = 1, Nombre = "VENTA" },
    //        new ComboItem { Id = 2, Nombre = "MERMA" },
    //        new ComboItem { Id = 3, Nombre = "DEVOLUCION" },
    //        new ComboItem { Id = 4, Nombre = "AJUSTE" },
    //        new ComboItem { Id = 5, Nombre = "OTRO" }
    //    };
    //    cmbMotivoSalida.DataSource = motivos;
    //    cmbMotivoSalida.DisplayMember = "Nombre";
    //    cmbMotivoSalida.ValueMember = "Nombre";
    //    cmbMotivoSalida.SelectedIndex = 0;

    //    // Tipo de Precio
    //    var tiposPrecio = new List<ComboItem>
    //    {
    //        new ComboItem { Id = 1, Nombre = "MINORISTA" },
    //        new ComboItem { Id = 2, Nombre = "MAYORISTA" }
    //    };
    //    cmbTipoPrecio.DataSource = tiposPrecio;
    //    cmbTipoPrecio.DisplayMember = "Nombre";
    //    cmbTipoPrecio.ValueMember = "Nombre";
    //    cmbTipoPrecio.SelectedIndex = 0;

    //    // Almacenes
    //    var almResult = await _almacenService.GetAlmacenesAsync();
    //    if (almResult.IsSuccess && almResult.Data != null)
    //    {
    //        _almacenes = almResult.Data.Where(a => a.Activo).ToList();

    //        var almacenesCombo = _almacenes.Select(a => new ComboItem
    //        {
    //            Id = a.Id,
    //            Nombre = $"{a.Nombre} ({(a.Tipo == "MERCADO" ? "Mercado" : "Almacén")})"
    //        }).ToList();

    //        cmbAlmacenOrigen.DataSource = almacenesCombo.ToList();
    //        cmbAlmacenOrigen.DisplayMember = "Nombre";
    //        cmbAlmacenOrigen.ValueMember = "Id";
    //        cmbAlmacenOrigen.SelectedIndex = -1;

    //        cmbAlmacenDestino.DataSource = almacenesCombo.ToList();
    //        cmbAlmacenDestino.DisplayMember = "Nombre";
    //        cmbAlmacenDestino.ValueMember = "Id";
    //        cmbAlmacenDestino.SelectedIndex = -1;
    //    }
    //}

    private bool _cargandoCombos = false;

    private async Task CargarCombosBaseAsync()
    {
        _cargandoCombos = true;

        try
        {
            // Tipo de movimiento
            var tipos = new List<ComboItem>
        {
            new ComboItem { Id = 1, Nombre = "ENTRADA" },
            new ComboItem { Id = 2, Nombre = "SALIDA" },
            new ComboItem { Id = 3, Nombre = "TRASLADO" }
        };
            cmbTipo.DataSource = tipos;
            cmbTipo.DisplayMember = "Nombre";
            cmbTipo.ValueMember = "Nombre";
            cmbTipo.SelectedIndex = 0;

            // Motivo de Salida
            var motivos = new List<ComboItem>
        {
            new ComboItem { Id = 1, Nombre = "VENTA" },
            new ComboItem { Id = 2, Nombre = "MERMA" },
            new ComboItem { Id = 3, Nombre = "DEVOLUCION" },
            new ComboItem { Id = 4, Nombre = "AJUSTE" },
            new ComboItem { Id = 5, Nombre = "OTRO" }
        };
            cmbMotivoSalida.DataSource = motivos;
            cmbMotivoSalida.DisplayMember = "Nombre";
            cmbMotivoSalida.ValueMember = "Nombre";
            cmbMotivoSalida.SelectedIndex = 0;

            // Tipo de Precio
            var tiposPrecio = new List<ComboItem>
        {
            new ComboItem { Id = 1, Nombre = "MINORISTA" },
            new ComboItem { Id = 2, Nombre = "MAYORISTA" }
        };
            cmbTipoPrecio.DataSource = tiposPrecio;
            cmbTipoPrecio.DisplayMember = "Nombre";
            cmbTipoPrecio.ValueMember = "Nombre";
            cmbTipoPrecio.SelectedIndex = 0;

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

                cmbAlmacenOrigen.DataSource = almacenesCombo.ToList();
                cmbAlmacenOrigen.DisplayMember = "Nombre";
                cmbAlmacenOrigen.ValueMember = "Id";
                cmbAlmacenOrigen.SelectedIndex = -1;

                cmbAlmacenDestino.DataSource = almacenesCombo.ToList();
                cmbAlmacenDestino.DisplayMember = "Nombre";
                cmbAlmacenDestino.ValueMember = "Id";
                cmbAlmacenDestino.SelectedIndex = -1;
            }

            // Limpiar combo productos
            LimpiarComboProductos();
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

    // ============================================================
    // EVENTOS DE COMBOS
    // ============================================================
    private async void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsHandleCreated || DesignMode) return;

        ActualizarVisibilidadPorTipo();
        GenerarNumeroDocumento();

        // Al cambiar el tipo, actualizar precios de los detalles existentes
        await ActualizarPreciosDetallesAsync();
    }

    private void cmbMotivoSalida_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsHandleCreated || DesignMode) return;
        ActualizarVisibilidadPorTipo();
    }

    private async void cmbTipoPrecio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsHandleCreated || DesignMode) return;
        await ActualizarPreciosDetallesAsync();
    }

    // *** CRÍTICO: Al seleccionar almacén origen, cargar SOLO productos con stock ***
    //private async void cmbAlmacenOrigen_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (!IsHandleCreated || DesignMode) return;

    //    var almacenItem = cmbAlmacenOrigen.SelectedItem as ComboItem;
    //    if (almacenItem == null || almacenItem.Id <= 0)
    //    {
    //        LimpiarComboProductos();
    //        return;
    //    }

    //    // Si ya había detalles y se cambia el almacén, preguntar si continuar
    //    if (_detalles.Count > 0 && _almacenOrigenSeleccionado.HasValue
    //        && _almacenOrigenSeleccionado.Value != almacenItem.Id)
    //    {
    //        var result = MessageBox.Show(
    //            "Ha cambiado el almacén. Los productos ya agregados podrían no tener stock en el nuevo almacén.\n\n" +
    //            "¿Desea limpiar los detalles agregados?",
    //            "Cambio de almacén",
    //            MessageBoxButtons.YesNo,
    //            MessageBoxIcon.Warning);

    //        if (result == DialogResult.Yes)
    //        {
    //            _detalles.Clear();
    //            RefrescarGrid();
    //        }
    //    }

    //    _almacenOrigenSeleccionado = almacenItem.Id;
    //    await CargarProductosDelAlmacenAsync(almacenItem.Id);
    //}



    // ============================================================
    // CARGA DE PRODUCTOS DEL ALMACÉN
    // ============================================================

    private async void cmbAlmacenOrigen_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Prevenir que se dispare durante la carga inicial
        if (!IsHandleCreated || DesignMode || _cargandoCombos) return;

        var almacenItem = cmbAlmacenOrigen.SelectedItem as ComboItem;

        if (almacenItem == null || almacenItem.Id <= 0)
        {
            LimpiarComboProductos();
            return;
        }

        // Si ya había detalles y se cambia el almacén, preguntar
        if (_detalles.Count > 0 && _almacenOrigenSeleccionado.HasValue
            && _almacenOrigenSeleccionado.Value != almacenItem.Id)
        {
            var result = MessageBox.Show(
                "Ha cambiado el almacén. Los productos ya agregados podrían no tener stock en el nuevo almacén.\n\n" +
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

        _almacenOrigenSeleccionado = almacenItem.Id;
        await CargarProductosDelAlmacenAsync(almacenItem.Id);
    }

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
            var result = await _movimientoService.GetProductosPorAlmacenAsync(almacenId);

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

            // Crear lista de items
            var productosCombo = _productosDelAlmacen.Select(p => new ComboItem
            {
                Id = p.ProductoId,
                Nombre = $"{p.Codigo} - {p.Nombre} [Stock: {p.StockActual} {p.UnidadAbreviatura}]"
            }).ToList();

            // Asignar con BindingSource (más confiable)
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
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstadoProductos.Text = "❌ Error al cargar productos";
            lblEstadoProductos.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void LimpiarComboProductos()
    {
        cmbProducto.DataSource = null;
        cmbProducto.Items.Clear();
        _productosDelAlmacen.Clear();
        lblEstadoProductos.Text = "Seleccione primero un almacén";
        lblEstadoProductos.ForeColor = System.Drawing.Color.Gray;
    }

    // ============================================================
    // AGREGAR PRODUCTO AL DETALLE
    // ============================================================
    private async void btnAgregarProducto_Click(object sender, EventArgs e)
    {
        // Validaciones iniciales
        if (cmbAlmacenOrigen.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione primero un almacén de origen", "Aviso",
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
            MessageBox.Show("Producto no encontrado en el almacén", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validar stock para SALIDA y TRASLADO
        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        var cantidadExistente = _detalles.Where(d => d.ProductoId == productoId).Sum(d => d.Cantidad);
        var cantidadTotal = cantidadExistente + numCantidad.Value;

        if ((tipo == "SALIDA" || tipo == "TRASLADO") && cantidadTotal > producto.StockActual)
        {
            MessageBox.Show(
                $"Stock insuficiente para '{producto.Nombre}'.\n\n" +
                $"Stock disponible: {producto.StockActual} {producto.UnidadAbreviatura}\n" +
                $"Cantidad solicitada: {cantidadTotal} {producto.UnidadAbreviatura}",
                "Stock insuficiente",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Obtener precio automáticamente
        var precio = await ObtenerPrecioProductoAsync(producto);

        if (!precio.HasValue || precio.Value <= 0)
        {
            MessageBox.Show($"El producto '{producto.Nombre}' no tiene precio definido para este tipo de movimiento.",
                "Sin precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Agregar o actualizar detalle
        var existente = _detalles.FirstOrDefault(d => d.ProductoId == productoId);
        if (existente != null)
        {
            existente.Cantidad += numCantidad.Value;
            existente.PrecioUnitario = precio.Value;
        }
        else
        {
            _detalles.Add(new MovimientoDetalleDto
            {
                ProductoId = productoId,
                ProductoCodigo = producto.Codigo,
                ProductoNombre = producto.Nombre,
                Cantidad = numCantidad.Value,
                PrecioUnitario = precio.Value
            });
        }

        RefrescarGrid();

        // Limpiar selección
        cmbProducto.SelectedIndex = -1;
        numCantidad.Value = 1;
    }

    // ============================================================
    // OBTENER PRECIO SEGÚN TIPO Y MOTIVO
    // ============================================================
    private async Task<decimal?> ObtenerPrecioProductoAsync(ProductoStockDto producto)
    {
        await Task.CompletedTask;

        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        switch (tipo)
        {
            case "ENTRADA":
                return producto.PrecioCosto ?? 0;

            case "SALIDA":
                var motivoItem = cmbMotivoSalida.SelectedItem as ComboItem;
                string motivo = motivoItem?.Nombre ?? "VENTA";

                switch (motivo)
                {
                    case "VENTA":
                        var tipoPrecioItem = cmbTipoPrecio.SelectedItem as ComboItem;
                        bool esMayorista = tipoPrecioItem?.Nombre == "MAYORISTA";
                        if (esMayorista && producto.PrecioVentaMayorista.HasValue && producto.PrecioVentaMayorista > 0)
                            return producto.PrecioVentaMayorista.Value;
                        return producto.PrecioVentaMinorista;

                    case "MERMA":
                    case "DEVOLUCION":
                    case "AJUSTE":
                        // Usar precio de costo para valorizar
                        return producto.PrecioCosto ?? producto.PrecioVentaMinorista;

                    default:
                        return producto.PrecioVentaMinorista;
                }

            case "TRASLADO":
                return producto.PrecioCosto ?? producto.PrecioVentaMinorista;

            default:
                return 0;
        }
    }

    private async Task ActualizarPreciosDetallesAsync()
    {
        foreach (var detalle in _detalles)
        {
            var producto = _productosDelAlmacen.FirstOrDefault(p => p.ProductoId == detalle.ProductoId);
            if (producto != null)
            {
                var precio = await ObtenerPrecioProductoAsync(producto);
                if (precio.HasValue)
                    detalle.PrecioUnitario = precio.Value;
            }
        }
        RefrescarGrid();
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
            var subtotal = d.Cantidad * d.PrecioUnitario;
            total += subtotal;

            dgvDetalles.Rows.Add(
                d.ProductoId,
                $"{d.ProductoCodigo} - {d.ProductoNombre}",
                d.Cantidad.ToString("N2"),
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
    // VISIBILIDAD Y UTILIDADES
    // ============================================================
    private void ActualizarVisibilidadPorTipo()
    {
        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        // Destino solo visible en traslados
        lblAlmacenDestino.Visible = tipo == "TRASLADO";
        cmbAlmacenDestino.Visible = tipo == "TRASLADO";

        // Etiqueta de origen
        lblAlmacenOrigen.Text = tipo == "ENTRADA" ? "Almacén Destino:" : "Almacén Origen:";

        // Motivo y tipo de precio solo en salidas
        lblMotivoSalida.Visible = tipo == "SALIDA";
        cmbMotivoSalida.Visible = tipo == "SALIDA";
        lblTipoPrecio.Visible = tipo == "SALIDA";
        cmbTipoPrecio.Visible = tipo == "SALIDA";

        // Color del motivo
        if (tipo == "SALIDA")
        {
            var motivoItem = cmbMotivoSalida.SelectedItem as ComboItem;
            string motivo = motivoItem?.Nombre ?? "VENTA";

            switch (motivo)
            {
                case "VENTA":
                    cmbMotivoSalida.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                    break;
                case "MERMA":
                    cmbMotivoSalida.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                    break;
                case "DEVOLUCION":
                    cmbMotivoSalida.BackColor = System.Drawing.Color.FromArgb(255, 245, 220);
                    break;
                case "AJUSTE":
                    cmbMotivoSalida.BackColor = System.Drawing.Color.FromArgb(220, 240, 255);
                    break;
                default:
                    cmbMotivoSalida.BackColor = System.Drawing.Color.White;
                    break;
            }
        }
    }

    private void GenerarNumeroDocumento()
    {
        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        string prefijo = tipo switch
        {
            "ENTRADA" => "ENT",
            "SALIDA" => "SAL",
            "TRASLADO" => "TRA",
            _ => "DOC"
        };

        txtNumeroDocumento.Text = $"{prefijo}-{DateTime.Now:yyyyMMddHHmmss}";
    }

    // ============================================================
    // GUARDAR
    // ============================================================
    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        var origenItem = cmbAlmacenOrigen.SelectedItem as ComboItem;
        var destinoItem = cmbAlmacenDestino.SelectedItem as ComboItem;
        var motivoItem = cmbMotivoSalida.SelectedItem as ComboItem;

        var dto = new MovimientoDto
        {
            Tipo = tipo,
            NumeroDocumento = txtNumeroDocumento.Text.Trim(),
            FechaMovimiento = dtpFecha.Value,
            Observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim(),
            MotivoSalida = tipo == "SALIDA" ? motivoItem?.Nombre : null,
            AlmacenOrigenId = origenItem?.Id ?? 0,
            AlmacenDestinoId = tipo == "TRASLADO" ? destinoItem?.Id : null,
            Detalles = _detalles
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        var result = await _movimientoService.CreateMovimientoAsync(dto);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.SuccessMessage ?? "Movimiento registrado exitosamente",
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
        if (string.IsNullOrWhiteSpace(txtNumeroDocumento.Text))
        {
            MessageBox.Show("El número de documento es obligatorio", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNumeroDocumento.Focus();
            return false;
        }

        if (cmbAlmacenOrigen.SelectedIndex < 0)
        {
            MessageBox.Show("Debe seleccionar un almacén", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbAlmacenOrigen.Focus();
            return false;
        }

        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        if (tipo == "TRASLADO")
        {
            if (cmbAlmacenDestino.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un almacén destino", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAlmacenDestino.Focus();
                return false;
            }

            var origenItem = cmbAlmacenOrigen.SelectedItem as ComboItem;
            var destinoItem = cmbAlmacenDestino.SelectedItem as ComboItem;

            if (origenItem?.Id == destinoItem?.Id)
            {
                MessageBox.Show("El almacén origen y destino no pueden ser el mismo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAlmacenDestino.Focus();
                return false;
            }
        }

        if (_detalles.Count == 0)
        {
            MessageBox.Show("Debe agregar al menos un producto al movimiento", "Validación",
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