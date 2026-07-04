using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioWeb.Core.Entities;

public class Consignacion : BaseEntity
{
    [Required]
    [StringLength(50)]
    [Display(Name = "Número de Consignación")]
    public string NumeroConsignacion { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Fecha de Entrega")]
    public DateTime FechaEntrega { get; set; } = DateTime.Now;

    [Display(Name = "Fecha de Devolución")]
    public DateTime? FechaDevolucion { get; set; }

    [Required]
    [StringLength(20)]
    [Display(Name = "Estado")]
    public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, PARCIAL, COMPLETADA, CANCELADA

    [Required]
    [Display(Name = "Vendedor")]
    [StringLength(200)]
    public string VendedorNombre { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Contacto")]
    public string? VendedorContacto { get; set; }

    [StringLength(20)]
    [Display(Name = "Teléfono")]
    public string? VendedorTelefono { get; set; }

    [StringLength(500)]
    [Display(Name = "Observaciones")]
    public string? Observaciones { get; set; }

    [Display(Name = "Almacén Origen")]
    public int AlmacenOrigenId { get; set; }

    [ForeignKey("AlmacenOrigenId")]
    public Almacen? AlmacenOrigen { get; set; }

    public ICollection<ConsignacionDetalle> Detalles { get; set; } = new List<ConsignacionDetalle>();

    [NotMapped]
    public int TotalProductos => Detalles?.Sum(d => d.CantidadEntregada) ?? 0;

    [NotMapped]
    public int TotalVendidos => Detalles?.Sum(d => d.CantidadVendida) ?? 0;

    [NotMapped]
    public int TotalDevueltos => Detalles?.Sum(d => d.CantidadDevuelta) ?? 0;

    [NotMapped]
    public decimal TotalValor => Detalles?.Sum(d => d.CantidadEntregada * d.PrecioUnitario) ?? 0;

    [NotMapped]
    public decimal TotalVendidoValor => Detalles?.Sum(d => d.CantidadVendida * d.PrecioUnitario) ?? 0;
}