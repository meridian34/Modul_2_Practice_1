using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_2_Practice_1.Entities
{
    public class OrderDetails
    {
        public Product Product { get; set; }

        private int _productCount;
        public int ProductCount
        {
            get { return _productCount; }
            set
            {
                _productCount = value;
                Amount = _productCount * Product.Price;
            }
        }

        public decimal Amount { get; set; }
    }
}
