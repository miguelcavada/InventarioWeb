using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.Mappings
{
    public static class CategoriaMapping
    {
        public static CategoriaDto ToDto(this Categoria categoria)
        {
            return new CategoriaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                TotalProductos = categoria.Productos?.Count ?? 0,
                Activo = categoria.Activo
            };
        }

        public static Categoria ToEntity(this CategoriaDto dto)
        {
            return new Categoria
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Activo = dto.Activo
            };
        }

        public static void UpdateEntity(this CategoriaDto dto, Categoria categoria)
        {
            categoria.Nombre = dto.Nombre;
            categoria.Descripcion = dto.Descripcion;
            categoria.FechaModificacion = DateTime.Now;
        }
    }
}
