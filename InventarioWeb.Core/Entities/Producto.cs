using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioWeb.Core.Entities;

public class Producto : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PrecioCosto { get; set; }  // nullable

    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioVenta { get; set; }   // NO nullable

    // Relaciones
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public ICollection<MovimientoDetalle> MovimientosDetalle { get; set; } = new List<MovimientoDetalle>();

    // Agregar relación a stocks
    public ICollection<StockAlmacen> Stocks { get; set; } = new List<StockAlmacen>();

    // Propiedades calculadas
    [NotMapped]
    public int StockTotal => Stocks?.Sum(s => s.StockActual) ?? 0;

    [NotMapped]
    public int StockMinimoTotal => Stocks?.Sum(s => s.StockMinimo) ?? 0;

    // Propiedad calculada para el margen
    [NotMapped]
    public decimal? MargenGanancia => PrecioCosto.HasValue && PrecioCosto > 0
        ? ((PrecioVenta - PrecioCosto.Value) / PrecioCosto.Value * 100)
        : null;
}