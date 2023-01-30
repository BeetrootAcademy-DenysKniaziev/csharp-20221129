using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16.Homework
{
    class Pull
    {
        public string Title { get; set; }

        public List<(string, int)> Options { get; set; }

        public Pull(string title, List<(string, int)> options)
        {
            Title = title;
            Options = options;
        }

        public static void ShowPulls(List<Pull> pulls)
        {
            Console.WriteLine("\n----- AVAILABLE PULLS -----");
            int index = 1;
            foreach (var pull in pulls)
            {
                Console.WriteLine($"{index}. {pull.Title}");
                index++;
            }
            Console.Write("Choose one: ");
            int number = int.Parse(Console.ReadLine());
            ShowOptions(pulls[number - 1]);
        }

        private static void ShowOptions(Pull pull)
        {
            Console.WriteLine($"\n----- {pull.Title} OPTIONS -----");
            int indexOpt = 1;
            foreach (var item in pull.Options)
            {
                Console.WriteLine($"{indexOpt}. {item.Item1}");
                indexOpt++;
            }
            Console.Write("Vote for one: ");
            int number = int.Parse(Console.ReadLine());
            
            (string, int) newValue = pull.Options[number - 1];
            newValue.Item2++;
            pull.Options[number - 1] = newValue;
            //pull.Options[number - 1].Item2++; Якщо ось так скоротити запис, то показує помилку
            ShowResults(pull);
        }
        private static void ShowResults(Pull pull)
        {
            pull.Options.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            Console.WriteLine($"\n----- VOTING RESULTS -----");
            int indexOpt = 1;
            foreach (var item in pull.Options)
            {
                Console.WriteLine($"{indexOpt}. {item.Item1} - {item.Item2} votes");
                indexOpt++;
            }
            Console.WriteLine();
        }

        public static List<Pull> CreatePull(List<Pull> pulls)
        {
            Console.WriteLine("\n----- CREATING NEW PULL -----");
            Console.Write("Enter pull title: ");
            string title = Console.ReadLine();

            Pull pull = new Pull(title, new List<(string, int)>());
            Console.WriteLine("Enter pull options: ");
            for (int i = 1; i < 10 ; i++)
            {
                Console.Write($"{i}. "); 
                string option = Console.ReadLine();
                pull.Options.Add((option, new Random().Next(10, 40)));

                if(pull.Options.Count > 2)
                {
                    Console.Write("ANY KEY - add more options | 1 - Stop adding | Input: ");
                    var input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            i = 10;
                            Console.WriteLine();
                            break;
                        default:
                            Console.WriteLine();
                            break;
                    }
                }
            }
            pulls.Add(pull);
            Console.WriteLine();
            return pulls;
        }
    }
}
