using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Api;

public static class ProductosEndpoints
{
    public static void MapProductosEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/productos")
            .RequireAuthorization()
            .WithTags("Productos")
            .WithOpenApi();

        // GET: api/productos
        api.MapGet("/", async (
            [FromServices] IProductoService service,
            [FromQuery] string? buscar,
            [FromQuery] string orden = "nombre") =>
        {
            var result = await service.GetProductosAsync(buscar, orden);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetProductos")
        .WithDescription("Obtiene todos los productos con filtros opcionales");

        // GET: api/productos/{id}
        api.MapGet("/{id:int}", async (
            [FromServices] IProductoService service,
            int id) =>
        {
            var result = await service.GetProductoByIdAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.NotFound(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetProductoById")
        .WithDescription("Obtiene un producto por su ID");

        // POST: api/productos
        api.MapPost("/", async (
            [FromServices] IProductoService service,
            [FromBody] ProductoDto dto) =>
        {
            var result = await service.CreateProductoAsync(dto);
            return result.IsSuccess
                ? Results.Created($"/api/productos/{result.Data!.Id}",
                    new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CreateProducto")
        .WithDescription("Crea un nuevo producto");

        // PUT: api/productos/{id}
        api.MapPut("/{id:int}", async (
            [FromServices] IProductoService service,
            int id,
            [FromBody] ProductoDto dto) =>
        {
            var result = await service.UpdateProductoAsync(id, dto);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("UpdateProducto")
        .WithDescription("Actualiza un producto existente");

        // DELETE: api/productos/{id}
        api.MapDelete("/{id:int}", async (
            [FromServices] ProductoService service,
            int id) =>
        {
            var result = await service.DeleteProductoAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("DeleteProducto")
        .WithDescription("Elimina un producto");

        // GET: api/productos/{id}/historial-precios
        api.MapGet("/{id:int}/historial-precios", async (
            [FromServices] IProductoService service,
            int id) =>
        {
            var result = await service.GetHistorialPreciosAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetHistorialPrecios")
        .WithDescription("Obtiene el historial de precios de un producto");

        // POST: api/productos/cambiar-precio
        api.MapPost("/cambiar-precio", async (
            [FromServices] IProductoService service,
            [FromBody] CambioPrecioDto dto,
            HttpContext context) =>
        {
            var usuario = context.User.Identity?.Name ?? "Sistema";
            var result = await service.CambiarPrecioAsync(dto, usuario);
            return result.IsSuccess
                ? Results.Ok(new { success = true, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CambiarPrecio")
        .WithDescription("Cambia los precios de un producto");
    }
}