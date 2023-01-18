using System.Collections;
using System.Text.RegularExpressions;

namespace Voting
{
    class Voting
    {
        public static void menu()
        {
            Console.WriteLine("NJ Voter System:");
            Console.WriteLine("(1) Sign up a new voter");
            Console.WriteLine("(2) View this year's election ballot");
            Console.WriteLine("(3) Vote");
            Console.WriteLine("(0) Exit");
        }

        static void Main(string[] args)
        {
            ArrayList voters = new ArrayList();
            Ballot november2023 = new Ballot(10, 10, 2023);

            november2023.addElection("Senator");
            november2023.addCandidate("Senator", "Jeff", "Starr", "Republican");
            november2023.addCandidate("Senator", "Alexandr", "Fred", "Democrat");
            november2023.addCandidate("Senator", "Ed", "Snow", "Democrat");
            november2023.addCandidate("Senator", "Ramille", "Moss", "Independent");
            november2023.addCandidate("Senator", "Dana", "Lime", "Reformator");

            int choice = 0;

            do
            {
                menu();
                Console.Write("What will yu like to do? ");
                String t = Console.ReadLine();
                t = Regex.Replace(t, "[^0-9]", "");
                choice = Convert.ToInt32(t);

                switch (choice)
                {
                    case 1:
                        bool found = false;
                        Voter temp = new Voter();
                        if (temp.getCriminalRecord())
                            Console.WriteLine("You may not vote because you have an active criminal record.");
                        else if (!temp.ofAge())
                            Console.WriteLine("You may not vote because you are not of age.");
                        else
                        {
                            foreach (Voter v in voters)
                            {
                                if (v.compare(temp))
                                {
                                    Console.WriteLine("This person is already registered.");
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                voters.Add(temp);
                                Console.WriteLine("You are registered to vote.");
                            }
                        }
                        break;
                    case 2:
                        november2023.printBallot();
                        break;
                    case 3:

                        november2023.vote();
                        break;
                    case 0:
                        Console.WriteLine("Exit program");
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
                Console.WriteLine();
            } while (choice != 0);
        }
    }
}


