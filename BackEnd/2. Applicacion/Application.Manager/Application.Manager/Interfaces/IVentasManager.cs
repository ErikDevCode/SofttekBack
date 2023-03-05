using Application.Dto;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IVentasManager
    {
        Task<List<VentasDiariasEntity>> GetVentasDiarias();

        Task<VentaDiariaEntity> RegistrarVentasDiarias(VentaDiariaEntity ventasDiariasDto);

        Task<List<ProductoEntity>> GetListarProducto();

    }
}
