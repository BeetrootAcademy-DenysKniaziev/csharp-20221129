using System.ComponentModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Lesson13.HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Buyer> buyers = new List<Buyer>();
            List<Receipt> receipts = new List<Receipt>();
            while (true)
            {
                Console.WriteLine("\n\nInternet shop \"Things\" ");
                Console.WriteLine("Select Action:");
                Console.WriteLine("1 - Register new product");
                Console.WriteLine("2 - Register buyer");
                Console.WriteLine("3 - Add quantity to existent product");
                Console.WriteLine("4 - Sell product");
                Console.WriteLine("5 - Show product");
                Console.WriteLine("6 - Show buyer");
                Console.WriteLine("7 - Try you`re luck");
                Console.WriteLine("0 - Exit");

                var action = Console.ReadKey();
                Console.WriteLine();

                switch (action.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("New product:");
                        Product product = new Product();
                        products.Add(product.AddProduct());
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("New buyer:");
                        Buyer buyer = new Buyer();
                        buyers.Add(buyer.AddBuyer());
                        Receipt receipt = new Receipt();
                        receipt.Buyer = buyer;
                        receipts.Add(receipt);
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Choose product:");
                        Product thing = new Product();
                        do
                        {
                            thing = products.Find(x => x.Name.Contains(Console.ReadLine()!));
                        } while (thing == null);
                        Console.WriteLine("\nChoose new quantity:");
                        int temp = int.Parse(Console.ReadLine()!);
                        thing.Quantity = temp;
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Choose buyer by last name:");
                        Buyer buyer1 = new Buyer();
                        do
                        {
                            buyer1 = buyers.Find(x => x.LastName.Contains(Console.ReadLine()!));
                        } while (buyer1 == null);
                        foreach (var customer in receipts)
                        {
                            if (customer.Buyer.LastName.Equals(buyer1.LastName))
                            {
                                Console.WriteLine("Choose product:");
                                Product product1 = new Product();
                                do
                                {
                                    product1 = products.Find(x => x.Name.Contains(Console.ReadLine()!));
                                } while (product1 == null);
                                customer.AddProduct(product1);
                                customer.Info();
                            }
                        }
                        break;
                    case ConsoleKey.D5:
                        foreach (var prod in products)
                        {
                            prod.Info();
                        }
                        break;
                    case ConsoleKey.D6:
                        foreach (var customer in buyers)
                        {
                            customer.Info();
                        }
                        break;
                    case ConsoleKey.D7:
                        Buyer buyer2= new Buyer();
                        buyer2.Luck();
                        //краще було зробити через статичний метод в данному випадку але я просто хотів показати реалізацію абстракції
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("Exit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect Input!");
                        break;
                }
            }

        }
    }
}