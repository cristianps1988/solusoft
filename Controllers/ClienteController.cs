
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
    public class ClienteController : ApiController
    {
        // GET api/cliente
        public List<Cliente> Get()
        {
            return ClienteData.ListarClientes();
        }

        // GET api/cliente/5
        public Cliente Get(int id)
        {
            return ClienteData.ObtenerCliente(id);
        }

        // POST api/cliente
        public bool Post([FromBody] Cliente cliente)
        {
            return ClienteData.RegistrarCliente(cliente);
        }

        // PUT api/cliente
        public bool Put([FromBody] Cliente cliente)
        {
            return ClienteData.ActualizarCliente(cliente);
        }

        // DELETE api/cliente/5
        public bool Delete(int id)
        {
            return ClienteData.EliminarCliente(id);
        }


    }
}