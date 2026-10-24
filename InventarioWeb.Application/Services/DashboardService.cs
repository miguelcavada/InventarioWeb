using InventarioWeb.Application.Common;
using InventarioWeb.Core.DTOs;

namespace InventarioWeb.Infrastructure.Services;

public interface IDashboardService
{
    Task<Result<DashboardData>> GetDashboardDataAsync();
}

public class DashboardData
{
    public int TotalProductos { get; set; }
    public int ProductosInactivos { get; set; }
    public int StockBajo { get; set; }
    public int TotalEntradas { get; set; }
    public int TotalSalidas { get; set; }
    public int TotalTraslados { get; set; }
    public int TotalAlmacenes { get; set; }
    public decimal ValorInventario { get; set; }
    public IEnumerable<UltimoMovimientoDto> UltimosMovimientos { get; set; } = new List<UltimoMovimientoDto>();

    // NUEVO: Para el gráfico de categorías
    public IEnumerable<ProductosPorCategoriaDto> ProductosPorCategoria { get; set; } = new List<ProductosPorCategoriaDto>();
}

public class ProductosPorCategoriaDto
{
    public string CategoriaNombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal ValorInventario { get; set; }
}

public class DashboardService : IDashboardService
{
    private readonly IUnitOfWork _unitOfWork;

    public DashboardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DashboardData>> GetDashboardDataAsync()
    {
        try
        {
            var productos = (await _unitOfWork.Productos.GetProductosConCategoriaAsync()).ToList();
            var movimientos = (await _unitOfWork.Movimientos.GetAllAsync()).ToList();
            var almacenes = (await _unitOfWork.Almacenes.GetAlmacenesActivosAsync()).ToList();

            // Productos por categoría (para el gráfico)
            var productosPorCategoria = productos
                .Where(p => p.Activo && p.Categoria != null)
                .GroupBy(p => p.Categoria!.Nombre)
                .Select(g => new ProductosPorCategoriaDto
                {
                    CategoriaNombre = g.Key,
                    Cantidad = g.Count(),
                    ValorInventario = g.Sum(p => p.Stocks.Sum(s => s.StockActual) * (p.PrecioCosto ?? 0))
                })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            var data = new DashboardData
            {
                TotalProductos = productos.Count(p => p.Activo),
                ProductosInactivos = productos.Count(p => !p.Activo),
                StockBajo = productos.Count(p =>
                    p.Activo &&
                    p.Stocks.Any() &&
                    p.Stocks.Sum(s => s.StockActual) <= p.Stocks.Sum(s => s.StockMinimo) &&
                    p.Stocks.Sum(s => s.StockActual) > 0),
                TotalEntradas = movimientos.Count(m => m.Tipo == "ENTRADA"),
                TotalSalidas = movimientos.Count(m => m.Tipo == "SALIDA"),
                TotalTraslados = movimientos.Count(m => m.Tipo == "TRASLADO"),
                TotalAlmacenes = almacenes.Count,
                ValorInventario = productos
                    .Where(p => p.Activo && p.PrecioCosto.HasValue)
                    .Sum(p => p.Stocks.Sum(s => s.StockActual) * (p.PrecioCosto ?? 0)),
                UltimosMovimientos = movimientos
                    .OrderByDescending(m => m.FechaMovimiento)
                    .Take(10)
                    .Select(m => new UltimoMovimientoDto
                    {
                        Id = m.Id,
                        Tipo = m.Tipo,
                        NumeroDocumento = m.NumeroDocumento,
                        FechaMovimiento = m.FechaMovimiento,
                        Total = m.Detalles?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0,
                        AlmacenOrigenNombre = m.AlmacenOrigen?.Nombre,
                        AlmacenDestinoNombre = m.AlmacenDestino?.Nombre
                    })
                    .ToList(),
                ProductosPorCategoria = productosPorCategoria
            };

            return Result<DashboardData>.Success(data);
        }
        catch (Exception ex)
        {
            return Result<DashboardData>.Failure($"Error al obtener dashboard: {ex.Message}");
        }
    }
}