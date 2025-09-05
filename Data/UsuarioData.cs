using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class UsuarioData {
        public static bool RegistrarUsuario(Usuario usuario)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarUsuario {usuario.ID_Empleado}, '{usuario.Nombre_Usuario}', '{usuario.Contraseña}', '{usuario.Rol}', {(usuario.Estado ? 1 : 0)}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool ActualizarUsuario(Usuario usuario)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarUsuario {usuario.ID_Empleado}, '{usuario.Nombre_Usuario}', '{usuario.Contraseña}', '{usuario.Rol}', {(usuario.Estado ? 1 : 0)}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static bool EliminarUsuario(int idEmpleado)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarUsuario {idEmpleado}";

            return conexion.EjecutarSentencia(sentencia, false);
        }

        public static Usuario ConsultarUsuario(int idEmpleado)
        {
            Usuario usuario = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarUsuario {idEmpleado}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    usuario = new Usuario
                    {
                        ID_Empleado = Convert.ToInt32(dr["ID_Empleado"]),
                        Nombre_Usuario = dr["Nombre_Usuario"].ToString(),
                        Contraseña = dr["Contraseña"].ToString(),
                        Rol = dr["Rol"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    };
                }
            }

            return usuario;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarUsuarios";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Usuario
                    {
                        ID_Empleado = Convert.ToInt32(dr["ID_Empleado"]),
                        Nombre_Usuario = dr["Nombre_Usuario"].ToString(),
                        Contraseña = dr["Contraseña"].ToString(),
                        Rol = dr["Rol"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        NombreEmpleado = $"{dr["Nombre"]} {dr["Apellidos"]}" 
                    });
                }
            }

            return lista;
        }


    }
}