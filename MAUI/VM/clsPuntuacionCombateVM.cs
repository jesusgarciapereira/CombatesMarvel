using ENT;
using MAUI.VM.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM
{
    public class clsPuntuacionCombateVM : clsCombate
    {
        #region Atributos
        private ObservableCollection<clsLuchador> listadoLuchadores;
        private int puntuacionMaxima;
        private clsLuchador luchadorElegido1;
        private clsLuchador luchadorElegido2;
        private int puntuacionElegida1;
        private int puntuacionElegida2;
        private DelegateCommand botonEnviar;
        private clsCombate combate;
        #endregion

        #region Propiedades
        public ObservableCollection<clsLuchador> ListadoLuchadores
        {
            get { return listadoLuchadores; }
        }

        public int PuntuacionMaxima
        {
            get { return puntuacionMaxima; }
        }

        public clsLuchador LuchadorElegido1
        {
            get { return luchadorElegido1; }
            set { luchadorElegido1 = value; }
        }

        public clsLuchador LuchadorElegido2
        {
            get { return luchadorElegido2; }
            set { luchadorElegido2 = value; }
        }

        public int PuntuacionElegida1
        {
            get { return puntuacionElegida1; }
            set { puntuacionElegida1 = value; }
        }

        public int PuntuacionElegida2
        {
            get { return puntuacionElegida2; }
            set { puntuacionElegida2 = value; }
        }

        public DelegateCommand BotonEnviar
        {
            get { return botonEnviar; }
        }
        #endregion

        #region Constructores
        public clsPuntuacionCombateVM() : base()
        {
        }

        public clsPuntuacionCombateVM(clsCombate combate, ObservableCollection<clsLuchador> listadoLuchadores,int puntuacionMaxima) : base(combate.IdLuchador1, combate.IdLuchador2, combate.PuntosLuchador1, combate.PuntosLuchador2)
        {
            this.listadoLuchadores = listadoLuchadores;
            this.puntuacionMaxima = puntuacionMaxima;
        }
        #endregion
    }
}
