using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class InventarioData
    {
        public static bool RegistrarInventario(Inventario inventario)
        {
            ConexionBD conexion = new ConexionBD();
            string fechaCaducidad = inventario.Fecha_Caducidad.HasValue
                ? $"'{inventario.Fecha_Caducidad.Value.ToString("yyyy-MM-dd")}'"
                : "NULL";

            string sentencia = $"EXEC usp_RegistrarInventario {inventario.ID_Producto}, {inventario.Cantidad}, '{inventario.Fecha_Ingreso:yyyy-MM-dd}', {fechaCaducidad}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool ActualizarInventario(Inventario inventario)
        {
            ConexionBD conexion = new ConexionBD();
            string fechaCaducidad = inventario.Fecha_Caducidad.HasValue
                ? $"'{inventario.Fecha_Caducidad.Value.ToString("yyyy-MM-dd")}'"
                : "NULL";

            string sentencia = $"EXEC usp_ActualizarInventario {inventario.ID_Inventario}, {inventario.ID_Producto}, {inventario.Cantidad}, '{inventario.Fecha_Ingreso:yyyy-MM-dd}', {fechaCaducidad}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool EliminarInventario(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarInventario {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static Inventario ConsultarInventario(int id)
        {
            Inventario inventario = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarInventario {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    inventario = new Inventario
                    {
                        ID_Inventario = Convert.ToInt32(dr["ID_Inventario"]),
                        ID_Producto = Convert.ToInt32(dr["ID_Producto"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha_Ingreso = Convert.ToDateTime(dr["Fecha_Ingreso"]),
                        Fecha_Caducidad = dr["Fecha_Caducidad"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Fecha_Caducidad"]),
                        NombreProducto = dr["NombreProducto"].ToString()
                    };
                }
            }

            return inventario;
        }

        public static List<Inventario> ListarInventario()
        {
            List<Inventario> lista = new List<Inventario>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarInventario";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Inventario
                    {
                        ID_Inventario = Convert.ToInt32(dr["ID_Inventario"]),
                        ID_Producto = Convert.ToInt32(dr["ID_Producto"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Fecha_Ingreso = Convert.ToDateTime(dr["Fecha_Ingreso"]),
                        Fecha_Caducidad = dr["Fecha_Caducidad"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Fecha_Caducidad"]),
                        NombreProducto = dr["NombreProducto"].ToString()
                    });
                }
            }

            return lista;
        }



    }
}