using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    public class Subject
    {
        public string SubjectName { get; set; }
        public string TimeSpan { get; set; }
        public Subject() 
        {
            this.SubjectName = "";
            this.TimeSpan = "";
        } 

        public Subject(string subjectName, string timeSpan)
        {
            this.SubjectName = subjectName;
            this.TimeSpan = timeSpan;
        }

        public Subject AddSubject()
        {
            Console.WriteLine("Add new subject:");
            int reg = 0;
            Console.WriteLine("Enter subject name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                SubjectName = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(SubjectName, @"[A-Za-z]"));

            reg = 0;
            Console.WriteLine("Enter time span:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                TimeSpan = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(TimeSpan, @"^[0-2][0-3]:[0-5][0-9]$"));

            return new Subject(SubjectName, TimeSpan);
        }

        public override string ToString()
        {
            return "SubjectName: " + SubjectName + ", TimeSpan: " + TimeSpan;
        }

    }
}
