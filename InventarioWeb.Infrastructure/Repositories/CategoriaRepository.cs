using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventarioWeb.Infrastructure.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Categoria>> GetCategoriasConProductosAsync()
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .ToListAsync();
        }

        public async Task<Categoria?> GetCategoriaConProductosAsync(int id)
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}