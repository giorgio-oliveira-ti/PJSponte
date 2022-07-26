using Sponte.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App.Contratos
{
    public interface IInscricaoService
    {
        Task<InscricaoDto> AddInscricao(InscricaoDto model);
        Task<InscricaoDto> UpdateInscricao(int inscricaoId, InscricaoDto model);
        Task<bool> DeleteInscricao(int inscricaoId);

        ///<summary>Get infors</summary>
        Task<InscricaoDto[]> GetAllInscricaoAsync();
        Task<InscricaoDto> GetAllInscricaoByIdAsync(int inscricaoId);
    }
}
