using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Lesson13.HomeWork
{
    public class Buyer : Person
    {
        public Buyer() { }

        public Buyer(string firstName, string lastName, int age, string adress) : base(firstName, lastName, age, adress)
        {
        }

        public Buyer AddBuyer()
        {
            int reg = 0;
            Console.WriteLine("Enter first name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                FirstName = (Console.ReadLine()!);
                reg++;
            } while (!Regex.IsMatch(FirstName, @"[A-Za-z]"));
            
            reg = 0;
            Console.WriteLine("Enter last name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                LastName = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(LastName, @"[A-Za-z]"));
            
            Console.WriteLine("Enter age:");
            Age = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter adress:");
            Adress = Console.ReadLine()!;

            Console.WriteLine("\n New buyer registered ");

            return new Buyer(FirstName, LastName, Age, Adress);
        }


        public override void Info()
        {
            Console.WriteLine("\nType: Buyer \nFull name: " + FullName + "\nAge: " + Age + "\nAdress: " + Adress);
        }

        public override void Luck()
        {
            Console.WriteLine("Try your luck. \nChoose number 1-3: ");
            int luck = int.Parse(Console.ReadLine()!);
            if (luck == 1)
            {
                Console.WriteLine("Congratulations you get 10 % discount in our store");
            }else if (luck == 2)
            {
                Console.WriteLine("Congratulations you get 10 % discount in our store. You`re lucky person");
            }else if (luck == 3)
            {
                Console.WriteLine("Sorry you didn't win anything.");
            }
            else
            {
                Console.WriteLine("Very funny. Plus 10% to the prices of any product");
            }
        }
    }
}
