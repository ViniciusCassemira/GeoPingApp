namespace GeoPingApp.Views;

public partial class Welcome : ContentPage
{
	public Welcome()
	{
        InitializeComponent();
	}

    async private void Button_Clicked_Comecar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.UserRegister());
    }
}