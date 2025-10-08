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




        // Label din�mico
        public string NomeLabel => Tipo == TipoMusico.Solo ? "Nome Completo" : "Nome da Banda";

        // Lista pro Picker
        public IEnumerable<TipoMusico> Tipos => Enum.GetValues(typeof(TipoMusico)).Cast<TipoMusico>();

            private bool ValidarCampos(Musico u)
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(u.nome)) 
            { 
                ErroNomeVisible = true; 
                valido = false; 
            } else {
                ErroNomeVisible = false; 
            }
            if (string.IsNullOrWhiteSpace(u.email) || !u.email.EndsWith(".com"))
            { 
                ErroEmailVisible = true; 
                valido = false; 
            } else { 
                ErroEmailVisible = false;
            }
            if (string.IsNullOrWhiteSpace(u.telefone) || Telefone.Length != 11 || !Telefone.All(char.IsDigit))
            { 
                ErroTelefoneVisible = true; 
                valido = false; 
            } else { 
                ErroTelefoneVisible = false; 
            }
            if (string.IsNullOrWhiteSpace(u.logradouro)) 
            { 
                ErroLogradouroVisible = true; 
                valido = false; 
            } else { 
                ErroLogradouroVisible = false; 
            }
            if (string.IsNullOrWhiteSpace(u.numero) || !Numero.All(char.IsDigit)) 
            { 
                ErroNumeroVisible = true; 
                valido = false;
            } else { 
                ErroNumeroVisible = false;
            }
            if (string.IsNullOrWhiteSpace(u.bairro)) 
            { 
                ErroBairroVisible = true; 
                valido = false; 
            } else { 
                ErroBairroVisible = false; 
            }
            if (string.IsNullOrWhiteSpace(u.cidade)) 
            { 
                ErroCidadeVisible = true; 
                valido = false; 
            } else { 
                ErroCidadeVisible = false; 
            }
            if (string.IsNullOrWhiteSpace(u.uf) || u.uf.Length != 2) { 
                ErroUfVisible = true;
                valido = false; 
            } else { 
                ErroUfVisible = false; 
            }
            if (string.IsNullOrWhiteSpace(u.cep) || u.cep.Length != 8 || !u.cep.All(char.IsDigit)) {
                ErroCepVisible = true; 
                valido = false; 
            } else { 
                ErroCepVisible = false; 
            }
            if (string.IsNullOrWhiteSpace(u.senha) || u.senha.Length < 8) {
                ErroSenhaVisible = true; 
                valido = false;
            } else { 
                ErroSenhaVisible = false; 
            }
            

            return valido;
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
            if (ValidarCampos(u))
            {
                var cu = new viewmodelmodel(u);
                await _navigation.PushAsync(new MusicianProfileView(cu));
            }
               
                


            // Se passou na valida��o, avan�a para a pr�xima p�gina
            
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



        private bool erroNomeVisible;
        public bool ErroNomeVisible
        {
            get => erroNomeVisible;
            set { erroNomeVisible = value; onPropertyChanged(); }
        }

        private bool erroEmailVisible;
        public bool ErroEmailVisible
        {
            get => erroEmailVisible;
            set { erroEmailVisible = value; onPropertyChanged(); }
        }

        private bool erroTelefoneVisible;
        public bool ErroTelefoneVisible
        {
            get => erroTelefoneVisible;
            set { erroTelefoneVisible = value; onPropertyChanged(); }
        }

        private bool erroLogradouroVisible;
        public bool ErroLogradouroVisible
        {
            get => erroLogradouroVisible;
            set { erroLogradouroVisible = value; onPropertyChanged(); }
        }

        private bool erroNumeroVisible;
        public bool ErroNumeroVisible
        {
            get => erroNumeroVisible;
            set { erroNumeroVisible = value; onPropertyChanged(); }
        }

        private bool erroBairroVisible;
        public bool ErroBairroVisible
        {
            get => erroBairroVisible;
            set { erroBairroVisible = value; onPropertyChanged(); }
        }

        private bool erroCidadeVisible;
        public bool ErroCidadeVisible
        {
            get => erroCidadeVisible;
            set { erroCidadeVisible = value; onPropertyChanged(); }
        }

        private bool erroUfVisible;
        public bool ErroUfVisible
        {
            get => erroUfVisible;
            set { erroUfVisible = value; onPropertyChanged(); }
        }

        private bool erroCepVisible;
        public bool ErroCepVisible
        {
            get => erroCepVisible;
            set { erroCepVisible = value; onPropertyChanged(); }
        }

        private bool erroSenhaVisible;
        public bool ErroSenhaVisible
        {
            get => erroSenhaVisible;
            set { erroSenhaVisible = value; onPropertyChanged(); }
        }

        private bool erroNomeEmpresaVisible;
        public bool ErroNomeEmpresaVisible
        {
            get => erroNomeEmpresaVisible;
            set { erroNomeEmpresaVisible = value; onPropertyChanged(); }
        }

        private bool erroFotoVisible;
        public bool ErroFotoVisible
        {
            get => erroFotoVisible;
            set { erroFotoVisible = value; onPropertyChanged(); }
        }

        private bool erroBiografiaVisible;
        public bool ErroBiografiaVisible
        {
            get => erroBiografiaVisible;
            set { erroBiografiaVisible = value; onPropertyChanged(); }
        }

        private bool erroInstrumentosVisible;
        public bool ErroInstrumentosVisible
        {
            get => erroInstrumentosVisible;
            set { erroInstrumentosVisible = value; onPropertyChanged(); }
        }

        private bool erroGenerosVisible;
        public bool ErroGenerosVisible
        {
            get => erroGenerosVisible;
            set { erroGenerosVisible = value; onPropertyChanged(); }
        }
    }
}
