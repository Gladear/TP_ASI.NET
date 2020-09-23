﻿using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ClientConvertisseurV2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Currency> _comboBoxCurrencies;

        public ObservableCollection<Currency> ComboBoxCurrencies
        {
            get { return _comboBoxCurrencies; }
            set
            {
                _comboBoxCurrencies = value;
                RaisePropertyChanged();
            }
        }

        private string _amountFrom;

        public string AmountFrom
        {
            get { return _amountFrom; }
            set
            {
                _amountFrom = value;
                RaisePropertyChanged();
            }
        }

        private Currency currency;

        public Currency SelectedCurrency
        {
            get { return currency; }
            set
            {
                currency = value;
                RaisePropertyChanged();
            }
        }

        private double _amountTo;

        public double AmountTo
        {
            get { return _amountTo; }
            set
            {
                _amountTo = value;
                RaisePropertyChanged();
            }
        }



        public ICommand BtnSetConversion { get; private set; }

        public MainViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        private async void ActionGetData()
        {
            var result = await WSService.GetAllCurrenciesAsync();
            ComboBoxCurrencies = new ObservableCollection<Currency>(result);
        }

        private async void ActionSetConversion()
        {
            if (AmountFrom.Length == 0)
            {
                var dialog = new MessageDialog("Please enter an amount to convert");
                await dialog.ShowAsync();
                return;
            }
            if (SelectedCurrency == null)
            {
                var dialog = new MessageDialog("Please select a currency");
                await dialog.ShowAsync();
                return;
            }
            try
            {
                var amountFrom = Convert.ToDouble(AmountFrom);
                AmountTo = await CurrencyService.ConvertCurrency(SelectedCurrency.Id, amountFrom);
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                await dialog.ShowAsync();
            }
        }
    }
}
