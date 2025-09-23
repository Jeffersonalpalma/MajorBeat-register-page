namespace MajorBeat.Views;

public partial class MusicianProfilePage : ContentPage
{
	public MusicianProfilePage()
	{
		InitializeComponent();
	}

    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HirerRegisterPage());
    }
}