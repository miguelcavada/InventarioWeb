using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmCambioPrecio : Form
{
    private readonly IProductoService _productoService;

    public int ProductoId { get; set; }

    private ProductoDto? _producto;

    public FrmCambioPrecio(IProductoService productoService)
    {
        InitializeComponent();
        _productoService = productoService;
    }

    private async void FrmCambioPrecio_Load(object sender, EventArgs e)
    {
        await CargarProductoAsync();
    }

    private async Task CargarProductoAsync()
    {
        var result = await _productoService.GetProductoByIdAsync(ProductoId);

        if (!result.IsSuccess || result.Data == null)
        {
            MessageBox.Show(result.ErrorMessage ?? "Producto no encontrado",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        _producto = result.Data;

        // Mostrar info del producto
        lblProducto.Text = $"📦 {_producto.Nombre}";
        lblCodigo.Text = $"Código: {_producto.Codigo}";
        lblCategoria.Text = $"Categoría: {_producto.CategoriaNombre}";
        lblUnidad.Text = $"Unidad: {_producto.UnidadMedidaAbreviatura}";

        // Mostrar precios actuales
        lblCostoActual.Text = _producto.PrecioCosto?.ToString("C2") ?? "No especificado";
        lblMinoristaActual.Text = _producto.PrecioVentaMinorista.ToString("C2");
        lblMayoristaActual.Text = _producto.PrecioVentaMayorista?.ToString("C2") ?? "No aplica";

        // Mostrar margen actual
        if (_producto.MargenGananciaMinorista.HasValue)
        {
            var m = _producto.MargenGananciaMinorista.Value;
            lblMargenMinorista.Text = $"{m:F1}%";
            lblMargenMinorista.ForeColor = m >= 30 ? System.Drawing.Color.Green :
                                            m >= 15 ? System.Drawing.Color.Orange :
                                                      System.Drawing.Color.Red;
        }
        else
        {
            lblMargenMinorista.Text = "Sin costo";
            lblMargenMinorista.ForeColor = System.Drawing.Color.Gray;
        }

        if (_producto.MargenGananciaMayorista.HasValue)
        {
            var m = _producto.MargenGananciaMayorista.Value;
            lblMargenMayorista.Text = $"{m:F1}%";
            lblMargenMayorista.ForeColor = m >= 30 ? System.Drawing.Color.Green :
                                            m >= 15 ? System.Drawing.Color.Orange :
                                                      System.Drawing.Color.Red;
        }
        else
        {
            lblMargenMayorista.Text = "No aplica";
            lblMargenMayorista.ForeColor = System.Drawing.Color.Gray;
        }

        // Precargar valores en los campos de edición
        numPrecioCosto.Value = _producto.PrecioCosto ?? 0;
        numPrecioMinorista.Value = _producto.PrecioVentaMinorista;
        numPrecioMayorista.Value = _producto.PrecioVentaMayorista ?? 0;
    }

    private void numPrecio_ValueChanged(object sender, EventArgs e)
    {
        CalcularNuevosMargenes();
    }

    private void CalcularNuevosMargenes()
    {
        decimal costo = numPrecioCosto.Value;
        decimal minorista = numPrecioMinorista.Value;
        decimal mayorista = numPrecioMayorista.Value;

        // Margen minorista
        if (costo > 0 && minorista > 0)
        {
            var margen = (minorista - costo) / costo * 100;
            lblNuevoMargenMinorista.Text = $"{margen:F1}%";
            lblNuevoMargenMinorista.ForeColor = margen >= 30 ? System.Drawing.Color.Green :
                                                 margen >= 15 ? System.Drawing.Color.Orange :
                                                                System.Drawing.Color.Red;
        }
        else
        {
            lblNuevoMargenMinorista.Text = "-";
            lblNuevoMargenMinorista.ForeColor = System.Drawing.Color.Gray;
        }

        // Margen mayorista
        if (costo > 0 && mayorista > 0)
        {
            var margen = (mayorista - costo) / costo * 100;
            lblNuevoMargenMayorista.Text = $"{margen:F1}%";
            lblNuevoMargenMayorista.ForeColor = margen >= 30 ? System.Drawing.Color.Green :
                                                 margen >= 15 ? System.Drawing.Color.Orange :
                                                                System.Drawing.Color.Red;
        }
        else
        {
            lblNuevoMargenMayorista.Text = "-";
            lblNuevoMargenMayorista.ForeColor = System.Drawing.Color.Gray;
        }

        // Detectar cambios
        bool hayCambios = (_producto?.PrecioCosto ?? 0) != costo ||
                         (_producto?.PrecioVentaMinorista ?? 0) != minorista ||
                         (_producto?.PrecioVentaMayorista ?? 0) != mayorista;

        lblCambios.Text = hayCambios ? "⚠️ Hay cambios sin guardar" : "";
        lblCambios.ForeColor = hayCambios ? System.Drawing.Color.Orange : System.Drawing.Color.Gray;
        btnGuardar.Enabled = hayCambios;
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var dto = new CambioPrecioDto
        {
            ProductoId = ProductoId,
            PrecioCostoNuevo = numPrecioCosto.Value > 0 ? numPrecioCosto.Value : null,
            PrecioVentaMinoristaNuevo = numPrecioMinorista.Value,
            PrecioVentaMayoristaNuevo = numPrecioMayorista.Value > 0 ? numPrecioMayorista.Value : null,
            Motivo = txtMotivo.Text.Trim()
        };

        btnGuardar.Enabled = false;
        lblMensaje.Text = "Guardando cambios...";
        lblMensaje.ForeColor = System.Drawing.Color.Blue;

        var usuario = Helpers.SessionManager.Usuario?.NombreCompleto ?? "Sistema";
        var result = await _productoService.CambiarPrecioAsync(dto, usuario);

        if (result.IsSuccess)
        {
            MessageBox.Show(result.SuccessMessage ?? "Precios actualizados exitosamente",
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
        if (numPrecioMinorista.Value <= 0)
        {
            MessageBox.Show("El precio minorista debe ser mayor a 0", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numPrecioMinorista.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtMotivo.Text))
        {
            var confirm = MessageBox.Show(
                "No ha ingresado un motivo. ¿Desea continuar de todas formas?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                txtMotivo.Focus();
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
}