using ACME.Models;
using AutoMapper;

namespace ACME
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ClienteDto, ClienteCrearDto>().ReverseMap();
            CreateMap<ClienteDto, ClienteActualizarDto>().ReverseMap();
        }
    }
}
