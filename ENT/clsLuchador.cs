using System.ComponentModel.DataAnnotations;

namespace ENT
{
    public class clsLuchador
    {
        #region Atributos
        private int idLuchador;
        private string nombre;
        private string foto;
        // private string puntuacion; // En nuestra BBDD no
        #endregion

        #region Propiedades
        [Display(Name = "ID")]
        public int IdLuchador
        {
            get { return idLuchador; }
            set { idLuchador = value; } // Puede que sí o puede que no
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        #endregion

        #region Constructores
        public clsLuchador()
        {
        }

        public clsLuchador(int idLuchador)
        {
            this.idLuchador = idLuchador;
        }

        public clsLuchador(int idLuchador, string nombre, string foto) 
        {
            this.idLuchador = idLuchador;
            this.nombre = nombre;
            this.foto = foto;
        }
        #endregion
    }
}
