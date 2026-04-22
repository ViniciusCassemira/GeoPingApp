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
            Application.Current!.MainPage = new NavigationPage(new Views.HomePage());
        else
            Application.Current!.MainPage = new NavigationPage(new Views.UserRegister());
    }
}