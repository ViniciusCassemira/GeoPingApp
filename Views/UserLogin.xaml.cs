namespace GeoPingApp.Views;

public partial class UserLogin : ContentPage
{
	public UserLogin()
	{
		InitializeComponent();
	}

    async private void Button_Clicked_Registrar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.UserRegister());
    }

    async private void Button_Clicked_AcessarConta(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Ok", "Você vai acessar sua conta", "Ok");
    }

    async private void TapGestureRecognizer_EsqueciSenha(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Views.UserRecoverPassword());
    }
}