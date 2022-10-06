using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Contextos;
using NetoBarbershop.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly NetoBarbershopContext _context;
        public TokenRepository(NetoBarbershopContext context)
        {
            _context = context;
        }

        public async Task<Token[]> GetAllTokensByUser(string id)
        {
            IQueryable<Token> query = _context.Tokens;

            query = query.OrderBy(o => o.Id).Where(u => u.UsuarioID == id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Token> GetTokenByRefreshToken(string refreshToken)
        {
            IQueryable<Token> query = _context.Tokens;

            query = query.OrderBy(o => o.Id).Where(r => r.RefreshToken == refreshToken && r.Ultilizado == false);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Token> GetTokenById(int id)
        {
            IQueryable<Token> query = _context.Tokens;

            query = query.OrderBy(o => o.Id).Where(r => r.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
