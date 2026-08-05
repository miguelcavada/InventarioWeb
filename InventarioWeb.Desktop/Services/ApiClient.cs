using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace InventarioWeb.Desktop.Services;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;
    private readonly IConfigService _configService;

    public ApiClient(ITokenService tokenService, IConfigService configService)
    {
        _tokenService = tokenService;
        _configService = configService;
        _httpClient = new HttpClient();
    }

    private async Task ConfigurarAuthAsync()
    {
        var tokenInfo = await _tokenService.ObtenerTokenActivoAsync();
        if (tokenInfo != null)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokenInfo.Token);
        }
    }

    public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
    {
        await ConfigurarAuthAsync();
        var baseUrl = await _configService.GetApiUrlAsync();
        var response = await _httpClient.GetAsync($"{baseUrl}{endpoint}");
        return await HandleResponse<T>(response);
    }

    public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
    {
        await ConfigurarAuthAsync();
        var baseUrl = await _configService.GetApiUrlAsync();
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{baseUrl}{endpoint}", content);
        return await HandleResponse<T>(response);
    }

    public async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
    {
        await ConfigurarAuthAsync();
        var baseUrl = await _configService.GetApiUrlAsync();
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{baseUrl}{endpoint}", content);
        return await HandleResponse<T>(response);
    }

    public async Task<ApiResponse<T>> DeleteAsync<T>(string endpoint)
    {
        await ConfigurarAuthAsync();
        var baseUrl = await _configService.GetApiUrlAsync();
        var response = await _httpClient.DeleteAsync($"{baseUrl}{endpoint}");
        return await HandleResponse<T>(response);
    }

    private async Task<ApiResponse<T>> HandleResponse<T>(HttpResponseMessage response)
    {
        var json = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            await _tokenService.InvalidarTokenAsync();
            throw new UnauthorizedAccessException("Sesión expirada. Inicie sesión nuevamente.");
        }

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<ApiResponse<T>>(json, options)
            ?? new ApiResponse<T> { Success = false, Error = "Error de comunicación" };
    }
}

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
    public string? Token { get; set; }
    public UsuarioInfo? Usuario { get; set; }
    public DateTime? Expiracion { get; set; }
}

public class UsuarioInfo
{
    public string Id { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public bool Activo { get; set; }
}