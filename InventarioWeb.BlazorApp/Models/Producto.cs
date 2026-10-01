namespace InventarioWeb.BlazorApp.Models;

public class Producto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal? PrecioCosto { get; set; }
    public decimal PrecioVentaMinorista { get; set; }
    public decimal? PrecioVentaMayorista { get; set; }
    public int CategoriaId { get; set; }
    public string? CategoriaNombre { get; set; }
    public int UnidadMedidaId { get; set; }
    public string? UnidadMedidaAbreviatura { get; set; }
    public int StockTotal { get; set; }
    public int StockMinimoTotal { get; set; }
    public bool Activo { get; set; }
}

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public int TotalProductos { get; set; }
}

public class Almacen
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string? Codigo { get; set; }
    public string? Direccion { get; set; }
    public string? Encargado { get; set; }
    public int TotalProductos { get; set; }
}

public class Movimiento
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string NumeroDocumento { get; set; } = string.Empty;
    public DateTime FechaMovimiento { get; set; }
    public string? Observacion { get; set; }
    public decimal Total { get; set; }
    public string? AlmacenOrigenNombre { get; set; }
}

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
}