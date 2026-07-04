using Microsoft.EntityFrameworkCore;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;

namespace InventarioWeb.Infrastructure.Repositories;

public class ConsignacionRepository : Repository<Consignacion>, IConsignacionRepository
{
    public ConsignacionRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Consignacion>> GetConsignacionesConDetallesAsync()
    {
        return await _context.Consignaciones
            .Include(c => c.AlmacenOrigen)
            .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
            .OrderByDescending(c => c.FechaEntrega)
            .ToListAsync();
    }

    public async Task<Consignacion?> GetConsignacionConDetallesAsync(int id)
    {
        return await _context.Consignaciones
            .Include(c => c.AlmacenOrigen)
            .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Consignacion>> GetConsignacionesPorEstadoAsync(string estado)
    {
        return await _context.Consignaciones
            .Include(c => c.Detalles)
            .Where(c => c.Estado == estado)
            .OrderByDescending(c => c.FechaEntrega)
            .ToListAsync();
    }

    public async Task<IEnumerable<Consignacion>> GetConsignacionesPorVendedorAsync(string vendedor)
    {
        return await _context.Consignaciones
            .Include(c => c.Detalles)
            .Where(c => c.VendedorNombre.Contains(vendedor))
            .OrderByDescending(c => c.FechaEntrega)
            .ToListAsync();
    }

    public async Task<IEnumerable<Consignacion>> GetConsignacionesPendientesAsync()
    {
        return await _context.Consignaciones
            .Include(c => c.AlmacenOrigen)
            .Include(c => c.Detalles)
                .ThenInclude(d => d.Producto)
            .Where(c => c.Estado == "PENDIENTE" || c.Estado == "PARCIAL")
            .OrderByDescending(c => c.FechaEntrega)
            .ToListAsync();
    }
}