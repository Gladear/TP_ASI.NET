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
    public class CompteViewModel : ViewModelBase
    {
        private string _search = "paul.durand@gmail.com";

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                RaisePropertyChanged("Search");
            }
        }

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


        public ICommand BtnSearch_Click { get; private set; }
        public ICommand Save_Click { get; set; }
        public ICommand Clear_Click { get; private set; }

        public CompteViewModel()
        {
            BtnSearch_Click = new RelayCommand(ActionSearch);
            Save_Click = new RelayCommand(ActionSave);
            Clear_Click = new RelayCommand(ActionClear);
        }

        private async void ActionSearch()
        {
            // TODO Check that `Search` is a valid email address
            if (Search.Length == 0)
            {
                await ShowDialog("Veuillez entrez une adresse e-mail valide");
                return;
            }
            var compte = await WSService.GetCompteByEmail(Search);
            if (compte == null)
            {
                await ShowDialog("Compte introuvable");
                return;
            }
            Compte = compte;
        }

        private async void ActionSave()
        {
            if (Compte == null)
            {
                await ShowDialog("Veuillez sélectionner un compte");
                return;
            }
            try
            {
                await WSService.UpdateCompte(Compte);
                await ShowDialog($"Compte {Compte.Nom} modifié !");
            }
            catch (Exception ex)
            {
                await ShowDialog(ex.Message);
            }
        }

        private void ActionClear()
        {
            Compte = null;
        }

        private async Task ShowDialog(string text)
        {
            var dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}
