using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson13.HomeWork
{
    public class Product : IShowable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product() { }
        public Product(string name, int price, int quqntity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quqntity;
        }

        public Product AddProduct()
        {
            int reg = 0;
            Console.WriteLine("Enter product name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                Name = (Console.ReadLine()!);
                reg++;
            } while (!Regex.IsMatch(Name, @"[A-Za-z]"));

            Console.WriteLine("Enter price:");
            Price = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter quantity:");
            Quantity = int.Parse(Console.ReadLine()!);
            return new Product(Name, Price, Quantity);
        }

        public void Info()
        {
            Console.Write("Name: " + Name + "  Price: " + Price + "  Quantity: " + Quantity);
        }
    }
}
