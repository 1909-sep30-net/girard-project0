using BusinessLogic;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0
{
    public class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => {
            builder.AddConsole();
        });
        static void Main(string[] args)
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<BlockBusterContext> options = new DbContextOptionsBuilder<BlockBusterContext>()
                .UseSqlServer(connectionString)
                .UseLoggerFactory(MyLoggerFactory)
                .Options;

            using var context = new BlockBusterContext(options);

            var repository = new BlockBusterRepository(context);




            string select;

            do
            {
                PrintMenu();


                select = Console.ReadLine();

                switch (Int32.Parse(select))
                {
                    case 1:
                        
                        repository.DisplayStores();
                        Console.WriteLine("Please enter the ID of your desired location?");
                        string id = Console.ReadLine();
                        var sqlStore = repository.GetStoreById(Int32.Parse(id));
                        BlockBuster store = new BlockBuster(sqlStore.LocationId, $"{sqlStore.City}, {sqlStore.State}");
                        Console.WriteLine("Enter Customer's First Name");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter Customer's Last Name");
                        string lname = Console.ReadLine();
                        var sqlCustomer = repository.GetCustomerByName(fname, lname);
                        Customer customer = new Customer(sqlCustomer.CustomerId, sqlCustomer.FirstName, sqlCustomer.LastName);
                        Console.WriteLine($"Thank you for visiting our {store.Location} location");
                        Console.WriteLine("This is our current selection of movies and video games");
                        repository.DisplayInventory(sqlStore);
                        Order order = new Order();
                        repository.MakeOrder(customer.CustomerId, store.LocationId, order.OrderDate);
                        Console.WriteLine("Enter the ID number of your selection");
                        string selection = Console.ReadLine();
                        var sqlProduct = repository.GetProductById(store.LocationId, Int32.Parse(selection));
                        Product add = new Product(sqlProduct.InventoryId, sqlProduct.Title, sqlProduct.Details, sqlProduct.Price, sqlProduct.Rating, sqlProduct.InventoryAmount);
                        add.ReduceInventory();   
                        repository.AddProductToOrder(order.OrderId, add.ProductId);
                        break;
                    case 2:
                        break;

                }
            } while (Int32.Parse(select) <= 6);
        }


        public static void DisplayOrderHistory(Customer c)
        {
            Console.WriteLine($"{c.FirstName} {c.LastName}");
            foreach (Order o in c.OrderHistory)
            {
                Console.WriteLine($"{o.OrderDate}");
                foreach (Product p in o.ProductList)
                {
                    Console.WriteLine($"{p.Title} {p.Details} {p.Price} {p.Rating}");
                }
            }

        }

        public void DisplayOrderHistory(BlockBuster b, string location)
        {

        }

        public static void DisplayProducts(BlockBuster b)
        {
            foreach (Product p in b.Inventory)
            {
                Console.WriteLine($"{p.Title} {p.Details} {p.Price} {p.Rating}");
            }
        }

        public static List<string> AskCustomerName()
        {
            Console.WriteLine("Enter Customer's First Name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Customer's Last Name");
            string lname = Console.ReadLine();
            List<string> name = new List<string>();
            name.Add(fname);
            name.Add(lname);
            return name;
        }

        public static void PrintMenu()
        {
            Console.WriteLine("\n\tMENU\n=======================================");
            Console.WriteLine("\nMake an order ");
            Console.WriteLine("\nDisplay customer order history");
            Console.WriteLine("\n=======================================");
            Console.WriteLine("\n Enter your choice (from 1 to 9 ): ");
        }
    }
}