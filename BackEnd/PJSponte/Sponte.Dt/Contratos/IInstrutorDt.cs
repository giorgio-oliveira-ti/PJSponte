using Sponte.Sdn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.Dt.Contratos
{
    public interface IInstrutorDt
    {
        Task<Instrutor[]> GetAllInstrutorAsync();
        Task<Instrutor[]> GetAllInstrutorByNomeAsync(string Nome);
        Task<Instrutor> GetAllInstrutorByIdAsync(int instrutorId);
    }
}
