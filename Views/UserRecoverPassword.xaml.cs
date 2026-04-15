using GeoPingApp.Models;

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
        try
        {
            User user = new()
            {
                Name = "",
                Email = user_email.Text,
                Password = ""
            };

            // Verifica se o email digitado existe no banco
            User existing_user = await App.Db.GetUserByEmail(user);
            if(existing_user == null)
            {
                throw new Exception("Erro ao recuperar senha da conta, tente novamente");
            }

            await DisplayAlertAsync("Senha recuperada", existing_user.Password, "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }
}