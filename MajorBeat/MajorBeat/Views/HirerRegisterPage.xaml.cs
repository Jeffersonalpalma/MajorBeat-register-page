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
    private void AtualizarCampos()
    {
        // Mostrar o campo empresa apenas se for Contratante E tiver selecionado "Sim"
        if (ContratanteRadio.IsChecked)
        {
            ContratanteFields.IsVisible = true;
            if (sim.IsChecked)
            {
                EmpresaFields.IsVisible = true;
            }
            else
            {
                EmpresaFields.IsVisible = false;
            }
            
        }
        else
        {
            EmpresaFields.IsVisible = false;
            ContratanteFields.IsVisible = false;
        }

        // Mostrar o campo banda apenas se for Músico e tiver escolhido "Banda"
        if (MusicoRadio.IsChecked)
        {
            MusicoFields.IsVisible = true;

            
            if (Choice.SelectedItem?.ToString() == "Banda")
            {
                CampoBanda.IsVisible = true;
                Nome.IsVisible = false;
            }
        }
        else
        {
            MusicoFields.IsVisible = false;
            CampoBanda.IsVisible = false;
        }
    }

    private void TipoPicker(object sender, EventArgs e)
    {
        AtualizarCampos();
    }
    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
       AtualizarCampos();
        
    }
    private void RadioButton_empresaChanged(object sender, CheckedChangedEventArgs e)
    {
        AtualizarCampos();

    }


    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InitialPage());
    }

    private async void CreateProfile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianProfilePage());
    }




}