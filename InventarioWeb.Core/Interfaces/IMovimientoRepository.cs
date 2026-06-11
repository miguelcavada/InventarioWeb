using InventarioWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Core.Interfaces
{
    public interface IMovimientoRepository: IRepository<Movimiento>
    {
        Task<Movimiento?> GetMovimientoConDetallesAsync(int id);
        Task<IEnumerable<Movimiento>> GetMovimientosPorTipoAsync(string tipo);
        Task<IEnumerable<Movimiento>> GetMovimientosPorFechaAsync(DateTime desde, DateTime hasta);
    }
}
