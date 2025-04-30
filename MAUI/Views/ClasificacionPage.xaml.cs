using BL;
using MAUI.VM;

namespace MAUI.Views;

public partial class ClasificacionPage : ContentPage
{
    clsClasificacionVM miVM;


    public ClasificacionPage()
	{
		InitializeComponent();
        
        miVM = (clsClasificacionVM)this.BindingContext;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        miVM.actualizarClasificacion();
    }
}