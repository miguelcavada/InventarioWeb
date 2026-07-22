using InventarioWeb.Application.Common;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Application.Services;

public interface IConsignacionService
{
    Task<Result<IEnumerable<ConsignacionDto>>> GetConsignacionesAsync();
    Task<Result<ConsignacionDto>> GetConsignacionByIdAsync(int id);
    Task<Result<ConsignacionDto>> CreateConsignacionAsync(ConsignacionDto dto);
    Task<Result> RegistrarVentaAsync(RegistrarVentaDto dto);
    Task<Result> RegistrarDevolucionAsync(RegistrarDevolucionDto dto);
    Task<Result<PrecioProductoDto>> ObtenerPrecioProductoAsync(int productoId); // Este método
}

public class ConsignacionService : IConsignacionService
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsignacionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<ConsignacionDto>>> GetConsignacionesAsync()
    {
        try
        {
            var consignaciones = await _unitOfWork.Consignaciones.GetConsignacionesConDetallesAsync();
            var result = consignaciones.Select(c => c.ToDto());
            return Result<IEnumerable<ConsignacionDto>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<ConsignacionDto>>.Failure($"Error al obtener consignaciones: {ex.Message}");
        }
    }

    public async Task<Result<ConsignacionDto>> GetConsignacionByIdAsync(int id)
    {
        try
        {
            var consignacion = await _unitOfWork.Consignaciones.GetConsignacionConDetallesAsync(id);
            if (consignacion == null)
                return Result<ConsignacionDto>.Failure("Consignación no encontrada");

            return Result<ConsignacionDto>.Success(consignacion.ToDto());
        }
        catch (Exception ex)
        {
            return Result<ConsignacionDto>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<ConsignacionDto>> CreateConsignacionAsync(ConsignacionDto dto)
    {
        try
        {
            var consignacion = dto.ToEntity();
            consignacion.Estado = "PENDIENTE";
            consignacion.FechaCreacion = DateTime.Now;
            consignacion.Activo = true;

            var movimientoSalida = new Movimiento
            {
                Tipo = "SALIDA",
                NumeroDocumento = $"SAL-{dto.NumeroConsignacion}",
                FechaMovimiento = dto.FechaEntrega,
                AlmacenOrigenId = dto.AlmacenOrigenId,
                Observacion = $"Salida por consignación #{dto.NumeroConsignacion} - Vendedor: {dto.VendedorNombre}",
                FechaCreacion = DateTime.Now,
                Activo = true,
                Detalles = new List<MovimientoDetalle>()
            };

            foreach (var detalle in consignacion.Detalles)
            {
                var stock = await _unitOfWork.StockAlmacenes
                    .GetStockAsync(detalle.ProductoId, consignacion.AlmacenOrigenId);

                if (stock == null)
                    return Result<ConsignacionDto>.Failure($"No hay stock del producto en este almacén");

                if (stock.StockActual < detalle.CantidadEntregada)
                    return Result<ConsignacionDto>.Failure($"Stock insuficiente. Stock actual: {stock.StockActual}");

                stock.StockActual -= detalle.CantidadEntregada;
                stock.FechaModificacion = DateTime.Now;
                await _unitOfWork.StockAlmacenes.UpdateAsync(stock);

                movimientoSalida.Detalles.Add(new MovimientoDetalle
                {
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.CantidadEntregada,
                    PrecioUnitario = detalle.PrecioUnitario,
                    FechaCreacion = DateTime.Now,
                    Activo = true
                });
            }

            await _unitOfWork.Movimientos.AddAsync(movimientoSalida);
            await _unitOfWork.Consignaciones.AddAsync(consignacion);
            await _unitOfWork.CompleteAsync();

            return Result<ConsignacionDto>.Success(consignacion.ToDto(), "Consignación creada exitosamente");
        }
        catch (Exception ex)
        {
            return Result<ConsignacionDto>.Failure($"Error al crear consignación: {ex.Message}");
        }
    }

    public async Task<Result> RegistrarVentaAsync(RegistrarVentaDto dto)
    {
        try
        {
            var detalle = await _unitOfWork.ConsignacionDetalles.GetByIdAsync(dto.ConsignacionDetalleId);
            if (detalle == null)
                return Result.Failure("Detalle de consignación no encontrado");

            var pendiente = detalle.CantidadEntregada - detalle.CantidadVendida - detalle.CantidadDevuelta;

            if (dto.CantidadVendida > pendiente)
                return Result.Failure($"La cantidad vendida ({dto.CantidadVendida}) supera la pendiente ({pendiente})");

            if (dto.CantidadVendida <= 0)
                return Result.Failure("La cantidad vendida debe ser mayor a 0");

            detalle.CantidadVendida += dto.CantidadVendida;
            detalle.FechaModificacion = DateTime.Now;
            await _unitOfWork.ConsignacionDetalles.UpdateAsync(detalle);

            var consignacion = await _unitOfWork.Consignaciones.GetConsignacionConDetallesAsync(detalle.ConsignacionId);
            if (consignacion != null)
            {
                ActualizarEstadoConsignacion(consignacion);
                await _unitOfWork.Consignaciones.UpdateAsync(consignacion);
            }

            await _unitOfWork.CompleteAsync();
            return Result.Success("Venta registrada exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error al registrar venta: {ex.Message}");
        }
    }

    public async Task<Result> RegistrarDevolucionAsync(RegistrarDevolucionDto dto)
    {
        try
        {
            var detalle = await _unitOfWork.ConsignacionDetalles.GetByIdAsync(dto.ConsignacionDetalleId);
            if (detalle == null)
                return Result.Failure("Detalle de consignación no encontrado");

            var consignacion = await _unitOfWork.Consignaciones.GetConsignacionConDetallesAsync(detalle.ConsignacionId);
            if (consignacion == null)
                return Result.Failure("Consignación no encontrada");

            var pendiente = detalle.CantidadEntregada - detalle.CantidadVendida - detalle.CantidadDevuelta;

            if (dto.CantidadDevuelta > pendiente)
                return Result.Failure($"La cantidad devuelta ({dto.CantidadDevuelta}) supera la pendiente ({pendiente})");

            if (dto.CantidadDevuelta <= 0)
                return Result.Failure("La cantidad devuelta debe ser mayor a 0");

            detalle.CantidadDevuelta += dto.CantidadDevuelta;
            detalle.FechaModificacion = DateTime.Now;
            await _unitOfWork.ConsignacionDetalles.UpdateAsync(detalle);

            var stock = await _unitOfWork.StockAlmacenes
                .GetStockAsync(detalle.ProductoId, consignacion.AlmacenOrigenId);

            if (stock != null)
            {
                stock.StockActual += dto.CantidadDevuelta;
                stock.FechaModificacion = DateTime.Now;
                await _unitOfWork.StockAlmacenes.UpdateAsync(stock);
            }
            else
            {
                stock = new StockAlmacen
                {
                    ProductoId = detalle.ProductoId,
                    AlmacenId = consignacion.AlmacenOrigenId,
                    StockActual = dto.CantidadDevuelta,
                    StockMinimo = 5,
                    StockMaximo = 100,
                    FechaCreacion = DateTime.Now,
                    Activo = true
                };
                await _unitOfWork.StockAlmacenes.AddAsync(stock);
            }

            var movimientoEntrada = new Movimiento
            {
                Tipo = "ENTRADA",
                NumeroDocumento = $"DEV-{consignacion.NumeroConsignacion}-{DateTime.Now:yyyyMMddHHmmss}",
                FechaMovimiento = DateTime.Now,
                AlmacenOrigenId = consignacion.AlmacenOrigenId,
                Observacion = $"Devolución consignación #{consignacion.NumeroConsignacion} - {detalle.Producto?.Nombre}",
                FechaCreacion = DateTime.Now,
                Activo = true,
                Detalles = new List<MovimientoDetalle>
                {
                    new MovimientoDetalle
                    {
                        ProductoId = detalle.ProductoId,
                        Cantidad = dto.CantidadDevuelta,
                        PrecioUnitario = detalle.PrecioUnitario,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    }
                }
            };

            await _unitOfWork.Movimientos.AddAsync(movimientoEntrada);
            ActualizarEstadoConsignacion(consignacion);
            await _unitOfWork.Consignaciones.UpdateAsync(consignacion);

            await _unitOfWork.CompleteAsync();
            return Result.Success("Devolución registrada exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error al registrar devolución: {ex.Message}");
        }
    }

    private void ActualizarEstadoConsignacion(Consignacion consignacion)
    {
        var totalPendiente = consignacion.Detalles?.Sum(d => d.Pendiente) ?? 0;

        if (totalPendiente == 0)
        {
            consignacion.Estado = "COMPLETADA";
            consignacion.FechaDevolucion = DateTime.Now;
        }
        else if (consignacion.Detalles?.Any(d => d.CantidadVendida > 0 || d.CantidadDevuelta > 0) == true)
        {
            consignacion.Estado = "PARCIAL";
        }
        else
        {
            consignacion.Estado = "PENDIENTE";
        }
    }

    public async Task<Result<PrecioProductoDto>> ObtenerPrecioProductoAsync(int productoId)
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(productoId);
            if (producto == null)
                return Result<PrecioProductoDto>.Failure("Producto no encontrado");

            return Result<PrecioProductoDto>.Success(new PrecioProductoDto
            {
                Precio = producto.PrecioVentaMinorista,
                Unidad = producto.UnidadMedida?.Abreviatura ?? "U",
                StockActual = producto.StockTotal
            });
        }
        catch (Exception ex)
        {
            return Result<PrecioProductoDto>.Failure($"Error: {ex.Message}");
        }
    }
}