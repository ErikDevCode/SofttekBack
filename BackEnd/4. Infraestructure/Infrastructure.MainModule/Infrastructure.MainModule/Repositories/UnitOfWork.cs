using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Utilidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SofttekBDContext context;

        private readonly IConfiguration configuration;

        private readonly IMapper mapper;

        //private readonly IMasterRepository masterRepository;

        private readonly ISecurityService _securityService;

        private readonly HashService hashService;


        public UnitOfWork(SofttekBDContext context,
            IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public ISecurityService SecurityRepository => _securityService ?? new SecurityRepository(context, configuration);

        public IVentasService VentasRepository => new VentasRepository(context,configuration);

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
