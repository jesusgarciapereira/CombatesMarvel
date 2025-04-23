using ASP.Models;
using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class ClasificacionController : Controller
    {
        /// <summary>
        /// Acci�n que obtiene el listado de luchadores con su puntuaci�n total y lo env�a a la vista.
        /// En caso de error, redirige a la vista de error personalizada.
        /// </summary>
        /// <returns>
        /// Vista con el listado de luchadores con puntuaci�n total o la vista de error personalizada en caso de excepci�n.
        /// </returns>
        public IActionResult Index()
        {
            List<clsLuchadorConPuntuacionTotal> listadoLuchadoresConPuntuacionTotal;

            try
            {
                 listadoLuchadoresConPuntuacionTotal = clsListadosLuchadoresConPuntuacionTotalBL.ObtenerListadoLuchadoresConPuntuacionTotalBL();
            }
            catch (Exception e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                return View("ErrorPersonalizado");
            }
            

            return View(listadoLuchadoresConPuntuacionTotal);
        }
    }
}
