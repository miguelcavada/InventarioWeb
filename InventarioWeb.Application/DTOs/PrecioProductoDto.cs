namespace InventarioWeb.Core.DTOs;

public class PrecioProductoDto
{
    public decimal Precio { get; set; }
    public string Unidad { get; set; } = string.Empty;
    public int StockActual { get; set; }
}