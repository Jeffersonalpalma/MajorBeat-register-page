using MajorBeat.Models.Enums;
using MajorBeat.ViewModels;
using MajorBeat.ViewModels.Hirers;
using MajorBeat.ViewModels.Musician;

namespace MajorBeat.Views.Musico;

public partial class MusicianProfileView : ContentPage
{
    public MusicianProfileView(viewmodelmodel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void voltar_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserRegisterView());
    }

    private void OnInstrumentosSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BindingContext is viewmodelmodel viewModel)
        {
            // Remove instrumentos que foram desmarcados
            foreach (InstrumentoEnum removido in e.PreviousSelection.Except(e.CurrentSelection))
                viewModel.InstrumentosSelecionados.Remove(removido);

            // Adiciona novos instrumentos selecionados
            foreach (InstrumentoEnum adicionado in e.CurrentSelection.Except(e.PreviousSelection))
                viewModel.InstrumentosSelecionados.Add(adicionado);
        }
    }

    private void OnGenerosSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BindingContext is viewmodelmodel viewModel)
        {
            // Remove gêneros que foram desmarcados
            foreach (GeneroEnum removido in e.PreviousSelection.Except(e.CurrentSelection))
                viewModel.GenerosSelecionados.Remove(removido);

            // Adiciona novos gêneros selecionados
            foreach (GeneroEnum adicionado in e.CurrentSelection.Except(e.PreviousSelection))
                viewModel.GenerosSelecionados.Add(adicionado);
        }
    }
}
