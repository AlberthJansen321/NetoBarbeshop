using NetoBarbershop.Application.DTO;
using System.Threading.Tasks;

namespace NetoBarbershop.Application.Interfaces
{
    public interface ITokenApplication
    {
        Task<TokenDTO> CreateToken(string email);
    }
}
