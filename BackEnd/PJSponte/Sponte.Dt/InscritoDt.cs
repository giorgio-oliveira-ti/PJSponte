using Sponte.Dt.Context;
using Sponte.Dt.Contratos;
using Sponte.Sdn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.Dt
{
    public class InscritoDt : IInscritoDt
    {
        private readonly DContext _context;
        public InscritoDt(DContext context)
        {
            _context = context;

        }

        public async Task<Inscrito[]> GetAllInscritoAsync()
        {
            IQueryable<Inscrito> query = _context.Inscrito;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Inscrito> GetAllInscritoByIdAsync(int inscritoId)
        {
            IQueryable<Inscrito> query = _context.Inscrito;

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == inscritoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Inscrito[]> GetAllInscritoByNomeAsync(string Nome)
        {
            IQueryable<Inscrito> query = _context.Inscrito;

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(Nome.ToLower()));
            return await query.ToArrayAsync();
        }
    }
}
