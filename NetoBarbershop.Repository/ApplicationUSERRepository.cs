using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models.Identity;
using NetoBarbershop.Repository.Contextos;
using NetoBarbershop.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository
{
    public class ApplicationUSERRepository : GeralRepository, IApplicationUSERRepository
    {
        private readonly NetoBarbershopContext _context;
        public ApplicationUSERRepository(NetoBarbershopContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ApplicationUSER> GetUserByIdAsync(string id, bool includeServiceDone = false)
        {

            IQueryable<ApplicationUSER> query = _context.Users;

            //if (includeServiceDone)
            //{
            //    query = query.Include(
            //        i => i.ServicesDones).ThenInclude(i => i.Service);
            //}

            query = query.OrderBy(o => o.Id).Where(w => w.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ApplicationUSER[]> GetAllUsersAsync(bool includeServiceDone = false)
        {
            IQueryable<ApplicationUSER> query = _context.Users;

            //if (includeServiceDone)
            //{
            //    query = query.Include(
            //        i => i.ServicesDones).ThenInclude(i => i.Service);
            //}

            query = query.OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }

        public async Task<ApplicationUSER[]> GetUsersByNomeAsync(string nome, bool includeServiceDone = false)
        {
            IQueryable<ApplicationUSER> query = _context.Users;

            //if (includeServiceDone)
            //{
            //    query = query.Include(
            //        i => i.ServicesDones).ThenInclude(i => i.Service);
            //}

            query = query.OrderBy(o => o.Id).Where(w => w.FullName.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<ApplicationUSER> GetUsersByEmailAsync(string email, bool includeServiceDone = false)
        {
            IQueryable<ApplicationUSER> query = _context.Users;

            //if (includeServiceDone)
            //{
            //    query = query.Include(
            //        i => i.ServicesDones).ThenInclude(i => i.Service);
            //}

            query = query.Where(u => u.UserName == email);

            return await query.FirstOrDefaultAsync();
        }
    }
}
