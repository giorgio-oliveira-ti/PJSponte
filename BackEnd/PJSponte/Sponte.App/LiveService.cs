using AutoMapper;
using Sponte.App.Contratos;
using Sponte.App.Dtos;
using Sponte.Dt.Contratos;
using Sponte.Sdn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App
{
    public class LiveService : ILiveService
    {
        private readonly IGeralDt _geralDt;
        private readonly ILiveDt _live;
        private readonly IMapper _imapper;
        public LiveService(IGeralDt geralDt, ILiveDt _liveDt, IMapper imapper)
        {
            _geralDt = geralDt;
            _live = _liveDt;
            _imapper = imapper;
        }

        public async Task<LiveDto[]> GetAllLiveAsync()
        {
            try
            {
                var lives = await _live.GetAllLiveAsync();
                if (lives == null) return null;
                var liveResultado = _imapper.Map<LiveDto[]>(lives);

                return liveResultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<LiveDto[]> GetAllLiveByNomeAsync(string Nome)
        {
            try
            {
                var lives = await _live.GetAllLiveNomeAsync(Nome);
                if (lives == null) return null;
                var liveResultado = _imapper.Map<LiveDto[]>(lives);

                return liveResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<LiveDto> GetAllLiveByIdAsync(int liveId)
        {
            try
            {
                var Lives = await _live.GetAllLiveByIdAsync(liveId);
                if (Lives == null) return null;
                var liveResultado = _imapper.Map<LiveDto>(Lives);

                return liveResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LiveDto> AddLive(LiveDto model)
        {
            try
            {
                var lives = _imapper.Map<Live>(model);
                _geralDt.Add<Live>(lives);
                if (await _geralDt.SaveChangesAsync())
                {
                    var liveRetorno = await _live.GetAllLiveByIdAsync(lives.Id);
                    return _imapper.Map<LiveDto>(liveRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LiveDto> UpdateLive(int LiveId, LiveDto model)
        {
            try
            {
                var lives = await _live.GetAllLiveByIdAsync(LiveId);
                if (lives == null) return null;
                model.Id = lives.Id;

                _imapper.Map(model, lives);
                _geralDt.Update<Live>(lives);

                if (await _geralDt.SaveChangesAsync())
                {
                    var liveRetorno = await _live.GetAllLiveByIdAsync(lives.Id);
                    return _imapper.Map<LiveDto>(liveRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteLive(int liveId)
        {
            try
            {
                var lives = await _live.GetAllLiveByIdAsync(liveId);
                if (lives == null) throw new Exception("O Instrutor para deletar não foi encontrado.");

                _geralDt.Delete<Live>(lives);

                return await _geralDt.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
