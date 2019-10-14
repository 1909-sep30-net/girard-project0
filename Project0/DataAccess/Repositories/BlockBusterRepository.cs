using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{ 
    public class BlockBusterRepository
    {
        private readonly BlockBusterContext _dbContext;

        public BlockBusterRepository (BlockBusterContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DisplayStores ()
        {
            foreach (Stores store in _dbContext.Stores)
            {
                Console.WriteLine($"ID: {store.LocationId} {store.City}, {store.State}");
            }
        }

        public Stores GetStoreById (int id)
        {
            return _dbContext.Stores.First(b => b.LocationId == id);
        }

        public void AddNewCustomer(string firstname, string lastname)
        {
            if (_dbContext.Customers.Any(c => (c.FirstName == firstname) && (c.LastName == lastname)))
            {
                Console.WriteLine($"{firstname} {lastname} has already visited one our locations.");
                return;
            }

            var customer = new DataAccess.Entities.Customers
            {
                FirstName = firstname,
                LastName = lastname
            };

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void AddProductToOrder (int orderId, int productId)
        {
            var product = new DataAccess.Entities.OrderDetails
            {
                OrderId = orderId,
                InventoryId = productId
            };

            _dbContext.OrderDetails.Add(product);
            _dbContext.SaveChanges();
        }

        public bool SearchCustomers (string firstname, string lastname)
        {
            if (_dbContext.Customers.Any(c => (c.FirstName == firstname) && (c.LastName == lastname)))
            {
                Console.WriteLine($"{firstname} {lastname} has already visited one of our locations.");
                return true;
            } else
            {
                return false;
            }
        }

        public Customers GetCustomerByName(string firstname, string lastname)
        {
            return _dbContext.Customers.First(c => (c.FirstName == firstname) && (c.LastName == lastname));
        }

        public void MakeOrder(int customerId, int storeId, DateTime date)
        {
            var order = new DataAccess.Entities.Orders
            {
                CustomerId = customerId,
                LocationId = storeId,
                Date = date
            };

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void DisplayInventory(Stores s)
        {
            foreach (Inventory product in s.Inventory)
            {
                Console.WriteLine($"ID: {product.InventoryId} Title: {product.Title} Rating: {product.Rating} Details: {product.Details} Price: {product.Price}");
            }
        }

        public Inventory GetProductById (int storeId, int id)
        {
            return _dbContext.Inventory.First(p => (p.InventoryId == id) && (storeId == p.LocationId));
        }



    }
}
