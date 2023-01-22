namespace Lesson_16.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many voter to day? (without admin)");
            int countVoter = Convert.ToInt32(Console.ReadLine());
            CreateVote vote = new CreateVote();
            List<Person> AllVotets = new List<Person>();
            bool gb = true;
            bool b = false;
            do
            {
                Console.WriteLine("console interface\n1. Admin\t2. Voter\t3. Exit");
                int x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Enter first name");
                    string strF = Console.ReadLine();
                    Console.WriteLine("Enter last name");
                    string strL = Console.ReadLine();
                    Console.WriteLine("Enter age");
                    int ageAdmin = Convert.ToInt32(Console.ReadLine());

                    Admin admin = new Admin(strF, strL, ageAdmin);

                    Console.WriteLine("You have options:\n1. Create Vote\t2. vote");
                    int x1 = Convert.ToInt32(Console.ReadLine());

                    switch (x1)
                    {
                        case 1:
                            Console.WriteLine("Vote topic");
                            string s = Console.ReadLine();
                            vote.TopicForVoting = s;
                            vote.NewVote();
                            break;
                        case 2:
                            vote.StartAnonimVote();
                            break;
                    }
                }
                else if (x == 2)
                {
                    int index = 1;
                    while (index <= countVoter)
                    {
                        Console.WriteLine($"Voter {index}:");
                        Console.WriteLine("Enter first name");
                        string strF = Console.ReadLine();
                        Console.WriteLine("Enter last name");
                        string strL = Console.ReadLine();
                        Console.WriteLine("Enter age");
                        int ageVoter = Convert.ToInt32(Console.ReadLine());
                        Voter voter = new Voter(strF, strL, ageVoter);
                        AllVotets.Add(voter);
                        vote.StartVote(voter);
                        index++;
                    }
                }
                else if (x == 3)
                {
                    Console.WriteLine("Good bye");
                    gb = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    b = true;
                }
            }
            while (b);
            if (gb)
            {
                vote.WhoWin();
                Console.WriteLine("if you want to see all voters?\n1. Yes\t2. No");
                int allvot = Convert.ToInt32(Console.ReadLine());
                if (allvot == 1)
                {
                    foreach (var av in AllVotets)
                        Console.WriteLine(av);
                }
                else
                    Console.WriteLine("Good bye");
            }
        }
    }
}