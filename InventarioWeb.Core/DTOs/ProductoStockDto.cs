namespace InventarioWeb.Core.DTOs;

/// <summary>
/// DTO para mostrar productos con su stock en un almacén específico
/// </summary>
public class ProductoStockDto
{
    public int ProductoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public decimal? PrecioCosto { get; set; }
    public decimal PrecioVentaMinorista { get; set; }
    public decimal? PrecioVentaMayorista { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public string? UnidadAbreviatura { get; set; }
    public string? CategoriaNombre { get; set; }

    // Propiedad para mostrar en el combo
    public string DisplayName => $"{Codigo} - {Nombre} (Stock: {StockActual})";
}