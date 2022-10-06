using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Contextos;
using NetoBarbershop.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly NetoBarbershopContext _context;
        public ServiceRepository(NetoBarbershopContext context)
        {
            _context = context;
        }
        public async Task<Service> GetServiceByIdAsync(int id)
        {
            IQueryable<Service> query = _context.Services;

            query = query.OrderBy(o => o.Id).Where(w => w.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Service[]> GetServiceByNomeAsync(string nome)
        {
            IQueryable<Service> query = _context.Services;

  
            query = query.OrderBy(o => o.Id).Where(w => w.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Service[]> GetAllServicesAsync()
        {
            IQueryable<Service> query = _context.Services;

            query = query.OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }
    }
}
