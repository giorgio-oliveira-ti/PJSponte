using Sponte.Sdn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.Dt.Contratos
{
    public interface IInscritoDt
    {
        Task<Inscrito[]> GetAllInscritoAsync();
        Task<Inscrito[]> GetAllInscritoByNomeAsync(string Nome);
        Task<Inscrito> GetAllInscritoByIdAsync(int inscritoId);
    }
}
