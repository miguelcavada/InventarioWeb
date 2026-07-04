using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces;

public interface IConsignacionDetalleRepository : IRepository<ConsignacionDetalle>
{
    Task<IEnumerable<ConsignacionDetalle>> GetDetallesPorConsignacionAsync(int consignacionId);
    Task<IEnumerable<ConsignacionDetalle>> GetDetallesPorProductoAsync(int productoId);
    Task<IEnumerable<ConsignacionDetalle>> GetDetallesPendientesAsync();
}