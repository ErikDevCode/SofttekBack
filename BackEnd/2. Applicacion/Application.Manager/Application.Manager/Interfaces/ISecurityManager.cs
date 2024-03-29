﻿using Application.Dto;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
   public interface ISecurityManager
    {
        
        Task<LoginResponseDTO> GetLoginCredentials(UserLoginDTO userLogin);
    }
}
