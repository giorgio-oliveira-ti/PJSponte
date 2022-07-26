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
    public class InscricaoService : IInscricaoService
    {
        private readonly IGeralDt _geralDt;
        private readonly IInscricaoDt _inscricao;
        private readonly IMapper _imapper;

        public InscricaoService(IGeralDt geralDt, IInscricaoDt _inscricaoDt, IMapper imapper)
        {
            _geralDt = geralDt;
            _inscricao = _inscricaoDt;
            _imapper = imapper;
        }

        public async Task<InscricaoDto[]> GetAllInscricaoAsync()
        {
            try
            {
                var Inscicoes = await _inscricao.GetAllInscricaoAsync();
                if (Inscicoes == null) return null;
                var InscicaoResultado = _imapper.Map<InscricaoDto[]>(Inscicoes);

                return InscicaoResultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       

        public async Task<InscricaoDto> GetAllInscricaoByIdAsync(int inscricaoId)
        {
            try
            {
                var Inscicoes = await _inscricao.GetAllInscricaoByIdAsync(inscricaoId);
                if (Inscicoes == null) return null;
                var inscricaoResultado = _imapper.Map<InscricaoDto>(Inscicoes);

                return inscricaoResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InscricaoDto> AddInscricao(InscricaoDto model)
        {
            try
            {
                var inscricoes = _imapper.Map<Inscricao>(model);
                _geralDt.Add<Inscricao>(inscricoes);
                if (await _geralDt.SaveChangesAsync())
                {
                    var inscricaoResultado = await _inscricao.GetAllInscricaoByIdAsync(inscricoes.Id);
                    return _imapper.Map<InscricaoDto>(inscricaoResultado);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InscricaoDto> UpdateInscricao(int inscricaoId, InscricaoDto model)
        {
            try
            {
                var inscricoes = await _inscricao.GetAllInscricaoByIdAsync(inscricaoId);
                if (inscricoes == null) return null;
                model.Id = inscricoes.Id;

                _imapper.Map(model, inscricoes);
                _geralDt.Update<Inscricao>(inscricoes);

                if (await _geralDt.SaveChangesAsync())
                {
                    var inscricaoResultado = await _inscricao.GetAllInscricaoByIdAsync(inscricoes.Id);
                    return _imapper.Map<InscricaoDto>(inscricaoResultado);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteInscricao(int inscricaoId)
        {
            try
            {
                var inscricoes = await _inscricao.GetAllInscricaoByIdAsync(inscricaoId);
                if (inscricoes == null) throw new Exception("O Instrutor para deletar não foi encontrado.");

                _geralDt.Delete<Inscricao>(inscricoes);

                return await _geralDt.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
