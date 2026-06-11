using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class MovimientoDto
{
    public int Id { get; set; }

    [Required]
    public string Tipo { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Número de Documento")]
    public string NumeroDocumento { get; set; } = string.Empty;

    [Display(Name = "Observación")]
    public string? Observacion { get; set; }

    [Required]
    [Display(Name = "Fecha")]
    public DateTime FechaMovimiento { get; set; } = DateTime.Now;

    public decimal Total { get; set; }

    [Required]
    [Display(Name = "Almacén Origen")]
    public int AlmacenOrigenId { get; set; }
    public string? AlmacenOrigenNombre { get; set; }

    [Display(Name = "Almacén Destino")]
    public int? AlmacenDestinoId { get; set; }
    public string? AlmacenDestinoNombre { get; set; }

    public List<MovimientoDetalleDto> Detalles { get; set; } = new();
}