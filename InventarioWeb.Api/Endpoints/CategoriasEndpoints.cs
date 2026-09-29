using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Api.Endpoints;

public static class CategoriasEndpoints
{
    public static void MapCategoriasEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/categorias")
            .RequireAuthorization()
            .WithTags("Categorías")
            .WithOpenApi();

        api.MapGet("/", async ([FromServices] ICategoriaService service) =>
        {
            var result = await service.GetCategoriasAsync();
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetCategorias")
        .WithDescription("Obtiene todas las categorías");

        api.MapGet("/{id:int}", async (
            [FromServices] ICategoriaService service,
            int id) =>
        {
            var result = await service.GetCategoriaByIdAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.NotFound(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetCategoriaById")
        .WithDescription("Obtiene una categoría por ID");

        api.MapGet("/{id:int}/productos", async (
            [FromServices] ICategoriaService service,
            int id) =>
        {
            var result = await service.GetProductosPorCategoriaAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetProductosPorCategoria")
        .WithDescription("Obtiene los productos de una categoría");

        api.MapPost("/", async (
            [FromServices] ICategoriaService service,
            [FromBody] CategoriaDto dto) =>
        {
            var result = await service.CreateCategoriaAsync(dto);
            return result.IsSuccess
                ? Results.Created($"/api/categorias/{result.Data!.Id}",
                    new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CreateCategoria")
        .WithDescription("Crea una nueva categoría");

        api.MapPut("/{id:int}", async (
            [FromServices] ICategoriaService service,
            int id,
            [FromBody] CategoriaDto dto) =>
        {
            var result = await service.UpdateCategoriaAsync(id, dto);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("UpdateCategoria")
        .WithDescription("Actualiza una categoría");

        api.MapDelete("/{id:int}", async (
            [FromServices] ICategoriaService service,
            int id) =>
        {
            var result = await service.DeleteCategoriaAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("DeleteCategoria")
        .WithDescription("Elimina una categoría");
    }
}