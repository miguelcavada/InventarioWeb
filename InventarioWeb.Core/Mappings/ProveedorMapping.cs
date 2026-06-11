using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.Mappings
{
    public static class ProveedorMapping
    {
        public static ProveedorDto ToDto(this Proveedor proveedor)
        {
            return new ProveedorDto
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                RUC = proveedor.RUC,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email,
                Activo = proveedor.Activo
            };
        }

        public static Proveedor ToEntity(this ProveedorDto dto)
        {
            return new Proveedor
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                RUC = dto.RUC,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Activo = dto.Activo
            };
        }

        public static void UpdateEntity(this ProveedorDto dto, Proveedor proveedor)
        {
            proveedor.Nombre = dto.Nombre;
            proveedor.RUC = dto.RUC;
            proveedor.Direccion = dto.Direccion;
            proveedor.Telefono = dto.Telefono;
            proveedor.Email = dto.Email;
            proveedor.FechaModificacion = DateTime.Now;
        }
    }
}
