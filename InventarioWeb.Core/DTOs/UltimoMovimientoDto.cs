namespace InventarioWeb.Core.DTOs;

public class UltimoMovimientoDto
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string NumeroDocumento { get; set; } = string.Empty;
    public DateTime FechaMovimiento { get; set; }
    public decimal Total { get; set; }
    public string? AlmacenOrigenNombre { get; set; }
    public string? AlmacenDestinoNombre { get; set; }
}