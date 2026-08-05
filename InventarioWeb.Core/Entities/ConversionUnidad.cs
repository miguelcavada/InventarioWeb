using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioWeb.Core.Entities;

public class ConversionUnidad : BaseEntity
{
    [Required]
    [Display(Name = "Unidad Origen")]
    public int UnidadOrigenId { get; set; }

    [ForeignKey("UnidadOrigenId")]
    public UnidadMedida? UnidadOrigen { get; set; }

    [Required]
    [Display(Name = "Unidad Destino")]
    public int UnidadDestinoId { get; set; }

    [ForeignKey("UnidadDestinoId")]
    public UnidadMedida? UnidadDestino { get; set; }

    [Required]
    [Display(Name = "Factor de Conversión")]
    [Column(TypeName = "decimal(18,6)")]
    public decimal Factor { get; set; }

    // Ejemplo: Onza → Gramo, Factor = 28.3495
    // Significa: 1 Onza = 28.3495 Gramos
    // Para convertir: cantidad * Factor

    [StringLength(200)]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }
}