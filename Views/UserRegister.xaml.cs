namespace GeoPingApp.Views;

public partial class UserRegister : ContentPage
{
	public UserRegister()
	{
		InitializeComponent();
	}

    async private void Button_Clicked_Logar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.UserLogin());
    }

    async private void Button_Clicked_CriarConta(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Ok", "Você vai criar sua conta", "Ok");
    }
}