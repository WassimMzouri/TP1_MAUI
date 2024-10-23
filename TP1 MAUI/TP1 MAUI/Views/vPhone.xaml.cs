using System.Text;
using Microsoft.Maui.Devices;

namespace TP1_MAUI.Views;

public partial class vPhone : ContentPage
{
	public vPhone()
	{
		InitializeComponent();
        Phone_Info();

    }

    // Méthode pour afficher les informations du téléphone
    public void Phone_Info()
    {
        // Créer une instance de StringBuilder
        StringBuilder sb = new StringBuilder();

        // Ajouter des informations sur le téléphone
        sb.AppendLine($"Modèle : {DeviceInfo.Current.Model}");
        sb.AppendLine($"Fabricant : {DeviceInfo.Current.Manufacturer}");
        sb.AppendLine($"Nom : {DeviceInfo.Name}");
        sb.AppendLine($"Version OS : {DeviceInfo.VersionString}");
        sb.AppendLine($"Plateforme : {DeviceInfo.Current.Platform}");

        // Afficher les informations dans le label "lbPhoneInfo"
        lbPhoneInfo.Text = sb.ToString();
    }

    // Méthode pour obtenir le type d'appareil (Téléphone, PC, Tablette)
    public string Get_Idiom()
    {
        string deviceType = "";

        // Vérifier l'idiom de l'appareil
        switch (DeviceInfo.Current.Idiom)
        {
            case DeviceIdiom.Phone:
                deviceType = "Téléphone";
                break;
            case DeviceIdiom.Tablet:
                deviceType = "Tablette";
                break;
            case DeviceIdiom.Desktop:
                deviceType = "PC";
                break;
            default:
                deviceType = "Inconnu";
                break;
        }

        // Afficher le type d'appareil dans le label (vous pouvez créer un label séparé si nécessaire)
        lbPhoneInfo.Text += $"\nType d'appareil : {deviceType}";

        return deviceType;
    }



    private async void Ecran_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(vEcran));
        Routing.RegisterRoute($"{nameof(vEcran)}", typeof(vEcran));


    }
}