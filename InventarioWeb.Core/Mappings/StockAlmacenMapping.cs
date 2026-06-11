using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Mappings;

public static class StockAlmacenMapping
{
    public static StockAlmacenDto ToDto(this StockAlmacen stock)
    {
        if (stock == null) return new StockAlmacenDto();

        return new StockAlmacenDto
        {
            Id = stock.Id,
            ProductoId = stock.ProductoId,
            ProductoNombre = stock.Producto?.Nombre,
            ProductoCodigo = stock.Producto?.Codigo,
            AlmacenId = stock.AlmacenId,
            AlmacenNombre = stock.Almacen?.Nombre,
            StockActual = stock.StockActual,
            StockMinimo = stock.StockMinimo,
            StockMaximo = stock.StockMaximo,
            Ubicacion = stock.Ubicacion
        };
    }
}