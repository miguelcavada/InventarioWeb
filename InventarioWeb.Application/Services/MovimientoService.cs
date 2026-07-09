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
    Task<Result<PrecioProductoDto>> ObtenerPrecioProductoAsync(int productoId, string tipo, string tipoPrecio = "MINORISTA");
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

    //public async Task<Result<MovimientoDto>> CreateMovimientoAsync(MovimientoDto dto)
    //{
    //    try
    //    {
    //        // Validar precios según tipo de movimiento
    //        foreach (var detalle in dto.Detalles)
    //        {
    //            var producto = await _unitOfWork.Productos.GetByIdAsync(detalle.ProductoId);
    //            if (producto == null)
    //                return Result<MovimientoDto>.Failure($"Producto ID {detalle.ProductoId} no encontrado");

    //            // Validar que el precio coincida con el tipo de movimiento
    //            if (dto.Tipo == "ENTRADA" && producto.PrecioCosto.HasValue && producto.PrecioCosto > 0)
    //            {
    //                // Asegurar que se use el precio de costo
    //                detalle.PrecioUnitario = producto.PrecioCosto.Value;
    //            }
    //            else if (dto.Tipo == "SALIDA")
    //            {
    //                // Validar que el precio sea minorista o mayorista
    //                if (detalle.PrecioUnitario != producto.PrecioVentaMinorista &&
    //                    detalle.PrecioUnitario != producto.PrecioVentaMayorista)
    //                {
    //                    // Si no coincide, usar minorista por defecto
    //                    detalle.PrecioUnitario = producto.PrecioVentaMinorista;
    //                }
    //            }
    //        }

    //        var movimiento = dto.ToEntity();
    //        movimiento.FechaCreacion = DateTime.Now;
    //        movimiento.Activo = true;

    //        // ... resto de la lógica de stock ...

    //        await _unitOfWork.Movimientos.AddAsync(movimiento);
    //        await _unitOfWork.CompleteAsync();

    //        return Result<MovimientoDto>.Success(movimiento.ToDto(), "Movimiento registrado exitosamente");
    //    }
    //    catch (Exception ex)
    //    {
    //        return Result<MovimientoDto>.Failure($"Error al crear movimiento: {ex.Message}");
    //    }
    //}

    public async Task<Result<MovimientoDto>> CreateMovimientoAsync(MovimientoDto dto)
    {
        try
        {
            // Validar precios según tipo de movimiento
            foreach (var detalle in dto.Detalles)
            {
                var producto = await _unitOfWork.Productos.GetByIdAsync(detalle.ProductoId);
                if (producto == null)
                    return Result<MovimientoDto>.Failure($"Producto ID {detalle.ProductoId} no encontrado");

                if (dto.Tipo == "ENTRADA" && producto.PrecioCosto.HasValue && producto.PrecioCosto > 0)
                {
                    detalle.PrecioUnitario = producto.PrecioCosto.Value;
                }
                else if (dto.Tipo == "SALIDA")
                {
                    if (detalle.PrecioUnitario != producto.PrecioVentaMinorista &&
                        detalle.PrecioUnitario != producto.PrecioVentaMayorista)
                    {
                        detalle.PrecioUnitario = producto.PrecioVentaMinorista;
                    }
                }
            }

            var movimiento = dto.ToEntity();
            movimiento.FechaCreacion = DateTime.Now;
            movimiento.Activo = true;

            // Actualizar stock para cada detalle
            foreach (var detalle in movimiento.Detalles)
            {
                var stock = await _unitOfWork.StockAlmacenes.GetStockAsync(detalle.ProductoId, movimiento.AlmacenOrigenId);

                if (movimiento.Tipo == "ENTRADA")
                {
                    if (stock == null)
                    {
                        // Crear nuevo stock si no existe
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
                    }
                    else
                    {
                        // AUMENTAR stock existente
                        stock.StockActual += (int)detalle.Cantidad;
                        stock.FechaModificacion = DateTime.Now;
                        await _unitOfWork.StockAlmacenes.UpdateAsync(stock);
                    }
                }
                else if (movimiento.Tipo == "SALIDA")
                {
                    if (stock == null)
                        return Result<MovimientoDto>.Failure($"No hay stock del producto en este almacén");

                    if (stock.StockActual < detalle.Cantidad)
                        return Result<MovimientoDto>.Failure($"Stock insuficiente. Stock actual: {stock.StockActual}");

                    // DISMINUIR stock
                    stock.StockActual -= (int)detalle.Cantidad;
                    stock.FechaModificacion = DateTime.Now;
                    await _unitOfWork.StockAlmacenes.UpdateAsync(stock);
                }
                else if (movimiento.Tipo == "TRASLADO")
                {
                    if (stock == null)
                        return Result<MovimientoDto>.Failure($"No hay stock del producto en el almacén origen");

                    if (stock.StockActual < detalle.Cantidad)
                        return Result<MovimientoDto>.Failure($"Stock insuficiente para traslado. Stock actual: {stock.StockActual}");

                    // DISMINUIR stock del origen
                    stock.StockActual -= (int)detalle.Cantidad;
                    stock.FechaModificacion = DateTime.Now;
                    await _unitOfWork.StockAlmacenes.UpdateAsync(stock);

                    // AUMENTAR stock del destino
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
                    }
                    else
                    {
                        stockDestino.StockActual += (int)detalle.Cantidad;
                        stockDestino.FechaModificacion = DateTime.Now;
                        await _unitOfWork.StockAlmacenes.UpdateAsync(stockDestino);
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

    public async Task<Result<PrecioProductoDto>> ObtenerPrecioProductoAsync(int productoId, string tipo, string tipoPrecio = "MINORISTA")
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetProductoConCategoriaAsync(productoId);

            if (producto == null)
                return Result<PrecioProductoDto>.Failure("Producto no encontrado");

            decimal precio = 0;
            string mensaje = "";

            switch (tipo)
            {
                case "ENTRADA":
                    if (producto.PrecioCosto.HasValue && producto.PrecioCosto > 0)
                    {
                        precio = producto.PrecioCosto.Value;
                    }
                    else
                    {
                        return Result<PrecioProductoDto>.Failure("El producto no tiene precio de costo definido. Ingrese manualmente.");
                    }
                    break;

                case "SALIDA":
                    if (tipoPrecio == "MAYORISTA" && producto.PrecioVentaMayorista.HasValue && producto.PrecioVentaMayorista > 0)
                    {
                        precio = producto.PrecioVentaMayorista.Value;
                        mensaje = "Precio mayorista aplicado";
                    }
                    else if (tipoPrecio == "MAYORISTA" && (!producto.PrecioVentaMayorista.HasValue || producto.PrecioVentaMayorista <= 0))
                    {
                        precio = producto.PrecioVentaMinorista;
                        mensaje = "No tiene precio mayorista. Se aplica precio minorista.";
                    }
                    else
                    {
                        precio = producto.PrecioVentaMinorista;
                    }
                    break;

                case "TRASLADO":
                    if (producto.PrecioCosto.HasValue && producto.PrecioCosto > 0)
                    {
                        precio = producto.PrecioCosto.Value;
                    }
                    else
                    {
                        precio = producto.PrecioVentaMinorista;
                        mensaje = "Sin costo definido. Se usa precio minorista.";
                    }
                    break;

                default:
                    return Result<PrecioProductoDto>.Failure("Tipo de movimiento no válido");
            }

            var result = new PrecioProductoDto
            {
                Precio = precio,
                Unidad = producto.UnidadMedida?.Abreviatura ?? "U",
                StockActual = producto.StockTotal
            };

            return Result<PrecioProductoDto>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<PrecioProductoDto>.Failure($"Error al obtener precio: {ex.Message}");
        }
    }
}