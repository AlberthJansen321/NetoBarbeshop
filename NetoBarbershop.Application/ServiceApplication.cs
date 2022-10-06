using AutoMapper;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetoBarbershop.Application
{
    public class ServiceApplication : IServiceApplication
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IServiceRepository _IServiceRepository;
        private readonly IMapper _mapper;

        public ServiceApplication(IGeralRepository geralRepository, IServiceRepository IServiceRepository, IMapper IMapper)
        {
            _geralRepository = geralRepository;
            _IServiceRepository = IServiceRepository;
            _mapper = IMapper;
        }
        public async Task<ServiceDTO> AddService(ServiceDTO model)
        {
            try
            {
                var service = _mapper.Map<Service>(model);

                _geralRepository.Add<Service>(service);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var retorno_service = await _IServiceRepository.GetServiceByIdAsync(service.Id);

                    return _mapper.Map<ServiceDTO>(retorno_service);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteService(int serviceid)
        {
            try
            {
                var service = _IServiceRepository.GetServiceByIdAsync(serviceid);

                if (service == null) return false;

                _geralRepository.Delete(service);

                return await _geralRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceDTO> UpdateService(int serviceid, ServiceDTO model)
        {
            try
            {
                var service = await _IServiceRepository.GetServiceByIdAsync(serviceid);

                if (service == null) return null;

                _mapper.Map(model, service);

                service.Id = serviceid;

                _geralRepository.Update(service);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var retorno_service = await _IServiceRepository.GetServiceByIdAsync(service.Id);

                    return _mapper.Map<ServiceDTO>(retorno_service);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceDTO> GetServiceByIdAsync(int id, bool includeServiceDone = false)
        {
            try
            {
                var service = await _IServiceRepository.GetServiceByIdAsync(id);
                if (service == null) return null;

                var resultado = _mapper.Map<ServiceDTO>(service);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDTO[]> GetServiceByNomeAsync(string nome, bool includeServiceDone = false)
        {
            try
            {
                var services = await _IServiceRepository.GetServiceByNomeAsync(nome);
                if (services == null) return null;

                var resultado = _mapper.Map<ServiceDTO[]>(services);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDTO[]> GetAllServicesAsync(bool includeServiceDone = false)
        {
            try
            {
                var services = await _IServiceRepository.GetAllServicesAsync();
                if (services == null) return null;

                var resultado = _mapper.Map<ServiceDTO[]>(services);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
