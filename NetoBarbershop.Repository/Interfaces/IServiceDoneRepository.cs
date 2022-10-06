using NetoBarbershop.Domain.Models;
using System;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface IServiceDoneRepository
    {
        //SERVICEDONE
        Task<ServiceDone[]> GetAllServicesDonesAsync(string usuarioid,string role);
        Task<ServiceDone> GetServiceDoneByIdAsync(string usuarioid, int id);
        Task<ServiceDone[]> GetByUsuarioServiceDone(string username);
        Task<ServiceDone[]> GetByClienteServiceDone(string usuarioid, string nome);
        Task<ServiceDone[]> GetByDataServiceDone(string usuarioid, DateTime datainicial, DateTime datafinal);
        Task<ServiceDone[]> GetByFinalizadoServiceDone(string usuarioid, bool finalizado);
        Task<ServiceDone[]> GetByCanceladoServiceDone(string usuarioid, bool cancelado);
    }
}
