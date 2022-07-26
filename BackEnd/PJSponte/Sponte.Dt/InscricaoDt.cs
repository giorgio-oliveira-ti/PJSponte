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
    public class InscricaoDt : IInscricaoDt
    {

        private readonly DContext _context;
        public InscricaoDt(DContext context)
        {
            _context = context;

        }


        public async Task<Inscricao[]> GetAllInscricaoAsync()
        {
            IQueryable<Inscricao> query = _context.Inscricao;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Inscricao> GetAllInscricaoByIdAsync(int inscricaoId)
        {
            IQueryable<Inscricao> query = _context.Inscricao;

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == inscricaoId);
            return await query.FirstOrDefaultAsync();
        }

    }
}
