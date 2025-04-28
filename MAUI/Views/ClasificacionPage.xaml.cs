using BL;

namespace MAUI.Views;

public partial class ClasificacionPage : ContentPage
{
	public ClasificacionPage()
	{
		InitializeComponent();

        // Asignamos la lista de luchadores al CollectionView, no hace falta si tienes un VM
        //LuchadoresCollectionView.ItemsSource = clsListadosLuchadoresConPuntuacionTotalBL.ObtenerListadoLuchadoresConPuntuacionTotalBL();
    }
}