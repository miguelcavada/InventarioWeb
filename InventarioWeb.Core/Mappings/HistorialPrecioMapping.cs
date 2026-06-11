using InventarioWeb.Core.DTOs;

namespace InventarioWeb.Core.Mappings;

public static class HistorialPrecioMapping
{
    public static HistorialPrecioDto ToDto(this HistorialPrecio historial)
    {
        if (historial == null) return new HistorialPrecioDto();

        return new HistorialPrecioDto
        {
            Id = historial.Id,
            ProductoId = historial.ProductoId,
            ProductoCodigo = historial.Producto?.Codigo,
            ProductoNombre = historial.Producto?.Nombre,
            PrecioCostoAnterior = historial.PrecioCostoAnterior,
            PrecioCostoNuevo = historial.PrecioCostoNuevo,
            PrecioVentaAnterior = historial.PrecioVentaAnterior,
            PrecioVentaNuevo = historial.PrecioVentaNuevo,
            VariacionCosto = CalcularVariacionCosto(historial.PrecioCostoNuevo, historial.PrecioCostoAnterior),
            VariacionVenta = historial.PrecioVentaNuevo - historial.PrecioVentaAnterior,
            PorcentajeVariacion = CalcularPorcentajeVariacion(historial.PrecioVentaAnterior, historial.PrecioVentaNuevo),
            Motivo = historial.Motivo,
            FechaCambio = historial.FechaCambio,
            UsuarioCambio = historial.UsuarioCambio
        };
    }

    private static decimal CalcularVariacionCosto(decimal? nuevo, decimal? anterior)
    {
        if (nuevo.HasValue && anterior.HasValue)
            return nuevo.Value - anterior.Value;
        if (nuevo.HasValue && !anterior.HasValue)
            return nuevo.Value;
        return 0;
    }

    private static decimal CalcularPorcentajeVariacion(decimal anterior, decimal nuevo)
    {
        if (anterior > 0)
            return (nuevo - anterior) / anterior * 100;
        return 0;
    }
}