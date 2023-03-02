using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Data.Context
{
    public partial class Usuario
    {
        public Usuario()
        {
            VentasDiaria = new HashSet<VentasDiaria>();
        }

        public int IdUsuario { get; set; }
        public string Dni { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<VentasDiaria> VentasDiaria { get; set; }
    }
}
