namespace TP1_MAUI.Views;

public partial class APropos : ContentPage
{
	public APropos()
	{
		InitializeComponent();
	}

    public async void APropos_Clicked(object sender, EventArgs e)
	{
        await Launcher.Default.OpenAsync("https://www.3il-ingenieurs.fr/");
    }
}