using System;
using System.Collections.Generic;

namespace BusinessLogic
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
            } 
            set
            {
                if (value == "")
                {
                    Console.WriteLine("You forgot to enter the customer's first name");
                }
                else if (value.Length > 20)
                {
                    Console.WriteLine("That first name exceeds the 25 character limit\n Please try again.\n");
                }
                else
                {
                    this._FirstName = value;
                }
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
                if (value == "")
                {
                    Console.WriteLine("You forgot to enter the customer's last name");
                }
                else if (value.Length > 20)
                {
                    Console.WriteLine("That last name exceeds the 25 character limit\n Please try again.\n");
                }
                else
                {
                    this._LastName = value;
                }
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

    }
}
