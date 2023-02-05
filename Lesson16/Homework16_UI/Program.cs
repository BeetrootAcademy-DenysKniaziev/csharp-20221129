//using Homework16;
using VotingLib;
using static System.Console;

namespace Homework16_UI;

internal class Program
{
    static void Main(string[] args)
    {
        //VoteMachine.LoadPersones();
        VoteMachine.LoadVotingsList();

        WriteLine("This is User Interface\nAs new user, please fulfill registration information");
        var person = VoteMachine.AddPerson();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteLine("\n1: Show votings list");
            WriteLine("0: Exit");

            var k = ReadKey(true);
            WriteLine("\n");
            if (k.Key == ConsoleKey.D1)
            {
                WriteLine("Choose voting number for detaled results or '0' for return to previus menu");
                foreach (var v in VoteMachine.Votings)
                {
                    Console.WriteLine((v.Id) + ". " + v.VoteTopic);
                }
                while (true)
                {
                    var input = ReadLine();
                    if (int.TryParse(input, out var value))
                    {
                        if (value == 0) break;
                        else
                        {
                            if (value <= VoteMachine.Votings.Count && value >= 1)
                            {
                                VoteMachine.Votings[value - 1].ShowVoting(person);
                                VoteMachine.Votings[value - 1].ShowDetaledResults();
                                break;
                            }
                            else WriteLine("Wrong input, repeat, please");
                        }
                    }
                    else WriteLine("Wrong input, repeat, please");
                }
            }
            if (k.Key == ConsoleKey.D0) Environment.Exit(1);
        }


    }
}
