using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Mappings;

public static class AlmacenMapping
{
    public static AlmacenDto ToDto(this Almacen almacen)
    {
        if (almacen == null) return new AlmacenDto();

        return new AlmacenDto
        {
            Id = almacen.Id,
            Nombre = almacen.Nombre,
            Codigo = almacen.Codigo,
            Tipo = almacen.Tipo,
            Direccion = almacen.Direccion,
            Descripcion = almacen.Descripcion,
            Encargado = almacen.Encargado,
            Telefono = almacen.Telefono,
            Activo = almacen.Activo,
            TotalProductos = almacen.Stocks?.Count ?? 0,
            ValorInventario = almacen.Stocks?.Sum(s => s.StockActual * (s.Producto?.PrecioCosto ?? 0)) ?? 0
        };
    }

    public static Almacen ToEntity(this AlmacenDto dto)
    {
        return new Almacen
        {
            Id = dto.Id,
            Nombre = dto.Nombre,
            Codigo = dto.Codigo,
            Tipo = dto.Tipo,
            Direccion = dto.Direccion,
            Descripcion = dto.Descripcion,
            Encargado = dto.Encargado,
            Telefono = dto.Telefono,
            Activo = dto.Activo
        };
    }

    public static void UpdateEntity(this AlmacenDto dto, Almacen almacen)
    {
        almacen.Nombre = dto.Nombre;
        almacen.Codigo = dto.Codigo;
        almacen.Tipo = dto.Tipo;
        almacen.Direccion = dto.Direccion;
        almacen.Descripcion = dto.Descripcion;
        almacen.Encargado = dto.Encargado;
        almacen.Telefono = dto.Telefono;
        almacen.FechaModificacion = DateTime.Now;
    }
}