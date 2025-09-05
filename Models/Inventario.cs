using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Models
{
    public class Inventario
    {
        public int ID_Inventario { get; set; }
        public int ID_Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime ? Fecha_Caducidad { get; set; }


        public string NombreProducto { get; set; }

    }
}