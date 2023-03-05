using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class VentasManager : IVentasManager
    {

        private readonly IVentasService ventasService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public VentasManager(
            IVentasService ventasService,
            IMapper mapper,
            IConfiguration configuration
           )
        {
            this.ventasService = ventasService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<List<ProductoEntity>> GetListarProducto()
        {
            var producto = await ventasService.GetListarProducto();
            return producto;
        }

        public async Task<List<VentasDiariasEntity>> GetVentasDiarias()
        {
            var ventas = await ventasService.GetVentasDiarias();
            return ventas;
        }

        public async Task<VentaDiariaEntity> RegistrarVentasDiarias(VentaDiariaEntity ventaDiariaEntity)
        {
            try
            {
                var mapp = mapper.Map<VentaDiariaEntity>(ventaDiariaEntity);
                VentaDiariaEntity _ventasResponseEntity = await ventasService.RegistrarVentasDiarias(mapp);

                return _ventasResponseEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
