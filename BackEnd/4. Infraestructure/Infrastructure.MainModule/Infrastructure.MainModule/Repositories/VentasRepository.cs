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
    public class VentasRepository : IVentasService
    {
        private readonly SofttekBDContext _context;
        private readonly IConfiguration _configuration;

        public VentasRepository(SofttekBDContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public async Task<List<ProductoEntity>> GetListarProducto()
        {
            var ListUsuarioLogin = await _context.Productos
               .Where(x => x.Stock >0).ToListAsync();

            return ListUsuarioLogin;
        }

        public async Task<List<VentasDiariasEntity>> GetVentasDiarias()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnSofttekBDSqlServer"]))
            {
                connection.Open();

                await using (var sql = new SqlCommand("sp_ListarVentasTotal", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();

                    List<VentasDiariasEntity> dataSql = new List<VentasDiariasEntity>();
                    VentasDiariasEntity ListarVentas = null;

                    while (lect.Read())
                    {
                        ListarVentas = new VentasDiariasEntity()
                        {
                            IdVenta = Convert.ToInt32(lect["IdVenta"]),
                            IdProducto = Convert.ToInt32(lect["IdProducto"]),
                            DescripcionProducto = Convert.ToString(lect["DescripcionProducto"]),
                            Cantidad = Convert.ToInt32(lect["Cantidad"]),
                            MontoTotal = Convert.ToDecimal(lect["MontoTotal"]),
                            FechaVenta = Convert.ToDateTime(lect["FechaVenta"]),
                            IdUsuarioVenta = Convert.ToInt32(lect["IdUsuarioVenta"]),
                            NombreUsuario = Convert.ToString(lect["NombreUsuario"]),

                        };
                        dataSql.Add(ListarVentas);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();

                    return dataSql;
                }
            }
        }

        public async Task<VentaDiariaEntity> RegistrarVentasDiarias(VentaDiariaEntity ventasDiariasDTO)
        {
             _context.VentasDiarias.Add(ventasDiariasDTO);
            await _context.SaveChangesAsync();

            return ventasDiariasDTO;
        }
    }
}
