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

    // M�thode pour afficher les informations du t�l�phone
    public void Phone_Info()
    {
        // Cr�er une instance de StringBuilder
        StringBuilder sb = new StringBuilder();

        // Ajouter des informations sur le t�l�phone
        sb.AppendLine($"Mod�le : {DeviceInfo.Current.Model}");
        sb.AppendLine($"Fabricant : {DeviceInfo.Current.Manufacturer}");
        sb.AppendLine($"Nom : {DeviceInfo.Name}");
        sb.AppendLine($"Version OS : {DeviceInfo.VersionString}");
        sb.AppendLine($"Plateforme : {DeviceInfo.Current.Platform}");

        // Afficher les informations dans le label "lbPhoneInfo"
        lbPhoneInfo.Text = sb.ToString();
    }

    // M�thode pour obtenir le type d'appareil (T�l�phone, PC, Tablette)
    public string Get_Idiom()
    {
        string deviceType = "";

        // V�rifier l'idiom de l'appareil
        switch (DeviceInfo.Current.Idiom)
        {
            case DeviceIdiom.Phone:
                deviceType = "T�l�phone";
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

        // Afficher le type d'appareil dans le label (vous pouvez cr�er un label s�par� si n�cessaire)
        lbPhoneInfo.Text += $"\nType d'appareil : {deviceType}";

        return deviceType;
    }



    private async void Ecran_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(vEcran));
        Routing.RegisterRoute($"{nameof(vEcran)}", typeof(vEcran));


    }
}