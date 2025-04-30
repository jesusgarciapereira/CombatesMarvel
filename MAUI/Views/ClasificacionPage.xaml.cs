using BL;
using MAUI.VM;

namespace MAUI.Views;

public partial class ClasificacionPage : ContentPage
{
    #region Atributos
    clsClasificacionVM miVM;
    #endregion

    #region Constructores
    public ClasificacionPage()
	{
		InitializeComponent();
        
        miVM = (clsClasificacionVM)this.BindingContext;

    }
    #endregion

    #region Métodos
    /// <summary>
    /// Método que se ejecuta cuando la página aparece en pantalla.
    /// Sobreescritura: Llama al método para actualizar la clasificación de luchadores.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        miVM.actualizarClasificacion();
    }
    #endregion
}