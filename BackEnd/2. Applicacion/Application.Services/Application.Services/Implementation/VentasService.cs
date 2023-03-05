using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class VentasService : IVentasService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public VentasService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<ProductoEntity>> GetListarProducto()
        {
            return await _unitOfWork.VentasRepository.GetListarProducto();
        }

        public async Task<List<VentasDiariasEntity>> GetVentasDiarias()
        {
            return await _unitOfWork.VentasRepository.GetVentasDiarias();
        }

        public async Task<VentaDiariaEntity> RegistrarVentasDiarias(VentaDiariaEntity ventaDiariaEntity)
        {
            return await _unitOfWork.VentasRepository.RegistrarVentasDiarias(ventaDiariaEntity);
        }
    }
}
