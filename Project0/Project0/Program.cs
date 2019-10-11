using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0
{
    public class Program
    {
        static void Main(string[] args)
        {
            BlockBuster arlington = new BlockBuster("Arlington");
            BlockBuster dallas = new BlockBuster("Dallas");
            BlockBuster houston = new BlockBuster("Houston");

            Product m = new Product("batman", "90 minutes", 15.0, "R", 5);
            arlington.AddInventory(m);


            string select;

            do
            {
                PrintMenu();

               
                select = Console.ReadLine();

                switch (Int32.Parse(select))
                {
                    case 1:
                        Console.WriteLine("Enter Customer's First Name");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter Customer's Last Name");
                        string lname = Console.ReadLine();
                        Customer customer = new Customer(fname, lname);
                        Console.WriteLine("Thank you for visiting our Arlington location");
                        Console.WriteLine("This is our current selection of movies and video games");
                        DisplayProducts(arlington);
                        arlington.AddCustomer(customer);
                        Order order = new Order(customer, arlington);
                        Console.WriteLine("Enter the title of your selection");
                        string selection = Console.ReadLine();
                        var one = from product in arlington.Inventory
                                      where product.Title.Equals(selection)
                                      select product;
                        Product add = one.Single();
                        order.AddItem(add);
                        customer.LogOrder(order);
                        arlington.LogOrder(order);
                        break;
                    case 2:
                        List<string> search = AskCustomerName();
                        foreach (Customer c in arlington.Customers)
                        {
                            if (c.FirstName.Equals(search[0]) && c.LastName.Equals(search[1]))
                            {
                                DisplayOrderHistory(c);
                            }
                        }
                        break;
                        
                }
            } while (Int32.Parse(select) <= 6);
        }

        public static void DisplayOrderHistory (Customer c)
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

        public void DisplayOrderHistory (BlockBuster b, string location)
        {

        }

        public static void DisplayProducts (BlockBuster b)
        {
            foreach (Product p in b.Inventory)
            {
                Console.WriteLine($"{p.Title} {p.Details} {p.Price} {p.Rating}" );
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