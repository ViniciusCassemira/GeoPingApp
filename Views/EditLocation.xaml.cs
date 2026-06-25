namespace GeoPingApp.Views;
using GeoPingApp.Models;

public partial class EditLocation : ContentPage
{
	public EditLocation()
	{
		InitializeComponent();
	}

    private async void Button_Clicked_Save(object sender, EventArgs e)
	{
		try
		{
			UserLocation location = BindingContext as UserLocation;
			location.Note = txt_location_note.Text;

			await App.Db.UpdateUserLocation(location);

			await DisplayAlertAsync("Successo!", "Localização atualizada com sucesso!", "OK");
			await Navigation.PopAsync();
		}
		catch(Exception ex)
		{
			await DisplayAlertAsync("Ops", ex.Message, "OK");
			await Navigation.PopAsync();
		}
	}

    private void TapGestureRecognizer_Tapped_ReturnPage(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}