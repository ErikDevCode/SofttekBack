using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Domain.MainModule.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [EnableCors("Cors")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VentasController : ControllerBase
    {
        private readonly IVentasManager ventasManager;

        public VentasController(
            IVentasManager ventasManager
            )
        {
            this.ventasManager = ventasManager;
        }

        [HttpGet("ListarVentas")]
        public async Task<IActionResult> ListarVentas()
        {

            List<VentasDiariasEntity> ventasEntity = await ventasManager.GetVentasDiarias();

            if (ventasEntity == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidUser });
            }
            else
            {
                return Ok(ventasEntity);
            }
        }

        [HttpPost("RegistrarVenta")]
        public async Task<IActionResult> RegistrarVenta([FromBody] VentaDiariaEntity ventasdiarias)
        {
            try
            {
                VentaDiariaEntity ventasDiarias  = await ventasManager.RegistrarVentasDiarias(ventasdiarias);
                if (ventasdiarias.IdVenta < 0)
                {
                    return Ok(new { valid = false, message = Constants.InvalidRegister });
                }
                return Ok(new { valid = true, message = Constants.ResponseRegisterVenta });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("ListarProductos")]
        public async Task<IActionResult> ListarProductos()
        {

            List<ProductoEntity> ventasEntity = await ventasManager.GetListarProducto();

            if (ventasEntity == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidUser });
            }
            else
            {
                return Ok(ventasEntity);
            }
        }
    }
}
       
