using Modul_2_Practice_1.Entities;
using Modul_2_Practice_1.Services;

namespace Modul_2_Practice_1.Converters
{
    public class CurrencyConverter
    {
        private readonly Logger _logger = Logger.Instance;

        public decimal CurrencyConvertIn(Currency currency, decimal value)
        {
            return value / currency.Rate;
        }
    }
}
