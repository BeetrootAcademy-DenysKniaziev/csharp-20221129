using System;
using System.Text.RegularExpressions;

namespace Lesson11.ClassLibraryForHomeWork
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Student()
        {
            this.FirstName = "";
            this.LastName = "";
            this.Age = 0;
        }
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age; 
        }
        public Student AddStudent()
        {
            Console.WriteLine("Add new student\n");
            int reg = 0;
            Console.WriteLine("Enter first name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                FirstName = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(FirstName, @"[A-Za-z]"));

            reg = 0;
            Console.WriteLine("Enter last name:");
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                LastName = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(LastName, @"[A-Za-z]"));

            reg = 0;
            Console.WriteLine("Enter age:");
            Age = int.Parse(Console.ReadLine()!);

            return new Student(FirstName, LastName, Age);
        }

        public override string ToString()
        {
            return "FirstName: " + FirstName + ", LastName: " + LastName + ", Age: " + Age;
        }
    }
}