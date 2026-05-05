using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class UserLogin : ContentPage
{
	public UserLogin()
	{
		InitializeComponent();
	}

    async private void Button_Clicked_Registrar(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("userRegister");
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
            await Shell.Current.GoToAsync("//main/homePage");
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }

    async private void TapGestureRecognizer_EsqueciSenha(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("userRecoverPassword");
    }
}