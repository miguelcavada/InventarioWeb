using InventarioWeb.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class HistorialPrecio : BaseEntity
{
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PrecioCostoAnterior { get; set; }  // nullable

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PrecioCostoNuevo { get; set; }      // nullable

    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioVentaAnterior { get; set; }    // NO nullable

    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioVentaNuevo { get; set; }       // NO nullable

    public string? Motivo { get; set; }
    public DateTime FechaCambio { get; set; } = DateTime.Now;
    public string? UsuarioCambio { get; set; }
}