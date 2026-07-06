using InventarioWeb.Application.Common;
using InventarioWeb.Application.DTOs;
using InventarioWeb.Core.Interfaces;

namespace InventarioWeb.Application.Services;

public interface IDashboardService
{
    Task<Result<DashboardData>> GetDashboardDataAsync();
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
            var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();
            var movimientos = await _unitOfWork.Movimientos.GetAllAsync();
            var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();

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
                TotalAlmacenes = almacenes.Count(),
                ValorInventario = productos
                    .Where(p => p.Activo && p.PrecioCosto.HasValue)
                    .Sum(p => p.Stocks.Sum(s => s.StockActual) * (p.PrecioCosto ?? 0)),
                UltimosMovimientos = movimientos
                    .OrderByDescending(m => m.FechaMovimiento)
                    .Take(5)
                    .Select(m => new UltimoMovimientoDto
                    {
                        Id = m.Id,
                        Tipo = m.Tipo,
                        NumeroDocumento = m.NumeroDocumento,
                        FechaMovimiento = m.FechaMovimiento,
                        Total = m.Detalles?.Sum(d => d.Cantidad * d.PrecioUnitario) ?? 0
                    })
                    .ToList()
            };

            return Result<DashboardData>.Success(data);
        }
        catch (Exception ex)
        {
            return Result<DashboardData>.Failure($"Error al obtener dashboard: {ex.Message}");
        }
    }
}