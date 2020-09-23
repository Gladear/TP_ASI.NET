using ClientConvertisseurV2.Service;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModel
{
    public class MainViewModel : ConverterViewModel
    {
        protected override async Task<double> DoConversion(int currencyId, double amount)
        {
            return await CurrencyService.ConvertCurrency(currencyId, amount);
        }
    }
}
