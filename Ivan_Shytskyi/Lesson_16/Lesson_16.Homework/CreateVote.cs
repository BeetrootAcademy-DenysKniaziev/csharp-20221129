using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_16.Homework
{
    internal class CreateVote : Candidate
    {
        public string TopicForVoting { get; set; }
        public Dictionary<int, Candidate> Candidates;
        public Dictionary<int, List<string>> Voters;
        public CreateVote()
        {
            Candidates = new Dictionary<int, Candidate>();
        }
        public void NewVote()
        {
            Console.WriteLine("Enter candidates");
            Console.WriteLine("how many candidates?");
            int x = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= x; i++)
            {
                Console.Write($"candidate number {i}\t");
                Candidates.Add(i, new Candidate(Console.ReadLine()));
                Console.WriteLine();
            }
        }
        public void StartVote(Person voter)
        {
            Console.WriteLine($"{TopicForVoting}");
            Console.WriteLine($"Candidate:");
            foreach (var candidate in Candidates)
                Console.Write($"{candidate.Key} {candidate.Value.Name} \t");
            Console.WriteLine();
            Console.WriteLine($"Your choices:");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Candidates.Count();
            Voters = new Dictionary<int, List<string>>();
            for (int i = 1; i <= y; i++)
            {
                Voters.Add(i, new List<string>());
            }
            foreach (var candidate in Candidates)
            {
                if (x == candidate.Key)
                {
                    candidate.Value.Count++;
                    Voters[candidate.Key].Add(voter.FullName);
                }
            }
        }
        public void StartAnonimVote()
        {
            Console.WriteLine($"{TopicForVoting}");
            Console.WriteLine($"Candidate:");
            foreach (var candidate in Candidates)
                Console.Write($"{candidate.Key} {candidate.Value.Name}\t");
            Console.WriteLine();
            Console.WriteLine($"Your choices:");
            int x = Convert.ToInt32(Console.ReadLine());
            foreach (var candidate in Candidates)
            {
                if (x == candidate.Key)
                {
                    candidate.Value.Count++;
                }
            }
        }
        public void WhoWin()
        {
            Console.WriteLine("The winner:");
            Candidate candidate = new Candidate();
            int a = default;
            foreach (var c in Candidates)
            {
                if (c.Value.Count > candidate.Count)
                {
                    candidate.Name = c.Value.Name;
                    candidate.Count = c.Value.Count;
                    a = c.Key;
                }
            }
            Console.WriteLine($"{candidate.Name} votes - {candidate.Count}");
            foreach (var v in Voters[a])
                Console.WriteLine($"{v}");
        }
    }
}
