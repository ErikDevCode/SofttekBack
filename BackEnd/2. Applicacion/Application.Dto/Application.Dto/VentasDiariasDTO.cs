using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class VentasDiariasDTO
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdUsuarioVenta { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
