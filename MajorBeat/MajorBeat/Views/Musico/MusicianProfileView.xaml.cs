using MajorBeat.ViewModels;
using MajorBeat.ViewModels.Musician;

namespace MajorBeat.Views.Musico;

public partial class MusicianProfileView : ContentPage
{
    public MusicianProfileView()
    {
        InitializeComponent();
        BindingContext = new viewmodelmodel();
    }

    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserRegisterView());
    }
    private viewmodelmodel ViewModel => BindingContext as viewmodelmodel;



    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        ViewModel?.FiltrarInstrumentos(e.NewTextValue);
    }

    private void OnInstrumentoSelecionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is string instrumento)
        {
            ViewModel.InstrumentoSelecionado = instrumento;
        }
    }
}
