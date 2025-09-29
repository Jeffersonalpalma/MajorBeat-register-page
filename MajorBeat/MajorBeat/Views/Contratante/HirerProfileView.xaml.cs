namespace MajorBeat.Views.Contratante;

public partial class HirerProfileView : ContentPage
{
	public HirerProfileView()
	{
		InitializeComponent();
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
    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserRegisterView());
    }
}