using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Mappings;

public static class MovimientoMapping
{
    public static MovimientoDto ToDto(this Movimiento movimiento)
    {
        if (movimiento == null) return new MovimientoDto();

        return new MovimientoDto
        {
            Id = movimiento.Id,
            Tipo = movimiento.Tipo,
            NumeroDocumento = movimiento.NumeroDocumento,
            Observacion = movimiento.Observacion,
            FechaMovimiento = movimiento.FechaMovimiento,
            Total = movimiento.Total,
            AlmacenOrigenId = movimiento.AlmacenOrigenId,
            AlmacenOrigenNombre = movimiento.AlmacenOrigen?.Nombre,
            AlmacenDestinoId = movimiento.AlmacenDestinoId,
            AlmacenDestinoNombre = movimiento.AlmacenDestino?.Nombre,
            Detalles = movimiento.Detalles?.Select(d => d.ToDto()).ToList() ?? new List<MovimientoDetalleDto>()
        };
    }

    public static Movimiento ToEntity(this MovimientoDto dto)
    {
        if (dto == null) return new Movimiento();

        return new Movimiento
        {
            Id = dto.Id,
            Tipo = dto.Tipo,
            NumeroDocumento = dto.NumeroDocumento,
            Observacion = dto.Observacion,
            FechaMovimiento = dto.FechaMovimiento,
            AlmacenOrigenId = dto.AlmacenOrigenId,
            AlmacenDestinoId = dto.AlmacenDestinoId,
            Detalles = dto.Detalles?.Select(d => d.ToEntity()).ToList() ?? new List<MovimientoDetalle>()
        };
    }

    public static MovimientoDetalleDto ToDto(this MovimientoDetalle detalle)
    {
        if (detalle == null) return new MovimientoDetalleDto();

        return new MovimientoDetalleDto
        {
            Id = detalle.Id,
            ProductoId = detalle.ProductoId,
            ProductoNombre = detalle.Producto?.Nombre,
            ProductoCodigo = detalle.Producto?.Codigo,
            Cantidad = detalle.Cantidad,
            PrecioUnitario = detalle.PrecioUnitario,
            Subtotal = detalle.Subtotal
        };
    }

    public static MovimientoDetalle ToEntity(this MovimientoDetalleDto dto)
    {
        if (dto == null) return new MovimientoDetalle();

        return new MovimientoDetalle
        {
            Id = dto.Id,
            ProductoId = dto.ProductoId,
            Cantidad = dto.Cantidad,
            PrecioUnitario = dto.PrecioUnitario
        };
    }
}