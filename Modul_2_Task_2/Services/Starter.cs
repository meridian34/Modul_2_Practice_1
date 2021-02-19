using System;
using System.Collections.Generic;
using Modul_2_Practice_1.Controllers;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Services
{
    public class Starter
    {
        private readonly List<Product> _products;
        private readonly ProductCatalogController _catalogController;
        private readonly PurchaseController _purchaseController;
        private readonly int _minRandomValue = 0;
        private readonly int _maxRandomValue = 10;
        private readonly Random _random;

        public Starter()
        {
            _catalogController = new ProductCatalogController();
            _products = _catalogController.GetCatalog();
            _purchaseController = new PurchaseController();
            _random = new Random();
        }

        public void Run()
        {
            var ukranianCustomer = new CustomerContactInformation() { Name = "Valera", LastName = "Valakas", Address = "Dnipro", Country = Country.Ukraine, Phone = "1234567890" };
            MakeCustomerOperation(ukranianCustomer);
            var germanCustomer = new CustomerContactInformation() { Name = "Otto", LastName = "fon Bismark", Address = "Berlin", Country = Country.Germany, Phone = "0987654321" };
            MakeCustomerOperation(germanCustomer);
            var usaCustomer = new CustomerContactInformation() { Name = "Donald", LastName = "Trap", Address = "San-Andreas", Country = Country.USA, Phone = "464135641146" };
            MakeCustomerOperation(usaCustomer);
        }

        private void FillBasket()
        {
            for (var i = 0; i < 20; i++)
            {
                var randomValue = _random.Next(_minRandomValue, _maxRandomValue);
                _purchaseController.AddInBasket(_products[randomValue].GetCopy());
            }
        }

        private void MakeCustomerOperation(CustomerContactInformation customer)
        {
            FillBasket();
            _purchaseController.DeleteProductPosition(_products[5]);
            _purchaseController.DeleteProductUnits(_products[3], 2);
            _purchaseController.MakeAnOrder(customer);
            _purchaseController.ClearBasket();
        }
    }
}
