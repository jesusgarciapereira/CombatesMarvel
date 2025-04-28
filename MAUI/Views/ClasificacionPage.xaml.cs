using BL;

namespace MAUI.Views;

public partial class ClasificacionPage : ContentPage
{
	public ClasificacionPage()
	{
		InitializeComponent();

        // Asignamos la lista de luchadores al CollectionView
        LuchadoresCollectionView.ItemsSource = clsListadosLuchadoresConPuntuacionTotalBL.ObtenerListadoLuchadoresConPuntuacionTotalBL();
    }
}