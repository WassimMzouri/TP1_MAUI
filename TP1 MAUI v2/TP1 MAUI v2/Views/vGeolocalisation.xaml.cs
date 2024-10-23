using Microsoft.Maui.Devices.Sensors;

namespace TP1_MAUI_v2.Views;

public partial class vGeolocalisation : ContentPage
{

    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public vGeolocalisation()
	{
		InitializeComponent();
	}

    public async Task GetCurrentLocation()
    {
        try
        {
            // Mettre isCheckingLocation � true pour indiquer que la localisation est en cours de v�rification
            _isCheckingLocation = true;

            // Cr�er une variable GeolocationRequest avec une pr�cision moyenne et un d�lai d'attente de 10 secondes
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            // Instancier CancellationTokenSource
            _cancelTokenSource = new CancellationTokenSource();

            // Essayer de r�cup�rer la localisation
            var location =  Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            // Si la localisation n'est pas nulle, mettre � jour les labels
            if (location != null)
            {

                lblLongitude.Text = $"Longitude: {location.Longitude}";
                lblLatitude.Text = $"Latitude: {location.Latitude}";
                //lblAltitude.Text = $"Altitude: {location.Altitude}";
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // La fonctionnalit� de localisation n'est pas support�e sur le dispositif
            await DisplayAlert("Erreur", "La g�olocalisation n'est pas support�e sur cet appareil.", "OK");
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // La localisation est d�sactiv�e sur le dispositif
            await DisplayAlert("Erreur", "Veuillez activer la g�olocalisation.", "OK");
        }
        catch (PermissionException pEx)
        {
            // Les permissions de localisation n'ont pas �t� accord�es
            await DisplayAlert("Erreur", "Permission de localisation non accord�e.", "OK");
        }
        catch (Exception ex)
        {
            // Autres exceptions possibles
            await DisplayAlert("Erreur", $"Une erreur est survenue : {ex.Message}", "OK");
        }
        finally
        {
            // Fin de la v�rification de la localisation
            _isCheckingLocation = false;
        }
    }


    private void Cancel(object sender, EventArgs e)
    {
        if (_isCheckingLocation && _cancelTokenSource != null && !_cancelTokenSource.IsCancellationRequested)
        {
            // Annuler la demande de g�olocalisation
            _cancelTokenSource.Cancel();
        }
    }
}