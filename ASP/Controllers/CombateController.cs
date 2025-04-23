using ASP.Models;
using ASP.Models.VM;
using BL;
using DTO;
using ENT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class CombateController : Controller
    {

        /// <summary>
        /// Acci�n GET que carga la vista inicial para introducir la puntuaci�n de un combate.
        /// Inicializa el ViewModel con los datos necesarios para el formulario.
        /// </summary>
        /// <returns>
        /// Vista con el formulario para registrar un combate o la vista de error personalizada en caso de excepci�n.
        /// </returns>
        public IActionResult Index()
        {
            clsPuntuacionCombateVM puntuacion;

            try
            {
                puntuacion = new clsPuntuacionCombateVM();
            }
            catch (Exception e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                return View("ErrorPersonalizado");
            }

            return View(puntuacion);
        }

        /// <summary>
        /// Acci�n POST que recibe los datos de un combate, los valida y guarda si son correctos.
        /// Muestra mensajes informativos seg�n el resultado de la operaci�n.
        /// </summary>
        /// <param name="combate">Objeto clsCombate con los datos del formulario.</param>
        /// <returns>
        /// Vista con los datos del combate introducido y el mensaje correspondiente, o la vista de error personalizada en caso de excepci�n.
        /// </returns>
        [HttpPost]
        public IActionResult Index(clsCombate combate)
        {
            bool hecho = false;

            clsPuntuacionCombateVM puntuacion;

            if (combate.IdLuchador1 == 0 || combate.IdLuchador2 == 0)
            {
                ViewBag.mensaje = "Tienes que seleccionar a dos Luchadores";
            }
            else
            {
                if (combate.IdLuchador1 != combate.IdLuchador2)
                {
                    try
                    {
                        hecho = clsManejadoraCombatesBL.GuardarCombateBL(combate);

                        if (hecho)
                        {
                            ViewBag.mensaje = "Puntuaci�n enviada correctamente";
                        }
                        else
                        {
                            ViewBag.mensaje = "Ha ocurrido un error. Int�ntelo m�s tarde";
                        }
                    }
                    catch (SqlException e)
                    {
                        // TODO: Lanzar mensaje de error. Vista Error
                        return View("ErrorPersonalizado");
                    }
                }
                else 
                {
                    ViewBag.mensaje = "Los Luchadores seleccionados deben ser diferentes";
                }
            }

            puntuacion = new clsPuntuacionCombateVM(combate);

            return View(puntuacion);


        }
    }
}
