using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces;

public interface IHistorialPrecioRepository : IRepository<HistorialPrecio>
{
    Task<IEnumerable<HistorialPrecio>> GetHistorialPorProductoAsync(int productoId);
    Task<IEnumerable<HistorialPrecio>> GetHistorialPorFechaAsync(DateTime desde, DateTime hasta);
    Task<IEnumerable<HistorialPrecio>> GetUltimosCambiosAsync(int cantidad = 10);
    Task<IEnumerable<HistorialPrecio>> GetHistorialCompletoAsync(DateTime? desde = null, DateTime? hasta = null, string? usuario = null);
}