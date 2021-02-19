using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Providers
{
    public class CurrencyProvider
    {
        public Currency[] GetCurrencies()
        {
            Currency[] currencies = new Currency[3];
            currencies[0] = new Currency() { CurrencyName = "UAH", Rate = 1 };
            currencies[1] = new Currency() { CurrencyName = "USD", Rate = 28 };
            currencies[2] = new Currency() { CurrencyName = "EUR", Rate = 33 };
            return currencies;
        }
    }
}
