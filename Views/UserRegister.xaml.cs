using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class UserRegister : ContentPage
{
	public UserRegister()
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

    async private void Button_Clicked_Logar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.UserLogin());
    }

    async private void Button_Clicked_CriarConta(object sender, EventArgs e)
    {
        try
        {
            // Verifica se o email já está sendo utilizado 
            List<User> all_users = await App.Db.GetAllUsers();
            if (all_users.Any(i => (i.Email == user_email.Text)))
            {
                throw new Exception("Erro ao criar cadastro, tente novamente");
            }

            // Verifica se as senhas são iguais
            if (user_password.Text != user_repeat_password.Text)
            {
                throw new Exception("As senhas precisam ser iguais");
            }

            User user = new()
            {
                Name = user_name.Text,
                Email = user_email.Text,
                Password = user_password.Text
            };

            // Adiciona usuário ao banco sqlite
            await App.Db.InsertUser(user);
            await DisplayAlertAsync("Sucesso", "Usuário criado com sucesso", "Ok");
            await Navigation.PushAsync(new Views.UserLogin());

        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }
}