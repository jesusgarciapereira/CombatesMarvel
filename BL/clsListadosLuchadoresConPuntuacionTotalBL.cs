using DAL;
using DAL.Conexion;
using DTO;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadosLuchadoresConPuntuacionTotalBL
    {
        #region Métodos
        /// <summary>
        /// Obtiene el listado completo de luchadores con puntuacion total desde la capa DAL.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsLuchadorConPuntuacionTotal con las reglas de negocio aplicadas.</returns>
        public static List<clsLuchadorConPuntuacionTotal> ObtenerListadoLuchadoresConPuntuacionTotalBL()
        {    
            return clsListadosLuchadoresConPuntuacionTotalDAL.ObtenerListadoLuchadoresConPuntuacionTotalDAL();
        }
        #endregion
    }
}
