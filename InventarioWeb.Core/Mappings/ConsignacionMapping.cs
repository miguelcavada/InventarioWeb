using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Mappings;

public static class ConsignacionMapping
{
    public static ConsignacionDto ToDto(this Consignacion consignacion)
    {
        if (consignacion == null) return new ConsignacionDto();

        return new ConsignacionDto
        {
            Id = consignacion.Id,
            NumeroConsignacion = consignacion.NumeroConsignacion,
            FechaEntrega = consignacion.FechaEntrega,
            FechaDevolucion = consignacion.FechaDevolucion,
            Estado = consignacion.Estado,
            VendedorNombre = consignacion.VendedorNombre,
            VendedorContacto = consignacion.VendedorContacto,
            VendedorTelefono = consignacion.VendedorTelefono,
            Observaciones = consignacion.Observaciones,
            AlmacenOrigenId = consignacion.AlmacenOrigenId,
            AlmacenOrigenNombre = consignacion.AlmacenOrigen?.Nombre,
            TotalProductos = consignacion.TotalProductos,
            TotalVendidos = consignacion.TotalVendidos,
            TotalDevueltos = consignacion.TotalDevueltos,
            TotalValor = consignacion.TotalValor,
            TotalVendidoValor = consignacion.TotalVendidoValor,
            Detalles = consignacion.Detalles?.Select(d => d.ToDto()).ToList() ?? new()
        };
    }

    public static Consignacion ToEntity(this ConsignacionDto dto)
    {
        if (dto == null) return new Consignacion();

        return new Consignacion
        {
            Id = dto.Id,
            NumeroConsignacion = dto.NumeroConsignacion,
            FechaEntrega = dto.FechaEntrega,
            FechaDevolucion = dto.FechaDevolucion,
            Estado = dto.Estado,
            VendedorNombre = dto.VendedorNombre,
            VendedorContacto = dto.VendedorContacto,
            VendedorTelefono = dto.VendedorTelefono,
            Observaciones = dto.Observaciones,
            AlmacenOrigenId = dto.AlmacenOrigenId,
            Detalles = dto.Detalles?.Select(d => d.ToEntity()).ToList() ?? new()
        };
    }

    public static ConsignacionDetalleDto ToDto(this ConsignacionDetalle detalle)
    {
        if (detalle == null) return new ConsignacionDetalleDto();

        return new ConsignacionDetalleDto
        {
            Id = detalle.Id,
            ConsignacionId = detalle.ConsignacionId,
            ProductoId = detalle.ProductoId,
            ProductoNombre = detalle.Producto?.Nombre,
            ProductoCodigo = detalle.Producto?.Codigo,
            CantidadEntregada = detalle.CantidadEntregada,
            CantidadVendida = detalle.CantidadVendida,
            CantidadDevuelta = detalle.CantidadDevuelta,
            PrecioUnitario = detalle.PrecioUnitario,
            Pendiente = detalle.Pendiente,
            SubtotalVendido = detalle.SubtotalVendido
        };
    }

    public static ConsignacionDetalle ToEntity(this ConsignacionDetalleDto dto)
    {
        if (dto == null) return new ConsignacionDetalle();

        return new ConsignacionDetalle
        {
            Id = dto.Id,
            ConsignacionId = dto.ConsignacionId,
            ProductoId = dto.ProductoId,
            CantidadEntregada = dto.CantidadEntregada,
            CantidadVendida = dto.CantidadVendida,
            CantidadDevuelta = dto.CantidadDevuelta,
            PrecioUnitario = dto.PrecioUnitario
        };
    }
}