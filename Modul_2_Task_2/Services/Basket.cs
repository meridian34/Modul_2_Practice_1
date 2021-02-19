using System;
using System.Collections.Generic;
using System.Text;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Services
{
    public class Basket
    {
        private static readonly Basket _instance;
        private readonly Order _order;

        static Basket()
        {
            _instance = new Basket();
        }

        private Basket()
        {
            _order = new Order();
        }

        public static Basket GetInstance
        {
            get
            {
                return _instance;
            }
        }

        public void AddProduct(Product product, int count)
        {
            var orderDetails = new OrderDetail() { Product = product, ProductCount = count };
            _order.OrderDetails.Add(orderDetails);
        }

        public Order GetOrder()
        {
            return _order;
        }

        public void BasketClear()
        {
            _order.OrderDetails.Clear();
        }
    }
}
