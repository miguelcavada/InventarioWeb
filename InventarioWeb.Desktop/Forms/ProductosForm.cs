using InventarioWeb.Desktop.Services;
using System.Data;

namespace InventarioWeb.Desktop.Forms;

public partial class ProductosForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly ITokenService _tokenService;
    private readonly IConfigService _configService;

    public ProductosForm()
    {
        InitializeComponent();
        _tokenService = new TokenService();
        _configService = new ConfigService();
        _apiClient = new ApiClient(_tokenService, _configService);
    }

    private async void ProductosForm_Load(object sender, EventArgs e)
    {
        await CargarProductosAsync();
    }

    private async Task CargarProductosAsync(string? buscar = null)
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            var endpoint = "productos";
            if (!string.IsNullOrEmpty(buscar))
                endpoint += $"?buscar={buscar}";

            var response = await _apiClient.GetAsync<List<ProductoDto>>(endpoint);

            if (response.Success && response.Data != null)
            {
                dgvProductos.DataSource = response.Data;
                ConfigurarDataGridView();
                lblTotal.Text = $"Total: {response.Data.Count} productos";
            }
            else
            {
                MessageBox.Show(response.Error ?? "Error al cargar productos",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void ConfigurarDataGridView()
    {
        dgvProductos.AutoGenerateColumns = false;
        dgvProductos.Columns.Clear();

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Codigo",
            HeaderText = "Código",
            Width = 80
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Nombre",
            HeaderText = "Nombre",
            Width = 200
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "CategoriaNombre",
            HeaderText = "Categoría",
            Width = 120
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "PrecioVentaMinorista",
            HeaderText = "Precio Venta",
            Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "StockTotal",
            HeaderText = "Stock",
            Width = 70,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "UnidadMedidaAbreviatura",
            HeaderText = "Unidad",
            Width = 60
        });

        // Columna de estado con color
        dgvProductos.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                var stock = Convert.ToInt32(e.Value);
                if (stock <= 0)
                    e.CellStyle.BackColor = Color.LightCoral;
                else if (stock <= 5)
                    e.CellStyle.BackColor = Color.LightYellow;
            }
        };
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
        await CargarProductosAsync(txtBuscar.Text);
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        var form = new ProductoEditForm();
        if (form.ShowDialog() == DialogResult.OK)
            await CargarProductosAsync();
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto", "Información");
            return;
        }

        var id = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
        var form = new ProductoEditForm(id);
        if (form.ShowDialog() == DialogResult.OK)
            await CargarProductosAsync();
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0) return;

        var nombre = dgvProductos.SelectedRows[0].Cells[1].Value?.ToString();
        var result = MessageBox.Show($"¿Eliminar {nombre}?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            var id = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
            var response = await _apiClient.DeleteAsync<object>($"productos/{id}");

            if (response.Success)
                await CargarProductosAsync();
            else
                MessageBox.Show(response.Error, "Error");
        }
    }

    private async void btnCambiarPrecio_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0) return;

        var id = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
        var nombre = dgvProductos.SelectedRows[0].Cells[1].Value?.ToString();
        var form = new CambioPrecioForm(id, nombre ?? "");
        if (form.ShowDialog() == DialogResult.OK)
            await CargarProductosAsync();
    }

    private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
            btnBuscar.PerformClick();
    }
}

public class ProductoDto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal? PrecioCosto { get; set; }
    public decimal PrecioVentaMinorista { get; set; }
    public decimal? PrecioVentaMayorista { get; set; }
    public int CategoriaId { get; set; }
    public string? CategoriaNombre { get; set; }
    public int UnidadMedidaId { get; set; }
    public string? UnidadMedidaAbreviatura { get; set; }
    public int StockTotal { get; set; }
    public bool Activo { get; set; }
}