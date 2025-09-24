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
}