using Microsoft.EntityFrameworkCore;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;

namespace InventarioWeb.Infrastructure.Repositories;

public class HistorialPrecioRepository : Repository<HistorialPrecio>, IHistorialPrecioRepository
{
    public HistorialPrecioRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<HistorialPrecio>> GetHistorialPorProductoAsync(int productoId)
    {
        return await _context.HistorialPrecios
            .Include(h => h.Producto)
            .Where(h => h.ProductoId == productoId)
            .OrderByDescending(h => h.FechaCambio)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistorialPrecio>> GetHistorialPorFechaAsync(DateTime desde, DateTime hasta)
    {
        return await _context.HistorialPrecios
            .Include(h => h.Producto)
            .Where(h => h.FechaCambio >= desde && h.FechaCambio <= hasta)
            .OrderByDescending(h => h.FechaCambio)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistorialPrecio>> GetUltimosCambiosAsync(int cantidad = 10)
    {
        return await _context.HistorialPrecios
            .Include(h => h.Producto)
            .OrderByDescending(h => h.FechaCambio)
            .Take(cantidad)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistorialPrecio>> GetHistorialCompletoAsync(DateTime? desde = null, DateTime? hasta = null, string? usuario = null)
    {
        var query = _context.HistorialPrecios
            .Include(h => h.Producto)
            .AsQueryable();

        if (desde.HasValue)
            query = query.Where(h => h.FechaCambio >= desde.Value);

        if (hasta.HasValue)
            query = query.Where(h => h.FechaCambio <= hasta.Value.AddDays(1).AddSeconds(-1));

        if (!string.IsNullOrEmpty(usuario))
            query = query.Where(h => h.UsuarioCambio != null && h.UsuarioCambio.Contains(usuario));

        return await query
            .OrderByDescending(h => h.FechaCambio)
            .ToListAsync();
    }
}