using Application.Dto;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<UsuarioEntity> GetLoginCredentials(UserLoginDTO usuarioLogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginCredentials(usuarioLogin);
        }
    }
}
