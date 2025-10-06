using MajorBeat.Services.Usuarios;
using MajorBeat.ViewModels;
using MajorBeat.ViewModels.Hirers;

namespace MajorBeat.Views.Contratante;

public partial class HirerProfileView : ContentPage
{
	public HirerProfileView(cuzasviewmodel viewModel)
	{

        InitializeComponent();

        BindingContext = viewModel;


    }
    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserRegisterView());
    }


}