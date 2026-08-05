using Microsoft.EntityFrameworkCore;

namespace InventarioWeb.Desktop.Data;

public class LocalDbContext : DbContext
{
    public DbSet<TokenStorage> Tokens { get; set; }
    public DbSet<AppConfig> Configuraciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "InventarioDesktop", "local.db");

        var dir = Path.GetDirectoryName(dbPath);
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}

public class TokenStorage
{
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public string UsuarioEmail { get; set; } = string.Empty;
    public string UsuarioNombre { get; set; } = string.Empty;
    public string UsuarioRol { get; set; } = string.Empty;
    public DateTime FechaExpiracion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public bool Activo { get; set; } = true;
}

public class AppConfig
{
    public int Id { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Valor { get; set; } = string.Empty;
}