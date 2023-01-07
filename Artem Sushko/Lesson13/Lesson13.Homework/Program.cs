using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Lesson13.Homework
{
    class Product
    {
        public string Name;
        public float Price;
        public int Amount;

        public Product(string name, float price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public void GetProductInfo()
        {
            Console.WriteLine($"Product's name: {Name}" +
                              $"\nProduct's Price: {Price} gruvni" +
                              $"\nAmount Of Product: {Amount} pieces");
        }

        public void AddProduct(int addItems)
        {
            Amount += addItems;
        }

        public void SellProduct(int sellItems)
        {
            if (Amount >= sellItems)
            {
                Amount -= sellItems;
            }
            else
            {
                Console.WriteLine($"We dont have that amout of {Name}");
            }
        }
    }

    class Adresse
    {
        public string City;
        public string Street;
        public int House;
        public int Flat;
    }

    class Customer
    {
        public string FirstName;
        public string LastName;
        public Adresse Adresse;
        public Customer(string firstName, string lastName, string city, string street, int house, int flat)
        {
            FirstName = firstName;
            LastName = lastName;
            Adresse = new Adresse
            {
                City = city,
                Street = street,
                House = house,
                Flat = flat
            };
        }

        public void GetCustomerInfo()
        {

            Console.WriteLine($"Customer's name: {FirstName} {LastName}" +
                              $"\n\nCustomer's Adresse" +
                              $"\nCity: {Adresse.City}" +
                              $"\nStreet: {Adresse.Street}" +
                              $"\nHouse: {Adresse.House}" +
                              $"\nFlat: {Adresse.Flat}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Clear();

            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();
            bool IsOpen = true;
            while (IsOpen)
            {
                Console.WriteLine("\tALL PRODUCTS");
                Console.WriteLine(new string('*', 30));
                for (int i = 0; i < products.Count; i++)
                {
                    Console.Write($"\n {i + 1} - ");
                    products[i].GetProductInfo();
                }
                Console.WriteLine(new string('*', 30));

                Console.WriteLine("\n\tALL CUSTOMERS");

                Console.WriteLine(new string('*', 30));
                for (int i = 0; i < customers.Count; i++)
                {
                    Console.Write($"\n {i + 1} - ");
                    customers[i].GetCustomerInfo();
                }
                Console.WriteLine(new string('*', 30));

                Console.WriteLine("\n\tWhat do you want?" +
                                                   "\n1 - Add a new customer" +
                                                   "\n2 - Add a new poduct" +
                                                   "\n3 - Add quantity to existent product" +
                                                   "\n4 - Buy Products" +
                                                   "\n5 - Remove Customer" +
                                                   "\n6 - Remove Product" +
                                                   "\n0 - Exit");

                var select = Console.ReadKey();
                switch (select.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("\nEnter the First Name of NEW Customer: ");
                        string newCustomerFirst = Console.ReadLine();
                        Console.Write("Enter the Last Name of NEW Customer: ");
                        string newCustomerLast = Console.ReadLine();
                        Console.Write("Enter the Name of Your City: ");
                        string cityName = Console.ReadLine();
                        Console.Write("Enter the Name of Your Street: ");
                        string streetName = Console.ReadLine();
                        Console.Write("Enter the Number of Your House: ");
                        int housNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Number of Your Flat: ");
                        int flatNumber = Convert.ToInt32(Console.ReadLine());
                        customers.Add(new Customer(newCustomerFirst, newCustomerLast,
                                                   cityName, streetName, housNumber, flatNumber));
                        break;

                    case ConsoleKey.D2:
                        Console.Write("\nEnter the Name of NEW product: ");
                        string newProductName = Console.ReadLine();
                        Console.Write("Enter the Price of NEW product:(!use \".\" as a seperator!) ");
                        float newProductPrice = Convert.ToSingle(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Enter the Amount of NEW product: ");
                        int newProductAmount = Convert.ToInt32(Console.ReadLine());
                        products.Add(new Product(newProductName, newProductPrice, newProductAmount));
                        break;

                    case ConsoleKey.D3:
                        Console.Write("\nEnter the number of poduct: ");
                        int productNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("How many items do you want to add?: ");
                        int AddItems = Convert.ToInt32(Console.ReadLine());
                        products[productNumber - 1].AddProduct(AddItems);
                        break;

                    case ConsoleKey.D4:
                        Console.Write("\nWhat would you like to buy(Enter the Number of Product)?:");
                        int wishProduct = Convert.ToInt32(Console.ReadLine());
                        Console.Write("How many items do you want to buy?: ");
                        int SellItems = Convert.ToInt32(Console.ReadLine());
                        products[wishProduct].SellProduct(SellItems);
                        break;

                    case ConsoleKey.D5:
                        Console.Write("Enter the Number of Customer to Remove: ");
                        int customerRemove = Convert.ToInt32(Console.ReadLine()) - 1;
                        customers.RemoveAt(customerRemove);
                        break;

                    case ConsoleKey.D6:
                        Console.Write("Enter the Number of Product to Remove: ");
                        int productRemove = Convert.ToInt32(Console.ReadLine()) - 1;
                        products.RemoveAt(productRemove);
                        break;

                    case ConsoleKey.D0:
                        IsOpen = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Input!");
                        break;
                }
                Console.WriteLine("\n\tPress any button to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}