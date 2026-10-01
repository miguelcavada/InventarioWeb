using InventarioWeb.BlazorApp.Models;
using System.Net.Http.Json;

namespace InventarioWeb.BlazorApp.Services;

public interface IProductoApiService
{
    Task<List<Producto>> GetProductosAsync(string? buscar = null);
    Task<Producto?> GetProductoByIdAsync(int id);
    Task<Producto?> CreateProductoAsync(Producto producto);
    Task<Producto?> UpdateProductoAsync(int id, Producto producto);
    Task<bool> DeleteProductoAsync(int id);
}

public class ProductoApiService : IProductoApiService
{
    private readonly HttpClient _httpClient;

    public ProductoApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Producto>> GetProductosAsync(string? buscar = null)
    {
        var url = "api/productos";
        if (!string.IsNullOrEmpty(buscar))
            url += $"?buscar={Uri.EscapeDataString(buscar)}";

        var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Producto>>>(url);
        return response?.Data ?? new List<Producto>();
    }

    public async Task<Producto?> GetProductoByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<Producto>>($"api/productos/{id}");
        return response?.Data;
    }

    public async Task<Producto?> CreateProductoAsync(Producto producto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/productos", producto);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<Producto>>();
            return result?.Data;
        }
        return null;
    }

    public async Task<Producto?> UpdateProductoAsync(int id, Producto producto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/productos/{id}", producto);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<Producto>>();
            return result?.Data;
        }
        return null;
    }

    public async Task<bool> DeleteProductoAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/productos/{id}");
        return response.IsSuccessStatusCode;
    }
}