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
    public class UsuarioController : ApiController
    {
        // GET api/usuario
        public List<Usuario> Get()
        {
            return UsuarioData.ListarUsuarios();
        }

        // GET api/usuario/5
        public Usuario Get(int id)
        {
            return UsuarioData.ConsultarUsuario(id);
        }

        // POST api/usuario
        public bool Post([FromBody] Usuario usuario)
        {
            return UsuarioData.RegistrarUsuario(usuario);
        }

        // PUT api/usuario
        public bool Put([FromBody] Usuario usuario)
        {
            return UsuarioData.ActualizarUsuario(usuario);
        }

        // DELETE api/usuario/5
        public bool Delete(int id)
        {
            return UsuarioData.EliminarUsuario(id);
        }


    }
}
