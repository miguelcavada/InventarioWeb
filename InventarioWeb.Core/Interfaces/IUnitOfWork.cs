using InventarioWeb.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductoRepository Productos { get; }
    ICategoriaRepository Categorias { get; }
    IMovimientoRepository Movimientos { get; }
    IProveedorRepository Proveedores { get; }
    IHistorialPrecioRepository HistorialPrecios { get; }
    IAlmacenRepository Almacenes { get; }
    IStockAlmacenRepository StockAlmacenes { get; }
    Task<int> CompleteAsync();
}