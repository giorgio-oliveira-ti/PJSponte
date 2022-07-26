using Sponte.Dt.Context;
using Sponte.Dt.Contratos;
using Sponte.Sdn;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Sponte.Dt
{
    public class LiveDt : ILiveDt
    {
        private readonly DContext _context;
        public LiveDt(DContext context)
        {
            _context = context;

        }
        public async Task<Live[]> GetAllLiveAsync()
        {
            IQueryable<Live> query = _context.Live;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Live> GetAllLiveByIdAsync(int LiveId)
        {
            IQueryable<Live> query = _context.Live;

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == LiveId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Live[]> GetAllLiveNomeAsync(string Nome)
        {
            IQueryable<Live> query = _context.Live;

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(Nome.ToLower()));
            return await query.ToArrayAsync();
        }

    }
}
