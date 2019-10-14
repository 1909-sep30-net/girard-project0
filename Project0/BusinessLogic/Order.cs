using System;
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

        public void ReduceInventory(Product p)
        {
             if (ProductList.Count > 5)
            {
                Console.WriteLine("You have already reached the 5 item limit for this clearance sale.");
            } else if (p.InventoryAmount > 0)
            {
                ProductList.Add(p);
                p.InventoryAmount--;
            } else
            {
                Console.WriteLine("That item is out of stock");
            }
        }


    }
}
