using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISecurityManager securityManager;

        public LoginController(
            ISecurityManager securityManager
            )
        {
            this.securityManager = securityManager;
        }


        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(UserLoginDTO userLogin)
        {
            userLogin.Password = CryptoHelper.EncryptAES(userLogin.Password);

            LoginResponseDTO usuarioEntity = await securityManager.GetLoginCredentials(userLogin);

            if (usuarioEntity == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidUser });
            }
            else
            {
                return Ok(usuarioEntity);
            }
        }
    }
}
