using FacturasPractica.DTOs;
using FacturasPractica.Models;
using AutoMapper;

namespace FacturasPractica.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TblFacturas, FacturaDto>()
                .ForMember(dest => dest.ClienteRazonSocial, opt => opt.MapFrom(src => src.Cliente.RazonSocial))
                .ReverseMap();
            CreateMap<TblDetallesFactura, DetalleFacturaDto>().ReverseMap();
        }
    }
}
