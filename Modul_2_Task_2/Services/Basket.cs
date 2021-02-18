using System;
using System.Collections.Generic;
using System.Text;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Services
{
    class Basket
    {
        private readonly static Basket _instance;
        private readonly Order _order; 
        private Basket()
        {
            _order = new Order();
        }
        static Basket()
        {
            _instance = new Basket();
        }

        public void AddProduct(Product product, int count)
        {
            var orderDetails = new OrderDetails() { Product = product, ProductCount = count };
            _order.OrderDetails.Add(orderDetails);
        }
        public List<Product> GetProductsBasket()
        {
            return _products;
        }
        public void BasketClear()
        {
            _products.Clear();
        }

        public static Basket GetInstance
        {
            get
            {
                return _instance;
            }
        }

    }
}
