using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Acción que devuelve la vista principal de la aplicación.
        /// </summary>
        /// <returns>Devuelve la vista asociada a la acción Index.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
