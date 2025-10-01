using MajorBeat.Views.Contratante;
using MajorBeat.Views.Musico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MajorBeat.ViewModels
{
    public class PrincipalViewModel : BaseViewModel
    {
        public MusicianProfileViewModel MusicoVM { get; }
        public UsuarioViewModel ContratanteVM { get; }
        private readonly INavigation _navigation;


        private bool isMusicoSelected;
        public bool IsMusicoSelected
        {
            get => isMusicoSelected;
            set
            {
                if (isMusicoSelected != value)
                {
                    isMusicoSelected = value;
                    onPropertyChanged(nameof(IsMusicoSelected));       // avisa que mudou
                    onPropertyChanged(nameof(IsContratanteSelected));
                }
            }
        }

        public bool IsContratanteSelected => !isMusicoSelected;

        public ICommand ConfirmarCommand { get; }

        public PrincipalViewModel(INavigation navigation)
        {
            _navigation = navigation;
            MusicoVM = new MusicianProfileViewModel();
            ContratanteVM = new UsuarioViewModel();

            ConfirmarCommand = new Command(async () => await OnConfirmarClicked());
        }

        private async Task OnConfirmarClicked()
        {
            if (IsMusicoSelected)
            {
                await _navigation.PushAsync(new MusicianProfileView());
                // MusicoVM.CadastrarMusico();
            }
            else
            {
                await _navigation.PushAsync(new HirerProfileView());
                // ContratanteVM.RegistrarUsuario();
            }
        }
    }
}
