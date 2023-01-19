using System;
using static Program;
using static Program.Class;

public class Program
{
    class School
    {
        public string Title { get; set; }

        public List<Class> Classes = new List<Class>();

        public School(string title)
        {
            Title = title;
        }
        public void AddClass(Class klas)
        {
            Classes.Add(klas);
        }

        public void RemoveClass(Class klas)
        {
            Classes.Remove(klas);
        }
        public void ReplaceClass(Class klas1, Class klas2)
        {
            Classes.Remove(klas1);
            Classes.Add(klas2);
        }

        public void PrintSchedule()
        {
            foreach (var klas in Classes)
            {
                Console.WriteLine(klas);
            }
        }
    }
    public class Class
    {
        public string ClassName { get; set; }
        public List<Subject> Subjects = new List<Subject>();
        public List<Pupil> Pupils = new List<Pupil>();
        public List<Teacher> Teachers = new List<Teacher>();
        public int Days { get; set; }

        public class Subject
        {
            public string Title { get; set; }

            int Hours { get; set; }

            public Subject(string title, int hours)
            {
                Title = title;
                Hours = hours;
            }

            public override string ToString()
            {
                return Title + $"\tHours per week: {Hours} ";
            }

        }

        public Class(string className, int days)
        {
            ClassName = className;
            Days = days;
        }
        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }
        public void RemoveSubject(Subject subject)
        {
            Subjects.Remove(subject);
        }
        public void ReplaceSubject(Subject subject)
        {
            Subjects.Remove(subject);
            Subjects.Add(subject);
        }
        public void AddPupil(Pupil pupil)
        {
            if (pupil.Klass == this.ClassName)
            {
                Pupils.Add(pupil);                
            }
        }
        public void AddTeacher(Teacher teacher)
        {
            foreach (var subj in Subjects)
            {
                if (subj.Title == teacher.Subj)
                {
                    Teachers.Add(teacher);
                }
            }
        }
        public void PrintClass()
        {
            Console.WriteLine("Class:\t" + ClassName + $"\tSchool days per week: {Days}\n");

            Console.Write("Subjects:\t");
            for (int i = 0; i < Subjects.Count; i++)
            {
                Console.Write($"{i + 1}) " + Subjects[i] + "; ");
            }
            Console.Write("\n\nTeachers:\t");
            for (int i = 0; i < Teachers.Count; i++)
            {
                Console.Write($"{i + 1}) " + Teachers[i] + "; ");
            }
            Console.WriteLine("\nPupils:");
            for (int i = 0; i < Pupils.Count; i++)
            {
                Console.WriteLine($"{i + 1}) " + Pupils[i].FirstName+ " "+Pupils[i].LastName + "; ");
            }
        }
    }
    public class Pupil
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Klass { get; set; }
        public Pupil(string firstName, string lastName, string klass)
        {
            FirstName = firstName;
            LastName = lastName;
            Klass = klass;
        }
        public override string ToString()
        {
            return $"Pupil: {this.FirstName + " " + LastName}   Class: {this.Klass}";
        }
    }
    public class Teacher
    {
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string Subj { get; set; }
        public Teacher(string firstName, string lastName, string subject) 
        {
            FirstName = firstName;
            LastName = lastName;
            Subj = subject;
        }
        public override string ToString()
        {
            return $"Teacher: {this.FirstName + " " + this.LastName}   Subject: {this.Subj}";
        }
    }
    static void Main()
    {

        var k = new Class("7B", 5);

        
        var s = new Subject("Eanglish", 3);

        k.AddSubject(s);

        var t = new Teacher("Gwen", "Stefany", "Eanglish");

        k.AddTeacher(t);

        var p1 = new Pupil("Petryk", "Pyatochkin", "7B");
        var p2 = new Pupil("Natochka", "Kosa", "7B");

        k.AddPupil(p1);
        k.AddPupil(p2);
        k.PrintClass();

        t.LastName = "Klinton";

        k.PrintClass();

    }
}
