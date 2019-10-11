using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int InventoryId { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Stores Location { get; set; }
    }
}
