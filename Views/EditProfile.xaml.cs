namespace GeoPingApp.Views;
using GeoPingApp.Models;

public partial class EditProfile : ContentPage
{
	public EditProfile()
	{
		InitializeComponent();
	}

	async private void Button_Clicked_SaveProfile(object sender, EventArgs e)
	{
		try
		{
            // Pegar o ID do usuário logado a partir do SecureStorage
			User current_user = await App.Db.GetUserByEmail(await SecureStorage.Default.GetAsync("user_email"));


            Boolean DoesEmailHasChanged = false;
			Boolean NewEmailIsCurrentUse = false;

            // Verificar se o email foi alterado em relação ao email armazenado no SecureStorage
            if (txt_user_email.Text != await SecureStorage.Default.GetAsync("user_email"))
			{
				DoesEmailHasChanged = true;
			}

            User existingUser = await App.Db.GetUserByEmail(txt_user_email.Text);

            if (existingUser != null && existingUser.Id != current_user.Id && DoesEmailHasChanged)
            {
                NewEmailIsCurrentUse = true;
                throw new Exception("Email já está em uso");
            }

			// Alterando senha


            User new_user = new()
			{
				Id = current_user.Id,
                Name = txt_user_name.Text,
				Email = txt_user_email.Text,
				Password = txt_user_password.Text
			};

			await App.Db.UpdateUser(new_user);

            // Atualizar o email no SecureStorage apenas se o email foi alterado corretamente
            if (DoesEmailHasChanged && !NewEmailIsCurrentUse)
			{
				await SecureStorage.Default.SetAsync("user_email", new_user.Email);
			}

            await DisplayAlertAsync("Sucesso", "Usuário alterado com sucesso!", "OK");
            await Navigation.PopAsync();

        }
		catch (Exception ex)
		{
			await DisplayAlertAsync("Ops", ex.Message, "Ok");
		}
	}
}