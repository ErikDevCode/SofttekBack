﻿using Application.Dto;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<UsuarioEntity> GetLoginCredentials(UserLoginDTO usuarioLogin);

    }
}
