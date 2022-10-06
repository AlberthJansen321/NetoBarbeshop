using AutoMapper;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetoBarbershop.Application
{
    public class ServiceDoneApplication : IServiceDoneApplication
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IServiceDoneRepository _serviceDoneRepository;
        private readonly IMapper _mapper;

        public ServiceDoneApplication(IGeralRepository geralRepository, IServiceDoneRepository serviceDoneRepository, IMapper mapper)
        {
            _geralRepository = geralRepository;
            _serviceDoneRepository = serviceDoneRepository;
            _mapper = mapper;
        }
        public async Task<ServiceDoneDTO> AddServiceDone(ServiceDoneDTO model)
        {
            try
            {
                var servicedone = _mapper.Map<ServiceDone>(model);

                _geralRepository.Add(servicedone);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var retorno_servicedone = await _serviceDoneRepository.GetServiceDoneByIdAsync(model.UsuarioID, servicedone.Id);

                    return _mapper.Map<ServiceDoneDTO>(retorno_servicedone);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteServiceDone(int id)
        {
            try
            {
                var servicedone = await _serviceDoneRepository.GetServiceDoneByIdAsync(null, id);
                if (servicedone == null) return false;

                _geralRepository.Delete(servicedone);

                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ServiceDoneDTO> UpdateServiceDone(int id, ServiceDoneDTO model)
        {
            try
            {

                var servicedone = await _serviceDoneRepository.GetServiceDoneByIdAsync(model.UsuarioID, id);
                ServiceDoneProduct[] serviceDoneProducts = servicedone.ServiceDoneProducts.ToArray();
                ServiceDoneService[] serviceDoneServices = servicedone.ServiceDoneServices.ToArray();
                if (servicedone == null) return null;

                _mapper.Map(model, servicedone);

                servicedone.Id = id;


                _geralRepository.DeleteRange(serviceDoneProducts);
                _geralRepository.DeleteRange(serviceDoneServices);


                _geralRepository.Update(servicedone);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var retorno_servicedone = await _serviceDoneRepository.GetServiceDoneByIdAsync(servicedone.UsuarioID, servicedone.Id);

                    return _mapper.Map<ServiceDoneDTO>(retorno_servicedone);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDoneDTO[]> GetAllServiceDone(string usuarioid,string role)
        {
            try
            {
               
                var servicedone = await _serviceDoneRepository.GetAllServicesDonesAsync(usuarioid,role);
          
                if (servicedone == null) return null;

                var resultado = _mapper.Map<ServiceDoneDTO[]>(servicedone);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDoneDTO[]> GetByCanceladoServiceDone(string usuarioid, bool cancelado)
        {
            try
            {
                var servicedone = await _serviceDoneRepository.GetByCanceladoServiceDone(usuarioid, cancelado);
                if (servicedone == null) return null;

                var resultado = _mapper.Map<ServiceDoneDTO[]>(servicedone);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDoneDTO[]> GetByClienteServiceDone(string usuarioid, string nome)
        {

            try
            {
                var servicedone = await _serviceDoneRepository.GetByClienteServiceDone(usuarioid, nome);
                if (servicedone == null) return null;

                var resultado = _mapper.Map<ServiceDoneDTO[]>(servicedone);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDoneDTO> GetByIdServiceDone(string usuarioid, int id)
        {
            try
            {
                var servicedone = await _serviceDoneRepository.GetServiceDoneByIdAsync(usuarioid, id);
                if (servicedone == null) return null;

                var resultado = _mapper.Map<ServiceDoneDTO>(servicedone);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDoneDTO[]> GetByUsuarioServiceDone(string username)
        {
            try
            {
                var servicedone = await _serviceDoneRepository.GetByUsuarioServiceDone(username);
                if (servicedone == null) return null;

                var resultado = _mapper.Map<ServiceDoneDTO[]>(servicedone);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceDoneDTO[]> GetByDataServiceDone(string usuarioid, DateTime datainicial, DateTime datafinal)
        {
            try
            {
                var servicedone = await _serviceDoneRepository.GetByDataServiceDone(usuarioid, datainicial, datafinal);
                if (servicedone == null) return null;

                var resultado = _mapper.Map<ServiceDoneDTO[]>(servicedone);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceDoneDTO[]> GetByFinalizadoServiceDone(string usuarioid, bool finalizado)
        {
            try
            {
                var servicedone = await _serviceDoneRepository.GetByFinalizadoServiceDone(usuarioid, finalizado);
                if (servicedone == null) return null;

                var resultado = _mapper.Map<ServiceDoneDTO[]>(servicedone);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
