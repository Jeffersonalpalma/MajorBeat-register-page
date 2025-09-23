namespace MajorBeat.Views.Musico;

public partial class MusicianProfileView : ContentPage
{
	public MusicianProfileView()
	{
		InitializeComponent();
	}
    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserRegisterView());
    }
}