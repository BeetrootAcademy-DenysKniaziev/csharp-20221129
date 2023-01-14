using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> voteTopics = new Dictionary<string, List<string>>();
        bool IsOpen = true;
        while (IsOpen)
        {
            Console.Clear();
            Console.WriteLine(new string('*', 25));
            int k = 1;
            foreach (var topic in voteTopics)
            {
                Console.WriteLine(k + " Vote Topic - " + topic.Key);
                Console.WriteLine("\nOptions:");
                for (int i = 0; i < topic.Value.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {topic.Value[i]}");
                }
                k++;
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 25));

            Console.WriteLine("1. Create a vote topic");
            Console.WriteLine("2. Vote");
            Console.WriteLine("3. Delete a vote topic ");
            Console.WriteLine("4. Exit");

            var choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:

                    Console.Write("\nEnter vote topic: ");
                    string topic = Console.ReadLine();
                    Console.Write("How many Options would you like to add: ");
                    int amount = int.Parse(Console.ReadLine());
                    string[] options = new string[amount];
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.Write($"Enter {i + 1} Option: ");
                        options[i] = Console.ReadLine();
                    }
                    voteTopics.Add(topic, new List<string>(options));
                    break;

                case ConsoleKey.D2:

                    Console.WriteLine("\nEnter vote topic:");
                    topic = Console.ReadLine();

                    if (voteTopics.ContainsKey(topic))
                    {
                        Console.WriteLine("Options:");
                        for (int i = 0; i < voteTopics[topic].Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {voteTopics[topic][i]}");
                        }
                        Console.Write("Enter option number: ");
                        int optionNum = int.Parse(Console.ReadLine());
                        voteTopics[topic][optionNum - 1] += " (1 vote)";
                    }
                    else
                    {
                        Console.WriteLine("Invalid topic");
                    }
                    break;

                case ConsoleKey.D3:

                    if (voteTopics.Count == 0)
                    {
                        Console.WriteLine("\nYour voiting list is empty! Add some vote topics first!");
                        break;
                    }
                    Console.WriteLine("\nEnter vote topic:");
                    topic = Console.ReadLine();

                    if (voteTopics.ContainsKey(topic))
                    {
                        voteTopics.Remove(topic);
                    }
                    else
                    {
                        Console.WriteLine("Invalid topic");
                    }
                    break;

                case ConsoleKey.D4:

                    IsOpen = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid Input! Try Again!");
                    break;
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
