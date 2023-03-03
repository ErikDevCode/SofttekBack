using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class VentaDiariaEntity
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdUsuarioVenta { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
