using MajorBeat.ViewModels;

namespace MajorBeat.Views;

public partial class HirerRegisterPage : ContentPage
{
	UsuarioViewModel viewModel;
	public HirerRegisterPage()
	{
		InitializeComponent();

		viewModel = new UsuarioViewModel();
		BindingContext = viewModel;


	}
    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) // Só quando o botão ficou marcado
        {
            if (sender == MusicoRadio)
            {
                MusicoFields.IsVisible = true;
                ContratanteFields.IsVisible = false;
            }
            else if (sender == ContratanteRadio)
            {
                MusicoFields.IsVisible = false;
                ContratanteFields.IsVisible = true;
            }
        }
    }


    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InitialPage());
    }

   
}