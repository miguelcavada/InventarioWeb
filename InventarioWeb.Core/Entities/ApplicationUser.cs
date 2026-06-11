using Microsoft.AspNetCore.Identity;

namespace InventarioWeb.Core.Entities;

public class ApplicationUser : IdentityUser
{
    // Campos personalizados adicionales
    public string NombreCompleto { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public DateTime? UltimoAcceso { get; set; }
    public bool Activo { get; set; } = true;
    public string? AvatarUrl { get; set; }
}