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
    public DbSet<UnidadMedida> UnidadesMedida { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // IMPORTANTE para Identity

        // Configuración Producto
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasIndex(p => p.Codigo).IsUnique();
            entity.Property(p => p.PrecioCosto).HasColumnType("decimal(18,2)");
            entity.Property(p => p.PrecioVentaMinorista).HasColumnType("decimal(18,2)");
            entity.Property(p => p.PrecioVentaMayorista).HasColumnType("decimal(18,2)");

            entity.HasOne(p => p.Categoria)
                  .WithMany(c => c.Productos)
                  .HasForeignKey(p => p.CategoriaId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.UnidadMedida)
                  .WithMany(u => u.Productos)
                  .HasForeignKey(p => p.UnidadMedidaId)
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
        SeedData.Seed(modelBuilder);        
    }
}