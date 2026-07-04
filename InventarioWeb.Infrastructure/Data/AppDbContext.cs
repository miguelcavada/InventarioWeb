using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tablas del inventario
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Movimiento> Movimientos { get; set; }
    public DbSet<MovimientoDetalle> MovimientoDetalles { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<HistorialPrecio> HistorialPrecios { get; set; }
    public DbSet<Almacen> Almacenes { get; set; }
    public DbSet<StockAlmacen> StockAlmacenes { get; set; }
    public DbSet<Consignacion> Consignaciones { get; set; }
    public DbSet<ConsignacionDetalle> ConsignacionDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // IMPORTANTE para Identity

        // Configuración Producto
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasIndex(p => p.Codigo).IsUnique();
            entity.Property(p => p.PrecioCosto).HasColumnType("decimal(18,2)");
            entity.Property(p => p.PrecioVenta).HasColumnType("decimal(18,2)");

            entity.HasOne(p => p.Categoria)
                  .WithMany(c => c.Productos)
                  .HasForeignKey(p => p.CategoriaId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración Almacen
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasIndex(a => a.Codigo).IsUnique();
        });

        // Configuración StockAlmacen
        modelBuilder.Entity<StockAlmacen>(entity =>
        {
            entity.HasIndex(s => new { s.ProductoId, s.AlmacenId }).IsUnique();

            entity.HasOne(s => s.Producto)
                  .WithMany(p => p.Stocks)
                  .HasForeignKey(s => s.ProductoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(s => s.Almacen)
                  .WithMany(a => a.Stocks)
                  .HasForeignKey(s => s.AlmacenId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración Movimiento
        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasIndex(m => m.NumeroDocumento).IsUnique();
            entity.Property(m => m.Tipo).HasMaxLength(20);

            entity.HasOne(m => m.AlmacenOrigen)
                  .WithMany(a => a.MovimientosOrigen)
                  .HasForeignKey(m => m.AlmacenOrigenId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.AlmacenDestino)
                  .WithMany(a => a.MovimientosDestino)
                  .HasForeignKey(m => m.AlmacenDestinoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración MovimientoDetalle
        modelBuilder.Entity<MovimientoDetalle>(entity =>
        {
            entity.Property(d => d.Cantidad).HasColumnType("decimal(18,2)");
            entity.Property(d => d.PrecioUnitario).HasColumnType("decimal(18,2)");

            entity.HasOne(d => d.Movimiento)
                  .WithMany(m => m.Detalles)
                  .HasForeignKey(d => d.MovimientoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Producto)
                  .WithMany(p => p.MovimientosDetalle)
                  .HasForeignKey(d => d.ProductoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<HistorialPrecio>(entity =>
        {
            entity.Property(h => h.PrecioCostoAnterior).HasColumnType("decimal(18,2)");
            entity.Property(h => h.PrecioCostoNuevo).HasColumnType("decimal(18,2)");
            entity.Property(h => h.PrecioVentaAnterior).HasColumnType("decimal(18,2)");
            entity.Property(h => h.PrecioVentaNuevo).HasColumnType("decimal(18,2)");

            entity.HasOne(h => h.Producto)
                  .WithMany()
                  .HasForeignKey(h => h.ProductoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(h => h.ProductoId);
            entity.HasIndex(h => h.FechaCambio);
        });

        modelBuilder.Entity<Consignacion>(entity =>
        {
            entity.HasIndex(c => c.NumeroConsignacion).IsUnique();

            entity.HasOne(c => c.AlmacenOrigen)
                  .WithMany()
                  .HasForeignKey(c => c.AlmacenOrigenId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ConsignacionDetalle>(entity =>
        {
            entity.HasOne(d => d.Consignacion)
                  .WithMany(c => c.Detalles)
                  .HasForeignKey(d => d.ConsignacionId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Producto)
                  .WithMany()
                  .HasForeignKey(d => d.ProductoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Datos semilla
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Electrónicos", Descripcion = "Productos electrónicos", Activo = true, FechaCreacion = DateTime.Now },
            new Categoria { Id = 2, Nombre = "Muebles", Descripcion = "Muebles de oficina", Activo = true, FechaCreacion = DateTime.Now },
            new Categoria { Id = 3, Nombre = "Suministros", Descripcion = "Suministros de oficina", Activo = true, FechaCreacion = DateTime.Now }
        );

        modelBuilder.Entity<Producto>().HasData(
            new Producto
            {
                Id = 1,
                Codigo = "PROD-001",
                Nombre = "Laptop HP",
                Descripcion = "Laptop HP 15 pulgadas",
                PrecioCosto = 800.00m,
                PrecioVenta = 1200.00m,
                CategoriaId = 1,
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Producto
            {
                Id = 2,
                Codigo = "PROD-002",
                Nombre = "Escritorio",
                Descripcion = "Escritorio ejecutivo",
                PrecioCosto = 300.00m,
                PrecioVenta = 500.00m,
                CategoriaId = 2,
                Activo = true,
                FechaCreacion = DateTime.Now
            }
        );

        // Datos semilla de almacenes
        modelBuilder.Entity<Almacen>().HasData(
            new Almacen { Id = 1, Nombre = "Almacén Central", Codigo = "ALM-CENTRAL", Tipo = "ALMACEN", Direccion = "Calle Principal #123", Activo = true, FechaCreacion = DateTime.Now },
            new Almacen { Id = 2, Nombre = "Mercado Norte", Codigo = "MER-NORTE", Tipo = "MERCADO", Direccion = "Av. Norte #456", Activo = true, FechaCreacion = DateTime.Now },
            new Almacen { Id = 3, Nombre = "Mercado Sur", Codigo = "MER-SUR", Tipo = "MERCADO", Direccion = "Av. Sur #789", Activo = true, FechaCreacion = DateTime.Now }
        );
    }
}