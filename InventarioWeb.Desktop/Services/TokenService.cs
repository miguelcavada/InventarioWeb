using InventarioWeb.Desktop.Data;
using Microsoft.EntityFrameworkCore;

namespace InventarioWeb.Desktop.Services;

public interface ITokenService
{
    Task GuardarTokenAsync(string token, string email, string nombre, string rol, DateTime expiracion);
    Task<TokenInfo?> ObtenerTokenActivoAsync();
    Task InvalidarTokenAsync();
    Task<bool> TokenEsValidoAsync();
}

public class TokenInfo
{
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
}

public class TokenService : ITokenService
{
    public async Task GuardarTokenAsync(string token, string email, string nombre, string rol, DateTime expiracion)
    {
        using var db = new LocalDbContext();
        await db.Database.EnsureCreatedAsync();

        // Invalidar tokens anteriores
        var tokensAnteriores = await db.Tokens.Where(t => t.Activo).ToListAsync();
        foreach (var t in tokensAnteriores)
            t.Activo = false;

        // Guardar nuevo token
        db.Tokens.Add(new TokenStorage
        {
            Token = token,
            UsuarioEmail = email,
            UsuarioNombre = nombre,
            UsuarioRol = rol,
            FechaExpiracion = expiracion,
            FechaCreacion = DateTime.Now,
            Activo = true
        });

        await db.SaveChangesAsync();
    }

    public async Task<TokenInfo?> ObtenerTokenActivoAsync()
    {
        using var db = new LocalDbContext();
        var token = await db.Tokens
            .Where(t => t.Activo && t.FechaExpiracion > DateTime.Now)
            .OrderByDescending(t => t.FechaCreacion)
            .FirstOrDefaultAsync();

        if (token == null) return null;

        return new TokenInfo
        {
            Token = token.Token,
            Email = token.UsuarioEmail,
            Nombre = token.UsuarioNombre,
            Rol = token.UsuarioRol
        };
    }

    public async Task InvalidarTokenAsync()
    {
        using var db = new LocalDbContext();
        var tokens = await db.Tokens.Where(t => t.Activo).ToListAsync();
        foreach (var t in tokens)
            t.Activo = false;
        await db.SaveChangesAsync();
    }

    public async Task<bool> TokenEsValidoAsync()
    {
        var token = await ObtenerTokenActivoAsync();
        return token != null;
    }
}