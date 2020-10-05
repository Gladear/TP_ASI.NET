using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MoviesClientApp.Services;
using MoviesWebApp.Models.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MoviesClientApp.ViewModel
{
    class AddCompteViewModel : ViewModelBase
    {
        private Compte _compte;

        public Compte Compte
        {
            get { return _compte; }
            set
            {
                _compte = value;
                RaisePropertyChanged("Compte");
            }
        }

        public ICommand Save_Click { get; private set; }
        public ICommand Clear_Click { get; private set; }

        public AddCompteViewModel()
        {
            _compte = new Compte();
            _compte.Nom = "PINEL";
            _compte.Prenom = "Marie";
            _compte.TelPortable = "0601020304";
            _compte.Mel = "marie.pinelle@example.com";
            _compte.Pwd = "azerty";
            _compte.Rue = "a";
            _compte.CP = "69000";
            _compte.Ville = "b";
            _compte.Pays = "c";

            Save_Click = new RelayCommand(ActionSave);
            Clear_Click = new RelayCommand(ActionClear);
        }

        private async void ActionSave()
        {
            try
            {
                await WSService.CreateCompte(Compte);
                await ShowDialog($"Compte {Compte.Nom} créé !");
            }
            catch (Exception e)
            {
                await ShowDialog(e.Message);
            }
        }

        private void ActionClear()
        {
            _compte = new Compte();
        }

        private async Task ShowDialog(string text)
        {
            var dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}
