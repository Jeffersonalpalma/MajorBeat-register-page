using MajorBeat.Models;
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

        public Musico musico { get; set; }


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

        public Command ExibirResumoCommand { get; }
        public viewmodelmodel(Musico m) {
            musico = m;
            ExibirResumoCommand = new Command(async () => await ExibirResumoCadastro());

            Instrumentos = new ObservableCollection<string>(
                Enum.GetNames(typeof(InstrumentoEnum))
            );

            InstrumentosFiltrados = new ObservableCollection<string>(Instrumentos);
            AddPhotoCommand = new Command(async () => await OnAddPhotoClicked());
        }

        private string biografia = string.Empty;
        public string Biografia
        {
            get { return biografia; }
            set
            {
                biografia = value;
                onPropertyChanged();
            }
        }

        private string username = string.Empty;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                onPropertyChanged();
            }
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

        private async Task ExibirResumoCadastro()
        {
            var usuario = musico;
            usuario.biografia = Biografia;
            usuario.username = Username;

            string resumo =
                $"Nome: {usuario.nome}\n" +
                $"Email: {usuario.email}\n" +
                $"Biografia: {usuario.biografia}\n" +
                $"Telefone: {usuario.telefone}\n" +
                $"Logradouro: {usuario.logradouro}, Nº {usuario.numero}\n" +
                $"Bairro: {usuario.bairro}\n" +
                $"Cidade: {usuario.cidade} - {usuario.uf}\n" +
                $"CEP: {usuario.cep}\n" +
                $"Senha: {usuario.senha}\n" +
                $"NomePerfil: {usuario.username}";

            await Application.Current.MainPage.DisplayAlert("Resumo do Cadastro", resumo, "OK");
        } 
    }
}
