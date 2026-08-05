using InventarioWeb.Desktop.Services;

namespace InventarioWeb.Desktop.Forms;

public partial class MainForm : Form
{
    private readonly ITokenService _tokenService;

    public MainForm()
    {
        InitializeComponent();
        _tokenService = new TokenService();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        var token = await _tokenService.ObtenerTokenActivoAsync();
        if (token != null)
        {
            lblUsuario.Text = $"{token.Nombre} ({token.Rol})";
        }
    }

    private void btnProductos_Click(object sender, EventArgs e)
    {
        var form = new ProductosForm();
        form.ShowDialog();
    }

    private void btnMovimientos_Click(object sender, EventArgs e)
    {
        var form = new MovimientosForm();
        form.ShowDialog();
    }

    private async void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        await _tokenService.InvalidarTokenAsync();
        var loginForm = new LoginForm();
        loginForm.Show();
        this.Close();
    }
}