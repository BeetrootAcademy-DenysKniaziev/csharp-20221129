using System.Xml.Linq;

class Library
{
    public const string status = "Open";

    public string Name { get; set; }
    public Location Location { get; set; }
    public Employee Employee { get; set; }
    public Bookshelf Bookshelf { get; set; }

    public static string GetStatus()
    {
        return "Library " + status;
    }
}

class Location
{
    public string Country { get; set; }
    public string Street { get; set; }
}

class Employee
{
    public const string DefaultMessage = "Need a worker";
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int WorkExperience { get; set; }
    public string FullName => FirstName + " " + LastName;

    public Employee()
    {
        Console.WriteLine(DefaultMessage);
    }
    
    public Employee(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public Employee(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

}

class Bookshelf
{
    public int Number { get; set; }
    public string Category { get; set; }
    public Book Book { get; set; }
}

class Book
{
    public string BookName { get; set; }
    public string Author { get; set; }
    public int NumberOfPages { get; set; }
}

class Program
{
    static void Main()
    {

    }
}