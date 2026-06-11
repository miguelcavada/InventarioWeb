using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces;

public interface IAlmacenRepository : IRepository<Almacen>
{
    Task<IEnumerable<Almacen>> GetAlmacenesActivosAsync();
    Task<IEnumerable<Almacen>> GetAlmacenesPorTipoAsync(string tipo);
    Task<Almacen?> GetAlmacenConStocksAsync(int id);
}

public interface IStockAlmacenRepository : IRepository<StockAlmacen>
{
    Task<StockAlmacen?> GetStockAsync(int productoId, int almacenId);
    Task<IEnumerable<StockAlmacen>> GetStocksPorProductoAsync(int productoId);
    Task<IEnumerable<StockAlmacen>> GetStocksPorAlmacenAsync(int almacenId);
    Task<IEnumerable<StockAlmacen>> GetProductosStockBajoAsync(int almacenId);
}