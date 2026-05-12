using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{ 
		InitializeComponent();
	}

    // Caso o usuário não esteja logado, redireciona para o login
    protected override async void OnAppearing()
    {
        string? user_email = await SecureStorage.Default.GetAsync("user_email");

        if (user_email == null)
        {
            await Navigation.PushAsync(new Views.UserLogin());
        }
    }

    async private void Button_Clicked_VerUsuarios(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.SeeAllUser());
    }

    async private void Button_Clicked_EnviarLocalizacao(object sender, EventArgs e)
    {
        try
        {
            GeolocationRequest request = new GeolocationRequest(
                GeolocationAccuracy.Medium,
                TimeSpan.FromSeconds(10));

            Location? local = await Geolocation.Default.GetLocationAsync(request);

            if (local != null)
            {
                await DisplayAlertAsync("Localização atual", $"Latitude: {local.Latitude}, Longitude: {local.Longitude}", "Ok");
            }
            else
            {
                throw new Exception("Não foi possível obter a localização atual");
            }

            // Já existia
            int user_id = int.Parse((await SecureStorage.Default.GetAsync("user_id"))!);

            string note = string.IsNullOrWhiteSpace(entry_note.Text) ? "(Sem nota)" : entry_note.Text;
            entry_note.Text = "";

            UserLocation localizacao_atual = new()
            {
                UserId = user_id,
                Latitude = local.Latitude.ToString(),
                Longitude = local.Longitude.ToString(),
                Note = note
            };

            await App.Db.InsertUserLocation(localizacao_atual);

            await DisplayAlertAsync("Aviso", "Localização salva com sucesso", "Ok");
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }
}