using ASP.Models;
using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class ClasificacionController : Controller
    {

        public IActionResult Index()
        {
            List<clsLuchadorConPuntuacionTotal> listadoLuchadoresConPuntuacionTotal = clsListadosLuchadoresConPuntuacionTotalBL.ObtenerListadoLuchadoresConPuntuacionTotalBL();

            return View(listadoLuchadoresConPuntuacionTotal);
        }
    }
}
