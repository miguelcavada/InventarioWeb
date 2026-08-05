using Microsoft.EntityFrameworkCore;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;

namespace InventarioWeb.Infrastructure.Repositories;

public class ConversionRepository : Repository<ConversionUnidad>, IConversionRepository
{
    public ConversionRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<ConversionUnidad>> GetConversionesConUnidadesAsync()
    {
        return await _context.Conversiones
            .Include(c => c.UnidadOrigen)
            .Include(c => c.UnidadDestino)
            .Where(c => c.Activo)
            .OrderBy(c => c.UnidadOrigen!.Abreviatura)
            .ToListAsync();
    }

    public async Task<IEnumerable<ConversionUnidad>> GetConversionesPorUnidadOrigenAsync(int unidadOrigenId)
    {
        return await _context.Conversiones
            .Include(c => c.UnidadOrigen)
            .Include(c => c.UnidadDestino)
            .Where(c => c.UnidadOrigenId == unidadOrigenId && c.Activo)
            .OrderBy(c => c.UnidadDestino!.Abreviatura)
            .ToListAsync();
    }

    public async Task<ConversionUnidad?> GetConversionAsync(int unidadOrigenId, int unidadDestinoId)
    {
        return await _context.Conversiones
            .FirstOrDefaultAsync(c => c.UnidadOrigenId == unidadOrigenId
                                   && c.UnidadDestinoId == unidadDestinoId
                                   && c.Activo);
    }
}