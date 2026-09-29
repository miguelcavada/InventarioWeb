using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Api.Endpoints;

public static class UnidadesMedidaEndpoints
{
    public static void MapUnidadesMedidaEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/unidades-medida")
            .RequireAuthorization()
            .WithTags("Unidades de Medida")
            .WithOpenApi();

        api.MapGet("/", async ([FromServices] IUnidadMedidaService service) =>
        {
            var result = await service.GetUnidadesAsync();
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetUnidadesMedida")
        .WithDescription("Obtiene todas las unidades de medida");

        api.MapGet("/{id:int}", async (
            [FromServices] IUnidadMedidaService service,
            int id) =>
        {
            var result = await service.GetUnidadByIdAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.NotFound(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetUnidadMedidaById")
        .WithDescription("Obtiene una unidad de medida por ID");

        api.MapPost("/", async (
            [FromServices] IUnidadMedidaService service,
            [FromBody] UnidadMedidaDto dto) =>
        {
            var result = await service.CreateUnidadAsync(dto);
            return result.IsSuccess
                ? Results.Created($"/api/unidades-medida/{result.Data!.Id}",
                    new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CreateUnidadMedida")
        .WithDescription("Crea una nueva unidad de medida");

        api.MapPut("/{id:int}", async (
            [FromServices] IUnidadMedidaService service,
            int id,
            [FromBody] UnidadMedidaDto dto) =>
        {
            var result = await service.UpdateUnidadAsync(id, dto);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("UpdateUnidadMedida")
        .WithDescription("Actualiza una unidad de medida");
    }
}