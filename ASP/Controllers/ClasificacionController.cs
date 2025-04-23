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
        /// Acción que obtiene el listado de luchadores con su puntuación total y lo envía a la vista.
        /// En caso de error, redirige a la vista de error personalizada.
        /// </summary>
        /// <returns>
        /// Vista con el listado de luchadores con puntuación total o la vista de error personalizada en caso de excepción.
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
