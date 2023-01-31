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
                        Console.WriteLine("Phone Book:");
                        
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Search:");
                        
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Add:");
                        
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Update:");
                        
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Remove:");
                       
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("Exit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect Input!");
                        break;
                }
            }
        }
    }
}