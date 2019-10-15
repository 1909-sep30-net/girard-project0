using BusinessLogic;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

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

                        List<BlockBuster> locations = new List<BlockBuster>();
                        repository.GetStores(locations);
                        DisplayStores(locations);
                        Console.WriteLine("Please enter the ID of your desired location?");
                        string id = Console.ReadLine();
                        BlockBuster choice = SelectStore(locations, Int32.Parse(id));
                        Console.WriteLine("Enter Customer's First Name");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter Customer's Last Name");
                        string lname = Console.ReadLine();
                        Customer c = new Customer(fname, lname);
                        repository.AddNewCustomer(c);
                        Order o = new Order();
                        repository.MakeOrder(c.CustomerId, choice.LocationId, o);
                        string response;
                        do
                        {
                            Console.WriteLine("This is our current selection of movies and video games");
                            repository.DisplayInventory(choice.LocationId);
                            Console.WriteLine("Please enter the title of your selection");
                            string selection = Console.ReadLine();
                            Product p = repository.GetProductByTitle(selection, choice);
                            p.ReduceInventory();
                            repository.EditInventory(choice, p);
                            repository.AddProductToOrder(o, p);
                            Console.WriteLine("Would you like to add another product to the order?");
                            Console.WriteLine("Please enter Yes or No");
                            response = Console.ReadLine();
                        } while (response == "Yes");
                        break;
                    case 2:
                        Console.WriteLine("Enter Customer's First Name");
                        string firstname = Console.ReadLine();
                        Console.WriteLine("Enter Customer's Last Name");
                        string lastname = Console.ReadLine();
                        var query = from customerS in context.Customers
                                    join order in context.Orders on customerS.CustomerId equals order.CustomerId
                                    join orderD in context.OrderDetails on order.OrderId equals orderD.OrderId
                                    join inv in context.Inventory on orderD.InventoryId equals inv.InventoryId
                                    join prod in context.Products on inv.ProductId equals prod.ProductId
                                    where customerS.FirstName == firstname && customerS.LastName == lastname
                                    select new { customerS.FirstName, customerS.LastName, order.Date, prod.Title, prod.Price };
                        foreach (var item in query)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 3:
                        List<BlockBuster> locationLookup = new List<BlockBuster>();
                        repository.GetStores(locationLookup);
                        DisplayStores(locationLookup);
                        Console.WriteLine("Please enter the ID of your desired location?");
                        string pick = Console.ReadLine();
                        var storeQuery = from store in context.Stores
                                         join order in context.Orders on store.LocationId equals order.LocationId
                                         join storeCust in context.Customers on order.CustomerId equals storeCust.CustomerId
                                         join orderD in context.OrderDetails on order.OrderId equals orderD.OrderId
                                         join inv in context.Inventory on orderD.InventoryId equals inv.InventoryId
                                         join prod in context.Products on inv.ProductId equals prod.ProductId
                                         where store.LocationId == Int32.Parse(pick)
                                         select new { store.City, store.State, storeCust.FirstName, storeCust.LastName, order.Date, prod.Title, prod.Price };
                        foreach (var item in storeQuery)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }
            } while (Int32.Parse(select) <= 3);
        }



        public static void DisplayStores(List<BlockBuster> print)
        {
            foreach (BlockBuster store in print)
            {
                Console.WriteLine($"ID: {store.LocationId} Location: {store.Location}");
            }
        }

        public static BlockBuster SelectStore(List<BlockBuster> stores, int id)
        {
            var q = stores.Select(b => b).Where(n => n.LocationId == id);
            return q.First();
        }


        public static void PrintMenu()
        {
            Console.WriteLine("\n\tMENU\n=======================================");
            Console.WriteLine("\n1. Make an order ");
            Console.WriteLine("\n2. Display customer order history");
            Console.WriteLine("\n3. Display store order history");
            Console.WriteLine("\n=======================================");
            Console.WriteLine("\n Enter your choice (from 1 to 3 ): ");
        }
    }
}