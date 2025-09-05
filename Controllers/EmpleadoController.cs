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
    public class EmpleadoController : ApiController
    {
        // GET api/empleado
        public List<Empleado> Get()
        {
            return EmpleadoData.ListarEmpleados();
        }

        // GET api/empleado/5
        public Empleado Get(int id)
        {
            return EmpleadoData.ConsultarEmpleado(id);
        }

        // POST api/empleado
        public bool Post([FromBody] Empleado empleado)
        {
            return EmpleadoData.RegistrarEmpleado(empleado);
        }

        // PUT api/empleado
        public bool Put([FromBody] Empleado empleado)
        {
            return EmpleadoData.ActualizarEmpleado(empleado);
        }

        // DELETE api/empleado/5
        public bool Delete(int id)
        {
            return EmpleadoData.EliminarEmpleado(id);
        }


    }
}
