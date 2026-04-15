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

    async private void Button_Clicked_EncerrarSessao(object sender, EventArgs e)
    {
        bool logout_confirmation = await DisplayAlertAsync("Tem certeza?", "Encerrar sessão", "Ok", "Cancelar");

        if (logout_confirmation)
        {
            SecureStorage.Default.Remove("user_email");

            await Navigation.PushAsync(new Views.UserLogin());
        }
    }
}