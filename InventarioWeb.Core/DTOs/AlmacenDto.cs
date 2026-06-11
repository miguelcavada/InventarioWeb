using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class AlmacenDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Dirección")]
    public string? Direccion { get; set; }

    [Required]
    [Display(Name = "Tipo")]
    public string Tipo { get; set; } = "ALMACEN";

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

    public int TotalProductos { get; set; }
    public decimal ValorInventario { get; set; }
    public bool Activo { get; set; }
}

public class StockAlmacenDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string? ProductoNombre { get; set; }
    public string? ProductoCodigo { get; set; }
    public int AlmacenId { get; set; }
    public string? AlmacenNombre { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
    public string? Ubicacion { get; set; }
}