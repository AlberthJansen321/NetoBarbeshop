using NetoBarbershop.Domain.Models;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface ITokenRepository
    {
        Task<Token> GetTokenByRefreshToken(string refreshToken);
        Task<Token> GetTokenById(int id);
        Task<Token[]> GetAllTokensByUser(string id);
    }
}
