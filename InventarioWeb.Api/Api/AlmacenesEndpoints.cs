using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Api;

public static class AlmacenesEndpoints
{
    public static void MapAlmacenesEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/almacenes")
            .RequireAuthorization()
            .WithTags("Almacenes")
            .WithOpenApi();

        // GET: api/almacenes
        api.MapGet("/", async ([FromServices] IAlmacenService service) =>
        {
            var result = await service.GetAlmacenesAsync();
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetAlmacenes")
        .WithDescription("Obtiene todos los almacenes");

        // GET: api/almacenes/{id}
        api.MapGet("/{id:int}", async (
            [FromServices] IAlmacenService service,
            int id) =>
        {
            var result = await service.GetAlmacenByIdAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.NotFound(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetAlmacenById")
        .WithDescription("Obtiene un almacén por ID");

        // GET: api/almacenes/{id}/inventario
        api.MapGet("/{id:int}/inventario", async (
            [FromServices] IAlmacenService service,
            int id) =>
        {
            var result = await service.GetInventarioAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetInventarioAlmacen")
        .WithDescription("Obtiene el inventario actual de un almacén");

        // POST: api/almacenes
        api.MapPost("/", async (
            [FromServices] IAlmacenService service,
            [FromBody] AlmacenDto dto) =>
        {
            var result = await service.CreateAlmacenAsync(dto);
            return result.IsSuccess
                ? Results.Created($"/api/almacenes/{result.Data!.Id}",
                    new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CreateAlmacen")
        .WithDescription("Crea un nuevo almacén");

        // PUT: api/almacenes/{id}
        api.MapPut("/{id:int}", async (
            [FromServices] IAlmacenService service,
            int id,
            [FromBody] AlmacenDto dto) =>
        {
            var result = await service.UpdateAlmacenAsync(id, dto);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("UpdateAlmacen")
        .WithDescription("Actualiza un almacén");

        // DELETE: api/almacenes/{id}
        api.MapDelete("/{id:int}", async (
            [FromServices] IAlmacenService service,
            int id) =>
        {
            var result = await service.DeleteAlmacenAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("DeleteAlmacen")
        .WithDescription("Elimina un almacén");
    }
}