using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Models
{
    public class Detalle_Venta
    {
        public int ID_Detalle { get; set; }
        public int ID_Venta { get; set; }
        public int ID_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Subtotal { get; set; }


        public string Producto { get; set; }


    }
}