using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Order
    {
        public string StoreLocation { get; set; }
        
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; }
        public List<Movie> MovieList = new List<Movie>();

        public Order (Customer c, string sLocation, DateTime date)
        {
            this.StoreLocation = sLocation;
            this.Customer = c;
            this.OrderDate = date;
        }

    }
}
