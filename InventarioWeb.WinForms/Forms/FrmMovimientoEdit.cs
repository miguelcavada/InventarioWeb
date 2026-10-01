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
    private List<ProductoDto> _productos = new();
    private List<MovimientoDetalleDto> _detalles = new();

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

    private async void FrmMovimientoEdit_Load(object sender, EventArgs e)
    {
        await CargarCombosAsync();

        // Configurar tipo inicial
        cmbTipo.SelectedValue = TipoInicial;

        // Fecha actual
        dtpFecha.Value = DateTime.Now;
        dtpFecha.Format = DateTimePickerFormat.Custom;
        dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";

        // Generar número de documento automático
        GenerarNumeroDocumento();

        // Configurar grid de detalles
        ConfigurarGridDetalles();

        // Actualizar visibilidad según tipo
        ActualizarVisibilidadPorTipo();

        // Combo TipoPrecio (solo para salidas)
        var tiposPrecio = new List<ComboItem>
{
    new ComboItem { Id = 1, Nombre = "MINORISTA" },
    new ComboItem { Id = 2, Nombre = "MAYORISTA" }
};

        cmbTipoPrecio.DataSource = tiposPrecio;
        cmbTipoPrecio.DisplayMember = "Nombre";
        cmbTipoPrecio.ValueMember = "Nombre";
        cmbTipoPrecio.SelectedIndex = 0;
    }

    private async Task CargarCombosAsync()
    {
        // Combo de Tipo de movimiento
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

        // Combo de Almacenes
        var almResult = await _almacenService.GetAlmacenesAsync();
        if (almResult.IsSuccess && almResult.Data != null)
        {
            _almacenes = almResult.Data.Where(a => a.Activo).ToList();

            cmbAlmacenOrigen.DataSource = _almacenes.Select(a => new ComboItem
            {
                Id = a.Id,
                Nombre = $"{a.Nombre} ({(a.Tipo == "MERCADO" ? "Mercado" : "Almacén")})"
            }).ToList();
            cmbAlmacenOrigen.DisplayMember = "Nombre";
            cmbAlmacenOrigen.ValueMember = "Id";
            cmbAlmacenOrigen.SelectedIndex = -1;

            cmbAlmacenDestino.DataSource = _almacenes.Select(a => new ComboItem
            {
                Id = a.Id,
                Nombre = $"{a.Nombre} ({(a.Tipo == "MERCADO" ? "Mercado" : "Almacén")})"
            }).ToList();
            cmbAlmacenDestino.DisplayMember = "Nombre";
            cmbAlmacenDestino.ValueMember = "Id";
            cmbAlmacenDestino.SelectedIndex = -1;
        }

        // Combo de Productos
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

    private void ActualizarVisibilidadPorTipo()
    {
        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        // Destino solo visible en traslados
        lblAlmacenDestino.Visible = tipo == "TRASLADO";
        cmbAlmacenDestino.Visible = tipo == "TRASLADO";

        // Cambiar etiqueta de origen
        lblAlmacenOrigen.Text = tipo == "ENTRADA" ? "Almacén Destino:" :
                                tipo == "TRASLADO" ? "Almacén Origen:" : "Almacén Origen:";

        // En salidas, permitir seleccionar tipo de precio
        lblTipoPrecio.Visible = tipo == "SALIDA";
        cmbTipoPrecio.Visible = tipo == "SALIDA";
    }

    private async void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsHandleCreated || DesignMode) return;

        ActualizarVisibilidadPorTipo();
        GenerarNumeroDocumento();

        // Si es salida, actualizar precios de los detalles existentes
        if ((cmbTipo.SelectedItem as ComboItem)?.Nombre == "SALIDA")
        {
            await ActualizarPreciosDetallesAsync();
        }
    }

    private async Task ActualizarPreciosDetallesAsync()
    {
        foreach (var detalle in _detalles)
        {
            var precioResult = await ObtenerPrecioProductoAsync(detalle.ProductoId);
            if (precioResult.HasValue)
                detalle.PrecioUnitario = precioResult.Value;
        }
        RefrescarGrid();
    }

    private async void btnAgregarProducto_Click(object sender, EventArgs e)
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
            existente.Cantidad += numCantidad.Value;
        }
        else
        {
            // Obtener precio según tipo
            decimal precio = 0;
            var tipoItem = cmbTipo.SelectedItem as ComboItem;
            string tipo = tipoItem?.Nombre ?? "ENTRADA";

            if (tipo == "ENTRADA")
            {
                precio = producto.PrecioCosto ?? 0;
            }
            else if (tipo == "SALIDA")
            {
                var tipoPrecioItem = cmbTipoPrecio.SelectedItem as ComboItem;
                bool esMayorista = tipoPrecioItem?.Nombre == "MAYORISTA";

                if (esMayorista && producto.PrecioVentaMayorista.HasValue)
                    precio = producto.PrecioVentaMayorista.Value;
                else
                    precio = producto.PrecioVentaMinorista;
            }
            else if (tipo == "TRASLADO")
            {
                precio = producto.PrecioCosto ?? producto.PrecioVentaMinorista;
            }

            _detalles.Add(new MovimientoDetalleDto
            {
                ProductoId = productoId,
                ProductoCodigo = producto.Codigo,
                ProductoNombre = producto.Nombre,
                Cantidad = numCantidad.Value,
                PrecioUnitario = precio
            });
        }

        RefrescarGrid();

        // Limpiar selección
        cmbProducto.SelectedIndex = -1;
        numCantidad.Value = 1;
    }

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

    private async Task<decimal?> ObtenerPrecioProductoAsync(int productoId)
    {
        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        var producto = _productos.FirstOrDefault(p => p.Id == productoId);
        if (producto == null) return null;

        switch (tipo)
        {
            case "ENTRADA":
                return producto.PrecioCosto ?? 0;

            case "SALIDA":
                var tipoPrecioItem = cmbTipoPrecio.SelectedItem as ComboItem;
                bool esMayorista = tipoPrecioItem?.Nombre == "MAYORISTA";

                if (esMayorista && producto.PrecioVentaMayorista.HasValue)
                    return producto.PrecioVentaMayorista.Value;
                return producto.PrecioVentaMinorista;

            case "TRASLADO":
                return producto.PrecioCosto ?? producto.PrecioVentaMinorista;

            default:
                return 0;
        }
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var tipoItem = cmbTipo.SelectedItem as ComboItem;
        string tipo = tipoItem?.Nombre ?? "ENTRADA";

        var origenItem = cmbAlmacenOrigen.SelectedItem as ComboItem;
        var destinoItem = cmbAlmacenDestino.SelectedItem as ComboItem;

        var dto = new MovimientoDto
        {
            Tipo = tipo,
            NumeroDocumento = txtNumeroDocumento.Text.Trim(),
            FechaMovimiento = dtpFecha.Value,
            Observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text.Trim(),
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