using InventarioWeb.Core.Entities;

namespace InventarioWeb.Core.Interfaces
{
    public interface ICategoriaRepository: IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriasConProductosAsync();
        Task<Categoria?> GetCategoriaConProductosAsync(int id);
    }
}