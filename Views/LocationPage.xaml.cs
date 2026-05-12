using System.Collections.ObjectModel;
using GeoPingApp.Models;

namespace GeoPingApp.Views;

public partial class LocationPage : ContentPage
{
    ObservableCollection<UserLocation> lista_localizacao = new();

    protected async override void OnAppearing()
    {
        string? userId = await SecureStorage.Default.GetAsync("user_id");

        try
        {
            lista_localizacao.Clear();
            List<UserLocation> tmp = await App.Db.GetUserLocationByUserId(int.Parse(userId!));

            tmp.ForEach(i => lista_localizacao.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    public LocationPage()
    {
        InitializeComponent();
        collection_user_location.ItemsSource = lista_localizacao;
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UserLocation selected_location = e.CurrentSelection.FirstOrDefault() as UserLocation;

        await Navigation.PushAsync(new Views.LocationDetail
        {
            BindingContext = selected_location
        });
    }
}