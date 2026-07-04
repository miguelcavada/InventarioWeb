using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioWeb.Core.Entities;

public class ConsignacionDetalle : BaseEntity
{
    public int ConsignacionId { get; set; }

    [ForeignKey("ConsignacionId")]
    public Consignacion? Consignacion { get; set; }

    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }

    [Display(Name = "Cantidad Entregada")]
    public int CantidadEntregada { get; set; }

    [Display(Name = "Cantidad Vendida")]
    public int CantidadVendida { get; set; }

    [Display(Name = "Cantidad Devuelta")]
    public int CantidadDevuelta { get; set; }

    [Display(Name = "Precio Unitario")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioUnitario { get; set; }

    [NotMapped]
    [Display(Name = "Pendiente por Vender")]
    public int Pendiente => CantidadEntregada - CantidadVendida - CantidadDevuelta;

    [NotMapped]
    [Display(Name = "Subtotal Vendido")]
    public decimal SubtotalVendido => CantidadVendida * PrecioUnitario;
}