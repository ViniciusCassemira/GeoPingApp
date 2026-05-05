using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class UserRegister : ContentPage
{
    public UserRegister()
    {
        InitializeComponent();
    }

    // Redireciona para HomePage se já estiver logado
    protected override async void OnAppearing()
    {
        string? user_email = await SecureStorage.Default.GetAsync("user_email");

        if (user_email != null)
            await Shell.Current.GoToAsync("//main/homePage");
    }

    async private void Button_Clicked_Logar(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("userLogin");
    }

    async private void Button_Clicked_CriarConta(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;
            if (button != null) button.IsEnabled = false;

            // Verifica se as senhas são iguais
            if (user_password.Text != user_repeat_password.Text)
                throw new Exception("As senhas precisam ser iguais");

            // Verifica se o email já está sendo utilizado
            List<User> all_users = await App.Db.GetAllUsers();
            if (all_users.Any(i => i.Email == user_email.Text.Trim()))
                throw new Exception("Este email já está cadastrado");

            User user = new()
            {
                Name = user_name.Text.Trim(),
                Email = user_email.Text.Trim(),
                Password = user_password.Text
            };

            await App.Db.InsertUser(user);

            await DisplayAlertAsync("Sucesso", "Usuário criado com sucesso", "Ok");

            await Shell.Current.GoToAsync("userLogin");
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