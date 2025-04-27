
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
    public class clsPuntuacionCombateVM : clsCombate
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

        public DelegateCommand BotonGuardar
        {
            get { return botonGuardar; }
        }
        #endregion

        #region Constructores
        public clsPuntuacionCombateVM() : base()
        {
            botonGuardar = new DelegateCommand(guardarExecute); // Si quieres añade un parámetro/funcion para habilitar el command

            try
            {
                listadoLuchadores = clsListadosLuchadoresBL.ObtenerListadoLuchadoresBL();
            }
            catch (SqlException e) // Mejor SQLException
            {
                muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");
            }



        }

        // creo que este constructor no hace falta
        public clsPuntuacionCombateVM(clsCombate combate, List<clsLuchador> listadoLuchadores, int puntuacionMaxima) : base(combate.IdLuchador1, combate.IdLuchador2, combate.PuntosLuchador1, combate.PuntosLuchador2)
        {
            this.listadoLuchadores = listadoLuchadores;
            this.puntuacionMaxima = puntuacionMaxima;
        }
        #endregion

        #region Funciones
        private async void muestraMensaje(string titulo, string cuerpo, string boton)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, cuerpo, boton);
        }


        #endregion

        #region Comandos
        /// <summary>
        /// Método asociado al execute del comando botonEnviar que actualiza la raza del caballo seleccionado
        /// </summary>
        private void guardarExecute()
        {
            bool hecho = false;

            if (luchadorElegido1 == null || luchadorElegido2 == null)
            {
                muestraMensaje("Error", $"Debes seleccionar a dos Luchadores", "OK");
            }
            else if (
                luchadorElegido1.IdLuchador == luchadorElegido2.IdLuchador)
            {
                muestraMensaje("Error", $"Los Luchadores seleccionados deben ser dferentes", "OK");
            }
            else
            {
                try
                {
                    // No sé si es así
                    combate = new clsCombate(luchadorElegido1.IdLuchador, luchadorElegido2.IdLuchador, PuntosLuchador1, PuntosLuchador2);

                    hecho = clsManejadoraCombatesBL.GuardarCombateBL(combate);
                }
                catch (SqlException e)
                {
                    muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");
                }
            }

            if (hecho)
            {
                muestraMensaje("Info", $"Se ha puntuado el combate perfectamente", "OK");
            }
        }

        private bool habilitarGuardar()
        {
            bool habilitado = false;

            if (luchadorElegido1 != null && luchadorElegido2 != null)
            {
                habilitado = true;
            }

            return habilitado;

        }

        #endregion
    }
}

