using System;
using System.Collections.Generic;

namespace BusinessLibrary
{
    public class Customer
    {

        private string _FirstName;
        private string _LastName;


        public string FirstName
        {
            get 
            {
                return _FirstName;
            } set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                this._FirstName = value;
            } 
        }
        public string LastName 
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                this._LastName = value;
            }
        }

        public Order order { get; set; }

        public List<Order> OrderHistory = new List<Order>();

        public Customer(string FName, string LName)
        {
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
