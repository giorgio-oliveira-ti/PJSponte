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
    public class InstrutorService : IIntrutorService
    {
        private readonly IGeralDt _geralDt;
        private readonly IInstrutorDt _instrutorDt;
        private readonly IMapper _imapper;

        public InstrutorService(IGeralDt geralDt, IInstrutorDt instrutorDt, IMapper imapper)
        {
            _geralDt = geralDt;
            _instrutorDt = instrutorDt;
            _imapper = imapper;
        }


        public async Task<InstrutorDto[]> GetAllInstrutorAsync()
        {
            try
            {
                var Instrutors = await _instrutorDt.GetAllInstrutorAsync();
                if (Instrutors == null) return null;
                var instrutorResultado = _imapper.Map<InstrutorDto[]>(Instrutors);

                return instrutorResultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<InstrutorDto[]> GetAllInstrutorByNomeAsync(string Nome)
        {
            try
            {
                var Instrutor = await _instrutorDt.GetAllInstrutorByNomeAsync(Nome);
                if (Instrutor == null) return null;
                var instrutorResultado = _imapper.Map<InstrutorDto[]>(Instrutor);

                return instrutorResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<InstrutorDto> GetAllInstrutorByIdAsync(int InstrutorId)
        {
            try
            {
                var Instrutor = await _instrutorDt.GetAllInstrutorByIdAsync(InstrutorId);
                if (Instrutor == null) return null;
                var instrutorResultado = _imapper.Map<InstrutorDto>(Instrutor);

                return instrutorResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InstrutorDto> AddInstrutor(InstrutorDto model)
        {
            try
            {
                var instrutor = _imapper.Map<Instrutor>(model);
                _geralDt.Add<Instrutor>(instrutor);
                if (await _geralDt.SaveChangesAsync())
                {
                    var instrutorRetorno = await _instrutorDt.GetAllInstrutorByIdAsync(instrutor.Id);
                    return _imapper.Map<InstrutorDto>(instrutorRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InstrutorDto> UpdateInstrutor(int InstrutorId, InstrutorDto model)
        {
            try
            {
                var Instrutor = await _instrutorDt.GetAllInstrutorByIdAsync(InstrutorId);
                if (Instrutor == null) return null;
                model.Id = Instrutor.Id;

                _imapper.Map(model, Instrutor);
                _geralDt.Update<Instrutor>(Instrutor);

                if (await _geralDt.SaveChangesAsync())
                {
                    var instrutorRetorno = await _instrutorDt.GetAllInstrutorByIdAsync(Instrutor.Id);
                    return _imapper.Map<InstrutorDto>(instrutorRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteInstrutor(int InstrutorId)
        {
            try
            {
                var Instrutor = await _instrutorDt.GetAllInstrutorByIdAsync(InstrutorId);
                if (Instrutor == null) throw new Exception("O Instrutor para deletar não foi encontrado.");

                _geralDt.Delete<Instrutor>(Instrutor);

                return await _geralDt.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
