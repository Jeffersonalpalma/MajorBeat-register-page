using MajorBeat.Models;
using MajorBeat.Models.Enums;
using MajorBeat.ViewModels.Musician;
using MajorBeat.Views;
using MajorBeat.Views.Musico;
using System.Windows.Input;

namespace MajorBeat.ViewModels
{
    public class MusicianProfileViewModel : BaseViewModel
    {

        private readonly INavigation _navigation;
        private TipoMusico _tipo;
        public TipoMusico Tipo
        {
            get => _tipo;
            set
            {
                if (_tipo!=value)
                {
                    _tipo = value;
                    onPropertyChanged(nameof(Tipo));       // atualiza o Picker
                    onPropertyChanged(nameof(NomeLabel)); // atualiza label
                }
            }
        }
        public MusicianProfileViewModel(INavigation navigation)
        {
            _navigation = navigation;

        }


        /*public async Task fds()
        {
            var cu = new viewmodelmodel(u);
            await _navigation.PushAsync(new MusicianProfileView(cu));
        }*/



        // Label dinâmico
        public string NomeLabel => Tipo == TipoMusico.Solo ? "Nome Completo" : "Nome da Banda";

        // Lista pro Picker
        public IEnumerable<TipoMusico> Tipos => Enum.GetValues(typeof(TipoMusico)).Cast<TipoMusico>();

            private bool ValidarCampos(Musico u,out string mensagemErro)
        {
            var erros = new List<string>();
            if (string.IsNullOrWhiteSpace(u.nome))
                erros.Add("O nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.email))
                erros.Add("O e-mail é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.telefone))
                erros.Add("O telefone é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.logradouro))
                erros.Add("O logradouro é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.numero))
                erros.Add("O número é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.bairro))
                erros.Add("O bairro é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.cidade))
                erros.Add("A cidade é obrigatória.");
            if (string.IsNullOrWhiteSpace(u.uf))
                erros.Add("O estado (UF) é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.cep))
                erros.Add("O CEP é obrigatório.");
            if (string.IsNullOrWhiteSpace(u.senha))
                erros.Add("A senha é obrigatória.");
            mensagemErro = string.Join("\n", erros);
            return erros.Count == 0;
        }
        public async Task UserSave()
        {
            Musico u = new Musico();
            u.nome = Nome;
            u.email = Email;
            u.telefone = Telefone;
            u.logradouro = Logradouro;
            u.numero = Numero;
            u.cep = Cep;
            u.bairro = Bairro;
            u.cidade = Cidade;
            u.uf = Uf;
            u.senha = Senha;
            u.tipoMusico = Tipo;


        string mensagemErro;
            if (!ValidarCampos(u, out mensagemErro))
            {
                // Há erros, mostra alerta e NÃO avança
                await Application.Current.MainPage.DisplayAlert("Campos obrigatórios", mensagemErro, "OK");
                return; // impede que o PushAsync seja chamado
            }

            // Se passou na validação, avança para a próxima página
            var cu = new viewmodelmodel(u);
            await _navigation.PushAsync(new MusicianProfileView(cu));
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                onPropertyChanged();
            }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                onPropertyChanged();
            }
        }

        private string telefone = string.Empty;
        public string Telefone
        {
            get { return telefone; }
            set
            {
                telefone = value;
                onPropertyChanged();
            }
        }

        private string logradouro = string.Empty;
        public string Logradouro
        {
            get { return logradouro; }
            set
            {
                logradouro = value;
                onPropertyChanged();
            }
        }

        private string numero = string.Empty;
        public string Numero
        {
            get { return numero; }
            set
            {
                numero = value;
                onPropertyChanged();
            }
        }

        private string cep = string.Empty;
        public string Cep
        {
            get { return cep; }
            set
            {
                cep = value;
                onPropertyChanged();
            }
        }

        private string bairro = string.Empty;
        public string Bairro
        {
            get { return bairro; }
            set
            {
                bairro = value;
                onPropertyChanged();
            }
        }

        private string cidade = string.Empty;
        public string Cidade
        {
            get { return cidade; }
            set
            {
                cidade = value;
                onPropertyChanged();
            }
        }

        private string uf = string.Empty;
        public string Uf
        {
            get { return uf; }
            set
            {
                uf = value;
                onPropertyChanged();
            }
        }

        private string senha = string.Empty;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                onPropertyChanged();
            }

        }

        private string codigoTelefone;
        public string CodigoTelefone
        {
            get => codigoTelefone;
            set
            {
                codigoTelefone = value;
                onPropertyChanged();
            }
        }
    }
}
