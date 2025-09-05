using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Models
{
    public class Usuario
    {
        public int ID_Empleado { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }


        public string NombreEmpleado { get; set; }



    }
}