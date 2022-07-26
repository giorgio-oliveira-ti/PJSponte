using Sponte.Sdn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.Dt.Contratos
{
    public interface ILiveDt
    {
        Task<Live[]> GetAllLiveAsync();
        Task<Live[]> GetAllLiveNomeAsync(string Nome);
        Task<Live> GetAllLiveByIdAsync(int liveId);
    }
}

