using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            Orders = new HashSet<Orders>();
        }

        public int InventoryId { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int LocationId { get; set; }

        public virtual Stores Location { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
