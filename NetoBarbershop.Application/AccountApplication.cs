using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Domain.Models.Identity;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NetoBarbershop.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUSER> _userManager;
        private readonly SignInManager<ApplicationUSER> _signInManager;
        private readonly IMapper _mapper;
        private readonly IApplicationUSERRepository _applicationUSERRepository;

        public AccountApplication(UserManager<ApplicationUSER> userManager, SignInManager<ApplicationUSER> signInManager,
             RoleManager<IdentityRole> roleManager, IMapper mapper, IApplicationUSERRepository applicationUSERRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _applicationUSERRepository = applicationUSERRepository;
            _roleManager = roleManager;
        }

        public async Task<SignInResult> CheckUserPasswordAsync(UsuarioDTO usuarioDTO, string password)
        {
            try
            {
                var usuario = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == usuarioDTO.Email);

                return await _signInManager.CheckPasswordSignInAsync(usuario, password, false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar a senha. Erro: {ex.Message}");
            }
        }


        public async Task<UsuarioDTO> CreateAccountAsync(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<ApplicationUSER>(usuarioDTO);

                usuario.UserName = usuarioDTO.Email;
                usuario.FullName = usuarioDTO.Nome;

                var result = await _userManager.CreateAsync(usuario, usuarioDTO.Senha);

                if (result.Succeeded)
                {
                    var retorno = _mapper.Map<UsuarioDTO>(usuario);


                    var roleExistFunc = await _roleManager.RoleExistsAsync("Funcionario");
                    var roleExistAdm = await _roleManager.RoleExistsAsync("ADMIN");

                    if (!roleExistFunc)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Funcionario"));                       
                    }
                    if (!roleExistAdm)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("ADMIN"));
                    }

                    var cargo = await _userManager.AddToRoleAsync(usuario, "Funcionario");

                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar conta. Erro: {ex.Message}");
            }
        }

        public async Task<UsuarioDTO> GetUserByIdAsync(string id, bool includeServiceDone)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetUserByIdAsync(id, includeServiceDone);
                if (usuario == null) return null;

                var resultado = _mapper.Map<UsuarioDTO>(usuario);
                resultado.Nome = usuario.FullName;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar usuario por id. Erro: {ex.Message}");
            }
        }

        public async Task<UsuarioDTO> GetUserByEmailAsync(string email, bool includeServiceDone)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetUsersByEmailAsync(email, includeServiceDone);
                if (usuario == null) return null;

                var resultado = _mapper.Map<UsuarioDTO>(usuario);
                resultado.Nome = usuario.FullName;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar usuario por email. Erro: {ex.Message}");
            }
        }
        public async Task<UsuarioDTO[]> GetAllUsers(bool includeServiceDone)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetAllUsersAsync(includeServiceDone);
                if (usuario == null) return null;
                
                var resultado = _mapper.Map<UsuarioDTO[]>(usuario);

                foreach (var dados in resultado)
                {
                    var user = usuario.FirstOrDefault(id => id.Id == dados.Id);

                    if (user != null && string.IsNullOrWhiteSpace(dados.Nome))
                    {
                        dados.Nome = user.FullName;
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar os usuarios. Erro: {ex.Message}");
            }
        }
        public async Task<UsuarioDTO[]> GetUserByNomeAsync(string nome, bool includeServiceDone = false)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetUsersByNomeAsync(nome, includeServiceDone);
                if (usuario == null) return null;

                var resultado = _mapper.Map<UsuarioDTO[]>(usuario);
         
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar usuario por nome. Erro: {ex.Message}");
            }
        }

        public async Task<UpdateUserDTO> UpdateAccount(UpdateUserDTO updateUserDTO)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetUsersByEmailAsync(updateUserDTO.Email);
                if (usuario == null) return null;

                _mapper.Map(updateUserDTO, usuario);

                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                if (!string.IsNullOrWhiteSpace(updateUserDTO.Senha))
                {
                    var result = await _userManager.ResetPasswordAsync(usuario, token, updateUserDTO.Senha);
                }

                usuario.FullName = updateUserDTO.Nome;

                _applicationUSERRepository.Update(usuario);

                if (await _applicationUSERRepository.SaveChangesAsync())
                {
                    var retornoUser = await _applicationUSERRepository.GetUsersByEmailAsync(usuario.Email);

                    var retorno = _mapper.Map<UpdateUserDTO>(retornoUser);
                    retorno.Nome = usuario.FullName;
                    return retorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar alterar o usuario. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string email)
        {
            try
            {
                return await _userManager.Users.AnyAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar se o usuario existe. Erro: {ex.Message}");
            }
        }

        public async Task<IdentityResult> AddRole(string role)
        {
            try
            {
                IdentityResult result;

                var roleExist = await _roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    result = await _roleManager.CreateAsync(new IdentityRole(role));

                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar cadastrar uma funcao. Erro: {ex.Message}");
            }
        }
        public async Task<IdentityResult> UpdateRoleUser(UserRoleDTO userRoleDTO)
        {
            try
            {
                IdentityResult result = null;

                var usuario = _mapper.Map<ApplicationUSER>(userRoleDTO);

                var user_role = _userManager.GetRolesAsync(usuario);

                var remove = await _userManager.RemoveFromRolesAsync(usuario, user_role.Result);

                if (remove.Succeeded)
                    result = await _userManager.AddToRoleAsync(usuario, userRoleDTO.Funcao.ToString());
                if (result.Succeeded)
                    return result;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar cadastrar uma funcao. Erro: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAccount(string id)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetUserByIdAsync(id);
                if (usuario == null) return false;

                var result = await _userManager.DeleteAsync(usuario);

                if (result.Succeeded)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar cadastrar uma funcao. Erro: {ex.Message}");
            }
        }

        public async Task<bool> ResetPassword(string id,string senha)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetUserByIdAsync(id);
                if (usuario == null) return false;

                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                if (!string.IsNullOrWhiteSpace(senha))
                {
                    var result = await _userManager.ResetPasswordAsync(usuario, token, senha);

                    if (result.Succeeded)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar cadastrar uma funcao. Erro: {ex.Message}");
            }
        }
    }
}
