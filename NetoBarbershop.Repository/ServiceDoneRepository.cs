using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Contextos;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository
{
    public class ServiceDoneRepository : IServiceDoneRepository
    {
        private readonly NetoBarbershopContext _context;
        public ServiceDoneRepository(NetoBarbershopContext context)
        {
            _context = context;
        }
        public async Task<ServiceDone> GetServiceDoneByIdAsync(string usuarioid, int id)
        {
          
            IQueryable<ServiceDone> query = _context.ServicesDones;

            if (!string.IsNullOrEmpty(usuarioid))
            {
                query = query.OrderBy(o => o.Id).Where(w => w.UsuarioID == usuarioid);
            }

            query = query.OrderBy(o => o.Id).
                    Include(p => p.ServiceDoneProducts).Include(s => s.ServiceDoneServices).
                    Where(w => w.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ServiceDone[]> GetAllServicesDonesAsync(string usuarioid,string role)
        {
            IQueryable<ServiceDone> query = _context.ServicesDones;

            if (role.Contains( "ADMIN"))
            {
                query = query.OrderBy(o => o.Id).Include(p => p.ServiceDoneProducts).Include(s => s.ServiceDoneServices).AsNoTracking();
            }
            else
            {
                query = query.OrderBy(o => o.Id).Include(p => p.ServiceDoneProducts).Include(s => s.ServiceDoneServices).
                    Where(w => w.UsuarioID == usuarioid).AsNoTracking();
            }
                

            return await query.ToArrayAsync();
        }

        public async Task<ServiceDone[]> GetByUsuarioServiceDone(string username)
        {
            IQueryable<ServiceDone> query = _context.ServicesDones;

            if (username != null)
            {
                query = query.OrderBy(i => i.Id).Where(i => i.Usuario.UserName == username);
            }

            query = query.OrderBy(o => o.Id).
                   Include(p => p.ServiceDoneProducts).Include(s => s.ServiceDoneServices);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<ServiceDone[]> GetByClienteServiceDone(string usuarioid, string nome)
        {
            IQueryable<ServiceDone> query = _context.ServicesDones;

            query = query.OrderBy(i => i.Id).Where(i => i.ClienteNome.ToLower().Contains(nome.ToLower()) && i.UsuarioID == usuarioid);

            return await query.ToArrayAsync();
        }

        public async Task<ServiceDone[]> GetByDataServiceDone(string usuarioid, DateTime datainicial, DateTime datafinal)
        {
            IQueryable<ServiceDone> query = _context.ServicesDones;

            query = query.OrderBy(i => i.Id).Where(i => i.Data.Date >= datainicial.Date && i.Data.Date <= datafinal.Date && i.UsuarioID == usuarioid);

            return await query.ToArrayAsync();
        }

        public async Task<ServiceDone[]> GetByFinalizadoServiceDone(string usuarioid, bool finalizado)
        {
            IQueryable<ServiceDone> query = _context.ServicesDones;

            query = query.OrderBy(i => i.Id).Where(i => i.Finalizado == finalizado && i.UsuarioID == usuarioid);

            return await query.ToArrayAsync();
        }

        public async Task<ServiceDone[]> GetByCanceladoServiceDone(string usuarioid, bool cancelado)
        {
            IQueryable<ServiceDone> query = _context.ServicesDones;

            query = query.OrderBy(i => i.Id).Where(i => i.Cancelado == cancelado && i.UsuarioID == usuarioid);

            return await query.ToArrayAsync();
        }
    }
}
