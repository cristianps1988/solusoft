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
    public class ProveedorController : ApiController
    {
        // GET api/proveedor
        public List<Proveedor> Get()
        {
            return ProveedorData.ListarProveedores();
        }

        // GET api/proveedor/5
        public Proveedor Get(int id)
        {
            return ProveedorData.ConsultarProveedor(id);
        }

        // POST api/proveedor
        public bool Post([FromBody] Proveedor proveedor)
        {
            return ProveedorData.RegistrarProveedor(proveedor);
        }

        // PUT api/proveedor
        public bool Put([FromBody] Proveedor proveedor)
        {
            return ProveedorData.ActualizarProveedor(proveedor);
        }

        // DELETE api/proveedor/5
        public bool Delete(int id)
        {
            return ProveedorData.EliminarProveedor(id);
        }





    }
}
