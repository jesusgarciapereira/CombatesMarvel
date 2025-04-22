using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTO
{
    public class clsLuchadorConPuntuacionTotal : clsLuchador
    {
        private int puntosTotales;

        public int PuntosTotales
        {
            get { return puntosTotales; }
            set { puntosTotales = value; } // ¿No tiene este?
        }

        public clsLuchadorConPuntuacionTotal()
        {
        }

        public clsLuchadorConPuntuacionTotal(clsLuchador luchador, int puntosTotales) : base(luchador.IdLuchador, luchador.Nombre, luchador.Foto)
        {
            this.puntosTotales = puntosTotales;
        }
    }
}
