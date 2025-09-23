namespace MajorBeat.Views.Contratante;

public partial class HirerProfileView : ContentPage
{
	public HirerProfileView()
	{
		InitializeComponent();
	}
    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserRegisterView());
    }
}