﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class VentasDiariasEntity
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdUsuarioVenta { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ProductoEntity IdProductoNavigation { get; set; }
        public virtual UsuarioEntity IdUsuarioNavigation { get; set; }
    }
}
