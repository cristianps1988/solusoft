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
    public class Detalle_VentaController : ApiController
    {
        // GET api/detalleventa?idVenta=1
        [HttpGet]
        public List<Detalle_Venta> Get(int idVenta)
        {
            return Detalle_VentaData.ListarDetallesPorVenta(idVenta);
        }

        // GET api/detalleventa/5
        [HttpGet]
        [Route("api/detalleventa/detalle/{id}")]
        public Detalle_Venta GetDetalle(int id)
        {
            return Detalle_VentaData.ConsultarDetalleVenta(id);
        }

        // POST api/detalleventa
        public bool Post([FromBody] Detalle_Venta detalle)
        {
            return Detalle_VentaData.RegistrarDetalleVenta(detalle);
        }

        // PUT api/detalleventa
        public bool Put([FromBody] Detalle_Venta detalle)
        {
            return Detalle_VentaData.ActualizarDetalleVenta(detalle);
        }

        // DELETE api/detalleventa/5
        public bool Delete(int id)
        {
            return Detalle_VentaData.EliminarDetalleVenta(id);
        }




    }
}
