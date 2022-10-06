using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetoBarbershop.API.Extensions;
using NetoBarbershop.Application;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetoBarbershop.API.V1.Controllers
{


    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenApplication _tokenApplication;
        private readonly IAccountApplication _accountApplication;
        public AccountController(IAccountApplication accountApplication, ITokenApplication tokenApplication)
        {
            _tokenApplication = tokenApplication;
            _accountApplication = accountApplication;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

                var usuario = await _accountApplication.GetUserByEmailAsync(loginDTO.Email, false);
                if (usuario == null) return Unauthorized("Email Incorreto");

                var result = await _accountApplication.CheckUserPasswordAsync(usuario, loginDTO.Senha);
                if (!result.Succeeded) return Unauthorized("Senha Incorreta");

                var dados = await _tokenApplication.CreateToken(loginDTO.Email);

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os usuarios. Erro {ex.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            try
            {
                var usuario = await _accountApplication.GetUserByNomeAsync(nome, false);
                if (usuario == null) return Unauthorized("Usuario Inválido");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar o usuario. Erro {ex.Message}");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetById()
        {
            try
            {
                var usuario_id = User.GetUserId();
                var usuario = await _accountApplication.GetUserByIdAsync(usuario_id, false);
                if (usuario == null) return Unauthorized("Usuario Inválido");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar o usuario. Erro {ex.Message}");
            }
        }
        [HttpGet("email/{email}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            try
            {
                var usuario = await _accountApplication.GetUserByEmailAsync(email, false);
                if (usuario == null) return Unauthorized("Usuario Inválido");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar o usuario. Erro {ex.Message}");
            }
        }
        [HttpGet("usuarios")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var usuario = await _accountApplication.GetAllUsers(false);
                if (usuario == null) return NoContent();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os usuarios. Erro {ex.Message}");
            }
        }
        [HttpPost("cadastrar")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Cadastrar([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

                if (await _accountApplication.UserExists(usuarioDTO.Email))
                    return BadRequest("Usuario já está cadastrado");

                var usuario = await _accountApplication.CreateAccountAsync(usuarioDTO);

                if (usuario == null) return BadRequest("Usuario não cadastrado, tente novamente mais tarde!");

                var dados = await _tokenApplication.CreateToken(usuarioDTO.Email);

                return Ok(dados);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel retornar os usuarios. Erro {ex.Message}");
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult> Alterar(UpdateUserDTO updateUserDTO)
        {
            try
            {
                if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

                var usuario = await _accountApplication.GetUserByEmailAsync(User.GetUserName(), false);
                if (usuario == null) return Unauthorized("Usuario Inválido");

                updateUserDTO.Email = usuario.Email;

                var usuario_retorno = await _accountApplication.UpdateAccount(updateUserDTO);

                if (usuario_retorno == null) return NoContent();

                //var dados = await _tokenApplication.CreateToken(usuario_retorno.Email);

                return Ok(usuario_retorno);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel alterar o usuario. Erro {ex.Message}");
            }
        }
        [HttpPut("update/username")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Alterar(UpdateUserDTO updateUserDTO, string username)
        {
            try
            {
                if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

                var usuario = await _accountApplication.GetUserByEmailAsync(username, false);
                if (usuario == null) return Unauthorized("Usuario Inválido");

                updateUserDTO.Email = usuario.Email;

                var usuario_retorno = await _accountApplication.UpdateAccount(updateUserDTO);

                if (usuario_retorno == null) return NoContent();

                return Ok(usuario_retorno);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel alterar o usuario. Erro {ex.Message}");
            }
        }
        [HttpGet("resetpassword/{id}/{senha}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> ResetPassword(string id,string senha)
        {
            try
            {

                var usuario = await _accountApplication.GetUserByIdAsync(id, false);
                if (usuario == null) return Unauthorized("Usuario Inválido");       

                var alterado = await _accountApplication.ResetPassword(id,senha);

                if (alterado == false) return NoContent();

                return Ok(alterado);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel alterar o usuario. Erro {ex.Message}");
            }
        }
        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delele(string id)
        {
            try
            {
             
                var usuario = await _accountApplication.GetUserByIdAsync(id, false);
                if (usuario == null) return Unauthorized("Usuario Inválido");

               return await _accountApplication.DeleteAccount(id) ? Ok("Deletado") :
               throw new Exception("Não foi possível deletar o Usuario");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel alterar o usuario. Erro {ex.Message}");
            }
        }
        [HttpPost("addfuncao")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddRole(string role)
        {
            try
            {
                var roleadd = _accountApplication.AddRole(role);
                if (roleadd.IsCompletedSuccessfully) return Ok(roleadd.Result);

                return BadRequest("Não foi possível cadastrar a função");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel adiconar a função. Erro {ex.Message}");
            }
        }
        [HttpPut("UpdateRoleUser")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> UpdateRoleUser(UserRoleDTO userRoleDTO)
        {
            try
            {
                var roleadd = _accountApplication.UpdateRoleUser(userRoleDTO);
                if (roleadd.IsCompletedSuccessfully) return Ok(roleadd.Result);

                return BadRequest("Não foi possível alterar a função");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel adiconar a função. Erro {ex.Message}");
            }
        }
        [HttpGet("role")]
        public async Task<ActionResult> GetRole()
        {
            try
            {
                return Ok(User.GetRole());
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel adiconar a função. Erro {ex.Message}");
            }
        }
    }
}
