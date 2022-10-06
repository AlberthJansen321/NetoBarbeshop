using NetoBarbershop.Domain.Models.Identity;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface IApplicationUSERRepository : IGeralRepository
    {
        Task<ApplicationUSER[]> GetAllUsersAsync(bool includeServiceDone = false);
        Task<ApplicationUSER> GetUserByIdAsync(string id, bool includeServiceDone = false);
        Task<ApplicationUSER[]> GetUsersByNomeAsync(string nome, bool includeServiceDone = false);
        Task<ApplicationUSER> GetUsersByEmailAsync(string email, bool includeServiceDone = false);
    }
}
