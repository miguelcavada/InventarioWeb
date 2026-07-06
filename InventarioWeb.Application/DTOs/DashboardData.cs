namespace InventarioWeb.Application.DTOs;

public class DashboardData
{
    public int TotalProductos { get; set; }
    public int ProductosInactivos { get; set; }
    public int StockBajo { get; set; }
    public int TotalEntradas { get; set; }
    public int TotalSalidas { get; set; }
    public int TotalTraslados { get; set; }
    public int TotalAlmacenes { get; set; }
    public decimal ValorInventario { get; set; }
    public List<UltimoMovimientoDto> UltimosMovimientos { get; set; } = new();
}

public class UltimoMovimientoDto
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string NumeroDocumento { get; set; } = string.Empty;
    public DateTime FechaMovimiento { get; set; }
    public decimal Total { get; set; }
}