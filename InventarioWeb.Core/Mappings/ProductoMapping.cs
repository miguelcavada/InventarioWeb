using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Mappings;

public static class ProductoMapping
{
    public static ProductoDto ToDto(this Producto producto)
    {
        if (producto == null) return new ProductoDto();

        return new ProductoDto
        {
            Id = producto.Id,
            Codigo = producto.Codigo,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            PrecioCosto = producto.PrecioCosto,
            PrecioVenta = producto.PrecioVenta,
            CategoriaId = producto.CategoriaId,
            CategoriaNombre = producto.Categoria?.Nombre,
            FechaCreacion = producto.FechaCreacion,
            Activo = producto.Activo,

            // Calcular desde los stocks
            StockTotal = producto.Stocks?.Sum(s => s.StockActual) ?? 0,
            StockMinimoTotal = producto.Stocks?.Sum(s => s.StockMinimo) ?? 0,

            MargenGanancia = producto.PrecioCosto.HasValue && producto.PrecioCosto > 0
                ? ((producto.PrecioVenta - producto.PrecioCosto.Value) / producto.PrecioCosto.Value * 100)
                : null,

            ValorInventario = producto.PrecioCosto.HasValue
                ? (producto.Stocks?.Sum(s => s.StockActual) ?? 0) * producto.PrecioCosto.Value
                : null,

            Stocks = producto.Stocks?.Select(s => s.ToDto()).ToList()
        };
    }

    public static Producto ToEntity(this ProductoDto dto)
    {
        return new Producto
        {
            Id = dto.Id,
            Codigo = dto.Codigo,
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            PrecioCosto = dto.PrecioCosto,
            PrecioVenta = dto.PrecioVenta,
            CategoriaId = dto.CategoriaId,
            FechaCreacion = dto.FechaCreacion,
            Activo = dto.Activo
        };
    }

    public static void UpdateEntity(this ProductoDto dto, Producto producto)
    {
        producto.Codigo = dto.Codigo;
        producto.Nombre = dto.Nombre;
        producto.Descripcion = dto.Descripcion;
        producto.PrecioCosto = dto.PrecioCosto;
        producto.PrecioVenta = dto.PrecioVenta;
        producto.CategoriaId = dto.CategoriaId;
        producto.FechaModificacion = DateTime.Now;
    }
}