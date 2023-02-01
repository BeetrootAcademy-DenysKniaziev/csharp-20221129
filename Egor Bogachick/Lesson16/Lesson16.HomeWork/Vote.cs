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
        public static List<string> Thems { get; set; }
        public static Dictionary<string, string> Voters { get; set; }

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
            for (int i = 0; i < Voters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Voters[i]}");
            }
        }


    }
}
