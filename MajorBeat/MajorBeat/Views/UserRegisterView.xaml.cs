using MajorBeat.ViewModels;
using MajorBeat.Views.Contratante;
using MajorBeat.Views.Musico;

namespace MajorBeat.Views;

public partial class UserRegisterView : ContentPage
{

    public UserRegisterView()
    {
        InitializeComponent();
        BindingContext = new PrincipalViewModel(Navigation);


    }
    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InitialPage());
    }

}