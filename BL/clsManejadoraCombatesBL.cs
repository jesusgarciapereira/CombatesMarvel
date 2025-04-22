using DAL;
using DAL.Conexion;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsManejadoraCombatesBL
    {
        #region Métodos

        /// <summary>
        /// Funcion asociada al boton guardar, crea o actualiza el combate que le pasamos por parámetro desde la capa DAL
        /// </summary>
        /// <param name="combate">Objeto de tipo clsCombate</param>
        /// <returns>True o false según si se ha llevado a cabo la acción con las reglas de negocio aplicadas</returns>
        public static bool GuardarCombateBL(clsCombate combate)
        {
            return clsManejadoraCombatesDAL.GuardarCombateDAL(combate);

        }
        #endregion
    }
}
