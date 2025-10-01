using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MajorBeat.ViewModels.Hirers
{
    public class cuzasviewmodel:BaseViewModel
    {
        public ICommand AddPhotoCommand { get; }
        public ImageSource FotoSelecionada { get; set; }
        public cuzasviewmodel()
        {
            AddPhotoCommand = new Command(async () => await OnAddPhotoClicked());
        }

        private async Task OnAddPhotoClicked()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet(
                "Adicionar Foto", "Cancelar", null, "Escolher da Galeria", "Tirar Foto");

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
                    using var stream = await photo.OpenReadAsync();
                    FotoSelecionada = ImageSource.FromStream(() => stream);
                    onPropertyChanged(nameof(FotoSelecionada));
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Erro", $"Não foi possível obter a imagem: {ex.Message}", "OK");
            }
        }
    }
}
