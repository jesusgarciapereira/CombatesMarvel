using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Acci�n que devuelve la vista principal de la aplicaci�n.
        /// </summary>
        /// <returns>Devuelve la vista asociada a la acci�n Index.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
