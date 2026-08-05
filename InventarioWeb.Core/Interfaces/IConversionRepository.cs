using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces;

public interface IConversionRepository : IRepository<ConversionUnidad>
{
    Task<IEnumerable<ConversionUnidad>> GetConversionesConUnidadesAsync();
    Task<IEnumerable<ConversionUnidad>> GetConversionesPorUnidadOrigenAsync(int unidadOrigenId);
    Task<ConversionUnidad?> GetConversionAsync(int unidadOrigenId, int unidadDestinoId);
}