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

    // Precio de costo (opcional)
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Precio de Costo")]
    public decimal? PrecioCosto { get; set; }

    // Precio de venta al por menor (obligatorio)
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Precio Venta Minorista")]
    public decimal PrecioVentaMinorista { get; set; }

    // Precio de venta al por mayor (opcional)
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Precio Venta Mayorista")]
    public decimal? PrecioVentaMayorista { get; set; }

    // Relaciones
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    public int UnidadMedidaId { get; set; }
    public UnidadMedida? UnidadMedida { get; set; }

    public ICollection<MovimientoDetalle> MovimientosDetalle { get; set; } = new List<MovimientoDetalle>();
    public ICollection<StockAlmacen> Stocks { get; set; } = new List<StockAlmacen>();

    // Propiedades calculadas
    [NotMapped]
    public int StockTotal => Stocks?.Sum(s => s.StockActual) ?? 0;

    [NotMapped]
    public int StockMinimoTotal => Stocks?.Sum(s => s.StockMinimo) ?? 0;

    [NotMapped]
    public decimal? MargenGananciaMinorista => PrecioCosto.HasValue && PrecioCosto > 0
        ? ((PrecioVentaMinorista - PrecioCosto.Value) / PrecioCosto.Value * 100)
        : null;

    [NotMapped]
    public decimal? MargenGananciaMayorista => PrecioCosto.HasValue && PrecioCosto > 0 && PrecioVentaMayorista.HasValue
        ? ((PrecioVentaMayorista.Value - PrecioCosto.Value) / PrecioCosto.Value * 100)
        : null;
}