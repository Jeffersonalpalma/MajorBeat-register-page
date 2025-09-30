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
     


    }


    private async void CreateProfile(object sender, EventArgs e)
    {
        string escolha = Choice.SelectedItem?.ToString();
            await Navigation.PushAsync(new MusicianProfileView(escolha));
    }
    




}