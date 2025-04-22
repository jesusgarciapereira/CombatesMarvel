using DAL.Conexion;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsListadosLuchadoresDAL
    {
        #region Metodos
        /// <summary>
        /// Obtiene el listado completo de Luchadores de la BBDD.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsLuchador</returns>
        public static List<clsLuchador> ObtenerListadoLuchadoresDAL()
        {
            // Declaración de variables para la conexión y operaciones con la base de datos
            SqlConnection miConexion;                   // Objeto para la conexión a SQL Server
            SqlCommand miComando = new SqlCommand();    // Objeto para ejecutar comandos SQL
            SqlDataReader miLector;                     // Objeto para leer los resultados de la consulta

            List<clsLuchador> listadoCompletoLuchadores = new List<clsLuchador>();
            clsLuchador luchador;

            try
            {
                // Establece la conexión con la base de datos
                miConexion = clsMyConnection.getConnection();

                // Configura el comando SQL que se va a ejecutar (consulta SELECT simple)
                miComando.CommandText = "SELECT * FROM Luchadores";
                // Asigna la conexión al comando
                miComando.Connection = miConexion;
                // Ejecuta el comando y obtiene un lector de datos
                miLector = miComando.ExecuteReader();

                // Verifica si el lector contiene filas (si hay datos)
                if (miLector.HasRows)
                {
                    // Lee fila por fila mientras haya datos
                    while (miLector.Read())
                    {
                        // Crea un nuevo objeto clsLuchador usando el constructor que recibe el id
                        // Los cast son necesarios porque el lector devuelve objetos
                        luchador = new clsLuchador((int)miLector["idLuchador"]);

                        // Asigna el nombre del luchador, verificando primero que no sea NULL en la BD
                        if (miLector["nombre"] != DBNull.Value)
                        {
                            luchador.Nombre = (string)miLector["nombre"];
                        }

                        // Asigna la foto del luchador, verificando primero que no sea NULL en la BD
                        if (miLector["foto"] != DBNull.Value)
                        {
                            luchador.Foto = (string)miLector["foto"];
                        }                      

                        listadoCompletoLuchadores.Add(luchador);
                    }
                }
                // Cierra el lector de datos (importante para liberar recursos)
                miLector.Close();
                // Cierra la conexión a la base de datos usando el método de la clase de conexión
                clsMyConnection.closeConnection(ref miConexion);
            }
            catch (SqlException exSql)
            {
                // Captura excepciones específicas de SQL y las relanza
                throw exSql;
            }

            // Devuelve la lista completa de luchadores obtenida de la base de datos
            return listadoCompletoLuchadores;
        }



        #endregion
    }
}
