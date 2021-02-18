using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Converters
{
    public class CurrencyConverter
    {
        private const CurrencyType _mainCurrencyType = CurrencyType.Hryvnias;
        private readonly decimal _dollarRate = 28.45M;
        private readonly decimal _euroRate = 32.15M;
        private readonly decimal _gryvniasRate = 1;

        public Product ConvertCurrencyInHryvnias(Product product)
        {
            switch (product.Currency)
            {
                case CurrencyType.Dollar:                    
                    product.Price *= _dollarRate;
                    break;
                case CurrencyType.Euro:
                    product.Price *= _euroRate;
                    break;
            }

            product.Currency = CurrencyType.Hryvnias;
            return product;
        }
    }
}
