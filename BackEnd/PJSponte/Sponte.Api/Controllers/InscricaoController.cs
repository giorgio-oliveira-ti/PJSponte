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
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoService _inscricaoService;

        public InscricaoController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var inscricoes = await _inscricaoService.GetAllInscricaoAsync();
                if (inscricoes == null) return NoContent();
                return Ok(inscricoes);

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
                var inscricoes = await _inscricaoService.GetAllInscricaoByIdAsync(id);
                if (inscricoes == null) return NoContent();
                return Ok(inscricoes);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os instrutor. Erro:{ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(InscricaoDto model)
        {
            try
            {
                var inscricoes = await _inscricaoService.AddInscricao(model);
                if (inscricoes == null) return BadRequest("Erro ao tentar adicionar instrutor.");
                return Ok(inscricoes);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar os infors. Erro:{ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, InscricaoDto model)
        {
            try
            {
                var inscricoes = await _inscricaoService.UpdateInscricao(Id, model);
                if (inscricoes == null) return NoContent();
                return Ok(inscricoes);

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
                return await _inscricaoService.DeleteInscricao(Id) ? Ok(new { message = "Excluido" }) : BadRequest("instrutor não excluir");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir os instrutor. Erro:{ex.Message}");
            }
        }

    }
}
