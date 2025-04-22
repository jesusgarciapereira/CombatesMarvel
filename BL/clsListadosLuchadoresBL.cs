using DAL;
using DAL.Conexion;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadosLuchadoresBL
    {
        #region Metodos
        /// <summary>
        /// Obtiene el listado completo de luchadores desde la capa DAL.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsLuchador con las reglas de negocio aplicadas.</returns>
        public static List<clsLuchador> ObtenerListadoLuchadoresBL()
        {
            return clsListadosLuchadoresDAL.ObtenerListadoLuchadoresDAL();
        }
        #endregion
    }
}