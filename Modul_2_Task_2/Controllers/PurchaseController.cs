using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_2_Practice_1.Entities;
using Modul_2_Practice_1.Services;

namespace Modul_2_Practice_1.Controllers
{
    public class PurchaseController
    {
        private readonly Basket _basket;
        private readonly Logger _logger;

        public PurchaseController()
        {
            _basket = Basket.GetInstance;
            _logger = Logger.Instance;
        }

        public void AddInBasket(Product product, int count)
        {
            _logger.LogInfo($"Invoke: {nameof(AddInBasket)}");
            _basket.AddProduct(product, count);
        }

        public void AddInBasket(Product product)
        {
            AddInBasket(product, 1);
        }

        public void ClearBasket()
        {
            _logger.LogInfo($"Invoke: {nameof(ClearBasket)}");
            _basket.BasketClear();
        }

        public void DeleteProductPosition(Product product)
        {
            _logger.LogInfo($"Invoke: {nameof(DeleteProductPosition)}");
            _basket.GetOrder().DeleteProductPosition(product);
        }

        public void DeleteProductUnits(Product product, int count)
        {
            _logger.LogInfo($"Invoke: {nameof(DeleteProductUnits)}");
            _basket.GetOrder().DeleteProductUnits(product, count);
        }

        public void MakeAnOrder(CustomerContactInformation information)
        {
            _logger.LogInfo($"Invoke: {nameof(MakeAnOrder)}");
            var sumPrices = 0.0M;
            var currency = CurrencyType.Hryvnias;

            if (CheckCustomerInformation(information))
            {
                switch (information.Country)
                {
                    case Country.Ukraine:
                        sumPrices = _basket.GetOrder().GetSumPricesInHryvnias();
                        currency = CurrencyType.Hryvnias;
                        break;
                    case Country.USA:
                        sumPrices = _basket.GetOrder().GetSumPricesInDollars();
                        currency = CurrencyType.Dollar;
                        break;
                    case Country.Germany:
                        sumPrices = _basket.GetOrder().GetSumPricesInEuro();
                        currency = CurrencyType.Euro;
                        break;
                }

                _logger.LogInfo($"Client {information.Name} {information.LastName} bought goods for {sumPrices} {currency}.");
                _basket.BasketClear();
            }
        }

        private bool CheckCustomerInformation(CustomerContactInformation info)
        {
            _logger.LogInfo($"Invoke: {nameof(CheckCustomerInformation)}");
            if (!string.IsNullOrEmpty(info.Address) &&
                !string.IsNullOrEmpty(info.Name) &&
                !string.IsNullOrEmpty(info.LastName) &&
                (!string.IsNullOrEmpty(info.Phone) || !string.IsNullOrEmpty(info.Email)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
