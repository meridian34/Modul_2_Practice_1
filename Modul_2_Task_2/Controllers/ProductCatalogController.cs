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

        public Product[] GetProducts()
        {
            _logger.LogInfo($"Invoke {nameof(ProductCatalogController.GetProducts)}");
            Product[] products = new Product[10];
            products[0] = new Product() { Id = 0, Name = "spark plug", Price = 10.5M };
            products[1] = new Product() { Id = 1, Name = "xenon lamp", Price = 1800.2M };
            products[2] = new Product() { Id = 2, Name = "brake shoe", Price = 15.3M };
            products[3] = new Product() { Id = 3, Name = "oil", Price = 200 };
            products[4] = new Product() { Id = 4, Name = "tire", Price = 899.5M };
            products[5] = new Product() { Id = 5, Name = "hood", Price = 3114.4M };
            products[6] = new Product() { Id = 6, Name = "bumper", Price = 135.3M };
            products[7] = new Product() { Id = 7, Name = "battery", Price = 1500 };
            products[8] = new Product() { Id = 8, Name = "exhaust pipe", Price = 739.6M };
            products[9] = new Product() { Id = 9, Name = "air filter", Price = 10.4M };
            return products;
        }
    }
}
