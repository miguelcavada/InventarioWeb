using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.Entities
{
    public class Proveedor: BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(20)]
        public string? RUC { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }
    }
}
