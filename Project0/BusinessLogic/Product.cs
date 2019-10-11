using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Product
    {
        public int InventoryAmount { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
        public string Rating { get; set; }

        public string Details { get; set; }

        public Product(string title, string details, double price, string rating, int count)
        {
            this.Title = title;
            this.Details = details;
            this.Price = price;
            this.Rating = rating;
            this.InventoryAmount = count;
        }
    }
}
