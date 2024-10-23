using System.Text;

namespace TP1_MAUI_v2.Views;

public partial class vBatterie : ContentPage
{
	public vBatterie()
	{
		InitializeComponent();

        //Changement de batterie 
        Battery.Default.BatteryInfoChanged += Battery_InfoChanged;

        //Changement mode d'utilisatioon de l'energie 
        Battery.Default.EnergySaverStatusChanged += Battery_ModeEcoChanged;

    }

    private void BatterieInfo(object sender, EventArgs e)
    {

        StringBuilder batterieInfo = new StringBuilder();


        var batterie = Battery.Default.PowerSource;
        

        switch (batterie)
        {
            case BatteryPowerSource.AC:
                batterieInfo.AppendLine(" Batterie : AC 220V");
                break;
            case BatteryPowerSource.Battery:
                batterieInfo.AppendLine(" Batterie : Sur batterie");
                break;
            case BatteryPowerSource.Wireless:
                batterieInfo.AppendLine(" Batterie : Chargeur sans fils");
                break;
            case BatteryPowerSource.Usb:
                batterieInfo.AppendLine(" Batterie : Cable USB");
                break;
            case BatteryPowerSource.Unknown:
                batterieInfo.AppendLine(" Batterie : Inconnu");
                break;

            default:
                batterieInfo.AppendLine(" Batterie : Impossible de trouver la source d'énergie");
                break;
        }

        // Afficher le contenu dans le Label "lbPhoneInfo"
        lbBatterie.Text = batterieInfo.ToString();
    }

    private void Battery_InfoChanged(object sender, BatteryInfoChangedEventArgs e)
    {
        StringBuilder batterieInfoChanged = new StringBuilder();

        // Vérifier l'état de la batterie avec des if-else
        if (e.State == BatteryState.Full)
        {
            batterieInfoChanged.Append("Batterie pleine");
        }
        else if (e.State == BatteryState.Discharging)
        {
            batterieInfoChanged.Append($"Batterie déchargée : {e.ChargeLevel * 100:F0}%");
        }
        else if (e.State == BatteryState.Unknown)
        {
            batterieInfoChanged.Append($"État de la batterie inconnu : {e.ChargeLevel * 100:F0}%");
        }
        else if (e.State == BatteryState.NotPresent)
        {
            batterieInfoChanged.Append("Aucune batterie présente");
        }
        else if (e.State == BatteryState.NotCharging)
        {
            batterieInfoChanged.Append($"Batterie non en charge : {e.ChargeLevel * 100:F0}%");
        }
        else if (e.State == BatteryState.Charging)
        {
            batterieInfoChanged.Append($"Batterie en charge : {e.ChargeLevel * 100:F0}%");
        }
        else
        {
            batterieInfoChanged.Append("État de la batterie non reconnu");
        }

        // Afficher les informations dans le label "lbBatterie"
        lbBatterie2.Text = batterieInfoChanged.ToString();
    }
    private async void Battery_ModeEcoChanged(object sender, EnergySaverStatusChangedEventArgs e)
    {
        // Vérifier si le mode économie d'énergie est activé
        if (Battery.Default.EnergySaverStatus == EnergySaverStatus.On)
        {
            // Afficher une alerte indiquant que le mode économie d'énergie est activé
            await DisplayAlert("Alerte", "Mode économie d'énergie activé", "OK");
        }
        else
        {
            // Afficher une alerte indiquant que le mode économie d'énergie est désactivé
            await DisplayAlert("Alerte", "Mode économie d'énergie arrêté", "OK");
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Désinscription de l'événement
        Battery.Default.EnergySaverStatusChanged -= Battery_ModeEcoChanged;
    }


}