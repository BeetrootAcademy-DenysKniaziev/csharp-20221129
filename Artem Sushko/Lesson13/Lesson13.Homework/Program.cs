using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Lesson13.Homework
{
    abstract class Succses
    {
        public abstract void Succsesful();
    }
    interface IShowing
    {
        void ShowInfo();
    }

    class Product : Succses, IShowing
    {
        private string _name;
        private float _price;
        private int _amount;

        public Product(string name, float price, int amount)
        {
            _name = name;
            _price = price;
            _amount = amount;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Product's name: {_name}" +
                              $"\nProduct's Price: {_price} gruvni" +
                              $"\nAmount Of Product: {_amount} pieces");
        }

        public void AddProduct(int addItems)
        {
            _amount += addItems;
        }

        public void SellProduct(int sellItems)
        {
            if (_amount >= sellItems)
            {
                _amount -= sellItems;
            }
            else
            {
                Console.WriteLine($"We dont have that amout of {_name}");
            }
        }

        public override void Succsesful()
        {
            Console.WriteLine("\n\tYour opperation with Product was Succsesful!");
        }
    }

    class Adresse
    {
        public string City;
        public string Street;
        public int House;
        public int Flat;
    }

    class Customer : Succses, IShowing
    {
        private string _firstName;
        private string _lastName;
        private Adresse _adresse;
        public Customer(string firstName, string lastName, string city, string street, int house, int flat)
        {
            _firstName = firstName;
            _lastName = lastName;
            _adresse = new Adresse
            {
                City = city,
                Street = street,
                House = house,
                Flat = flat
            };
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Customer's name: {_firstName} {_lastName}" +
                              $"\n\nCustomer's Adresse" +
                              $"\nCity: {_adresse.City}" +
                              $"\nStreet: {_adresse.Street}" +
                              $"\nHouse: {_adresse.House}" +
                              $"\nFlat: {_adresse.Flat}");
        }

        public override void Succsesful()
        {
            Console.WriteLine("Your opperation with Customer was Succsesful!");
        }
    }

    internal class Program
    {
        private 
        static void Main(string[] args)
        {
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
                    products[i].ShowInfo();
                }
                Console.WriteLine(new string('*', 30));

                Console.WriteLine("\n\tALL CUSTOMERS");

                Console.WriteLine(new string('*', 30));
                for (int i = 0; i < customers.Count; i++)
                {
                    Console.Write($"\n {i + 1} - ");
                    customers[i].ShowInfo();
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
                string userInput;
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
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int housNumber))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        Console.Write("Enter the Number of Your Flat: ");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int flatNumber))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        customers.Add(new Customer(newCustomerFirst, newCustomerLast,
                                                   cityName, streetName, housNumber, flatNumber));
                        customers[0].Succsesful();
                        break;

                    case ConsoleKey.D2:
                        
                        Console.Write("\nEnter the Name of NEW product: ");
                        string newProductName = Console.ReadLine();
                        Console.Write("Enter the Price of NEW product:(!use \".\" as a seperator!) ");
                        userInput= Console.ReadLine();
                        if (float.TryParse(userInput, out float newProductPrice))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        Console.Write("Enter the Amount of NEW product: ");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int newProductAmount))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        products.Add(new Product(newProductName, newProductPrice, newProductAmount));
                        products[0].Succsesful();
                        break;

                    case ConsoleKey.D3:
                        Console.Write("\nEnter the number of poduct: ");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int productNumber))
                        {
                            if (productNumber>products.Count)
                            {
                                Console.WriteLine("We don't have Product by this number! Try Again!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        Console.Write("How many items do you want to add?: ");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int AddItems))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        products[productNumber - 1].AddProduct(AddItems);
                        products[0].Succsesful();

                        break;

                    case ConsoleKey.D4:
                        Console.Write("\nWhat would you like to buy(Enter the Number of Product)?:");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int wishProduct))
                        {
                            if (wishProduct > products.Count)
                            {
                                Console.WriteLine("We don't have Product by this number! Try Again!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        Console.Write("How many items do you want to buy?: ");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int SellItems))
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        products[wishProduct].SellProduct(SellItems);
                        products[0].Succsesful();

                        break;

                    case ConsoleKey.D5:
                        Console.Write("\nEnter the Number of Customer to Remove: ");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int customerRemove))
                        {
                            customerRemove -= 1;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        customers.RemoveAt(customerRemove);
                        products[0].Succsesful();

                        break;

                    case ConsoleKey.D6:
                        Console.Write("\nEnter the Number of Product to Remove: ");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int productRemove))
                        {
                            productRemove -= 1;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input! Try again!");
                            break;
                        }
                        products.RemoveAt(productRemove);
                        products[0].Succsesful();

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