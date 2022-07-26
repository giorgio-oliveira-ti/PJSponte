using Sponte.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App.Contratos
{
    public interface IInscritoService
    {
        Task<InscritoDto> AddInscrito(InscritoDto model);
        Task<InscritoDto> UpdateInscrito(int inscritoId, InscritoDto model);
        Task<bool> DeleteInscrito(int inscritoId);

        ///<summary>Get infors</summary>
        Task<InscritoDto[]> GetAllInscritoAsync();
        Task<InscritoDto[]> GetAllInscritoByNomeAsync(string Nome);
        Task<InscritoDto> GetAllInscritoByIdAsync(int inscritoId);
    }
}
