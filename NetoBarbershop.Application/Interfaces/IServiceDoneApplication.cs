using NetoBarbershop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetoBarbershop.Application.Interfaces
{
    public interface IServiceDoneApplication
    {
        Task<ServiceDoneDTO> AddServiceDone(ServiceDoneDTO model);
        Task<ServiceDoneDTO> UpdateServiceDone(int id, ServiceDoneDTO model);
        Task<bool> DeleteServiceDone(int id);
        Task<ServiceDoneDTO[]> GetAllServiceDone(string usuarioid,string role);
        Task<ServiceDoneDTO> GetByIdServiceDone(string usuarioid, int id);
        Task<ServiceDoneDTO[]> GetByUsuarioServiceDone(string username);
        Task<ServiceDoneDTO[]> GetByClienteServiceDone(string usuarioid, string nome);
        Task<ServiceDoneDTO[]> GetByDataServiceDone(string usuarioid, DateTime datainicial, DateTime datafinal);
        Task<ServiceDoneDTO[]> GetByFinalizadoServiceDone(string usuarioid, bool finalizado);
        Task<ServiceDoneDTO[]> GetByCanceladoServiceDone(string usuarioid, bool cancelado);
    }
}
