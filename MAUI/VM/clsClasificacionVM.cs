using BL;
using DTO;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM
{
    public class clsClasificacionVM
    {
        private List<clsLuchadorConPuntuacionTotal> listaLuchadoresConPuntuacionTotal;

        public List<clsLuchadorConPuntuacionTotal> ListaLuchadoresConPuntuacionTotal
        {
            get { return listaLuchadoresConPuntuacionTotal; }
        }

        public clsClasificacionVM() 
        {
            listaLuchadoresConPuntuacionTotal = clsListadosLuchadoresConPuntuacionTotalBL.ObtenerListadoLuchadoresConPuntuacionTotalBL();
        }

    }
}
