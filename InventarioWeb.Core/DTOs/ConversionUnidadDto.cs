using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class ConversionUnidadDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La unidad origen es obligatoria")]
    [Display(Name = "Unidad Origen")]
    public int UnidadOrigenId { get; set; }
    public string? UnidadOrigenNombre { get; set; }
    public string? UnidadOrigenAbreviatura { get; set; }

    [Required(ErrorMessage = "La unidad destino es obligatoria")]
    [Display(Name = "Unidad Destino")]
    public int UnidadDestinoId { get; set; }
    public string? UnidadDestinoNombre { get; set; }
    public string? UnidadDestinoAbreviatura { get; set; }

    [Required(ErrorMessage = "El factor es obligatorio")]
    [Display(Name = "Factor de Conversión")]
    [Range(0.000001, 999999, ErrorMessage = "Factor debe ser mayor a 0")]
    public decimal Factor { get; set; }

    [StringLength(200)]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }
}

public class ConvertirCantidadDto
{
    [Required]
    [Display(Name = "Unidad Origen")]
    public int UnidadOrigenId { get; set; }

    [Required]
    [Display(Name = "Unidad Destino")]
    public int UnidadDestinoId { get; set; }

    [Required]
    [Range(0.01, 999999)]
    [Display(Name = "Cantidad")]
    public decimal Cantidad { get; set; }
}

public class ConversionResultadoDto
{
    public decimal CantidadOriginal { get; set; }
    public string UnidadOrigen { get; set; } = string.Empty;
    public decimal CantidadConvertida { get; set; }
    public string UnidadDestino { get; set; } = string.Empty;
    public decimal Factor { get; set; }
    public string Formula { get; set; } = string.Empty;
}