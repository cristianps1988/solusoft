using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class VentaData
    {
        public static int RegistrarVenta(Venta venta)
        {
            ConexionBD conexion = new ConexionBD();
            int idVentaGenerado = 0;

            string sentencia = $"EXEC usp_RegistrarVenta '{venta.Fecha:yyyy-MM-dd}', {venta.Total}, {venta.ID_Cliente}, {venta.ID_Empleado}, {venta.ID_Metodo}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    idVentaGenerado = Convert.ToInt32(dr["ID_Venta"]);
                }
            }

            return idVentaGenerado;
        }

        public static bool ActualizarVenta(Venta venta)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarVenta {venta.ID_Venta}, '{venta.Fecha:yyyy-MM-dd}', {venta.Total}, {venta.ID_Cliente}, {venta.ID_Empleado}, {venta.ID_Metodo}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool EliminarVenta(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarVenta {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static Venta ConsultarVenta(int id)
        {
            Venta venta = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarVenta {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    venta = new Venta
                    {
                        ID_Venta = Convert.ToInt32(dr["ID_Venta"]),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Total = Convert.ToDecimal(dr["Total"]),
                        ID_Cliente = Convert.ToInt32(dr["ID_Cliente"]),
                        ID_Empleado = Convert.ToInt32(dr["ID_Empleado"]),
                        ID_Metodo = Convert.ToInt32(dr["ID_Metodo"]),
                        Cliente = dr["Cliente"].ToString(),
                        Empleado = dr["Empleado"].ToString(),
                        MetodoPago = dr["MetodoPago"].ToString()
                    };
                }
            }

            return venta;
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarVentas";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Venta
                    {
                        ID_Venta = Convert.ToInt32(dr["ID_Venta"]),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Total = Convert.ToDecimal(dr["Total"]),
                        Cliente = dr["Cliente"].ToString(),
                        Empleado = dr["Empleado"].ToString(),
                        MetodoPago = dr["MetodoPago"].ToString()
                    });
                }
            }

            return lista;
        }



    }
}