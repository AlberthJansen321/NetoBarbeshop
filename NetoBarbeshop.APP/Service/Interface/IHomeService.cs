using NetoBarbeshop.APP.Models;
using NetoBarbeshop.APP.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbeshop.APP.Service.Interface
{
    public interface IHomeService
    {
        Task<List<ServiceDone>> ServiceDonesByUser();
        Task<List<Services>> Services();
        Task<bool> DeleteServiceDone(string id);
        Task<bool> AddServiceDone(ServiceDone model);
        Task<UsuarioDTO> Getusuario();
    }
}
