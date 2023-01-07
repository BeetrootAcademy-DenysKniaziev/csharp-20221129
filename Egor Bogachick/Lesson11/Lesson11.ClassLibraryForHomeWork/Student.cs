using System.Text.RegularExpressions;

namespace Lesson11.ClassLibraryForHomeWork
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public Student()
        {
            this.FirstName = "";
            this.LastName = "";
            this.Age = "";
        }
        public Student(string firstName, string lastName, string age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age; 
        }
        public Student AddStudent()
        {
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
            do
            {
                if (reg > 0)
                {
                    Console.WriteLine("\nIncorrect input, try again:");
                }
                Age = Console.ReadLine()!;
                reg++;
            } while (!Regex.IsMatch(Age, @"\d{2}"));

            return new Student(FirstName, LastName, Age);
        }
    }
}