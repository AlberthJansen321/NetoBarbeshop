using Microsoft.AspNetCore.Identity;
using NetoBarbershop.Application.DTO;
using System.Threading.Tasks;

namespace NetoBarbershop.Application.Interfaces
{
    public interface IAccountApplication
    {
        Task<bool> UserExists(string email);
        Task<UsuarioDTO[]> GetAllUsers(bool includeServiceDone = false);
        Task<UsuarioDTO> GetUserByEmailAsync(string email, bool includeServiceDone = false);
        Task<UsuarioDTO[]> GetUserByNomeAsync(string nome, bool includeServiceDone = false);
        Task<UsuarioDTO> GetUserByIdAsync(string id, bool includeServiceDone = false);
        Task<SignInResult> CheckUserPasswordAsync(UsuarioDTO usuarioDTO, string password);
        Task<UsuarioDTO> CreateAccountAsync(UsuarioDTO usuarioDTO);
        Task<UpdateUserDTO> UpdateAccount(UpdateUserDTO updateUserDTO);
        Task<bool> DeleteAccount(string id);
        Task<IdentityResult> AddRole(string role);
        Task<IdentityResult> UpdateRoleUser(UserRoleDTO userRoleDTO);
        Task<bool> ResetPassword(string id,string senha);
    }
}
