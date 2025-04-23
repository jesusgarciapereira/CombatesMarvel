using BL;
using ENT;

namespace ASP.Models.VM
{
    public class clsPuntuacionCombateVM : clsCombate
    {
        private List<clsLuchador> listadoLuchadores;


        public List<clsLuchador> ListadoLuchadores
        {
            get { return listadoLuchadores; }
        }

        public clsPuntuacionCombateVM() : base()
        {
            this.listadoLuchadores = clsListadosLuchadoresBL.ObtenerListadoLuchadoresBL();
            listadoLuchadores.Insert(0, new clsLuchador(0, "--- Seleccione un Luchador ---", ""));
        }

        public clsPuntuacionCombateVM(clsCombate combate) : base(combate.IdLuchador1, combate.IdLuchador2, combate.PuntosLuchador1, combate.PuntosLuchador2)
        {
            this.listadoLuchadores = clsListadosLuchadoresBL.ObtenerListadoLuchadoresBL();
            listadoLuchadores.Insert(0, new clsLuchador(0, "--- Seleccione un Luchador ---", ""));
        }
    }
}
