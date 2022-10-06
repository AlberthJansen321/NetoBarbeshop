using AutoMapper;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Domain.Models.Identity;

namespace NetoBarbershop.Application.Helpers
{
    public class NetoBarbershopProfile : Profile
    {
        public NetoBarbershopProfile()
        {
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<ServiceDone, ServiceDoneDTO>().ReverseMap();
            CreateMap<ApplicationUSER, UsuarioDTO>().ReverseMap();
            CreateMap<ApplicationUSER, UserRoleDTO>().ReverseMap();
            CreateMap<ApplicationUSER, UpdateUserDTO>().ReverseMap();     
            CreateMap<Token, TokenDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<ServiceDoneService, ServiceDoneServiceDTO>().ReverseMap();
            CreateMap<ServiceDoneProduct, ServiceDoneProductDTO>().ReverseMap();
        }
    }
}
