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

    #region M�todos
    /// <summary>
    /// M�todo que se ejecuta cuando la p�gina aparece en pantalla.
    /// Sobreescritura: Llama al m�todo para actualizar la clasificaci�n de luchadores.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        miVM.actualizarClasificacion();
    }
    #endregion
}