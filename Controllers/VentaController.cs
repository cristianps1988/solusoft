using Solusoft.Data;
using Solusoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Solusoft.Controllers
{
    public class VentaController : ApiController
    {
        // GET api/venta
        public List<Venta> Get()
        {
            return VentaData.ListarVentas();
        }

        // GET api/venta/5
        public Venta Get(int id)
        {
            return VentaData.ConsultarVenta(id);
        }

        // POST api/venta
        public int Post([FromBody] Venta venta)
        {
            return VentaData.RegistrarVenta(venta);
        }

        // PUT api/venta
        public bool Put([FromBody] Venta venta)
        {
            return VentaData.ActualizarVenta(venta);
        }

        // DELETE api/venta/5
        public bool Delete(int id)
        {
            return VentaData.EliminarVenta(id);
        }

    }
}
