using System;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        // LINQ

        //List<Person> Persons = new List<Person>();
        //Persons.Add(/* тут має бути обєкт класу персон */);
        //public void GetPeople(List<Person> Persons)
        //{

        //    var listPerson = from p in Persons
        //                     where p.StartsWith("T")
        //                     select p;

        //    foreach (var p in listPerson)
        //        Console.WriteLine(p.Name);
        //}

        public static int CountSequence(string dna, string sequence)
        {
            string[] words = dna.Split(new char[] { '-' });
            int count = 0;
            foreach (var s in words)
            {
                if (s.Length == 3 && s == sequence)
                {
                    count++;
                }
            }
            return count;
        }
        public static string ReplaceSequence(string dna, string oldSequence, string newSequence)
        {
            string D = "input wrong";
            string[] newS = newSequence.Split(new char[] { '-' });
            foreach (var i in newS)
            {
                if (oldSequence.Length == newSequence.Length && i.Length == 3)
                {
                    dna = dna.Replace(oldSequence, newSequence);
                    D = dna;
                }
            }
            return D;
        }
        static void Main(string[] args)
        {
            // 1
            string DNA = "CAG-ACT-TCG-TAC-TAC-CGT-CAG-ACT-TAC";
            int result = CountSequence(DNA, "CAG");
            Console.WriteLine(result);

            //2
            Console.WriteLine(DNA);
            string result2 = ReplaceSequence(DNA, "CAG-ACT", "ACT-CA");
            Console.WriteLine(result2);


        }
    }
}