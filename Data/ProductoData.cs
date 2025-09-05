using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class ProductoData
    {
        public static bool RegistrarProducto(Producto producto)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarProducto '{producto.Nombre}', '{producto.Descripcion}', {producto.Precio}, {producto.Stock}, {producto.ID_Categoria}, {producto.ID_Proveedor}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool ActualizarProducto(Producto producto)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarProducto {producto.ID_Producto}, '{producto.Nombre}', '{producto.Descripcion}', {producto.Precio}, {producto.Stock}, {producto.ID_Categoria}, {producto.ID_Proveedor}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool EliminarProducto(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarProducto {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static Producto ConsultarProducto(int id)
        {
            Producto producto = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarProducto {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    producto = new Producto
                    {
                        ID_Producto = Convert.ToInt32(dr["ID_Producto"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        ID_Categoria = Convert.ToInt32(dr["ID_Categoria"]),
                        ID_Proveedor = Convert.ToInt32(dr["ID_Proveedor"])
                    };
                }
            }

            return producto;
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarProductos";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Producto
                    {
                        ID_Producto = Convert.ToInt32(dr["ID_Producto"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        ID_Categoria = Convert.ToInt32(dr["ID_Categoria"]),
                        ID_Proveedor = Convert.ToInt32(dr["ID_Proveedor"])
                    });
                }
            }

            return lista;
        }




    }
}