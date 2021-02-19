using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_2_Practice_1.Entities;
using Modul_2_Practice_1.Services;

namespace Modul_2_Practice_1.Controllers
{
    public class ProductCatalogController
    {
        private readonly Logger _logger;

        public ProductCatalogController()
        {
            _logger = Logger.Instance;
        }

        public List<Product> GetCatalog()
        {
            _logger.LogInfo($"Invoke {nameof(ProductCatalogController.GetCatalog)}");
            List<Product> products = new List<Product>();
            products.Add(new Product() { Id = 0, Name = "spark plug", Price = 10.5M, Currency = CurrencyType.Euro });
            products.Add(new Product() { Id = 1, Name = "xenon lamp", Price = 1800.2M, Currency = CurrencyType.Hryvnias });
            products.Add(new Product() { Id = 2, Name = "brake shoe", Price = 15.3M, Currency = CurrencyType.Dollar });
            products.Add(new Product() { Id = 3, Name = "oil", Price = 200, Currency = CurrencyType.Euro });
            products.Add(new Product() { Id = 4, Name = "tire", Price = 899.5M, Currency = CurrencyType.Hryvnias });
            products.Add(new Product() { Id = 5, Name = "hood", Price = 3114.4M, Currency = CurrencyType.Hryvnias });
            products.Add(new Product() { Id = 6, Name = "bumper", Price = 135.3M, Currency = CurrencyType.Euro });
            products.Add(new Product() { Id = 7, Name = "battery", Price = 1500, Currency = CurrencyType.Hryvnias });
            products.Add(new Product() { Id = 8, Name = "exhaust pipe", Price = 739.6M, Currency = CurrencyType.Hryvnias });
            products.Add(new Product() { Id = 9, Name = "air filter", Price = 10.4M, Currency = CurrencyType.Dollar });
            return products;
        }
    }
}
