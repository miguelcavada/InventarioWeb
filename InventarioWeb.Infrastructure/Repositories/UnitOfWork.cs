using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;
using InventarioWeb.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IProductoRepository? _productos;
    private ICategoriaRepository? _categorias;
    private IMovimientoRepository? _movimientos;
    private IProveedorRepository? _proveedores;
    private IHistorialPrecioRepository? _historialPrecios;
    private IAlmacenRepository? _almacenes;
    private IStockAlmacenRepository? _stockAlmacenes;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IProductoRepository Productos =>
        _productos ??= new ProductoRepository(_context);

    public ICategoriaRepository Categorias =>
        _categorias ??= new CategoriaRepository(_context);

    public IMovimientoRepository Movimientos =>
        _movimientos ??= new MovimientoRepository(_context);

    public IProveedorRepository Proveedores =>
        _proveedores ??= new ProveedorRepository(_context);

    public IHistorialPrecioRepository HistorialPrecios =>
        _historialPrecios ??= new HistorialPrecioRepository(_context);

    public IAlmacenRepository Almacenes =>
        _almacenes ??= new AlmacenRepository(_context);

    public IStockAlmacenRepository StockAlmacenes =>
        _stockAlmacenes ??= new StockAlmacenRepository(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}