using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class LocationDetail : ContentPage
{
	public UserLocation Location { get; set; }
	public LocationDetail()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
	{
		Location = BindingContext as UserLocation;

		if (Location != null)
		{
			string lat = Location.Latitude.Replace(",", ".");
			string lng = Location.Longitude.Replace(",", ".");

			mapWebView.Source = $"https://www.openstreetmap.org/?mlat={lat}&mlon={lng}#map=15/{lat}/{lng}";
		}
	}

    private async void Button_Clicked_EditLocation(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.EditLocation
        {
            BindingContext = Location
        });
    }

    private async void Button_Clicked_DeleteLocation(object sender, EventArgs e)
	{
		bool confirm = await DisplayAlertAsync("Confirmar exclusão", "Tem certeza que deseja excluir esta localização?", "Sim", "Não");

		if (confirm)
		{
			try
			{
				await App.Db.DeleteUserLocation(Location);
				await DisplayAlertAsync("Sucesso", "Localização excluída com sucesso!", "OK");
				await Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				await DisplayAlertAsync("Ops", ex.Message, "OK");
			}
		}
	}

    private void TapGestureRecognizer_Tapped_ReturnPage(object sender, TappedEventArgs e)
    {
		Navigation.PopAsync();
    }
}