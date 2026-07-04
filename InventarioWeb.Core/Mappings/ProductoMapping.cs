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
            PrecioVentaMinorista = producto.PrecioVentaMinorista,
            PrecioVentaMayorista = producto.PrecioVentaMayorista,
            CategoriaId = producto.CategoriaId,
            CategoriaNombre = producto.Categoria?.Nombre,
            UnidadMedidaId = producto.UnidadMedidaId,
            UnidadMedidaNombre = producto.UnidadMedida?.Nombre,
            UnidadMedidaAbreviatura = producto.UnidadMedida?.Abreviatura,
            FechaCreacion = producto.FechaCreacion,
            Activo = producto.Activo,
            StockTotal = producto.Stocks?.Sum(s => s.StockActual) ?? 0,
            StockMinimoTotal = producto.Stocks?.Sum(s => s.StockMinimo) ?? 0,
            MargenGananciaMinorista = producto.MargenGananciaMinorista,
            MargenGananciaMayorista = producto.MargenGananciaMayorista,
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
            PrecioVentaMinorista = dto.PrecioVentaMinorista,
            PrecioVentaMayorista = dto.PrecioVentaMayorista,
            CategoriaId = dto.CategoriaId,
            UnidadMedidaId = dto.UnidadMedidaId,
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
        producto.PrecioVentaMinorista = dto.PrecioVentaMinorista;
        producto.PrecioVentaMayorista = dto.PrecioVentaMayorista;
        producto.CategoriaId = dto.CategoriaId;
        producto.UnidadMedidaId = dto.UnidadMedidaId;
        producto.FechaModificacion = DateTime.Now;
    }
}