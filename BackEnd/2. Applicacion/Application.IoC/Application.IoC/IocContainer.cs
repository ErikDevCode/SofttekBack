using Application.Manager.Implementation;
using Application.Manager.Interfaces;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Infrastructure.MainModule.Repositories;
using Infrastructure.MainModule.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC
{
    public static class IocContainer
    {
        public static IServiceCollection AddDependencyInjectionInterfaces(this IServiceCollection services)
        {
            services.AddScoped<DbContext, SofttekBDContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDependencyInjectionsAppService();
            services.AddDependencyInjectionsAppManager();
            services.AddIDependencynjectionsRepository();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
 
            return services;
        }

        public static void AddDependencyInjectionsAppService(this IServiceCollection service)
        {
            service.AddTransient<ISecurityService, SecurityService>();
            service.AddTransient<IPasswordService, PasswordService>();
          //  service.AddTransient<ISedesService, SedesService>();

        }
        public static void AddDependencyInjectionsAppManager(this IServiceCollection service)
        {
            service.AddTransient<ISecurityManager, SecurityManager>();
         //   service.AddTransient<ISedesManager, SedesManager>();
        }
        public static void AddIDependencynjectionsRepository(this IServiceCollection service)
        {
            service.AddScoped<ISecurityService, SecurityRepository>();
         //   service.AddScoped<ISedesService, SedesRepository>();

        }
    }
}
