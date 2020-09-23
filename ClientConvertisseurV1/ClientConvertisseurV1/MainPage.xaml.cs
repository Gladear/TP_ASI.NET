using ClientConvertisseurV1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WSConvertisseur.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ActionGetData();
        }

        private async void ActionGetData()
        {
            var currencies = await WSService.GetAllCurrenciesAsync();
            if (currencies != null)
            {
                Currency.DataContext = new List<Currency>(currencies);
            }
        }

        private async void OnButtonConvertClick(object sender, RoutedEventArgs ev)
        {
            try
            {
                var amount = Convert.ToDouble(AmountFrom.Text);
                var currencyId = (int) Currency.SelectedValue;
                var result = await CurrencyService.ConvertCurrency(currencyId, amount);
                AmountTo.Text = result.ToString();
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                await dialog.ShowAsync();
            }
        }
    }
}
