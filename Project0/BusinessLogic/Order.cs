﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Order
    {

        public DateTime OrderDate { get; }
        public List<Product> ProductList = new List<Product>();
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }

        public Order()
        {
            this.OrderDate = DateTime.Now;
        }




    }
}
