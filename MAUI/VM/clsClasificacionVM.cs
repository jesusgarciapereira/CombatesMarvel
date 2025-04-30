using BL;
using DTO;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM
{
    public class clsClasificacionVM : INotifyPropertyChanged
    {
        #region Atributos
        private ObservableCollection<clsLuchadorConPuntuacionTotal> listaLuchadoresConPuntuacionTotal;
        #endregion

        #region Propiedades
        public ObservableCollection<clsLuchadorConPuntuacionTotal> ListaLuchadoresConPuntuacionTotal
        {
            get { return listaLuchadoresConPuntuacionTotal; }
            set
            {
                listaLuchadoresConPuntuacionTotal = value;
                NotifyPropertyChanged(nameof(ListaLuchadoresConPuntuacionTotal));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructores
        public clsClasificacionVM()
        {
            actualizarClasificacion();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Actualiza la lista de luchadores con su puntuación total llamando a la Base de Datos.
        /// Se asigna a la propiedad para notificar el cambio y actualizar la vista.
        /// </summary>
        public void actualizarClasificacion() {

            // En mayúscula porque necesito que llame al set para notificarlo
            ListaLuchadoresConPuntuacionTotal = new ObservableCollection<clsLuchadorConPuntuacionTotal>
                    (clsListadosLuchadoresConPuntuacionTotalBL.ObtenerListadoLuchadoresConPuntuacionTotalBL());
        }


        /// <summary>
        /// Lanza el evento PropertyChanged para notificar a la vista que una propiedad ha cambiado.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad que cambió.</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
