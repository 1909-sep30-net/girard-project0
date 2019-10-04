using System;
using System.Collections.Generic;

namespace BusinessLibrary
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName
        {
            get 
            {
                return FirstName;
            } set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                this.FirstName = value;
            } 
        }
        public string LastName 
        {
            get
            {
                return LastName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                this.LastName = value;
            }
        }

        public List<Order> OrderHistory = new List<Order>();

        public Customer(int Id, string FName, string LName)
        {
            this.CustomerId = Id;
            this.FirstName = FName;
            this.LastName = LName;
        }

        public void LogOrder(Order order)
        {
            OrderHistory.Add(order);
        }

        public void DisplayOrderHistory(Customer c)
        {
            foreach (Order o in c.OrderHistory)
            {
                Console.WriteLine(o);
            }
        }

    }
}
