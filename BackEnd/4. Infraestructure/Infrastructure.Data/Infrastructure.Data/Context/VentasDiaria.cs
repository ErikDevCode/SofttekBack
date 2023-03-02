using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Data.Context
{
    public partial class VentasDiaria
    {
        public int IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public DateTime? FechaVenta { get; set; }
        public int? IdUsuarioVenta { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioVentaNavigation { get; set; }
    }
}
