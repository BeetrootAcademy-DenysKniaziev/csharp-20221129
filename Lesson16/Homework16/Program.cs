//Create a program to ‘vote’ for anything.
//Via the console interface users will create a ‘vote topic’ with options.
//Voters will vote via console interface as well.
//Users can see voting results via console interface.
using System.ComponentModel;
using System.Text;
using static System.Console;
using VotingLib;
namespace Homework16;

internal class Program
{
    static void Main(string[] args)
    {
        VoteMachine.LoadPersones();
        VoteMachine.LoadVotingsList();

        WriteLine("This is Administrator application");
        while (true)
        {
            Console.ForegroundColor= ConsoleColor.Green;    
            WriteLine("\n1: Create new voting");
            WriteLine("2: Show all votings with results");
            WriteLine("3: Show users list");
            WriteLine("4: Show votings list");
            WriteLine("0: Exit");

            var k = ReadKey(true);
            WriteLine("\n");
            if (k.Key == ConsoleKey.D1) VoteMachine.AddVoting("");
            if (k.Key == ConsoleKey.D2)
                foreach(var v in VoteMachine.Votings)
                {
                    Console.WriteLine();//$"{v.Id} {v.FileName} {v.}" );
                    v.ShowResults();
                }
            if (k.Key == ConsoleKey.D3)
                foreach(var p in VoteMachine.Persons)
                {
                    Console.WriteLine($"{p.Id} {p.Name} {p.Age} {p.Gender}\n");

                }
            if (k.Key == ConsoleKey.D4)
            {
                WriteLine("Choose voting number for detaled results or '0' for return to previus menu");
                foreach (var v in VoteMachine.Votings)
                {
                    Console.WriteLine(v.Id + ". " + v.VoteTopic);
                }



                while (true)
                {
                    var input = ReadLine();
                    if (int.TryParse(input, out var value))
                    {
                        if (value == 0) break;
                        else
                        {
                            if (value  <= VoteMachine.Votings.Count && value >= 1)
                            {
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
        //VoteMachine.Votings[0].ShowVoting(VoteMachine.Persons[0]);

    }
}