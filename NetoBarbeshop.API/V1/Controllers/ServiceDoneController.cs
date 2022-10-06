using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetoBarbershop.API.Extensions;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetoBarbershop.API.V1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceDoneController : ControllerBase
    {
        private readonly IServiceDoneApplication _serviceDoneApplication;
        private readonly IAccountApplication _accountApplication;
        public ServiceDoneController(IServiceDoneApplication serviceDoneApplication, IAccountApplication accountApplication)
        {
            _serviceDoneApplication = serviceDoneApplication;
            _accountApplication = accountApplication;
        }

        [HttpGet("todos/{role}")]
        public async Task<ActionResult> Get(string role)
        {
            try
            {
           
                var servicesdones = await _serviceDoneApplication.GetAllServiceDone(User.GetUserId(),role);
                
                if (servicesdones == null) return NoContent();

                return Ok(servicesdones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os serviços realizados. Erro {ex.Message}");
            }
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var servicesdones = await _serviceDoneApplication.GetByIdServiceDone(User.GetUserId(), id);

                if (servicesdones == null) return NoContent();

                return Ok(servicesdones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar o serviço realizado. Erro {ex.Message}");
            }
        }
        [HttpGet("usuario/{username}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetByUsuario(string username)
        {
            try
            {
                var servicesdones = await _serviceDoneApplication.GetByUsuarioServiceDone(username);

                if (servicesdones == null) return NoContent();

                return Ok(servicesdones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os serviços realizados pelo usuario. Erro {ex.Message}");
            }
        }
        [HttpGet("cliente/{nome}")]

        public async Task<ActionResult> GetByCliente(string nome)
        {
            try
            {
                var servicesdones = await _serviceDoneApplication.GetByClienteServiceDone(User.GetUserId(), nome);

                if (servicesdones == null) return NoContent();

                return Ok(servicesdones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar o serviço realizados no cliente. Erro {ex.Message}");
            }
        }
        [HttpGet("cancelado/{cancelado}")]
        public async Task<ActionResult> GetByCancelado(bool cancelado)
        {
            try
            {
                var servicesdones = await _serviceDoneApplication.GetByCanceladoServiceDone(User.GetUserId(), cancelado);

                if (servicesdones == null) return NoContent();

                return Ok(servicesdones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os serviços cancelados. Erro {ex.Message}");
            }
        }
        [HttpGet("finalizado/{finalizado}")]
        public async Task<ActionResult> GetByFinalizado(bool finalizado)
        {
            try
            {
                var servicesdones = await _serviceDoneApplication.GetByFinalizadoServiceDone(User.GetUserId(), finalizado);

                if (servicesdones == null) return NoContent();

                return Ok(servicesdones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os serviços finalizados. Erro {ex.Message}");
            }
        }
        [HttpGet("data/{inicial}/{final}")]
        public async Task<ActionResult> GetByData(DateTime inicial, DateTime final)
        {
            try
            {
                var servicesdones = await _serviceDoneApplication.GetByDataServiceDone(User.GetUserId(), inicial, final);

                if (servicesdones == null) return NoContent();

                return Ok(servicesdones);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os serviços nas datas selecionadas. Erro {ex.Message}");
            }
        }
        [HttpPost("cadastrar")]
        public async Task<ActionResult> Post(ServiceDoneDTO model)
        {
            try
            {
                var resultado = await _serviceDoneApplication.AddServiceDone(model);
                if (resultado == null) return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel cadastrar o serviço realizado. Erro {ex.Message}");
            }
        }
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Put(int id, ServiceDoneDTO model)
        {
            try
            {
                var resultado = await _serviceDoneApplication.UpdateServiceDone(id, model);
                if (resultado == null) return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel alterar o serviço realizado. Erro {ex.Message}");
            }
        }
        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var servicesdones = await _serviceDoneApplication.GetByIdServiceDone(null, id);
                if (servicesdones == null) return NoContent();

                return await _serviceDoneApplication.DeleteServiceDone(id) ? Ok("Deletado") :
                throw new Exception("Não foi possível deletar o Serviço");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel alterar o serviço realizado. Erro {ex.Message}");
            }
        }
    }
}
