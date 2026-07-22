using InventarioWeb.Application.Services;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Api;

public static class DashboardEndpoints
{
    public static void MapDashboardEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/dashboard")
            .RequireAuthorization()
            .WithTags("Dashboard")
            .WithOpenApi();

        // GET: api/dashboard
        api.MapGet("/", async ([FromServices] IDashboardService service) =>
        {
            var result = await service.GetDashboardDataAsync();
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetDashboard")
        .WithDescription("Obtiene los datos del dashboard");
    }
}