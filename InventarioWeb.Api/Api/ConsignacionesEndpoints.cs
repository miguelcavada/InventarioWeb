using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Api;

public static class ConsignacionesEndpoints
{
    public static void MapConsignacionesEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/consignaciones")
            .RequireAuthorization()
            .WithTags("Consignaciones")
            .WithOpenApi();

        // GET: api/consignaciones
        api.MapGet("/", async ([FromServices] IConsignacionService service) =>
        {
            var result = await service.GetConsignacionesAsync();
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetConsignaciones")
        .WithDescription("Obtiene todas las consignaciones");

        // GET: api/consignaciones/{id}
        api.MapGet("/{id:int}", async (
            [FromServices] IConsignacionService service,
            int id) =>
        {
            var result = await service.GetConsignacionByIdAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.NotFound(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetConsignacionById")
        .WithDescription("Obtiene una consignación por ID");

        // POST: api/consignaciones
        api.MapPost("/", async (
            [FromServices] IConsignacionService service,
            [FromBody] ConsignacionDto dto) =>
        {
            var result = await service.CreateConsignacionAsync(dto);
            return result.IsSuccess
                ? Results.Created($"/api/consignaciones/{result.Data!.Id}",
                    new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CreateConsignacion")
        .WithDescription("Crea una nueva consignación");

        // POST: api/consignaciones/registrar-venta
        api.MapPost("/registrar-venta", async (
            [FromServices] IConsignacionService service,
            [FromBody] RegistrarVentaDto dto) =>
        {
            var result = await service.RegistrarVentaAsync(dto);
            return result.IsSuccess
                ? Results.Ok(new { success = true, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("RegistrarVenta")
        .WithDescription("Registra una venta en una consignación");

        // POST: api/consignaciones/registrar-devolucion
        api.MapPost("/registrar-devolucion", async (
            [FromServices] IConsignacionService service,
            [FromBody] RegistrarDevolucionDto dto) =>
        {
            var result = await service.RegistrarDevolucionAsync(dto);
            return result.IsSuccess
                ? Results.Ok(new { success = true, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("RegistrarDevolucion")
        .WithDescription("Registra una devolución en una consignación");

        // GET: api/consignaciones/precio-producto
        api.MapGet("/precio-producto", async (
            [FromServices] IConsignacionService service,
            [FromQuery] int productoId) =>
        {
            var result = await service.ObtenerPrecioProductoAsync(productoId);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("ObtenerPrecioProductoConsignacion")
        .WithDescription("Obtiene el precio de venta minorista de un producto para consignación");
    }
}