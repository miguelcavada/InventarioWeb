using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioWeb.Core.Entities;

public class Movimiento : BaseEntity
{
    [Required]
    [StringLength(20)]
    public string Tipo { get; set; } = string.Empty; // ENTRADA, SALIDA, TRASLADO

    [Required]
    [StringLength(50)]
    public string NumeroDocumento { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Observacion { get; set; }

    public DateTime FechaMovimiento { get; set; } = DateTime.Now;

    // Para traslados entre almacenes
    public int AlmacenOrigenId { get; set; }

    [ForeignKey("AlmacenOrigenId")]
    public Almacen? AlmacenOrigen { get; set; }

    public int? AlmacenDestinoId { get; set; }

    [ForeignKey("AlmacenDestinoId")]
    public Almacen? AlmacenDestino { get; set; }

    public ICollection<MovimientoDetalle> Detalles { get; set; } = new List<MovimientoDetalle>();

    [NotMapped]
    public decimal Total => Detalles?.Sum(d => d.Subtotal) ?? 0;
}