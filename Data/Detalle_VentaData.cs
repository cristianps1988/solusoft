using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class Detalle_VentaData
    {
        public static bool RegistrarDetalleVenta(Detalle_Venta detalle)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarDetalleVenta {detalle.ID_Venta}, {detalle.ID_Producto}, {detalle.Cantidad}, {detalle.Precio_Unitario}, {detalle.Subtotal}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool ActualizarDetalleVenta(Detalle_Venta detalle)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarDetalleVenta {detalle.ID_Detalle}, {detalle.ID_Venta}, {detalle.ID_Producto}, {detalle.Cantidad}, {detalle.Precio_Unitario}, {detalle.Subtotal}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool EliminarDetalleVenta(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarDetalleVenta {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static Detalle_Venta ConsultarDetalleVenta(int id)
        {
            Detalle_Venta detalle = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarDetalleVenta {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    detalle = new Detalle_Venta
                    {
                        ID_Detalle = Convert.ToInt32(dr["ID_Detalle"]),
                        ID_Venta = Convert.ToInt32(dr["ID_Venta"]),
                        ID_Producto = Convert.ToInt32(dr["ID_Producto"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Precio_Unitario = Convert.ToDecimal(dr["Precio_Unitario"]),
                        Subtotal = Convert.ToDecimal(dr["Subtotal"]),
                        Producto = dr["Producto"].ToString() // viene del JOIN en el procedimiento Almacenado
                    };
                }
            }

            return detalle;
        }

        public static List<Detalle_Venta> ListarDetallesPorVenta(int idVenta)
        {
            List<Detalle_Venta> lista = new List<Detalle_Venta>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ListarDetallesPorVenta {idVenta}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Detalle_Venta
                    {
                        ID_Detalle = Convert.ToInt32(dr["ID_Detalle"]),
                        Producto = dr["Producto"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Precio_Unitario = Convert.ToDecimal(dr["Precio_Unitario"]),
                        Subtotal = Convert.ToDecimal(dr["Subtotal"])
                    });
                }
            }

            return lista;
        }

    }
}