using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Models
{
    public class Venta
    {
        public int ID_Venta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Empleado { get; set; }
        public int ID_Metodo { get; set; }


        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public string MetodoPago { get; set; }

    }
}