using System;
using System.Collections.Generic;
using System.Text;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Entities
{
    public class Order
    {
        private List<OrderDetails> _orderDetails;
        public List<OrderDetails> OrderDetails
        {
            get { return _orderDetails; }
            set
            {

            }
        }
        public CustomerContactInformation CustomerContactInformation { get; set; }
        public decimal SumPrice { get; set; }
        
    }
}
