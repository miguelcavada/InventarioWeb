using InventarioWeb.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        [Display(Name = "Precio de Costo")]
        public decimal? PrecioCosto { get; set; }

        [Required(ErrorMessage = "El precio de venta minorista es obligatorio")]
        [Display(Name = "Precio Venta Minorista")]
        public decimal PrecioVentaMinorista { get; set; }

        [Display(Name = "Precio Venta Mayorista")]
        public decimal? PrecioVentaMayorista { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int CategoriaId { get; set; }
        public string? CategoriaNombre { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria")]
        public int UnidadMedidaId { get; set; }
        public string? UnidadMedidaNombre { get; set; }
        public string? UnidadMedidaAbreviatura { get; set; }

        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int StockTotal { get; set; }
        public int StockMinimoTotal { get; set; }
        public decimal? MargenGananciaMinorista { get; set; }
        public decimal? MargenGananciaMayorista { get; set; }
        public decimal? ValorInventario { get; set; }
        public List<StockAlmacenDto>? Stocks { get; set; }
    }
}

    