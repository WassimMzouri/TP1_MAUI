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
            // Mettre isCheckingLocation à true pour indiquer que la localisation est en cours de vérification
            _isCheckingLocation = true;

            // Créer une variable GeolocationRequest avec une précision moyenne et un délai d'attente de 10 secondes
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            // Instancier CancellationTokenSource
            _cancelTokenSource = new CancellationTokenSource();

            // Essayer de récupérer la localisation
            var location =  Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            // Si la localisation n'est pas nulle, mettre à jour les labels
            if (location != null)
            {

                lblLongitude.Text = $"Longitude: {location.Longitude}";
                lblLatitude.Text = $"Latitude: {location.Latitude}";
                //lblAltitude.Text = $"Altitude: {location.Altitude}";
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // La fonctionnalité de localisation n'est pas supportée sur le dispositif
            await DisplayAlert("Erreur", "La géolocalisation n'est pas supportée sur cet appareil.", "OK");
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // La localisation est désactivée sur le dispositif
            await DisplayAlert("Erreur", "Veuillez activer la géolocalisation.", "OK");
        }
        catch (PermissionException pEx)
        {
            // Les permissions de localisation n'ont pas été accordées
            await DisplayAlert("Erreur", "Permission de localisation non accordée.", "OK");
        }
        catch (Exception ex)
        {
            // Autres exceptions possibles
            await DisplayAlert("Erreur", $"Une erreur est survenue : {ex.Message}", "OK");
        }
        finally
        {
            // Fin de la vérification de la localisation
            _isCheckingLocation = false;
        }
    }


    private void Cancel(object sender, EventArgs e)
    {
        if (_isCheckingLocation && _cancelTokenSource != null && !_cancelTokenSource.IsCancellationRequested)
        {
            // Annuler la demande de géolocalisation
            _cancelTokenSource.Cancel();
        }
    }
}