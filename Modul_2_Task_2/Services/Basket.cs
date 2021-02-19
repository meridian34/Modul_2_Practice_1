using System.Collections.Generic;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Services
{
    public class Basket
    {
        private static readonly Basket _instance;
        private readonly Logger _logger;

        static Basket()
        {
            _instance = new Basket();
        }

        private Basket()
        {
            Products = new List<Product>();
            _logger = Logger.Instance;
        }

        public static Basket Instance
        {
            get
            {
                return _instance;
            }
        }

        private List<Product> Products { get; set; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            var productDeleted = false;
            for (var i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == product.Id)
                {
                    Products.Remove(Products[i]);
                    productDeleted = true;
                }
            }

            if (!productDeleted)
            {
                _logger.LogWarning($"invoke - {nameof(DeleteProduct)}, but not faund Product for delete");
            }
        }

        public Product[] GetOrderProducts()
        {
            return Products.ToArray();
        }

        public void BasketClear()
        {
            Products.Clear();
        }
    }
}
