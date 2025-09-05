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
    public class InventarioController : ApiController
    {
        // GET api/inventario
        public List<Inventario> Get()
        {
            return InventarioData.ListarInventario();
        }

        // GET api/inventario/5
        public Inventario Get(int id)
        {
            return InventarioData.ConsultarInventario(id);
        }

        // POST api/inventario
        public bool Post([FromBody] Inventario inventario)
        {
            return InventarioData.RegistrarInventario(inventario);
        }

        // PUT api/inventario
        public bool Put([FromBody] Inventario inventario)
        {
            return InventarioData.ActualizarInventario(inventario);
        }

        // DELETE api/inventario/5
        public bool Delete(int id)
        {
            return InventarioData.EliminarInventario(id);
        }


    }
}
