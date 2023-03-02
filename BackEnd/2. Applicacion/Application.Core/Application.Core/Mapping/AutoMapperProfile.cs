using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDTO, UsuarioEntity>()
               .ForMember(t => t.IdUsuario, opt => opt.MapFrom(o => o.IdUsuario))
               .ForMember(t => t.Dni, opt => opt.MapFrom(o => o.Dni))
               .ForMember(t => t.ApellidoPaterno, opt => opt.MapFrom(o => o.ApellidoPaterno))
               .ForMember(t => t.ApellidoMaterno, opt => opt.MapFrom(o => o.ApellidoMaterno))
               .ForMember(t => t.Nombres, opt => opt.MapFrom(o => o.Nombres))
               .ForMember(t => t.Correo, opt => opt.MapFrom(o => o.Correo))
               .ForMember(t => t.Contrasena, opt => opt.MapFrom(o => o.Contrasena))
               .ForMember(t => t.Activo, opt => opt.MapFrom(o => o.Activo))
               .ReverseMap()
               ;

            CreateMap<ProductoDTO, Producto>()
               .ForMember(t => t.IdProducto, opt => opt.MapFrom(o => o.IdProducto))
               .ForMember(t => t.DescProducto, opt => opt.MapFrom(o => o.DescProducto))
               .ForMember(t => t.Stock, opt => opt.MapFrom(o => o.Stock))
               .ForMember(t => t.Activo, opt => opt.MapFrom(o => o.Activo))
               .ForMember(t => t.FechaRegistro, opt => opt.MapFrom(o => o.FechaRegistro))
               .ReverseMap()
               ;

            CreateMap<VentasDiariasDTO, VentasDiarias>()
               .ForMember(t => t.IdVenta, opt => opt.MapFrom(o => o.IdVenta))
               .ForMember(t => t.IdProducto, opt => opt.MapFrom(o => o.IdProducto))
               .ForMember(t => t.FechaVenta, opt => opt.MapFrom(o => o.FechaVenta))
               .ForMember(t => t.IdUsuarioVenta, opt => opt.MapFrom(o => o.IdUsuarioVenta))
               .ForMember(t => t.FechaRegistro, opt => opt.MapFrom(o => o.FechaRegistro))
               .ReverseMap()
               ;

        }
    }
}
