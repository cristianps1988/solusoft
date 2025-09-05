using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class Metodo_PagoData
    {
        public static bool RegistrarMetodoPago(Metodo_Pago metodo)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarMetodoPago '{metodo.Descripcion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool ActualizarMetodoPago(Metodo_Pago metodo)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarMetodoPago {metodo.ID_Metodo}, '{metodo.Descripcion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool EliminarMetodoPago(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarMetodoPago {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static Metodo_Pago ConsultarMetodoPago(int id)
        {
            Metodo_Pago metodo = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarMetodoPago {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    metodo = new Metodo_Pago
                    {
                        ID_Metodo = Convert.ToInt32(dr["ID_Metodo"]),
                        Descripcion = dr["Descripcion"].ToString()
                    };
                }
            }

            return metodo;
        }

        public static List<Metodo_Pago> ListarMetodosPago()
        {
            List<Metodo_Pago> lista = new List<Metodo_Pago>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarMetodosPago";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Metodo_Pago
                    {
                        ID_Metodo = Convert.ToInt32(dr["ID_Metodo"]),
                        Descripcion = dr["Descripcion"].ToString()
                    });
                }
            }

            return lista;
        }





    }
}