using MajorBeat.ViewModels;

namespace MajorBeat.Views.Musico;

public partial class MusicianProfileView : ContentPage
{
    public MusicianProfileView(string escolha)
    {
        InitializeComponent();
        BindingContext = new MusicianProfileViewModel(escolha, Navigation, this);
    }
}
