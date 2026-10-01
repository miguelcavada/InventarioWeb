using InventarioWeb.BlazorApp.Models;
using System.Net.Http.Json;

namespace InventarioWeb.Blazor.Services;

public interface IMovimientoApiService
{
    Task<List<Movimiento>> GetMovimientosAsync();
}

public class MovimientoApiService : IMovimientoApiService
{
    private readonly HttpClient _httpClient;

    public MovimientoApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Movimiento>> GetMovimientosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Movimiento>>>("api/movimientos");
        return response?.Data ?? new List<Movimiento>();
    }
}