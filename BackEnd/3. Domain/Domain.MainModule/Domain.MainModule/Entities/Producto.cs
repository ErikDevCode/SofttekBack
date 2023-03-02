using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public int Stock { get; set; }
        public int Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
