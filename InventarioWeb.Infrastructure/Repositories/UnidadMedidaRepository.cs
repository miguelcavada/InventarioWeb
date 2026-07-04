using Microsoft.EntityFrameworkCore;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;

namespace InventarioWeb.Infrastructure.Repositories;

public class UnidadMedidaRepository : Repository<UnidadMedida>, IUnidadMedidaRepository
{
    public UnidadMedidaRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<UnidadMedida>> GetUnidadesConProductosAsync()
    {
        return await _context.UnidadesMedida
            .Include(u => u.Productos)
            .ToListAsync();
    }

    public async Task<UnidadMedida?> GetUnidadConProductosAsync(int id)
    {
        return await _context.UnidadesMedida
            .Include(u => u.Productos)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}