namespace GeoPingApp.Views;

public partial class Welcome : ContentPage
{
    public Welcome()
    {
        InitializeComponent();
    }

    private async void Button_Clicked_Comecar(object sender, EventArgs e)
    {
        string? is_user_logged = await SecureStorage.Default.GetAsync("user_email");

        if (is_user_logged != null)
            await Shell.Current.GoToAsync("//main/homePage");
        else
            await Shell.Current.GoToAsync("userLogin"); // sem // pois é rota avulsa
    }
}