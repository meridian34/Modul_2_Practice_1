using System;
using System.Collections.Generic;
using System.Text;
using Modul_2_Practice_1.Entities;
using Modul_2_Practice_1.Converters;
using Modul_2_Practice_1.Services;

namespace Modul_2_Practice_1.Entities
{
    public class Order
    {
        private const int _valueNotFaundPosition = -1;
        private const decimal _defaultSumPricesValue = 0.0M;
        private readonly CurrencyConverter _currencyConverter = new CurrencyConverter();
        private readonly Logger _logger;

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
            _logger = Logger.Instance;
        }

        public List<OrderDetail> OrderDetails { get; set; }

        public CustomerContactInformation CustomerContactInformation { get; set; }

        public decimal GetSumPricesInDollars()
        {
            return GetSumPricesInCurrency(CurrencyType.Dollar);
        }

        public decimal GetSumPricesInEuro()
        {
            return GetSumPricesInCurrency(CurrencyType.Euro);
        }

        public decimal GetSumPricesInHryvnias()
        {
            return GetSumPricesInCurrency(CurrencyType.Hryvnias);
        }

        public decimal GetSumPricesInCurrency(CurrencyType currencyType)
        {
            var sumPrices = _defaultSumPricesValue;
            foreach (var item in OrderDetails)
            {
                switch (currencyType)
                {
                    case CurrencyType.Dollar:
                        sumPrices = sumPrices + (_currencyConverter.ConvertCurrencyInDollar(item.Product) * item.ProductCount);
                        break;
                    case CurrencyType.Euro:
                        sumPrices = sumPrices + (_currencyConverter.ConvertCurrencyInEuro(item.Product) * item.ProductCount);
                        break;
                    case CurrencyType.Hryvnias:
                        sumPrices = sumPrices + (_currencyConverter.ConvertCurrencyInHryvnias(item.Product) * item.ProductCount);
                        break;
                }
            }

            return sumPrices;
        }

        public void AddProductPosition(Product product, int itemCount)
        {
            var position = GetPositionInOrderDetails(product);
            if (position != _valueNotFaundPosition)
            {
                OrderDetails[position].ProductCount += itemCount;
            }
            else
            {
                OrderDetails.Add(new OrderDetail() { Product = product, ProductCount = itemCount });
            }
        }

        public void DeleteProductPosition(Product product)
        {
            var position = GetPositionInOrderDetails(product);
            if (position != _valueNotFaundPosition)
            {
                OrderDetails.Remove(OrderDetails[position]);
            }
            else
            {
                _logger.LogWarning($"this item is not in the order: {product.Id} {product.Name}");
            }
        }

        public void DeleteProductUnits(Product product, int inputCount)
        {
            var position = GetPositionInOrderDetails(product);
            if (position != _valueNotFaundPosition)
            {
                if (OrderDetails[position].ProductCount > inputCount)
                {
                    OrderDetails[position].ProductCount -= inputCount;
                }
                else
                {
                    _logger.LogWarning($"ProductCount < inputCount - so the position has been removed in order");
                    DeleteProductPosition(product);
                }
            }
            else
            {
                _logger.LogWarning($"this item is not in the order: {product.Id} {product.Name}");
            }
        }

        /// <summary>
        /// Looks for the item number in the shopping list.
        /// </summary>
        /// <returns>Returns '-1' if the item is not found in the shopping list.</returns>
        private int GetPositionInOrderDetails(Product product)
        {
            var position = _valueNotFaundPosition;
            for (var i = 0; i < OrderDetails.Count; i++)
            {
                if (OrderDetails[i].Product.Id == product.Id &&
                    OrderDetails[i].Product.Name == product.Name)
                {
                    position = i;
                    return position;
                }
            }

            return position;
        }
    }
}
