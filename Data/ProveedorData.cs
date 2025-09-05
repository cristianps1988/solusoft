using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Solusoft.Data
{
    public class ProveedorData
    {
        public static bool RegistrarProveedor(Proveedor proveedor)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarProveedor '{proveedor.Nombre}', '{proveedor.Telefono}', '{proveedor.Correo}', '{proveedor.Direccion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool ActualizarProveedor(Proveedor proveedor)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarProveedor {proveedor.ID_Proveedor}, '{proveedor.Nombre}', '{proveedor.Telefono}', '{proveedor.Correo}', '{proveedor.Direccion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool EliminarProveedor(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarProveedor {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static Proveedor ConsultarProveedor(int id)
        {
            Proveedor proveedor = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarProveedor {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    proveedor = new Proveedor
                    {
                        ID_Proveedor = Convert.ToInt32(dr["ID_Proveedor"]),
                        Nombre = dr["Nombre"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    };
                }
            }

            return proveedor;
        }

        public static List<Proveedor> ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarProveedores";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Proveedor
                    {
                        ID_Proveedor = Convert.ToInt32(dr["ID_Proveedor"]),
                        Nombre = dr["Nombre"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    });
                }
            }

            return lista;
        }

    }
}