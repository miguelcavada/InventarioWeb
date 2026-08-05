using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Mappings;

public static class ConversionUnidadMapping
{
    public static ConversionUnidadDto ToDto(this ConversionUnidad conversion)
    {
        return new ConversionUnidadDto
        {
            Id = conversion.Id,
            UnidadOrigenId = conversion.UnidadOrigenId,
            UnidadOrigenNombre = conversion.UnidadOrigen?.Nombre,
            UnidadOrigenAbreviatura = conversion.UnidadOrigen?.Abreviatura,
            UnidadDestinoId = conversion.UnidadDestinoId,
            UnidadDestinoNombre = conversion.UnidadDestino?.Nombre,
            UnidadDestinoAbreviatura = conversion.UnidadDestino?.Abreviatura,
            Factor = conversion.Factor,
            Descripcion = conversion.Descripcion
        };
    }
}