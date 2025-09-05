using System;
using System.Collections.Generic;
using Solusoft.Data;
using Solusoft.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Solusoft.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/producto
        public List<Producto> Get()
        {
            return ProductoData.ListarProductos();
        }

        // GET api/producto/5
        public Producto Get(int id)
        {
            return ProductoData.ConsultarProducto(id);
        }

        // POST api/producto
        public bool Post([FromBody] Producto producto)
        {
            return ProductoData.RegistrarProducto(producto);
        }

        // PUT api/producto
        public bool Put([FromBody] Producto producto)
        {
            return ProductoData.ActualizarProducto(producto);
        }

        // DELETE api/producto/5
        public bool Delete(int id)
        {
            return ProductoData.EliminarProducto(id);
        }


    }
}
