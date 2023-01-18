using System.Collections;
using System.Text.RegularExpressions;

namespace Voting
{
    class Ballot
    {
        private ArrayList elections;
        DateTime electionDate;
        String format = "dd/MM/yyyy";

        public Ballot(int day, int month, int year)
        {
            electionDate = new DateTime(year, month, day);
            elections = new ArrayList();
        }

        public void printBallot()
        {
            Console.WriteLine("Ballot for " + electionDate.ToString(format) + " Election:");
            foreach (Election e in elections)
                e.printBallot();
            Console.WriteLine();
        }

        public void printResults()
        {
            Console.WriteLine("Results for " + electionDate.ToString(format) + " Election:");
            foreach (Election e in elections)
                e.printResults();
            Console.WriteLine();
        }

        public void vote()
        {
            foreach (Election e in elections)
            {
                bool valid;

                do
                {
                    valid = false;
                    e.printBallot();
                    Console.Write("Using the number with the candidate, who do you vote for? ");
                    String t = Console.ReadLine().Trim();
                    t = Regex.Replace(t, "[^0-9]", "");
                    if (String.IsNullOrEmpty(t))
                        Console.WriteLine("Invalid entry");
                    else
                    {
                        int i = Convert.ToInt32(t);
                        if (i < 1 || i > 5)
                            Console.WriteLine("Incompatiable entry");
                        else
                        {
                            e.vote(i);
                            valid = true;
                        }
                    }
                } while (!valid);
                Console.WriteLine();
            }
        }

        public void addElection(String position)
        {
            if (!search(position))
                elections.Add(new Election(position));
            else
                Console.WriteLine("Election already added to ballot.");
        }

        public void addCandidate(String position, String fN, String lN, string pP)
        {
            if (search(position))
            {
                foreach (Election e in elections)
                {
                    if ((e.getPosition()).Equals(position, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!e.search(fN, lN))
                            e.addCandidate(fN, lN, pP);
                    }
                }
            }
        }

        public bool search(String position)
        {
            foreach (Election i in elections)
            {
                String name = i.getPosition();
                if (position.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
