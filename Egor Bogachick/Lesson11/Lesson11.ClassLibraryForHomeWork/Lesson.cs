using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    internal class Lesson
    {
        public string LessonName { get; set; }
        public string TimeSpan { get; set; }
        public Lesson() 
        {
            this.LessonName = "";
            this.TimeSpan = "";
        } 

        public Lesson(string lessonName, string timeSpan)
        {
            this.LessonName = lessonName;
            this.TimeSpan = timeSpan;
        }

        public Lesson AddLesson()
        {
            int reg = 0;
            Console.WriteLine("Enter first name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                LessonName = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(LessonName, @"[A-Za-z]"));

            reg = 0;
            Console.WriteLine("Enter last name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                TimeSpan = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(TimeSpan, @"^[0-2][0-3]:[0-5][0-9]$"));

            return new Lesson(LessonName, TimeSpan);
        }

    }
}
