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
        private static Random rand = new Random();
        public string Title { get; set; }

        public Dictionary<string, int> Options { get; set; }

        public Pull(string title, Dictionary<string, int> options)
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
                Console.WriteLine($"{indexOpt}. {item.Key}");
                indexOpt++;
            }
            Console.Write("Vote for one: ");
            int number = int.Parse(Console.ReadLine());

            int index = 1;
            foreach (var key in pull.Options.Keys)
            {
                if(index == number) pull.Options[key]++;
                index++;
            }


            ShowResults(pull);
        }
        private static void ShowResults(Pull pull)
        {
            var sortedDict = from entry in pull.Options orderby entry.Value descending select entry;

            Console.WriteLine($"\n----- VOTING RESULTS -----");
            int indexOpt = 1;
            foreach (var item in sortedDict)
            {
                Console.WriteLine($"{indexOpt}. {item.Key} - {item.Value} votes");
                indexOpt++;
            }
            Console.WriteLine();
        }

        public static List<Pull> CreatePull(List<Pull> pulls)
        {
            Console.WriteLine("\n----- CREATING NEW PULL -----");
            Console.Write("Enter pull title: ");
            string title = Console.ReadLine();

            Pull pull = new Pull(title, new Dictionary<string, int>());
            Console.WriteLine("Enter pull options: ");
            for (int i = 1; i < 10; i++)
            {
                Console.Write($"{i}. ");
                string option = Console.ReadLine();
                pull.Options.Add(option, rand.Next(10, 40));

                if (pull.Options.Count > 2)
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
