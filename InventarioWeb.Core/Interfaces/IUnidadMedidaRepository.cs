using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces;

public interface IUnidadMedidaRepository : IRepository<UnidadMedida>
{
    Task<IEnumerable<UnidadMedida>> GetUnidadesConProductosAsync();
    Task<UnidadMedida?> GetUnidadConProductosAsync(int id);
}