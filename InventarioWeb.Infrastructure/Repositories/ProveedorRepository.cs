using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventarioWeb.Infrastructure.Repositories
{
    internal class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Proveedor>> GetProveedoresActivosAsync()
        {
            return await _context.Proveedores
                .Where(p => p.Activo)
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        public async Task<Proveedor?> GetProveedorConMovimientosAsync(int id)
        {
            return await _context.Proveedores
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> RUCExisteAsync(string ruc, int? excludeId = null)
        {
            if (string.IsNullOrEmpty(ruc)) return false;

            var query = _context.Proveedores.Where(p => p.RUC == ruc);
            if (excludeId.HasValue)
                query = query.Where(p => p.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Proveedor>> BuscarProveedoresAsync(string termino)
        {
            if (string.IsNullOrEmpty(termino))
                return await GetProveedoresActivosAsync();

            return await _context.Proveedores
                .Where(p => p.Activo &&
                           (p.Nombre.Contains(termino) ||
                            p.RUC.Contains(termino) ||
                            p.Email.Contains(termino)))
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }
    }
}