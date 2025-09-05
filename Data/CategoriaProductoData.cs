using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class CategoriaProductoData
    {
        public static bool RegistrarCategoria(CategoriaProducto categoria)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarCategoria '{categoria.Nombre}', '{categoria.Descripcion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }




        public static bool ActualizarCategoria(CategoriaProducto categoria)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarCategoria {categoria.ID_Categoria}, '{categoria.Nombre}', '{categoria.Descripcion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }




        public static bool EliminarCategoria(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarCategoria {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }



        public static CategoriaProducto ObtenerCategoria(int id)
        {
            CategoriaProducto categoria = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarCategoria {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    categoria = new CategoriaProducto
                    {
                        ID_Categoria = Convert.ToInt32(dr["ID_Categoria"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    };
                }
            }

            return categoria;
        }



        public static List<CategoriaProducto> ListarCategorias()
        {
            List<CategoriaProducto> lista = new List<CategoriaProducto>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarCategorias";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new CategoriaProducto
                    {
                        ID_Categoria = Convert.ToInt32(dr["ID_Categoria"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    });
                }
            }

            return lista;
        }





    }
}