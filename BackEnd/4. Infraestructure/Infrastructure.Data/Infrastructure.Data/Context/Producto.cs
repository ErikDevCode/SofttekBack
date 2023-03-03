using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Data.Context
{
    public partial class Producto
    {
        public Producto()
        {
            VentasDiaria = new HashSet<VentasDiaria>();
        }

        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public int? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<VentasDiaria> VentasDiaria { get; set; }
    }
}
