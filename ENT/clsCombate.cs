using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ENT
{
    public class clsCombate
    {
        private int idLuchador1;
        private int idLuchador2;
        private DateTime fecha;
        private int puntosLuchador1;
        private int puntosLuchador2;

        public int IdLuchador1
        {
            get { return idLuchador1; }
            set { idLuchador1 = value; } // Puede que sí o puede que no
        }

        public int IdLuchador2
        {
            get { return idLuchador2; }
            set { idLuchador2 = value; } // Puede que sí o puede que no
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; } // No lo creo ¿o puede?
        }

        public int PuntosLuchador1
        {
            get { return puntosLuchador1; }
            set { puntosLuchador1 = value; }
        }

        public int PuntosLuchador2
        {
            get { return puntosLuchador2; }
            set { puntosLuchador2 = value; }
        }

        public clsCombate()
        {
            this.fecha = DateTime.Now;

        }

        public clsCombate(int idLuchador1, int idLuchador2, DateTime fecha)
        {
            this.idLuchador1 = idLuchador1;
            this.idLuchador2 = idLuchador2;
            this.fecha = fecha;
        }

        public clsCombate(int idLuchador1, int idLuchador2, DateTime fecha, int puntosLuchador1, int puntosLuchador2)
        {
            this.idLuchador1 = idLuchador1;
            this.idLuchador2 = idLuchador2;
            this.fecha = fecha;
            this.puntosLuchador1 = puntosLuchador1;
            this.puntosLuchador2 = puntosLuchador2;
        }
    }
}
