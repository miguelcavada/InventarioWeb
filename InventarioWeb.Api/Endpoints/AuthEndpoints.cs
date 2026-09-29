using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWeb.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/auth")
            .WithTags("Autenticación")
            .WithOpenApi();

        api.MapPost("/login", async (
            [FromServices] IAuthService authService,
            [FromBody] LoginDto loginDto) =>
        {
            // Usar LoginJwtAsync en lugar de LoginAsync
            var result = await authService.LoginJwtAsync(loginDto);

            if (result.Success)
            {
                return Results.Ok(new
                {
                    success = true,
                    token = result.Token,
                    usuario = result.Usuario,
                    expiracion = result.Expiration
                });
            }

            return Results.Unauthorized();
        })
        .AllowAnonymous()
        .WithName("Login")
        .WithDescription("Inicia sesión y obtiene un token JWT");
    }
}