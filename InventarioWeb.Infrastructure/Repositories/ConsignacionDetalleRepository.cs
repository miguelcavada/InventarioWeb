using Microsoft.EntityFrameworkCore;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;

namespace InventarioWeb.Infrastructure.Repositories;

public class ConsignacionDetalleRepository : Repository<ConsignacionDetalle>, IConsignacionDetalleRepository
{
    public ConsignacionDetalleRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<ConsignacionDetalle>> GetDetallesPorConsignacionAsync(int consignacionId)
    {
        return await _context.ConsignacionDetalles
            .Include(d => d.Producto)
            .Where(d => d.ConsignacionId == consignacionId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ConsignacionDetalle>> GetDetallesPorProductoAsync(int productoId)
    {
        return await _context.ConsignacionDetalles
            .Include(d => d.Consignacion)
            .Where(d => d.ProductoId == productoId)
            .OrderByDescending(d => d.FechaCreacion)
            .ToListAsync();
    }

    public async Task<IEnumerable<ConsignacionDetalle>> GetDetallesPendientesAsync()
    {
        return await _context.ConsignacionDetalles
            .Include(d => d.Producto)
            .Include(d => d.Consignacion)
            .Where(d => (d.CantidadEntregada - d.CantidadVendida - d.CantidadDevuelta) > 0)
            .OrderBy(d => d.Consignacion!.FechaEntrega)
            .ToListAsync();
    }
}