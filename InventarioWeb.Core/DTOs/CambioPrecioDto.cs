using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioWeb.Core.DTOs;

public class CambioPrecioDto
{
    public int ProductoId { get; set; }

    [Display(Name = "Nuevo Precio de Costo")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? PrecioCostoNuevo { get; set; }

    [Required(ErrorMessage = "El precio de venta es obligatorio")]
    [Display(Name = "Nuevo Precio de Venta")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioVentaNuevo { get; set; }

    [StringLength(500)]
    [Display(Name = "Motivo del Cambio")]
    public string? Motivo { get; set; }
}