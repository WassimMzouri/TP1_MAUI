namespace TP1_MAUI.Views;

public partial class vEcran : ContentPage
{
	public vEcran()
	{
		InitializeComponent();
	}

    private async void Ecran_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(vEcran));

    }
}