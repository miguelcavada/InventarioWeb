using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Api.Endpoints;

public static class ProveedoresEndpoints
{
    public static void MapProveedoresEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/proveedores")
            .RequireAuthorization()
            .WithTags("Proveedores")
            .WithOpenApi();

        api.MapGet("/", async (
            [FromServices] IProveedorService service,
            [FromQuery] string? buscar = null) =>
        {
            var result = await service.GetProveedoresAsync(buscar);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetProveedores")
        .WithDescription("Obtiene todos los proveedores");

        api.MapGet("/{id:int}", async (
            [FromServices] IProveedorService service,
            int id) =>
        {
            var result = await service.GetProveedorByIdAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.NotFound(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetProveedorById")
        .WithDescription("Obtiene un proveedor por ID");

        api.MapPost("/", async (
            [FromServices] IProveedorService service,
            [FromBody] ProveedorDto dto) =>
        {
            var result = await service.CreateProveedorAsync(dto);
            return result.IsSuccess
                ? Results.Created($"/api/proveedores/{result.Data!.Id}",
                    new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CreateProveedor")
        .WithDescription("Crea un nuevo proveedor");

        api.MapPut("/{id:int}", async (
            [FromServices] IProveedorService service,
            int id,
            [FromBody] ProveedorDto dto) =>
        {
            var result = await service.UpdateProveedorAsync(id, dto);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("UpdateProveedor")
        .WithDescription("Actualiza un proveedor");

        api.MapDelete("/{id:int}", async (
            [FromServices] IProveedorService service,
            int id) =>
        {
            var result = await service.DeleteProveedorAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("DeleteProveedor")
        .WithDescription("Elimina un proveedor");
    }
}