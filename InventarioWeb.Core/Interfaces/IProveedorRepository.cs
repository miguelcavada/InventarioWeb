using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces
{
    public interface IProveedorRepository: IRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> GetProveedoresActivosAsync();
        Task<Proveedor?> GetProveedorConMovimientosAsync(int id);
        Task<bool> RUCExisteAsync(string ruc, int? excludeId = null);
        Task<IEnumerable<Proveedor>> BuscarProveedoresAsync(string termino);
    }
}