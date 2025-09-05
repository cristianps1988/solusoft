using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Models
{
    public class Empleado
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
    }
}
