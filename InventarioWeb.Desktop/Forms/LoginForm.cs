using InventarioWeb.Desktop.Services;

namespace InventarioWeb.Desktop.Forms;

public partial class LoginForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly ITokenService _tokenService;
    private readonly IConfigService _configService;

    public LoginForm()
    {
        InitializeComponent();
        _tokenService = new TokenService();
        _configService = new ConfigService();
        _apiClient = new ApiClient(_tokenService, _configService);
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            MessageBox.Show("Complete todos los campos", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnLogin.Enabled = false;
        lblStatus.Text = "Conectando...";

        try
        {
            var loginData = new { email = txtEmail.Text, password = txtPassword.Text };
            var response = await _apiClient.PostAsync<LoginResponse>("auth/login", loginData);

            if (response.Success && response.Data != null)
            {
                await _tokenService.GuardarTokenAsync(
                    response.Data.Token,
                    response.Data.Usuario.Email,
                    response.Data.Usuario.NombreCompleto,
                    response.Data.Usuario.Rol,
                    response.Data.Expiracion ?? DateTime.Now.AddHours(8)
                );

                var mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                lblStatus.Text = response.Error ?? "Credenciales incorrectas";
                MessageBox.Show(response.Error ?? "Error al iniciar sesión",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error de conexión";
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }

    private async void LoginForm_Load(object sender, EventArgs e)
    {
        // Verificar si hay token válido
        if (await _tokenService.TokenEsValidoAsync())
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public UsuarioInfo Usuario { get; set; } = new();
    public DateTime? Expiracion { get; set; }
}