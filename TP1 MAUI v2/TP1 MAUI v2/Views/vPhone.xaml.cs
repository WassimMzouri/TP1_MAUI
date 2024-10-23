namespace TP1_MAUI_v2.Views;
using Microsoft.Maui.Devices;  
using System.Text;

public partial class vPhone : ContentPage
{
	public vPhone()
	{
		InitializeComponent();
		Phone_Info();
        Routing.RegisterRoute($"{nameof(vEcran)}", typeof(vEcran));


    }

    private void Phone_Info()
	{
        // Créer un StringBuilder
        StringBuilder phoneInfo = new StringBuilder();

        // Ajouter les informations du DeviceInfo
        phoneInfo.AppendLine($"Modèle: {DeviceInfo.Current.Model}");
        phoneInfo.AppendLine($"Fabricant: {DeviceInfo.Current.Manufacturer}");
        phoneInfo.AppendLine($"Nom de l'appareil: {DeviceInfo.Name}");
        phoneInfo.AppendLine($"Version du système: {DeviceInfo.VersionString}");
        phoneInfo.AppendLine($"Plateforme: {DeviceInfo.Current.Platform}");

        // Afficher le contenu dans le Label "lbPhoneInfo"
        lbPhoneInfo.Text = phoneInfo.ToString();
    }

    // Méthode pour obtenir et afficher le type de device
    private void Get_Idiom()
    {
        string deviceType = "Inconnu";

        // Obtenir le type d'appareil
        var test = DeviceInfo.Current.Idiom;

        // Comparer le type d'appareil avec des conditions if-else
        if (test == DeviceIdiom.Phone)
        {
            deviceType = "Téléphone";
        }
        else if (test == DeviceIdiom.Tablet)
        {
            deviceType = "Tablette";
        }
        else if (test == DeviceIdiom.Desktop)
        {
            deviceType = "PC";
        }
        else
        {
            deviceType = "Inconnu";
        }

        // Afficher le type d'appareil dans le Label
        lbPhoneInfo.Text += $"\nType d'appareil: {deviceType}";
    }

    private async void Ecran_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(vEcran));
    }

    private async void Batterie_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(vBatterie));

    }
}