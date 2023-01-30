using System.Security.AccessControl;

namespace Lesson16.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pull autoPull = new Pull("Cars", new List<(string, int)>
            {
                { ("Audi", 26)},
                { ("Porsche", 28)},
                { ("Morgan", 15)},
                { ("Jeep", 17)}
            });
            Pull laptopsPull = new Pull("Laptops", new List<(string, int)>
            {
                { ("MacBook", 27)},
                { ("ASUS", 28)},
                { ("Lenovo", 29)},
                { ("HP", 25)}
            });

            List<Pull> pulls = new List<Pull> {autoPull, laptopsPull };

            bool whileStatus = true;

            while (whileStatus)
            {
                Console.WriteLine("----- CHOOSE ACTION -----");
                Console.WriteLine("1 - Show pulls");
                Console.WriteLine("2 - Create new pull");
                Console.WriteLine("0 - Exit");
                Console.Write("Choose one: ");
                var input = Console.ReadKey();
                Console.WriteLine("");

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Pull.ShowPulls(pulls);
                        break;
                    case ConsoleKey.D2: // ------------
                        pulls = Pull.CreatePull(pulls);
                        break;
                    case ConsoleKey.D0:
                        whileStatus = false;
                        break;
                    default:
                        Console.WriteLine(" - Incorrect input!\n");
                        break;
                }

            }
        }
    }
}