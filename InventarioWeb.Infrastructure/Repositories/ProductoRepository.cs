using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Infrastructure.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Producto>> GetProductosConCategoriaAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.UnidadMedida)
                .Include(p => p.Stocks)
                    .ThenInclude(s => s.Almacen)
                .ToListAsync();
        }

        public async Task<Producto?> GetProductoConCategoriaAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.UnidadMedida)
                .Include(p => p.Stocks)
                    .ThenInclude(s => s.Almacen)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Producto>> GetProductosStockBajoAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Stocks)
                .Where(p => p.Activo && p.Stocks.Any(s => s.StockActual <= s.StockMinimo))
                .ToListAsync();
        }

        public async Task<bool> CodigoExisteAsync(string codigo, int? excludeId = null)
        {
            var query = _context.Productos.Where(p => p.Codigo == codigo);
            if (excludeId.HasValue)
                query = query.Where(p => p.Id != excludeId.Value);

            return await query.AnyAsync();
        }
    }
}
