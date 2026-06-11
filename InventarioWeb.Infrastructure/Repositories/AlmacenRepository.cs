using Microsoft.EntityFrameworkCore;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;

namespace InventarioWeb.Infrastructure.Repositories;

public class AlmacenRepository : Repository<Almacen>, IAlmacenRepository
{
    public AlmacenRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Almacen>> GetAlmacenesActivosAsync()
    {
        return await _context.Almacenes
            .Where(a => a.Activo)
            .OrderBy(a => a.Nombre)
            .ToListAsync();
    }

    public async Task<IEnumerable<Almacen>> GetAlmacenesPorTipoAsync(string tipo)
    {
        return await _context.Almacenes
            .Where(a => a.Tipo == tipo && a.Activo)
            .OrderBy(a => a.Nombre)
            .ToListAsync();
    }

    public async Task<Almacen?> GetAlmacenConStocksAsync(int id)
    {
        return await _context.Almacenes
            .Include(a => a.Stocks)
                .ThenInclude(s => s.Producto)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}

public class StockAlmacenRepository : Repository<StockAlmacen>, IStockAlmacenRepository
{
    public StockAlmacenRepository(AppDbContext context) : base(context) { }

    public async Task<StockAlmacen?> GetStockAsync(int productoId, int almacenId)
    {
        return await _context.StockAlmacenes
            .Include(s => s.Producto)
            .Include(s => s.Almacen)
            .FirstOrDefaultAsync(s => s.ProductoId == productoId && s.AlmacenId == almacenId);
    }

    public async Task<IEnumerable<StockAlmacen>> GetStocksPorProductoAsync(int productoId)
    {
        return await _context.StockAlmacenes
            .Include(s => s.Almacen)
            .Where(s => s.ProductoId == productoId)
            .ToListAsync();
    }

    public async Task<IEnumerable<StockAlmacen>> GetStocksPorAlmacenAsync(int almacenId)
    {
        return await _context.StockAlmacenes
            .Include(s => s.Producto)
            .Where(s => s.AlmacenId == almacenId)
            .ToListAsync();
    }

    public async Task<IEnumerable<StockAlmacen>> GetProductosStockBajoAsync(int almacenId)
    {
        return await _context.StockAlmacenes
            .Include(s => s.Producto)
            .Where(s => s.AlmacenId == almacenId && s.StockActual <= s.StockMinimo)
            .ToListAsync();
    }
}