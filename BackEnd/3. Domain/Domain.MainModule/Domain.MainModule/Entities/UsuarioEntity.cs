using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class UsuarioEntity
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Dni { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int Activo { get; set; }

    }
}
