using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class UnidadMedidaDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    [Display(Name = "Abreviatura")]
    public string Abreviatura { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    public int TotalProductos { get; set; }
    public bool Activo { get; set; }
}