using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.Entities
{
    public class Categoria: BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
