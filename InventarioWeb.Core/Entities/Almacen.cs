using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.Entities;

public class Almacen : BaseEntity
{
    [Required]
    [StringLength(100)]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Dirección")]
    public string? Direccion { get; set; }

    [StringLength(20)]
    [Display(Name = "Tipo")]
    public string Tipo { get; set; } = "ALMACEN"; // ALMACEN o MERCADO

    [StringLength(50)]
    [Display(Name = "Código")]
    public string? Codigo { get; set; }

    [StringLength(500)]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [StringLength(100)]
    [Display(Name = "Encargado")]
    public string? Encargado { get; set; }

    [StringLength(20)]
    [Display(Name = "Teléfono")]
    public string? Telefono { get; set; }

    [Display(Name = "Activo")]
    public bool Activo { get; set; } = true;

    // Relaciones
    public ICollection<StockAlmacen> Stocks { get; set; } = new List<StockAlmacen>();
    public ICollection<Movimiento> MovimientosOrigen { get; set; } = new List<Movimiento>();
    public ICollection<Movimiento> MovimientosDestino { get; set; } = new List<Movimiento>();
}