using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.DTOs
{
    public class ProveedorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? RUC { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; }
    }
}
