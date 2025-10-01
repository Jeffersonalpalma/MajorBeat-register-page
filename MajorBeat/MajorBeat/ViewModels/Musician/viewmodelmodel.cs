using MajorBeat.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MajorBeat.ViewModels.Musician
{
    public class viewmodelmodel: BaseViewModel
    {

        public ObservableCollection<string> Instrumentos { get; set; }
        public ObservableCollection<string> InstrumentosFiltrados { get; set; }

        private string _instrumentoSelecionado;
        public string InstrumentoSelecionado
        {
            get => _instrumentoSelecionado;
            set
            {
                _instrumentoSelecionado = value;
                onPropertyChanged();
            }
        }



        public void FiltrarInstrumentos(string busca)
        {
            var filtrado = Instrumentos
                .Where(i => i.ToLower().Contains(busca.ToLower()))
                .ToList();

            InstrumentosFiltrados.Clear();
            foreach (var item in filtrado)
                InstrumentosFiltrados.Add(item);
        }
        public ICommand AddPhotoCommand { get; }
        public ImageSource FotoSelecionada { get; set; }
        public viewmodelmodel() {
            Instrumentos = new ObservableCollection<string>(
                Enum.GetNames(typeof(InstrumentoEnum))
            );

            InstrumentosFiltrados = new ObservableCollection<string>(Instrumentos);
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
