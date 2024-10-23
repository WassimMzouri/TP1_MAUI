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
                batterieInfo.AppendLine(" Batterie : Impossible de trouver la source d'�nergie");
                break;
        }

        // Afficher le contenu dans le Label "lbPhoneInfo"
        lbBatterie.Text = batterieInfo.ToString();
    }

    private void Battery_InfoChanged(object sender, BatteryInfoChangedEventArgs e)
    {
        StringBuilder batterieInfoChanged = new StringBuilder();

        // V�rifier l'�tat de la batterie avec des if-else
        if (e.State == BatteryState.Full)
        {
            batterieInfoChanged.Append("Batterie pleine");
        }
        else if (e.State == BatteryState.Discharging)
        {
            batterieInfoChanged.Append($"Batterie d�charg�e : {e.ChargeLevel * 100:F0}%");
        }
        else if (e.State == BatteryState.Unknown)
        {
            batterieInfoChanged.Append($"�tat de la batterie inconnu : {e.ChargeLevel * 100:F0}%");
        }
        else if (e.State == BatteryState.NotPresent)
        {
            batterieInfoChanged.Append("Aucune batterie pr�sente");
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
            batterieInfoChanged.Append("�tat de la batterie non reconnu");
        }

        // Afficher les informations dans le label "lbBatterie"
        lbBatterie2.Text = batterieInfoChanged.ToString();
    }
    private async void Battery_ModeEcoChanged(object sender, EnergySaverStatusChangedEventArgs e)
    {
        // V�rifier si le mode �conomie d'�nergie est activ�
        if (Battery.Default.EnergySaverStatus == EnergySaverStatus.On)
        {
            // Afficher une alerte indiquant que le mode �conomie d'�nergie est activ�
            await DisplayAlert("Alerte", "Mode �conomie d'�nergie activ�", "OK");
        }
        else
        {
            // Afficher une alerte indiquant que le mode �conomie d'�nergie est d�sactiv�
            await DisplayAlert("Alerte", "Mode �conomie d'�nergie arr�t�", "OK");
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // D�sinscription de l'�v�nement
        Battery.Default.EnergySaverStatusChanged -= Battery_ModeEcoChanged;
    }


}