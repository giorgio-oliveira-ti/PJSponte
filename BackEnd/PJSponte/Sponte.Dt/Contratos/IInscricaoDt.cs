using Sponte.Sdn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.Dt.Contratos
{
    public interface IInscricaoDt
    {
        Task<Inscricao[]> GetAllInscricaoAsync();
        Task<Inscricao> GetAllInscricaoByIdAsync(int inscricaoId);
    }
}
