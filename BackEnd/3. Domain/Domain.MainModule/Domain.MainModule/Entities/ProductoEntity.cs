using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class ProductoEntity
    {
        [Key]
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public int Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
