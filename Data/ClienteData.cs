using Solusoft.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solusoft.Data
{
    public class ClienteData
    {
        public static bool RegistrarCliente(Cliente cliente)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_RegistrarCliente '{cliente.Nombre}', '{cliente.Apellidos}', '{cliente.Telefono}', '{cliente.Correo}', '{cliente.Direccion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }


        public static bool ActualizarCliente(Cliente cliente)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ActualizarCliente {cliente.ID_Cliente}, '{cliente.Nombre}', '{cliente.Apellidos}', '{cliente.Telefono}', '{cliente.Correo}', '{cliente.Direccion}'";

            return conexion.EjecutarSentencia(sentencia, false);
        }


        public static bool EliminarCliente(int id)
        {
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_EliminarCliente {id}";

            return conexion.EjecutarSentencia(sentencia, false);
        }


        public static List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "EXEC usp_ListarClientes";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        ID_Cliente = Convert.ToInt32(dr["ID_Cliente"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    });
                }
            }

            return lista;
        }

        public static Cliente ObtenerCliente(int id)
        {
            Cliente cliente = null;
            ConexionBD conexion = new ConexionBD();
            string sentencia = $"EXEC usp_ConsultarCliente {id}";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                if (dr.Read())
                {
                    cliente = new Cliente
                    {
                        ID_Cliente = Convert.ToInt32(dr["ID_Cliente"]),
                        Nombre = dr["Nombre"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    };
                }
            }

            return cliente;
        }

    }
}