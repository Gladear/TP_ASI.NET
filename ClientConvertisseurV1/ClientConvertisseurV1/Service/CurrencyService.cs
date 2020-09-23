using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Service
{
    class CurrencyService
    {
        internal async static Task<double> ConvertCurrency(int currencyId, double amount)
        {
            var currency = await WSService.GetCurrencyAsync(currencyId);
            return amount * currency.Rate;
        }
    }
}
