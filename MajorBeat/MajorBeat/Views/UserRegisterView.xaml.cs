using MajorBeat.ViewModels;
using MajorBeat.Views.Contratante;
using MajorBeat.Views.Musico;

namespace MajorBeat.Views;

public partial class UserRegisterView : ContentPage
{
    UsuarioViewModel viewModel;
    public UserRegisterView()
    {
        InitializeComponent();

        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
        AtualizarCampos();


    }
    private void AtualizarCampos()
    {
        // Mostrar o campo empresa apenas se for Contratante E tiver selecionado "Sim"
        if (ContratanteRadio.IsChecked)
        {
            Nome.IsVisible = true;
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
            Nome.IsVisible = true;
            EmpresaFields.IsVisible = false;
            ContratanteFields.IsVisible = false;
        }
        if (MusicoRadio.IsChecked)
        {
            MusicoFields.IsVisible = true;
            Nome.IsVisible = true;

            if (Choice.SelectedItem?.ToString() == "Banda")
            {
                CampoBanda.IsVisible = true;
                Nome.IsVisible = false;
            }
            else
            {
                CampoBanda.IsVisible = false;
            }
        }
        else
        {
            MusicoFields.IsVisible = false;
            CampoBanda.IsVisible = false;
            Nome.IsVisible = true;
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
        if (ContratanteRadio.IsChecked) { 
        await Navigation.PushAsync(new HirerProfileView());
        }else if(MusicoRadio.IsChecked && Choice.SelectedItem?.ToString() == "Banda") {
            await Navigation.PushAsync(new MusicianProfileView());
        }
        else
        {
            await Navigation.PushAsync(new MusicianProfileView());
        }
    }




}