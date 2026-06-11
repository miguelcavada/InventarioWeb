namespace InventarioWeb.Core.DTOs;

public class HistorialPrecioDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string? ProductoCodigo { get; set; }
    public string? ProductoNombre { get; set; }
    public decimal? PrecioCostoAnterior { get; set; }
    public decimal? PrecioCostoNuevo { get; set; }
    public decimal PrecioVentaAnterior { get; set; }
    public decimal PrecioVentaNuevo { get; set; }
    public decimal VariacionCosto { get; set; }
    public decimal VariacionVenta { get; set; }
    public decimal PorcentajeVariacion { get; set; }
    public string? Motivo { get; set; }
    public DateTime FechaCambio { get; set; }
    public string? UsuarioCambio { get; set; }
}