using InventarioWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.Interfaces
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetProductosConCategoriaAsync();
        Task<Producto?> GetProductoConCategoriaAsync(int id);
        Task<IEnumerable<Producto>> GetProductosStockBajoAsync();
        Task<bool> CodigoExisteAsync(string codigo, int? excludeId = null);
    }
}
