using MajorBeat.Models.Enums;
using MajorBeat.Views;
using System.Windows.Input;

namespace MajorBeat.ViewModels
{
    public class MusicianProfileViewModel : BaseViewModel
    {
     
        
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

       

        // Label dinâmico
        public string NomeLabel => Tipo == TipoMusico.Solo ? "Nome" : "Nome da Banda";

        // Lista pro Picker
        public IEnumerable<TipoMusico> Tipos => Enum.GetValues(typeof(TipoMusico)).Cast<TipoMusico>();

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
