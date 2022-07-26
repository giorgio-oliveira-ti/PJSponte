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
    public class InstrutorDt : IInstrutorDt
    {
        private readonly DContext _context;
        public InstrutorDt(DContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Instrutor[]> GetAllInstrutorAsync()
        {
            IQueryable<Instrutor> query = _context.Instrutor;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Instrutor> GetAllInstrutorByIdAsync(int instrutorId)
        {
            IQueryable<Instrutor> query = _context.Instrutor;
              
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == instrutorId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Instrutor[]> GetAllInstrutorByNomeAsync(string Nome)
        {
            IQueryable<Instrutor> query = _context.Instrutor;
           
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(Nome.ToLower()));
            return await query.ToArrayAsync();
        }
    }
}
