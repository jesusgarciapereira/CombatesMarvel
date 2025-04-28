
using BL;
using ENT;
using MAUI.VM.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM
{
    public class clsPuntuacionCombateVM 
    {
        #region Atributos
        private List<clsLuchador> listadoLuchadores;
        private int puntuacionMaxima;
        private clsLuchador luchadorElegido1;
        private clsLuchador luchadorElegido2;
        private int puntuacionElegida1;
        private int puntuacionElegida2;
        private DelegateCommand botonGuardar;
        private clsCombate combate;
        #endregion

        #region Propiedades
        public List<clsLuchador> ListadoLuchadores
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
            set
            {
                luchadorElegido1 = value;
                botonGuardar.RaiseCanExecuteChanged();
            }
        }

        public clsLuchador LuchadorElegido2
        {
            get { return luchadorElegido2; }
            set
            {
                luchadorElegido2 = value;
                botonGuardar.RaiseCanExecuteChanged();
            }
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

        public DelegateCommand BotonGuardar
        {
            get { return botonGuardar; }
        }
        #endregion

        #region Constructores
        public clsPuntuacionCombateVM()

        {
            puntuacionElegida1 = 1;
            puntuacionElegida2 = 1;
            puntuacionMaxima = 5;

            botonGuardar = new DelegateCommand(guardarExecute, habilitarGuardar); // Si quieres añade un parámetro/funcion para habilitar el command

            try
            {
                listadoLuchadores = clsListadosLuchadoresBL.ObtenerListadoLuchadoresBL();
            }
            catch (SqlException e) // Mejor SQLException
            {
                muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");
            }



        }

        // Creo que este Constructor no hace falta
        //public clsPuntuacionCombateVM(clsCombate combate, List<clsLuchador> listadoLuchadores, int puntuacionMaxima) : base(combate.IdLuchador1, combate.IdLuchador2, combate.PuntosLuchador1, combate.PuntosLuchador2)
        //{
        //    this.listadoLuchadores = listadoLuchadores;
        //    this.puntuacionMaxima = puntuacionMaxima;
        //}
        #endregion

        #region Funciones
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

        #region Comandos
        /// <summary>
        /// Método asociado al execute del comando botonGuardar que guarda el Combate
        /// </summary>
        private void guardarExecute()
        {
            // Todas estas condiciones y mensajes son innecesarios si usamos habilitarGuardar()
            bool hecho = false;

            //if (luchadorElegido1 == null || luchadorElegido2 == null)
            //{
            //    muestraMensaje("Error", $"Debes seleccionar a dos Luchadores", "OK");
            //}
            //else if (
            //    luchadorElegido1.IdLuchador == luchadorElegido2.IdLuchador)
            //{
            //    muestraMensaje("Error", $"Los Luchadores seleccionados deben ser dferentes", "OK");
            //}
            //else
            //{
            try
            {
                combate = new clsCombate(luchadorElegido1.IdLuchador, luchadorElegido2.IdLuchador, puntuacionElegida1, puntuacionElegida2);

                hecho = clsManejadoraCombatesBL.GuardarCombateBL(combate);

                //Creo que aquí deberíamos actualizar la clasificación
            }
            catch (SqlException e)
            {
                muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");
            }
            //}

            if (hecho)
            {
                muestraMensaje("Info", $"Se ha puntuado el combate perfectamente", "OK");
            }
        }

        /// <summary>
        /// Método asociado al canExecute del comando botonGuardar que habilita o deshabilita el botón de guardar.
        /// </summary>
        /// <returns>True si se han seleccionado dos luchadores diferentes, false en caso contrario.</returns>
        private bool habilitarGuardar()
        {
            bool habilitado = false;

            if (luchadorElegido1 != null && luchadorElegido2 != null && luchadorElegido1.IdLuchador != luchadorElegido2.IdLuchador)
            {
                habilitado = true;
            }

            return habilitado;

        }

        #endregion
    }
}

