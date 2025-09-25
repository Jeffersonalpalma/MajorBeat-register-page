namespace MajorBeat.Views.Musico;

public partial class MusicianProfileView : ContentPage
{
	public MusicianProfileView(string escolha)
	{
		InitializeComponent();

        if (escolha == "Banda")
        {
            musicoField1.IsVisible = false;
            musicoField.IsVisible = false;
            bandaField.IsVisible = true;  
        }
        else
        {
            bandaField.IsVisible = false;
            musicoField.IsVisible = true;
            musicoField1.IsVisible = true;
        }
	}
    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserRegisterView());
    }

    private async void OnAddPhotoClicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Adicionar Foto", "Cancelar", null, "Escolher da Galeria", "Tirar Foto");

        FileResult photo = null;

        try
        {
            if (action == "Escolher da Galeria")
            {
                photo = await MediaPicker.PickPhotoAsync();
            }
            else if (action == "Tirar Foto")
            {
                photo = await MediaPicker.CapturePhotoAsync();
            }

            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                SelectedImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Não foi possível obter a imagem: " + ex.Message, "OK");
        }
    }
}