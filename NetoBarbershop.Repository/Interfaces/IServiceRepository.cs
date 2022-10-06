using NetoBarbershop.Domain.Models;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface IServiceRepository
    {
        //SERVICE
        Task<Service[]> GetServiceByNomeAsync(string nome);
        Task<Service[]> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
    }
}
