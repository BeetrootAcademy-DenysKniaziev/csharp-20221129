using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.HomeWork
{
    public class Receipt : IShowable
    {
        public Buyer Buyer { get; set; }
        List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void Info()
        {
            Console.WriteLine("\nReceipt ");
            Buyer.Info();
            foreach (var product in Products)
            {
                Console.Write( "\n[" );
                product.Info();
                Console.Write("]");
            }

        }
    }
}
