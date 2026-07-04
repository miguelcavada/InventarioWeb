using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class RegistrarVentaDto
{
    public int ConsignacionDetalleId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    [Display(Name = "Cantidad Vendida")]
    public int CantidadVendida { get; set; }
}

public class RegistrarDevolucionDto
{
    public int ConsignacionDetalleId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    [Display(Name = "Cantidad Devuelta")]
    public int CantidadDevuelta { get; set; }
}