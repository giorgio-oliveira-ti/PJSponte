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
    public class LiveController : ControllerBase
    {

        private readonly ILiveService _liveService;

        public LiveController(ILiveService liveService)
        {
            _liveService = liveService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var lives = await _liveService.GetAllLiveAsync();
                if (lives == null) return NoContent();
                return Ok(lives);

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
                var lives = await _liveService.GetAllLiveByIdAsync(id);
                if (lives == null) return NoContent();
                return Ok(lives);

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
                var lives = await _liveService.GetAllLiveByNomeAsync(Nome);
                if (lives == null) return NoContent();
                return Ok(lives);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar os instrutor. Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(LiveDto model)
        {
            try
            {
                var lives = await _liveService.AddLive(model);
                if (lives == null) return BadRequest("Erro ao tentar adicionar instrutor.");
                return Ok(lives);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar os infors. Erro:{ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, LiveDto model)
        {
            try
            {
                var lives = await _liveService.UpdateLive(Id, model);
                if (lives == null) return NoContent();
                return Ok(lives);

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
                return await _liveService.DeleteLive(Id) ? Ok(new { message = "Excluido" }) : BadRequest("instrutor não excluir");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir os instrutor. Erro:{ex.Message}");
            }
        }

    }
    }
