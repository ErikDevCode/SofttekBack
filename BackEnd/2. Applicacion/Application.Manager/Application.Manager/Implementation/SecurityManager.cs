using Application.Dto;
//using Application.Dto.Security;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using Infrastructure.MainModule.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Application.Manager.Implementation
{
    public class SecurityManager : ISecurityManager
    {
        private readonly ISecurityService securityService;
        private readonly IMapper mapper;
        private readonly IPasswordService passwordService;
        private readonly IConfiguration configuration;

        public SecurityManager(
            ISecurityService securityService,
            IMapper mapper,
            IPasswordService passwordService,
            IConfiguration configuration
           )
        {
            this.securityService = securityService;
            this.mapper = mapper;
            this.passwordService = passwordService;
            this.configuration = configuration;
        }

        public async Task<LoginResponseDTO> GenerateToken(UsuarioDTO userMap)
        {
            LoginResponseDTO response = null;
            //Header 

            var razonSocial = string.Empty;
            var nomCli = string.Empty;
            var apePaterno = string.Empty;
            var apeMaterno = string.Empty;

            ////add Claims
            var claims = new[]
            {
                new Claim("idUsuario", userMap.IdUsuario.ToString()),
                new Claim("nombres", nomCli),
                new Claim("apellidoPaterno", apePaterno),
                new Claim("apellidoMaterno", apeMaterno)
            };

            var sata = configuration["Authentication:SecretKey"];

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(40);
            var arqtoken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: signingCredentials);

            response = new LoginResponseDTO
            {
                Codigo = userMap.IdUsuario,
                Token = new JwtSecurityTokenHandler().WriteToken(arqtoken)
            };

            return response;
        }
        public async Task<LoginResponseDTO> GetLoginCredentials(UserLoginDTO userLogin)
        {
            var user = await securityService.GetLoginCredentials(userLogin);
            UsuarioDTO userMap = mapper.Map<UsuarioDTO>(user);
            LoginResponseDTO response = await GenerateToken(userMap);
            return response;
        }

    }
}
