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
        public ICommand SelectionChangedCommand { get; }
        public List<InstrumentoEnum> TodosInstrumentos { get; } =
        Enum.GetValues(typeof(InstrumentoEnum)).Cast<InstrumentoEnum>().ToList();
        public ObservableCollection<string> Instrumentos { get; set; }
        public ObservableCollection<InstrumentoEnum> InstrumentosSelecionados { get; set; } = new();

        public ICommand AddPhotoCommand { get; }
        public ImageSource FotoSelecionada { get; set; }

        public Command ExibirResumoCommand { get; }

        public string InstrumentosSelecionadosTexto =>
        !InstrumentosSelecionados.Any()
            ? "Instrumentos: nenhum"
            : $"Instrumentos: {string.Join(", ", InstrumentosSelecionados)}";
        public viewmodelmodel(Musico m)
        {
            InstrumentosSelecionados.CollectionChanged += (s, e) =>
               onPropertyChanged(nameof(InstrumentosSelecionadosTexto));

            // comando que vai ser chamado pelo CollectionView
            SelectionChangedCommand = new Command<SelectionChangedEventArgs>(OnSelectionChanged);
            musico = m;
            if (musico.tipoMusico == TipoMusico.Solo)
            {

                IsVisible = true;
                cIsVisible = false;

            }
            else if (musico.tipoMusico == TipoMusico.Banda)
            {
                IsVisible = false;
                cIsVisible = true;



            }
            ExibirResumoCommand = new Command(async () => await ExibirResumoCadastro());
            AddPhotoCommand = new Command(async () => await OnAddPhotoClicked());
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                onPropertyChanged(nameof(IsVisible));
            }
        }

        private bool c_isVisible;
        public bool cIsVisible
        {
            get => c_isVisible;
            set
            {
                c_isVisible = value;
                onPropertyChanged(nameof(cIsVisible));
            }
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

        private byte[] _fotoBytes;
        public byte[] FotoBytes
        {
            get => _fotoBytes;
            set
            {
                _fotoBytes = value;
                onPropertyChanged(nameof(FotoBytes));
            }
        }



        private async Task OnAddPhotoClicked()
        {
            await Task.Yield(); // Libera o UI thread
            await Task.Delay(100);
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
                    using var originalStream = await photo.OpenReadAsync();

                    // Copia para memória para reutilizar
                    using var memoryStream = new MemoryStream();
                    await originalStream.CopyToAsync(memoryStream);
                    FotoBytes = memoryStream.ToArray();

                    // Cria nova cópia do stream para a imagem
                    FotoSelecionada = ImageSource.FromStream(() => new MemoryStream(FotoBytes));
                    onPropertyChanged(nameof(FotoSelecionada));
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Erro", $"Não foi possível obter a imagem: {ex.Message}", "OK");
            }
        }

        private void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            // Atualiza lista de seleção manualmente
            InstrumentosSelecionados.Clear();
            foreach (var item in e.CurrentSelection)
            {
                if (item is InstrumentoEnum instrumento)
                    InstrumentosSelecionados.Add(instrumento);
            }
        }

        private async Task ExibirResumoCadastro()
        {
            var usuario = musico;
            usuario.biografia = Biografia;
            usuario.username = Username;
            usuario.FotoBytes = FotoBytes;
            usuario.instrumentos = InstrumentosSelecionados.ToList();

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
                $"NomePerfil: {usuario.username}\n"+
                $"TipoMusico: {usuario.tipoMusico}\n"+
                $"Bytes:{usuario.FotoBytes}\n"+
                $"Instrumentos: {string.Join(", ", InstrumentosSelecionados)}";


            await Application.Current.MainPage.DisplayAlert("Resumo do Cadastro", resumo, "OK");
        } 
    }
}
