using Sponte.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App.Contratos
{
    public interface IIntrutorService
    {
        Task<InstrutorDto> AddInstrutor(InstrutorDto model);
        Task<InstrutorDto> UpdateInstrutor(int InstrutorId, InstrutorDto model);
        Task<bool> DeleteInstrutor(int InstrutorId);

        ///<summary>Get infors</summary>
        Task<InstrutorDto[]> GetAllInstrutorAsync();
        Task<InstrutorDto[]> GetAllInstrutorByNomeAsync(string Nome);
        Task<InstrutorDto> GetAllInstrutorByIdAsync(int InstrutorId);
    }
}
