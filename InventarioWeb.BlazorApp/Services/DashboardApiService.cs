using InventarioWeb.BlazorApp.Models;
using System.Net.Http.Json;

namespace InventarioWeb.BlazorApp.Services;

public interface IDashboardApiService
{
    Task<DashboardData?> GetDashboardAsync();
}

public class DashboardApiService : IDashboardApiService
{
    private readonly HttpClient _httpClient;

    public DashboardApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DashboardData?> GetDashboardAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<DashboardData>>("api/dashboard");
            return response?.Data;
        }
        catch
        {
            return new DashboardData();
        }
    }
}