using MajorBeat.Models;
using MajorBeat.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MajorBeat.ViewModels
{
    public class UsuarioViewModel:BaseViewModel
    {

        private UsuarioService uService;


        public ICommand RegistrarCommand { get; set; }
       
        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
  
            RegistrarCommand = new Command(async () => await RegistrarUsuario());

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

        public async Task RegistrarUsuario()
        {
            try
            {
                Contratante u = new Contratante();
                u.nome = Nome; 
                u.email = Email;
                u.telefone = Telefone;
                u.logradouro = Logradouro;
                u.numero = Numero;
                u.cep = Cep;
                u.bairro = Bairro;
                u.cidade = Cidade;
                u.uf = Uf;
                u.senha = senha;




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
        }



    }
}
