using MajorBeat.Views;
using System.Windows.Input;

namespace MajorBeat.ViewModels
{
    public class MusicianProfileViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly ContentPage _page;

        public ICommand VoltarCommand { get; }
        public ICommand AddPhotoCommand { get; }

        public MusicianProfileViewModel(string escolha, INavigation navigation, ContentPage page)
        {
            _navigation = navigation;
            _page = page;

            if (escolha == "Banda")
            {
                _page.FindByName<Label>("musicoField1").IsVisible = false;
                _page.FindByName<VerticalStackLayout>("musicoField").IsVisible = false;
                _page.FindByName<Label>("bandaField").IsVisible = true;
            }
            else
            {
                _page.FindByName<Label>("bandaField").IsVisible = false;
                _page.FindByName<VerticalStackLayout>("musicoField").IsVisible = true;
                _page.FindByName<Label>("musicoField1").IsVisible = true;
            }

            VoltarCommand = new Command(async () => await _navigation.PushAsync(new UserRegisterView()));
            AddPhotoCommand = new Command(async () => await OnAddPhotoClicked());
        }

        private async Task OnAddPhotoClicked()
        {
            string action = await _page.DisplayActionSheet("Adicionar Foto", "Cancelar", null, "Escolher da Galeria", "Tirar Foto");

            FileResult photo = null;

            try
            {
                if (action == "Escolher da Galeria")
                {
                    photo = await MediaPicker.PickPhotoAsync();
                }
                else if (action == "Tirar Foto")
                {
                    photo = await MediaPicker.CapturePhotoAsync();
                }

                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    var selectedImage = _page.FindByName<Image>("SelectedImage");
                    selectedImage.Source = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                await _page.DisplayAlert("Erro", "Não foi possível obter a imagem: " + ex.Message, "OK");
            }
        }
    }
}
