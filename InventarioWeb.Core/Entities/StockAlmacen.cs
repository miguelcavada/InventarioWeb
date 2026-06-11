using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioWeb.Core.Entities;

public class StockAlmacen : BaseEntity
{
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }

    public int AlmacenId { get; set; }

    [ForeignKey("AlmacenId")]
    public Almacen? Almacen { get; set; }

    [Required]
    [Display(Name = "Stock Actual")]
    public int StockActual { get; set; }

    [Required]
    [Display(Name = "Stock Mínimo")]
    public int StockMinimo { get; set; }

    [Display(Name = "Stock Máximo")]
    public int StockMaximo { get; set; }

    [StringLength(20)]
    [Display(Name = "Ubicación")]
    public string? Ubicacion { get; set; } // Ej: Pasillo A, Estante 3
}