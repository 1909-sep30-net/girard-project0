using BusinessLibrary;
using System;
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
                        var one = order.ProductList.Where(x => arlington.Inventory.Any(p => p.Title == selection));
                        break;
                        
                }
            } while (Int32.Parse(select) != 6);
        }

        public void DisplayOrderHistory (Customer c)
        {

        }

        public void DisplayOrderHistory (BlockBuster b, string location)
        {

        }

        public static void DisplayProducts (BlockBuster b)
        {
            foreach (Product p in b.Inventory)
            {
                Console.WriteLine(p);
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("\n\tMENU\n=======================================");
            Console.WriteLine("\nMake an order ");
            Console.WriteLine("\n=======================================");
            Console.WriteLine("\n Enter your choice (from 1 to 9 ): ");
        }
    }
}