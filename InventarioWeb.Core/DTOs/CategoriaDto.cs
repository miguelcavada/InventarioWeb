using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int TotalProductos { get; set; }
        public bool Activo { get; set; }
    }
}
