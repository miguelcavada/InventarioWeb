using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Web.Api;

public static class MovimientosEndpoints
{
    public static void MapMovimientosEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/movimientos")
            .RequireAuthorization()
            .WithTags("Movimientos")
            .WithOpenApi();

        // GET: api/movimientos
        api.MapGet("/", async (
            [FromServices] IMovimientoService service,
            [FromQuery] string tipo = "TODOS",
            [FromQuery] DateTime? desde = null,
            [FromQuery] DateTime? hasta = null) =>
        {
            var result = await service.GetMovimientosAsync(tipo, desde, hasta);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetMovimientos")
        .WithDescription("Obtiene movimientos con filtros opcionales");

        // GET: api/movimientos/{id}
        api.MapGet("/{id:int}", async (
            [FromServices] IMovimientoService service,
            int id) =>
        {
            var result = await service.GetMovimientoByIdAsync(id);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.NotFound(new { success = false, error = result.ErrorMessage });
        })
        .WithName("GetMovimientoById")
        .WithDescription("Obtiene un movimiento por ID");

        // POST: api/movimientos
        api.MapPost("/", async (
            [FromServices] IMovimientoService service,
            [FromBody] MovimientoDto dto) =>
        {
            var result = await service.CreateMovimientoAsync(dto);
            return result.IsSuccess
                ? Results.Created($"/api/movimientos/{result.Data!.Id}",
                    new { success = true, data = result.Data, message = result.SuccessMessage })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("CreateMovimiento")
        .WithDescription("Crea un nuevo movimiento");

        // GET: api/movimientos/precio-producto
        api.MapGet("/precio-producto", async (
            [FromServices] IMovimientoService service,
            [FromQuery] int productoId,
            [FromQuery] string tipo,
            [FromQuery] string tipoPrecio = "MINORISTA") =>
        {
            var result = await service.ObtenerPrecioProductoAsync(productoId, tipo, tipoPrecio);
            return result.IsSuccess
                ? Results.Ok(new { success = true, data = result.Data })
                : Results.BadRequest(new { success = false, error = result.ErrorMessage });
        })
        .WithName("ObtenerPrecioProducto")
        .WithDescription("Obtiene el precio de un producto según el tipo de movimiento");
    }
}