using System.ComponentModel.DataAnnotations;

public class MovimientoDetalleDto
{
    public int Id { get; set; }

    [Required]
    public int ProductoId { get; set; }
    public string? ProductoNombre { get; set; }
    public string? ProductoCodigo { get; set; }

    [Required]
    public decimal Cantidad { get; set; }

    [Required]
    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }
}