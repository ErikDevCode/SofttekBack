﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISecurityService SecurityRepository { get; }
        IVentasService VentasRepository { get; }
    }
}
