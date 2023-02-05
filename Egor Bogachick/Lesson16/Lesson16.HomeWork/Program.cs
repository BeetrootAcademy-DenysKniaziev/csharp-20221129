namespace Lesson16.HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nVote Application");
                Console.WriteLine("Select Action:");
                Console.WriteLine("1 - Create voting theme");
                Console.WriteLine("2 - Vote");
                Console.WriteLine("3 - All voters");
                Console.WriteLine("4 - Selected voters");
                Console.WriteLine("0 - Exit");

                var action = Console.ReadKey();
                Console.WriteLine();

                switch (action.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\nCreate theme:");
                        Vote.Create();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("\nVote:");
                        Vote.VoteFor();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("\nAll voters:");
                        Vote.ShowVoters();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("\nSelected voters:");
                        Vote.SelectVoters();
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("\nExit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nIncorrect Input!");
                        break;
                }
            }
        }
    }
}