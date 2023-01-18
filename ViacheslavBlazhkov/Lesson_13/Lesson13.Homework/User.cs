using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.Homework
{
    // class User is not divided into seller and buyer because each user can sell and buy
    internal class User : IHasInfo
    {
        public int UserID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string PhoneNumber { get; set; }

        public User(string fname, string lname, string numb)
        {
            UserID = new Random().Next(0, 999999);
            FirstName = fname;
            LastName = lname;
            PhoneNumber = numb;
        }

        public static User RegisterUser()
        {
            Console.WriteLine("----- REGISTRATION NEW USER -----");
            Console.Write("Enter first name: ");
            string fname = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lname = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string number = Console.ReadLine();
            Console.WriteLine();

            return new User(fname, lname, number);
        }

        public void BuyProducts(User seller, params Product[] products)
        {
            if (!CheckProductsAvailable(products)) return;

            foreach (var product in products)
            {
                product.Count--;
            }
            Console.WriteLine("Thanks for purchase! Your check:\n");
            GetCheck(new Check(products, seller, this));
        }

        public bool CheckProductsAvailable(params Product[] products)
        {
            Console.WriteLine($"----- AVAILABLE THESE PRODUCTS -----");
            if (products.Length == 0)
            {
                Console.WriteLine("There isn't any product");
                return false;
            }
            else if (products.Length > 0)
            {
                int countNotAvailable = 0;
                foreach (var product in products)
                {
                    if (product.Count > 0) Console.WriteLine($"Product: {product.Name} | Count: {product.Count}");
                    else
                    {
                        Console.WriteLine($"Product {product.Name} isn't available");
                        countNotAvailable++;
                    }
                }
                if (countNotAvailable > 0)
                {
                    return false;
                }
            }
            Console.WriteLine();
            return true;
        }

        public void GetCheck(Check check)
        {
            check.ShowInfo();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"----- USER №{UserID} -----");
            Console.WriteLine($"Full name: {FullName}");
            Console.WriteLine($"Phone number: { PhoneNumber}\n");
        }
    }
}
