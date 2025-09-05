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
    public class CategoriaProductoController : ApiController
    {
        // GET api/categoriaproducto
        public List<CategoriaProducto> Get()
        {
            return CategoriaProductoData.ListarCategorias();
        }

        // GET api/categoriaproducto/5
        public CategoriaProducto Get(int id)
        {
            return CategoriaProductoData.ObtenerCategoria(id);
        }

        // POST api/categoriaproducto
        public bool Post([FromBody] CategoriaProducto categoria)
        {
            return CategoriaProductoData.RegistrarCategoria(categoria);
        }

        // PUT api/categoriaproducto
        public bool Put([FromBody] CategoriaProducto categoria)
        {
            return CategoriaProductoData.ActualizarCategoria(categoria);
        }

        // DELETE api/categoriaproducto/5
        public bool Delete(int id)
        {
            return CategoriaProductoData.EliminarCategoria(id);
        }



    }
}

