using System;
using Modul_2_Practice_1.Controllers;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Services
{
    public class Starter
    {
        private readonly Product[] _products;
        private readonly ProductCatalogController _catalogController;
        private readonly PurchaseController _purchaseController;
        private readonly Providers.CurrencyProvider _currencyProvider;
        private readonly Currency[] _currencies;
        private readonly Basket _basket;
        private readonly int _minRandomValue = 0;
        private readonly int _maxRandomValue = 10;
        private readonly Random _random;

        public Starter()
        {
            _catalogController = new ProductCatalogController();
            _products = _catalogController.GetProducts();
            _purchaseController = new PurchaseController();
            _currencyProvider = new Providers.CurrencyProvider();
            _currencies = _currencyProvider.GetCurrencies();
            _random = new Random();
            _basket = Basket.Instance;
        }

        public void Run()
        {
            var ukranianCustomer = new CustomerContactInformation() { FirstName = "Valera", LastName = "Valakas", Address = "Dnipro", Phone = "1234567890", Email = "qwerty@com", SelectedCurrency = _currencies[0] };
            MakeCustomerOperation(ukranianCustomer);
            var germanCustomer = new CustomerContactInformation() { FirstName = "Otto", LastName = "fon Bismark", Address = "Berlin", Phone = "0987654321", Email = "1qwerty@com1", SelectedCurrency = _currencies[1] };
            MakeCustomerOperation(germanCustomer);
            var usaCustomer = new CustomerContactInformation() { FirstName = "Donald", LastName = "Trap", Address = "San-Andreas", Phone = "464135641146", Email = "2qwerty@com2", SelectedCurrency = _currencies[2] };
            MakeCustomerOperation(usaCustomer);
        }

        private void FillBasket()
        {
            for (var i = 0; i < 20; i++)
            {
                var randomValue = _random.Next(_minRandomValue, _maxRandomValue);
                _basket.AddProduct(_products[randomValue]);
            }
        }

        private void MakeCustomerOperation(CustomerContactInformation customer)
        {
            FillBasket();
            _basket.DeleteProduct(_products[5]);
            _purchaseController.MakeAnOrder(customer);
        }
    }
}
