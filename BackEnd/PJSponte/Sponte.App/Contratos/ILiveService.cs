using Sponte.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App.Contratos
{
    public interface ILiveService
    {
        Task<LiveDto> AddLive(LiveDto model);
        Task<LiveDto> UpdateLive(int LiveId, LiveDto model);
        Task<bool> DeleteLive(int LiveId);

        ///<summary>Get infors</summary>
        Task<LiveDto[]> GetAllLiveAsync();
        Task<LiveDto[]> GetAllLiveByNomeAsync(string Nome);
        Task<LiveDto> GetAllLiveByIdAsync(int LiveId);

    }
}
