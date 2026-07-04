using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class ConsignacionDto
{
    public int Id { get; set; }

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
    public string Estado { get; set; } = "PENDIENTE";

    [Required]
    [StringLength(200)]
    [Display(Name = "Vendedor")]
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

    [Required]
    [Display(Name = "Almacén Origen")]
    public int AlmacenOrigenId { get; set; }
    public string? AlmacenOrigenNombre { get; set; }

    public int TotalProductos { get; set; }
    public int TotalVendidos { get; set; }
    public int TotalDevueltos { get; set; }
    public decimal TotalValor { get; set; }
    public decimal TotalVendidoValor { get; set; }

    public List<ConsignacionDetalleDto> Detalles { get; set; } = new();
}

public class ConsignacionDetalleDto
{
    public int Id { get; set; }
    public int ConsignacionId { get; set; }

    [Required]
    public int ProductoId { get; set; }
    public string? ProductoNombre { get; set; }
    public string? ProductoCodigo { get; set; }

    [Required]
    [Display(Name = "Cantidad Entregada")]
    public int CantidadEntregada { get; set; }

    [Display(Name = "Cantidad Vendida")]
    public int CantidadVendida { get; set; }

    [Display(Name = "Cantidad Devuelta")]
    public int CantidadDevuelta { get; set; }

    [Required]
    [Display(Name = "Precio Unitario")]
    public decimal PrecioUnitario { get; set; }

    public int Pendiente { get; set; }
    public decimal SubtotalVendido { get; set; }
}