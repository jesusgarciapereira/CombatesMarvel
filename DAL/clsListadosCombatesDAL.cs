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
    public class clsListadosCombatesDAL
    {
        #region Metodos
        /// <summary>
        /// Obtiene el listado completo de Combates de la BBDD.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsCombate</returns>
        public static List<clsCombate> ObtenerListadoCombatesDAL()
        {
            // Declaración de variables para la conexión y operaciones con la base de datos
            SqlConnection miConexion;                   // Objeto para la conexión a SQL Server
            SqlCommand miComando = new SqlCommand();    // Objeto para ejecutar comandos SQL
            SqlDataReader miLector;                     // Objeto para leer los resultados de la consulta

            List<clsCombate> listadoCompletoCombates = new List<clsCombate>();
            clsCombate combate;

            try
            {
                // Establece la conexión con la base de datos
                miConexion = clsMyConnection.getConnection();

                // Configura el comando SQL que se va a ejecutar (consulta SELECT simple)
                miComando.CommandText = "SELECT * FROM Combates";
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
                        // Crea un nuevo objeto clsCombate usando el constructor que recibe todos los PK
                        // Los cast son necesarios porque el lector devuelve objetos
                        combate = new clsCombate(
                            (int)miLector["idLuchador1"], 
                            (int)miLector["idLuchador2"], 
                            DateTime.Parse((string)miLector["fecha"])
                            );

                        // Asigna los puntos del Luchador1, verificando primero que no sea NULL en la BD
                        if (miLector["puntosLuchador1"] != DBNull.Value)
                        {
                            combate.PuntosLuchador1 = (int)miLector["puntosLuchador1"];
                        }

                        // Asigna los puntos del Luchador2, verificando primero que no sea NULL en la BD
                        if (miLector["puntosLuchador2"] != DBNull.Value)
                        {
                            combate.PuntosLuchador2 = (int)miLector["puntosLuchador2"];
                        }


                        listadoCompletoCombates.Add(combate);
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
            return listadoCompletoCombates;
        }

        #endregion
    }
}
