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
    public class InstrutorController : ControllerBase
    {
        private readonly IIntrutorService _instrutorService;

        public InstrutorController(IIntrutorService instrutorService)
        {
            _instrutorService = instrutorService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var instrutor = await _instrutorService.GetAllInstrutorAsync();
                if (instrutor == null) return NoContent();
                return Ok(instrutor);

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
                var infors = await _instrutorService.GetAllInstrutorByIdAsync(id);
                if (infors == null) return NoContent();
                return Ok(infors);

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
                var infors = await _instrutorService.GetAllInstrutorByNomeAsync(Nome);
                if (infors == null) return NoContent();
                return Ok(infors);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os instrutor. Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InstrutorDto model)
        {
            try
            {
                var instrutor = await _instrutorService.AddInstrutor(model);
                if (instrutor == null) return BadRequest("Erro ao tentar adicionar instrutor.");
                return Ok(instrutor);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar os infors. Erro:{ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, InstrutorDto model)
        {
            try
            {
                var instrutor = await _instrutorService.UpdateInstrutor(Id, model);
                if (instrutor == null) return NoContent();
                return Ok(instrutor);

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
                return await _instrutorService.DeleteInstrutor(Id) ? Ok(new { message = "Excluido" }) : BadRequest("instrutor não excluir");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir os instrutor. Erro:{ex.Message}");
            }
        }

    }
}
