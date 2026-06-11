using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioWeb.Infrastructure.Repositories
{
    public class MovimientoRepository : Repository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(AppDbContext context) : base(context) { }

        public async Task<Movimiento?> GetMovimientoConDetallesAsync(int id)
        {
            return await _context.Movimientos
                .Include(m => m.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movimiento>> GetMovimientosPorTipoAsync(string tipo)
        {
            return await _context.Movimientos
                .Where(m => m.Tipo == tipo)
                .Include(m => m.Detalles)
                .OrderByDescending(m => m.FechaMovimiento)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetMovimientosPorFechaAsync(DateTime desde, DateTime hasta)
        {
            return await _context.Movimientos
                .Where(m => m.FechaMovimiento >= desde && m.FechaMovimiento <= hasta)
                .Include(m => m.Detalles)
                .OrderByDescending(m => m.FechaMovimiento)
                .ToListAsync();
        }
    }
}
