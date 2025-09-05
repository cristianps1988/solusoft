using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Models
{
    public class Producto
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int ID_Categoria { get; set; }
        public int ID_Proveedor { get; set; }
    }
}