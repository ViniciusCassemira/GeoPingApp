using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class UserLogin : ContentPage
{
	public UserLogin()
	{
		InitializeComponent();
	}

    // Caso o usuário esteja logado, redireciona para a HomePage
    protected override async void OnAppearing()
    {
        string? user_email = await SecureStorage.Default.GetAsync("user_email");

        if (user_email != null)
        {
            await Navigation.PushAsync(new Views.HomePage());
        }
    }

    async private void Button_Clicked_Registrar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.UserRegister());
    }

    async private void Button_Clicked_AcessarConta(object sender, EventArgs e)
    {
        try
        {
            User user = new()
            {
                Name = "",
                Email = user_email.Text,
                Password = user_password.Text
            };

            // Verifica se o usuário digitado existe no banco
            User existing_user = await App.Db.GetUser(user);
            if(existing_user == null)
            {
                throw new Exception("Erro ao realizar login, tente novamente");
            }

            //Exibe msg caso o usuário exista
            await DisplayAlertAsync("Bem vindo!", existing_user.Name, "Ok");
            await SecureStorage.Default.SetAsync("user_email", existing_user.Email);
            await Navigation.PushAsync(new Views.HomePage());
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }

    async private void TapGestureRecognizer_EsqueciSenha(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Views.UserRecoverPassword());
    }
}