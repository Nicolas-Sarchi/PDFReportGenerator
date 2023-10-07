using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Factura, FacturaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaDto>().ReverseMap();
            CreateMap<Factura, FacturaPostDto>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaPostDto>().ReverseMap();
            
            CreateMap<Factura, FacturaDto>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente));
            CreateMap<DetalleFactura, DetalleFacturaDto>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto));
        }
    }
}