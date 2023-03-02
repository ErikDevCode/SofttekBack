using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class VentasDiarias
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdUsuarioVenta { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual UsuarioEntity IdUsuarioNavigation { get; set; }
    }
}
