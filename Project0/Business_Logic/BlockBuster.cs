using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class BlockBuster
    {
        public string Location { get; set; }

        public List<Product> Inventory = new List<Product>();

        public List<Order> OrderHistory = new List<Order>();

        public BlockBuster (string location)
        {
            this.Location = Location;
        }

        public void LogOrder(Order order)
        {
            OrderHistory.Add(order);
        }

        public void AddCustomer(Customer c)
        {

        }

    }
}
