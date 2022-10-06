using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetoBarbershop.API.V1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceApplication _serviceApplication;
        public ServiceController(IServiceApplication serviceApplication)
        {
            _serviceApplication = serviceApplication;
        }
        [HttpGet("todos")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var resultado = await _serviceApplication.GetAllServicesAsync(true);
                if (resultado == null) return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao retorna os serviços. Erro: {ex.Message}");
            }
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var resultado = await _serviceApplication.GetServiceByIdAsync(id, true);
                if (resultado == null) return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao retorna os serviços. Erro: {ex.Message}");
            }
        }
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            try
            {
                var resultado = await _serviceApplication.GetServiceByNomeAsync(nome, true);
                if (resultado == null) return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao retorna os serviços. Erro: {ex.Message}");
            }
        }
        [HttpPost("cadastrar")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Post(ServiceDTO model)
        {
            try
            {
                var service = await _serviceApplication.GetServiceByNomeAsync(model.Nome);
                if (service == null) return NoContent();

                var resultado = await _serviceApplication.AddService(model);
                if (resultado == null) return BadRequest("Erro ao cadastrar usuario, tente novamente!");

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar o serviço. Erro: {ex.Message}");
            }
        }
        [HttpPut("atualizar/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Put(int id, ServiceDTO model)
        {
            try
            {
                var service = await _serviceApplication.GetServiceByIdAsync(id, true);
                if (service == null) return NoContent();

                var resultado = await _serviceApplication.UpdateService(id, model);
                if (resultado == null) return BadRequest("Erro ao alterar produto");

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao alterar o serviço. Erro: {ex.Message}");
            }
        }
        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var service = await _serviceApplication.GetServiceByIdAsync(id, true);
                if (service == null) return NoContent();

                return await _serviceApplication.DeleteService(id) ?
                Ok("Deletado") :
                throw new Exception("Ocorreu um problema não especifico ao tentar deletar o serviço");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o serviço. Erro: {ex.Message}");
            }
        }
    }
}
