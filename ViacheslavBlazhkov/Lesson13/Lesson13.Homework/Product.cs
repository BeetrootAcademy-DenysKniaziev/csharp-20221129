using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.Homework
{
    internal class Product : UnregisteredProduct, IHasInfo
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public Product(string name, double price, int count) : base(name)
        {
            ProductID = new Random().Next(0, 999999);
            Price = price;
            Count = count;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"----- PRODUCT №{ProductID} -----");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}$");
            Console.WriteLine($"Count: {Count}\n");
        }
        public static void ShowInfo(params Product[] products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"----- PRODUCT №{product.ProductID} -----");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}$");
                Console.WriteLine($"Count: {product.Count}\n");
            }
        }
    }
}
