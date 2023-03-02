using Application.Dto;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class SecurityRepository : ISecurityService
    {
        private readonly SofttekBDContext _context;
        private readonly IConfiguration _configuration;

        public SecurityRepository(SofttekBDContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public async Task<UsuarioEntity> GetLoginCredentials(UserLoginDTO usuarioLogin)
        {

            var ListUsuarioLogin = await _context.Usuarios
                .Where(x => x.Correo == usuarioLogin.Credential && x.Contrasena == usuarioLogin.Password).ToListAsync();

            UsuarioEntity usuarioEntity = new UsuarioEntity();

            usuarioEntity.IdUsuario = ListUsuarioLogin[0].IdUsuario;
            usuarioEntity.Dni = ListUsuarioLogin[0].Dni;
            usuarioEntity.ApellidoPaterno = ListUsuarioLogin[0].ApellidoPaterno;
            usuarioEntity.ApellidoMaterno = ListUsuarioLogin[0].ApellidoMaterno;
            usuarioEntity.Nombres = ListUsuarioLogin[0].Nombres;
            usuarioEntity.Correo = ListUsuarioLogin[0].Correo;
            usuarioEntity.Contrasena = ListUsuarioLogin[0].Contrasena;

            return usuarioEntity;

        }
    }
}
