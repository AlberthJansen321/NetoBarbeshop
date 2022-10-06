using NetoBarbershop.Application.DTO;
using System.Threading.Tasks;

namespace NetoBarbershop.Application.Interfaces
{
    public interface IServiceApplication
    {
        Task<ServiceDTO> AddService(ServiceDTO model);
        Task<ServiceDTO> UpdateService(int serviceid, ServiceDTO model);
        Task<bool> DeleteService(int serviceid);
        Task<ServiceDTO[]> GetServiceByNomeAsync(string nome, bool includeServiceDone = false);
        Task<ServiceDTO[]> GetAllServicesAsync(bool includeServiceDone = false);
        Task<ServiceDTO> GetServiceByIdAsync(int id, bool includeServiceDone = false);
    }
}
