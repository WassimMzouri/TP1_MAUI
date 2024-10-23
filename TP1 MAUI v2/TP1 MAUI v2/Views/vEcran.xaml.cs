namespace TP1_MAUI_v2.Views;
using System.Text;

public partial class vEcran : ContentPage
{
	public vEcran()
	{
		InitializeComponent();
        EcranInfo();
    }


	private void EcranInfo()
	{
        // Cr�er un StringBuilder
        StringBuilder ecraninfo = new StringBuilder();

        // Ajouter les informations du DeviceInfo
        ecraninfo.AppendLine($"R�solution : {DeviceDisplay.Current.MainDisplayInfo.Height} x {DeviceDisplay.Current.MainDisplayInfo.Width}");
        ecraninfo.AppendLine($"Densit� : {DeviceDisplay.Current.MainDisplayInfo.Density}");
        ecraninfo.AppendLine($"Orientation : {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        ecraninfo.AppendLine($"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
        ecraninfo.AppendLine($"Vitesse de rafraichissement : {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");


        Console.WriteLine(ecraninfo);

        // Afficher le contenu dans le Label "ecranInfo"
        lbEcran.Text = ecraninfo.ToString();

        
    }
}