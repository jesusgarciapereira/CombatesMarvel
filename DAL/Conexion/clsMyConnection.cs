using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _server: cadena 
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//

namespace DAL.Conexion
{
    public class clsMyConnection
    {
        #region Propiedades
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        #endregion


        #region Constructores
        public clsMyConnection()
        {

            this.Server = "jesus-garcia.database.windows.net";
            this.DataBase = "JesusDB";
            this.User = "usuario";
            this.Pass = "java.Jesus90";

        }
        //Con parámetros por si quisiera cambiar las conexiones
        public clsMyConnection(String server, String database, String user, String pass)
        {
            this.Server = server;
            this.DataBase = database;
            this.User = user;
            this.Pass = pass;
        }
        #endregion


        #region Métodos
        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión abierta con la base de datos</returns>
        public static SqlConnection getConnection() // ¿No sería lo ideal que este método sea static?
        {
            SqlConnection connection = new SqlConnection();
            clsMyConnection conexionConfig = new clsMyConnection();

            try
            {
                connection.ConnectionString = $"server={conexionConfig.Server};database={conexionConfig.DataBase};uid={conexionConfig.User};pwd={conexionConfig.Pass};";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }

        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>La conexion es cerrada</post>
        /// <param name="connection">SqlConnection pr referencia. Conexion a cerrar
        /// </param>
        public static void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}

