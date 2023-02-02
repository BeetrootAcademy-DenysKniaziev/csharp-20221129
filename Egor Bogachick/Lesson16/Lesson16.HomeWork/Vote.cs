using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson16.HomeWork
{
    public class Vote
    {
        public static string Name { get; set; }
        public static List<string> Thems { get; set; } = new List<string>();
        public static Dictionary<string, string> Voters { get; set; } = new Dictionary<string, string>();

        public static void Create()
        {
            int reg = 0;
            Console.WriteLine("Enter voting theme name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                Name = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(Name, @"[A-Za-z]"));

            int n = 0;
            Console.WriteLine("Enter number of thems:");
            n = int.Parse(Console.ReadLine()!);
            string temp;
            for (int i = 0; i < n; i++ )
            {
                reg = 0;
                Console.WriteLine($"Enter {i + 1} voting theme:");
                do
                {
                    if (reg > 0)
                    {
                        Console.WriteLine("\nIncorrect input, try again:");
                    }
                    temp = Console.ReadLine()!;
                    reg++;
                } while (!Regex.IsMatch(temp, @"[A-Za-z]"));
                Thems.Add(temp);
            }
        } 

        public static void VoteFor()
        {
            Console.WriteLine("\nWrite you're last name: ");
            int reg = 0;
            string lastname = "" ;
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                lastname = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(lastname, @"[A-Za-z]"));

            Console.WriteLine("\nSelect voting option (number): ");
            Console.WriteLine($"Today's theme: {Name}");
            ShowThems();
            int temp = int.Parse(Console.ReadLine()!);
            if (temp >= Thems.Count || temp <= 0)
            {
                Console.WriteLine("Unexpected erorr");
            }
            else
            {
                Voters.Add(lastname, Thems[temp]);
            }
        }

        public static void SelectVoters()
        {
            Console.WriteLine("\nSelect theme:");
            ShowThems();
            int temp = int.Parse(Console.ReadLine()!);
            if (temp >= Thems.Count)
            {
                Console.WriteLine("Unexpected erorr");
            }
            else
            {
                int i = 1;
                foreach (var person in Voters)
                {
                    if (person.Value == Thems[temp])
                    {
                        Console.WriteLine($"{i}. {person.Key} {person.Value}");
                        i++;
                    }
                }
            }
        }

       public static void ShowThems()
        {
            for (int i = 0; i < Thems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Thems[i]}");
            }
        }

        public static void ShowVoters()
        {
            int i = 1;
            foreach (var person in Voters)
            {
                Console.WriteLine($"{i}. {person.Key} {person.Value}");
                i++;
            }
        }
    }
}
