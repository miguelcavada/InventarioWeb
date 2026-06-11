using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class ProductoDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El código es obligatorio")]
    [StringLength(50)]
    [Display(Name = "Código")]
    public string Codigo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(200)]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(1000)]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [Display(Name = "Precio de Costo")]
    public decimal? PrecioCosto { get; set; }

    [Required(ErrorMessage = "El precio de venta es obligatorio")]
    [Display(Name = "Precio de Venta")]
    public decimal PrecioVenta { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria")]
    [Display(Name = "Categoría")]
    public int CategoriaId { get; set; }

    public string? CategoriaNombre { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Activo { get; set; }

    // Propiedades calculadas desde los stocks
    public int StockTotal { get; set; }
    public int StockMinimoTotal { get; set; }
    public decimal? MargenGanancia { get; set; }
    public decimal? ValorInventario { get; set; }
    public List<StockAlmacenDto>? Stocks { get; set; }
}