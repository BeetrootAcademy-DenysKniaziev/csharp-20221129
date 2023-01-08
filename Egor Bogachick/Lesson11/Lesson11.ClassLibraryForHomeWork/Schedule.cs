using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson11.ClassLibraryForHomeWork
{
    public class Schedule
    {
        public string Day { get; set; }
        public Subject[] Subjects { get; set; } = Array.Empty<Subject>();

        public Schedule()
        {
            Subjects = Array.Empty<Subject>();
        }

        public Schedule(string day)
        {
            this.Day = day;
            Subjects = Array.Empty<Subject>();
        }
        public Schedule(string day, Subject[] subjects)
        {
            this.Day = day;
            this.Subjects = subjects;
        }

        public void AddNewSubject()
        {
            Subject subject = new Subject();
            subject.AddSubject();
            var newSubjects = new Subject[Subjects.Length + 1];
            Array.Copy(Subjects, newSubjects, Subjects.Length);
            Subjects = newSubjects;
            Subjects[^1] = (subject); ;
        }

        public override string ToString()
        {
            foreach (var subject in Subjects)
            {
                Console.WriteLine("Day: " + Day + ", Subject: " + subject + "\n");
            }
            return "\n";
        }
    }
}

