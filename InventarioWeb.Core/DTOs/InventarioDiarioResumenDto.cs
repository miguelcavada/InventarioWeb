namespace InventarioWeb.Core.DTOs;

public class InventarioDiarioResumenDto
{
    public int ProductoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Producto { get; set; } = string.Empty;
    public string Unidad { get; set; } = string.Empty;
    public int ExistenciaInicial { get; set; }
    public int Entradas { get; set; }
    public int Ventas { get; set; }        // ← NUEVO
    public int Mermas { get; set; }        // ← NUEVO
    public int Devoluciones { get; set; }  // ← NUEVO
    public int OtrasSalidas { get; set; }  // ← NUEVO
    public int Salidas { get; set; }
    public int ExistenciaFinal { get; set; }
    public decimal PrecioMinorista { get; set; }
    public decimal? PrecioMayorista { get; set; }
    public decimal ValorInventario { get; set; }
    public decimal ValorVentas { get; set; } // ← NUEVO
}