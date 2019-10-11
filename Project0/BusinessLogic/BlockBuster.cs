using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class BlockBuster
    {
        public string Location { get; set; }

        public List<Product> Inventory = new List<Product>();

        public List<Order> OrderHistory = new List<Order>();

        public List<Customer> Customers = new List<Customer>();

        public BlockBuster (string location)
        {
            this.Location = Location;
        }

        public void AddInventory(Product p)
        {
            Inventory.Add(p);
        }

        public void LogOrder(Order order)
        {
            OrderHistory.Add(order);
        }

        public void AddCustomer(Customer c)
        {
            Customers.Add(c);
        }

    }
}
