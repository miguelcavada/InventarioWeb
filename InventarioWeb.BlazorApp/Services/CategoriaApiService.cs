using InventarioWeb.BlazorApp.Models;
using System.Net.Http.Json;

namespace InventarioWeb.BlazorApp.Services;

public interface ICategoriaApiService
{
    Task<List<Categoria>> GetCategoriasAsync();
}

public class CategoriaApiService : ICategoriaApiService
{
    private readonly HttpClient _httpClient;

    public CategoriaApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Categoria>> GetCategoriasAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Categoria>>>("api/categorias");
        return response?.Data ?? new List<Categoria>();
    }
}