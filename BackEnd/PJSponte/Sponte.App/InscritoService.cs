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
    public class InscritoService : IInscritoService
    {
        private readonly IGeralDt _geralDt;
        private readonly IInscritoDt _inscrito;
        private readonly IMapper _imapper;

        public InscritoService(IGeralDt geralDt, IInscritoDt _inscritDt, IMapper imapper)
        {
            _geralDt = geralDt;
            _inscrito = _inscritDt;
            _imapper = imapper;
        }

        public async Task<InscritoDto[]> GetAllInscritoAsync()
        {
            try
            {
                var Inscritos = await _inscrito.GetAllInscritoAsync();
                if (Inscritos == null) return null;
                var inscritoResultado = _imapper.Map<InscritoDto[]>(Inscritos);

                return inscritoResultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<InscritoDto[]> GetAllInscritoByNomeAsync(string Nome)
        {
            try
            {
                var Inscritos = await _inscrito.GetAllInscritoByNomeAsync(Nome);
                if (Inscritos == null) return null;
                var inscritoResultado = _imapper.Map<InscritoDto[]>(Inscritos);

                return inscritoResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<InscritoDto> GetAllInscritoByIdAsync(int inscritoId)
        {
            try
            {
                var Inscritos = await _inscrito.GetAllInscritoByIdAsync(inscritoId);
                if (Inscritos == null) return null;
                var inscritoResultado = _imapper.Map<InscritoDto>(Inscritos);

                return inscritoResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InscritoDto> AddInscrito(InscritoDto model)
        {
            try
            {
                var inscritos = _imapper.Map<Inscrito>(model);
                _geralDt.Add<Inscrito>(inscritos);
                if (await _geralDt.SaveChangesAsync())
                {
                    var inscritosRetorno = await _inscrito.GetAllInscritoByIdAsync(inscritos.Id);
                    return _imapper.Map<InscritoDto>(inscritosRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InscritoDto> UpdateInscrito(int inscritoId, InscritoDto model)
        {
            try
            {
                var inscritos = await _inscrito.GetAllInscritoByIdAsync(inscritoId);
                if (inscritos == null) return null;
                model.Id = inscritos.Id;

                _imapper.Map(model, inscritos);
                _geralDt.Update<Inscrito>(inscritos);

                if (await _geralDt.SaveChangesAsync())
                {
                    var inscritoRetorno = await _inscrito.GetAllInscritoByIdAsync(inscritos.Id);
                    return _imapper.Map<InscritoDto>(inscritoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteInscrito(int inscritoId)
        {
            try
            {
                var inscritos = await _inscrito.GetAllInscritoByIdAsync(inscritoId);
                if (inscritos == null) throw new Exception("O Instrutor para deletar não foi encontrado.");

                _geralDt.Delete<Inscrito>(inscritos);

                return await _geralDt.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
