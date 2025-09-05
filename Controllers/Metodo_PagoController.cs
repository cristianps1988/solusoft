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
    public class Metodo_PagoController : ApiController
    {

        // GET api/metodopago
        public List<Metodo_Pago> Get()
        {
            return Metodo_PagoData.ListarMetodosPago();
        }

        // GET api/metodopago/5
        public Metodo_Pago Get(int id)
        {
            return Metodo_PagoData.ConsultarMetodoPago(id);
        }

        // POST api/metodopago
        public bool Post([FromBody] Metodo_Pago metodo)
        {
            return Metodo_PagoData.RegistrarMetodoPago(metodo);
        }

        // PUT api/metodopago
        public bool Put([FromBody] Metodo_Pago metodo)
        {
            return Metodo_PagoData.ActualizarMetodoPago(metodo);
        }

        // DELETE api/metodopago/5
        public bool Delete(int id)
        {
            return Metodo_PagoData.EliminarMetodoPago(id);
        }





    }
}
