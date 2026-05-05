using System.Collections.ObjectModel;
using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class SeeAllUser : ContentPage
{
    ObservableCollection<User> lista = new();

    public SeeAllUser()
	{
		InitializeComponent();
        list_user.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();
            List<User> tmp = await App.Db.GetAllUsers();
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    async private void ToolbarItem_Clicked_Voltar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.HomePage());
    }

    async private void txt_search_user_TextChanged(object sender, TextChangedEventArgs e)
    {
        string texto_digitado = e.NewTextValue;
        lista.Clear();
        List<User> tmp = await App.Db.SearchUserByName(texto_digitado);
        tmp.ForEach(i => lista.Add(i));
    }

    async private void list_user_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            User? user = e.SelectedItem as User;

            await DisplayAlertAsync("Usuário selecionado:",$"{user?.Name} - {user?.CreatedAt}", "Fechar");

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}