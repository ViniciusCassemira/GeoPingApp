namespace GeoPingApp.Views;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
	}

    async private void Button_Clicked_EncerrarSessao(object sender, EventArgs e)
    {
        bool logout_confirmation = await DisplayAlertAsync("Tem certeza?", "Encerrar sessão", "Ok", "Cancelar");

        if (logout_confirmation)
        {
            SecureStorage.Default.Remove("user_email");

            await Navigation.PushAsync(new Views.UserLogin());
        }
    }

    async private void Button_Clicked_WebHook(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.WebHookDashboard());
    }
}