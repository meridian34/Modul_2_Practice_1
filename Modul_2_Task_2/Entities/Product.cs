﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modul_2_Practice_1.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public CurrencyType Currency { get; set; }

        public Product GetCopy()
        {
            return new Product() { Currency = Currency, Id = Id, Name = Name, Price = Price };
        }
    }
}
