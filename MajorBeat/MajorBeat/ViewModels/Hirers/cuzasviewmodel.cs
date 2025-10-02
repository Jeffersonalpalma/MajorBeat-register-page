using MajorBeat.Models;
using MajorBeat.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MajorBeat.ViewModels.Hirers
{
    public class cuzasviewmodel:BaseViewModel
    {
        public Command ExibirResumoCommand { get; }
        private readonly UsuarioService uService;
        public ICommand AddPhotoCommand { get; }
        public ImageSource FotoSelecionada { get; set; }

        public Contratante Usuario { get; private set; }
        public cuzasviewmodel(Contratante cc)
        {
            Usuario = cc;  
            AddPhotoCommand = new Command(async () => await OnAddPhotoClicked());
            ExibirResumoCommand = new Command(async () => await ExibirResumoCadastro());

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

        private string nomePerfil = string.Empty;
        public string NomePerfil
        {
            get { return nomePerfil; }
            set
            {
                nomePerfil = value;
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
            var usuario = Usuario;
            usuario.biografia = Biografia;
            usuario.nomePerfil = NomePerfil;

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
                $"NomePerfil: {usuario.nomePerfil}";

            await Application.Current.MainPage.DisplayAlert("Resumo do Cadastro", resumo, "OK");
        } /*
           public async Task RegistrarUsuario()
            {
                try
                {
                    var dto = new CadastroHirerDto
                    {
                        Nome = Nome,
                        Email = Email,
                        Telefone = Telefone,
                        Logradouro = Logradouro,
                        Numero = Numero,
                        Cep = Cep,
                        Bairro = Bairro,
                        Cidade = Cidade,
                        Uf = Uf,
                        Senha = senha
                    };




                    Contratante cRegistrado = await uService.PostRegistrarUsuarioAsync(u);

                    if (cRegistrado.id != 0)
                    {
                        string mensagem = $"{cRegistrado.nome} cadastrado com sucesso.";
                        await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                        await Application.Current.MainPage
                            .Navigation.PopAsync();
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "OK");
                }
            }*/
    }
}
