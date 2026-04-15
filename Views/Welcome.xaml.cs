namespace GeoPingApp.Views;

public partial class Welcome : ContentPage
{
	public Welcome()
	{
        InitializeComponent();
	}

    async private void Button_Clicked_Comecar(object sender, EventArgs e)
    {
        string? is_user_logged = await SecureStorage.Default.GetAsync("user_name");
        if (is_user_logged != null)
        {
            await Navigation.PushAsync(new Views.HomePage());
        }
        else
        {
            await Navigation.PushAsync(new Views.UserRegister());
        }
    }
}