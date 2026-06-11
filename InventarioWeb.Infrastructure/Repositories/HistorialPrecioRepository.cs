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
}