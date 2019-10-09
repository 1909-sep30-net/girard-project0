﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Order
    {
        
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; }
        public List<Product> ProductList = new List<Product>();

        public Order (Customer c, BlockBuster b)
        {
            this.Customer = c;
            this.OrderDate = DateTime.Now;
        }

        public void AddItem(Product p)
        {
            ProductList.Add(p);
            p.InventoryAmount--;
        }


    }
}
