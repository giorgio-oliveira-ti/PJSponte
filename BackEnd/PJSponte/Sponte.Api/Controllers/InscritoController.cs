using Sponte.App.Contratos;
using Sponte.App.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Sponte.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscritoController : ControllerBase
    {
        private readonly IInscritoService _inscritoService;

        public InscritoController(IInscritoService inscritoService)
        {
            _inscritoService = inscritoService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var inscritos = await _inscritoService.GetAllInscritoAsync();
                if (inscritos == null) return NoContent();
                return Ok(inscritos);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os instrutor. Erro:{ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var inscritos = await _inscritoService.GetAllInscritoByIdAsync(id);
                if (inscritos == null) return NoContent();
                return Ok(inscritos);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os instrutor. Erro:{ex.Message}");
            }
        }

        [HttpGet("{Nome}/Nome")]
        public async Task<IActionResult> GetByNome(string Nome)
        {
            try
            {
                var inscritos = await _inscritoService.GetAllInscritoByNomeAsync(Nome);
                if (inscritos == null) return NoContent();
                return Ok(inscritos);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os instrutor. Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InscritoDto model)
        {
            try
            {
                var inscritos = await _inscritoService.AddInscrito(model);
                if (inscritos == null) return BadRequest("Erro ao tentar adicionar instrutor.");
                return Ok(inscritos);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar os infors. Erro:{ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, InscritoDto model)
        {
            try
            {
                var inscritos = await _inscritoService.UpdateInscrito(Id, model);
                if (inscritos == null) return NoContent();
                return Ok(inscritos);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar os instrutor. Erro:{ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                return await _inscritoService.DeleteInscrito(Id) ? Ok(new { message = "Excluido" }) : BadRequest("instrutor não excluir");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir os instrutor. Erro:{ex.Message}");
            }
        }

    }
}
