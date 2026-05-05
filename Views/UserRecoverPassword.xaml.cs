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
        await Shell.Current.GoToAsync("..");
    }

    async private void Button_Clicked_RecuperarSenha(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;
            if (button != null) button.IsEnabled = false;

            if (string.IsNullOrWhiteSpace(user_email.Text))
                throw new Exception("Informe o email cadastrado");

            User user = new()
            {
                Name = "",
                Email = user_email.Text.Trim(),
                Password = ""
            };

            User existing_user = await App.Db.GetUserByEmail(user);

            if (existing_user == null)
                throw new Exception("Email não encontrado");

            await DisplayAlertAsync("Senha recuperada", existing_user.Password, "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
        finally
        {
            var button = sender as Button;
            if (button != null) button.IsEnabled = true;
        }
    }
}