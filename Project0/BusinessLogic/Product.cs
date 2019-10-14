using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Product
    {
        public int InventoryAmount { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        public string Rating { get; set; }

        public string Details { get; set; }

        public int ProductId { get; set; }

        public Product(int id, string title, string details, decimal price, string rating, int count)
        {
            this.ProductId = id;
            this.Title = title;
            this.Details = details;
            this.Price = price;
            this.Rating = rating;
            this.InventoryAmount = count;
        }

        public void ReduceInventory ()
        {
            if (this.InventoryAmount > 0)
            {
                this.InventoryAmount--;
            }
            else
            {
                Console.WriteLine("That item is out of stock");
            }
        }
    }
}
