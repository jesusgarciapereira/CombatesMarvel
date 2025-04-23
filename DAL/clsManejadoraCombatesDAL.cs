using DAL.Conexion;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsManejadoraCombatesDAL
    {
        #region Métodos
        /// <summary>
        /// Crea un nuevo Combate en la Base de Datos
        /// Pre: Ninguno
        /// Post: Ninguno
        /// </summary>
        /// <returns>El número de filas afectadas</returns>
        private static int CreaCombateDAL(clsCombate combate)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            // Recuerda poner el tipo que corresponda (Int, Varchar, Date...)
            miComando.Parameters.Add("@idLuchador1", SqlDbType.Int).Value = combate.IdLuchador1;
            miComando.Parameters.Add("@idLuchador2", SqlDbType.Int).Value = combate.IdLuchador2;
            miComando.Parameters.Add("@fecha", SqlDbType.Date).Value = combate.Fecha;
            miComando.Parameters.Add("@puntosLuchador1", SqlDbType.Int).Value = combate.PuntosLuchador1;
            miComando.Parameters.Add("@puntosLuchador2", SqlDbType.Int).Value = combate.PuntosLuchador2;

            try
            {
                miConexion = clsMyConnection.getConnection();

                miComando.CommandText = "INSERT INTO Combates VALUES (@idLuchador1, @idLuchador2, @fecha, @puntosLuchador1, @puntosLuchador2)";

                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

                clsMyConnection.closeConnection(ref miConexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Actualiza los datos del combate que pasamos por parámetro y devuelve el número de filas afectadas
        /// Pre: Las PK del objeto clsCombate que pasamos por parámetro deben existir en la Base de Datos
        /// Post: Ninguno
        /// </summary>
        /// <param name="combate">Objeto de tipo clsCombate</param>
        /// <returns>Cantidad de filas afectadas</returns>
        private static int ActualizaCombateDAL(clsCombate combate)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            // Recuerda poner el tipo que corresponda (Int, Varchar, Date...)
            miComando.Parameters.Add("@idLuchador1", SqlDbType.Int).Value = combate.IdLuchador1;
            miComando.Parameters.Add("@idLuchador2", SqlDbType.Int).Value = combate.IdLuchador2;
            miComando.Parameters.Add("@fecha", SqlDbType.Date).Value = combate.Fecha;
            miComando.Parameters.Add("@puntosLuchador1", SqlDbType.Int).Value = combate.PuntosLuchador1;
            miComando.Parameters.Add("@puntosLuchador2", SqlDbType.Int).Value = combate.PuntosLuchador2;

            try
            {
                miConexion = clsMyConnection.getConnection();

                miComando.CommandText = "UPDATE Combates SET puntosLuchador1+=@puntosLuchador1, puntosLuchador2+=@puntosLuchador2" +
                    " WHERE idLuchador1=@idLuchador1 AND idLuchador2=@idLuchador2 AND fecha=@fecha";

                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

                clsMyConnection.closeConnection(ref miConexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Consulta en la BBDD la existencia del combate que le pasamos por parámetro
        /// </summary>
        /// <param name="combate">Objeto de tipo clsCombate</param>
        /// <returns>0 si no existe, 1 si existe y 2 si existe pero con los id intercambiados</returns>
        private static int CompruebaExistenciaCombateDAL(clsCombate combate)
        {
            int resultado = 0;

            // Declaración de variables para la conexión y operaciones con la base de datos
            SqlConnection miConexion;                   // Objeto para la conexión a SQL Server
            SqlCommand miComando = new SqlCommand();    // Objeto para ejecutar comandos SQL
            SqlDataReader miLector;                     // Objeto para leer los resultados de la consulta

            // Recuerda poner el tipo que corresponda (Int, Varchar, Date...)
            miComando.Parameters.Add("@idLuchador1", SqlDbType.Int).Value = combate.IdLuchador1;
            miComando.Parameters.Add("@idLuchador2", SqlDbType.Int).Value = combate.IdLuchador2;
            miComando.Parameters.Add("@fecha", SqlDbType.Date).Value = combate.Fecha;

            try
            {
                // Establece la conexión con la base de datos
                miConexion = clsMyConnection.getConnection();

                // Configura el comando SQL que se va a ejecutar (consulta SELECT simple)
                miComando.CommandText = "SELECT * FROM Combates WHERE idLuchador1=@idLuchador1 AND idLuchador2=@idLuchador2 AND fecha=@fecha";
                // Asigna la conexión al comando
                miComando.Connection = miConexion;
                // Ejecuta el comando y obtiene un lector de datos
                miLector = miComando.ExecuteReader();

                // Verifica si el lector contiene filas (si hay datos)
                if (miLector.HasRows)
                {
                    resultado = 1;

                }
                else
                {
                    // Cierra el lector de datos (importante para liberar recursos)
                    miLector.Close();
                    // Cierra la conexión a la base de datos usando el método de la clase de conexión
                    clsMyConnection.closeConnection(ref miConexion);

                    // Establece la conexión con la base de datos
                    miConexion = clsMyConnection.getConnection();

                    miComando.CommandText = "SELECT * FROM Combates WHERE idLuchador1=@idLuchador2 AND idLuchador2=@idLuchador1 AND fecha=@fecha";
                    miComando.Connection = miConexion;
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        resultado = 2;
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

            return resultado;
        }

        /// <summary>
        /// Funcion asociada al boton guardar, crea o actualiza el combate que le pasamos por parámetro
        /// </summary>
        /// <param name="combate">Objeto de tipo clsCombate</param>
        /// <returns>True o false según si se ha llevado a cabo la acción</returns>
        public static bool GuardarCombateDAL(clsCombate combate)
        {
            bool hecho = false;
            try
            {
                int opcion = CompruebaExistenciaCombateDAL(combate);

                switch (opcion)
                {
                    case 0:
                        // El combate no existe, lo creamos
                        CreaCombateDAL(combate);

                        break;

                    case 1:
                        // El combate existe, lo actualizamos
                        ActualizaCombateDAL(combate);

                        break;

                    case 2:
                        // El combate existe pero con los id intercambiados, modificamos el parámetro y lo actualizamos
                        clsCombate combateIntercambio = new clsCombate(combate.IdLuchador2, combate.IdLuchador1, combate.Fecha, combate.PuntosLuchador2, combate.PuntosLuchador1);
                        ActualizaCombateDAL(combateIntercambio);
                        break;

                    default:
                        break;
                }

                hecho = true;
            }
            catch (SqlException exSql)
            {
                // Captura excepciones específicas de SQL y las relanza
                throw exSql;
            }
            return hecho;

        }
        #endregion
    }
}
