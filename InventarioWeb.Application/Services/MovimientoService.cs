using InventarioWeb.Application.Common;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Infrastructure.Services;

public interface IMovimientoService
{
    Task<Result<IEnumerable<MovimientoDto>>> GetMovimientosAsync(string tipo = "TODOS", DateTime? desde = null, DateTime? hasta = null);
    Task<Result<MovimientoDto>> GetMovimientoByIdAsync(int id);
    Task<Result<MovimientoDto>> CreateMovimientoAsync(MovimientoDto dto);
}

public class MovimientoService : IMovimientoService
{
    private readonly IUnitOfWork _unitOfWork;

    public MovimientoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<MovimientoDto>>> GetMovimientosAsync(string tipo = "TODOS", DateTime? desde = null, DateTime? hasta = null)
    {
        try
        {
            IEnumerable<Movimiento> movimientos;

            if (desde.HasValue && hasta.HasValue)
                movimientos = await _unitOfWork.Movimientos.GetMovimientosPorFechaAsync(desde.Value, hasta.Value);
            else if (tipo != "TODOS")
                movimientos = await _unitOfWork.Movimientos.GetMovimientosPorTipoAsync(tipo);
            else
                movimientos = await _unitOfWork.Movimientos.GetAllAsync();

            var result = movimientos.OrderByDescending(m => m.FechaMovimiento).Select(m => m.ToDto());
            return Result<IEnumerable<MovimientoDto>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<MovimientoDto>>.Failure($"Error al obtener movimientos: {ex.Message}");
        }
    }

    public async Task<Result<MovimientoDto>> GetMovimientoByIdAsync(int id)
    {
        try
        {
            var movimiento = await _unitOfWork.Movimientos.GetMovimientoConDetallesAsync(id);
            if (movimiento == null)
                return Result<MovimientoDto>.Failure("Movimiento no encontrado");

            return Result<MovimientoDto>.Success(movimiento.ToDto());
        }
        catch (Exception ex)
        {
            return Result<MovimientoDto>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<MovimientoDto>> CreateMovimientoAsync(MovimientoDto dto)
    {
        try
        {
            var movimiento = dto.ToEntity();
            movimiento.FechaCreacion = DateTime.Now;
            movimiento.Activo = true;

            foreach (var detalle in movimiento.Detalles)
            {
                var stock = await _unitOfWork.StockAlmacenes.GetStockAsync(detalle.ProductoId, movimiento.AlmacenOrigenId);

                if (movimiento.Tipo == "ENTRADA")
                {
                    if (stock == null)
                    {
                        stock = new StockAlmacen
                        {
                            ProductoId = detalle.ProductoId,
                            AlmacenId = movimiento.AlmacenOrigenId,
                            StockActual = (int)detalle.Cantidad,
                            StockMinimo = 5,
                            StockMaximo = 100,
                            FechaCreacion = DateTime.Now,
                            Activo = true
                        };
                        await _unitOfWork.StockAlmacenes.AddAsync(stock);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                    {
                        stock.StockActual += (int)detalle.Cantidad;
                        stock.FechaModificacion = DateTime.Now;
                    }
                }
                else if (movimiento.Tipo == "SALIDA")
                {
                    if (stock == null || stock.StockActual < detalle.Cantidad)
                        return Result<MovimientoDto>.Failure($"Stock insuficiente en el almacén");

                    stock.StockActual -= (int)detalle.Cantidad;
                    stock.FechaModificacion = DateTime.Now;
                }
                else if (movimiento.Tipo == "TRASLADO")
                {
                    if (stock == null || stock.StockActual < detalle.Cantidad)
                        return Result<MovimientoDto>.Failure("Stock insuficiente para traslado");

                    stock.StockActual -= (int)detalle.Cantidad;
                    stock.FechaModificacion = DateTime.Now;

                    var stockDestino = await _unitOfWork.StockAlmacenes.GetStockAsync(detalle.ProductoId, movimiento.AlmacenDestinoId!.Value);
                    if (stockDestino == null)
                    {
                        stockDestino = new StockAlmacen
                        {
                            ProductoId = detalle.ProductoId,
                            AlmacenId = movimiento.AlmacenDestinoId!.Value,
                            StockActual = (int)detalle.Cantidad,
                            StockMinimo = 5,
                            StockMaximo = 100,
                            FechaCreacion = DateTime.Now,
                            Activo = true
                        };
                        await _unitOfWork.StockAlmacenes.AddAsync(stockDestino);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                    {
                        stockDestino.StockActual += (int)detalle.Cantidad;
                        stockDestino.FechaModificacion = DateTime.Now;
                    }
                }
            }

            await _unitOfWork.Movimientos.AddAsync(movimiento);
            await _unitOfWork.CompleteAsync();

            return Result<MovimientoDto>.Success(movimiento.ToDto(), "Movimiento registrado exitosamente");
        }
        catch (Exception ex)
        {
            return Result<MovimientoDto>.Failure($"Error al crear movimiento: {ex.Message}");
        }
    }
}