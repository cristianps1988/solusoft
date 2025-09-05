using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Solusoft.Data
{
    public class EmpleadoData
    {
        public static bool RegistrarEmpleado(Empleado empleado)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarEmpleado '{empleado.Nombre}', '{empleado.Apellidos}', '{empleado.Telefono}', '{empleado.Direccion}', '{empleado.Cargo}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }


        public static bool ActualizarEmpleado(Empleado empleado)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarEmpleado {empleado.ID_Empleado}, '{empleado.Nombre}', '{empleado.Apellidos}', '{empleado.Telefono}', '{empleado.Direccion}', '{empleado.Cargo}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }



        public static bool EliminarEmpleado(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarEmpleado {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }



        public static Empleado ConsultarEmpleado(int id)
        {
            Empleado empleado = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarEmpleado {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    empleado = new Empleado
                    {
                        ID_Empleado = Convert.ToInt32(dr["ID_Empleado"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Cargo = dr["Cargo"].ToString()
                    };
                }
            }

            return empleado;
        }



        public static List<Empleado> ListarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarEmpleados";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Empleado
                    {
                        ID_Empleado = Convert.ToInt32(dr["ID_Empleado"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Cargo = dr["Cargo"].ToString()
                    });
                }
            }

            return lista;
        }





    }
}