using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MoviesClientApp.Services;
using MoviesWebApp.Models.EntityFramework;
using System;
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

        public CompteViewModel()
        {
            BtnSearch_Click = new RelayCommand(ActionSearch);
        }

        private async void ActionSearch()
        {
            // TODO Check that `Search` is a valid email address
            if (Search.Length == 0)
            {
                var dialog = new MessageDialog("Veuillez entrez une adresse e-mail valide");
                await dialog.ShowAsync();
                return;
            }
            var compte = await WSService.GetCompteByEmail(Search);
            if (compte == null)
            {
                var dialog = new MessageDialog("Compte introuvable");
                await dialog.ShowAsync();
                return;
            }
            Compte = compte;
        }
    }
}
