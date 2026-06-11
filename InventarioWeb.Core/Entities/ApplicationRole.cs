using Microsoft.AspNetCore.Identity;

namespace InventarioWeb.Core.Entities;

public class ApplicationRole : IdentityRole
{
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}