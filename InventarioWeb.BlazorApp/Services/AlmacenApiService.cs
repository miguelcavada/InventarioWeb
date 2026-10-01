using InventarioWeb.BlazorApp.Models;
using System.Net.Http.Json;

namespace InventarioWeb.BlazorApp.Services;

public interface IAlmacenApiService
{
    Task<List<Almacen>> GetAlmacenesAsync();
}

public class AlmacenApiService : IAlmacenApiService
{
    private readonly HttpClient _httpClient;

    public AlmacenApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Almacen>> GetAlmacenesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Almacen>>>("api/almacenes");
        return response?.Data ?? new List<Almacen>();
    }
}