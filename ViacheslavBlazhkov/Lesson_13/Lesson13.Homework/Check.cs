using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.Homework
{
    internal class Check : IHasInfo
    {
        public int CheckID { get; set; }
        public Product[] ProductList { get; set; }
        public User Seller { get; set; }
        public User Buyer { get; set; }
        private double TotalSum { get; set; } = 0;

        public Check(Product[] productList, User seller, User buyer)
        {
            CheckID = new Random().Next(0, 999999);
            ProductList = productList;
            Seller = seller;
            Buyer = buyer;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"----- CHECK №{CheckID} -----");
            foreach (var product in ProductList)
            {
                Console.WriteLine($"   {product.Name} | {product.Price}$");
                TotalSum += product.Price;
            }
            Console.WriteLine($"From {Seller.FullName} To {Buyer.FullName}");
            Console.WriteLine($"\tTotal sum: {TotalSum}$\n");
        }
    }
}
