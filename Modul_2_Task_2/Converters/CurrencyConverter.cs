using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_2_Practice_1.Entities;
using Modul_2_Practice_1.Services;

namespace Modul_2_Practice_1.Converters
{
    public class CurrencyConverter
    {
        private readonly decimal _dollarRate = 28.45M;
        private readonly decimal _euroRate = 32.15M;
        private readonly Logger _logger = Logger.Instance;

        public decimal ConvertCurrencyInHryvnias(Product product)
        {
            switch (product.Currency)
            {
                case CurrencyType.Dollar:
                    product.Price = ConvertDollarToHryvnias(product.Price);
                    break;
                case CurrencyType.Euro:
                    product.Price = ConvertEuroToHryvnias(product.Price);
                    break;
            }

            return product.Price;
        }

        public decimal ConvertCurrencyInDollar(Product product)
        {
            switch (product.Currency)
            {
                case CurrencyType.Euro:
                    product.Price = ConvertEuroToDollar(product.Price);
                    break;
                case CurrencyType.Hryvnias:
                    product.Price = ConvertHryvniasToDollar(product.Price);
                    break;
            }

            return product.Price;
        }

        public decimal ConvertCurrencyInEuro(Product product)
        {
            switch (product.Currency)
            {
                case CurrencyType.Dollar:
                    product.Price = ConvertDollarToEuro(product.Price);
                    break;
                case CurrencyType.Hryvnias:
                    product.Price = ConvertHryvniasToEuro(product.Price);
                    break;
            }

            return product.Price;
        }

        public decimal ConvertHryvniasToDollar(decimal price)
        {
            return price / _dollarRate;
        }

        public decimal ConvertHryvniasToEuro(decimal price)
        {
            return price / _euroRate;
        }

        private decimal ConvertDollarToHryvnias(decimal price)
        {
            return price * _dollarRate;
        }

        private decimal ConvertDollarToEuro(decimal price)
        {
            return (price * _dollarRate) / _euroRate;
        }

        private decimal ConvertEuroToHryvnias(decimal price)
        {
            return price * _euroRate;
        }

        private decimal ConvertEuroToDollar(decimal price)
        {
            return (price * _euroRate) / _dollarRate;
        }
    }
}
