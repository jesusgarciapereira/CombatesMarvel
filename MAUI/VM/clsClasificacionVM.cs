using BL;
using DTO;
using ENT;
using Microsoft.Data.SqlClient;
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
            //set
            //{
            //    listaLuchadoresConPuntuacionTotal = value;
            //    NotifyPropertyChanged(nameof(ListaLuchadoresConPuntuacionTotal));
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructores
        public clsClasificacionVM()
        {
            // No hace falta dos veces
            // actualizarClasificacion();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Actualiza la lista de luchadores con su puntuación total llamando a la Base de Datos.
        /// </summary>
        public void actualizarClasificacion()
        {
            try
            { 
                listaLuchadoresConPuntuacionTotal = new ObservableCollection<clsLuchadorConPuntuacionTotal>
                        (clsListadosLuchadoresConPuntuacionTotalBL.ObtenerListadoLuchadoresConPuntuacionTotalBL());
               
                // Aquí se debe notificar, no en un set
                NotifyPropertyChanged(nameof(ListaLuchadoresConPuntuacionTotal));

            }
            catch (SqlException ex)

            {
                muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");
            }

        }


        /// <summary>
        /// Lanza el evento PropertyChanged para notificar a la vista que una propiedad ha cambiado.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad que cambió.</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Muestra un mensaje emergente en la pantalla principal de la aplicación.
        /// </summary>
        /// <param name="titulo">Título del mensaje.</param>
        /// <param name="cuerpo">Cuerpo del mensaje.</param>
        /// <param name="boton">Texto del botón de cierre.</param>
        private async void muestraMensaje(string titulo, string cuerpo, string boton)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, cuerpo, boton);
        }

        #endregion

    }
}
