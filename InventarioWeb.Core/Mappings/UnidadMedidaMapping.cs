using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Mappings;

public static class UnidadMedidaMapping
{
    public static UnidadMedidaDto ToDto(this UnidadMedida unidad)
    {
        if (unidad == null) return new UnidadMedidaDto();

        return new UnidadMedidaDto
        {
            Id = unidad.Id,
            Nombre = unidad.Nombre,
            Abreviatura = unidad.Abreviatura,
            Descripcion = unidad.Descripcion,
            TotalProductos = unidad.Productos?.Count ?? 0,
            Activo = unidad.Activo
        };
    }

    public static UnidadMedida ToEntity(this UnidadMedidaDto dto)
    {
        return new UnidadMedida
        {
            Id = dto.Id,
            Nombre = dto.Nombre,
            Abreviatura = dto.Abreviatura,
            Descripcion = dto.Descripcion,
            Activo = dto.Activo
        };
    }

    public static void UpdateEntity(this UnidadMedidaDto dto, UnidadMedida unidad)
    {
        unidad.Nombre = dto.Nombre;
        unidad.Abreviatura = dto.Abreviatura;
        unidad.Descripcion = dto.Descripcion;
        unidad.FechaModificacion = DateTime.Now;
    }
}