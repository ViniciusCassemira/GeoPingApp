namespace GeoPingApp.Views;

public partial class UserRecoverPassword : ContentPage
{
	public UserRecoverPassword()
	{
		InitializeComponent();
	}

    async private void Button_Clicked_Voltar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.UserLogin());
    }

    async private void Button_Clicked_RecuperarSenha(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Ok", "Recuperar senha", "Ok");
    }
}