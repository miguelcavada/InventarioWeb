using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces;

public interface IConsignacionRepository : IRepository<Consignacion>
{
    Task<IEnumerable<Consignacion>> GetConsignacionesConDetallesAsync();
    Task<Consignacion?> GetConsignacionConDetallesAsync(int id);
    Task<IEnumerable<Consignacion>> GetConsignacionesPorEstadoAsync(string estado);
    Task<IEnumerable<Consignacion>> GetConsignacionesPorVendedorAsync(string vendedor);
    Task<IEnumerable<Consignacion>> GetConsignacionesPendientesAsync();
}