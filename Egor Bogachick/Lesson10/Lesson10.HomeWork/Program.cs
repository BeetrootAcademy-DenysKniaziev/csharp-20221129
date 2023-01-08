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

    public Location(string country, string street)
    {
        this.Country = country;
        this.Street = street;
    }
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
    public int NumberOfBooks { get; set; }
    public Book Book { get; set; }
}

class Book
{
    public string BookName { get; set; }
    public string Author { get; set; }
    public int NumberOfPages { get; set; }

    public override string ToString()
    {
        return "Book: " + BookName + "\nAuthor: " + Author + "\nNumber of pages: " + NumberOfPages;
    }
}

class Program
{
    static void Main()
    {
        var book1 = new Book
        {
            BookName = "1984",
            Author = "George Orwell",
            NumberOfPages = 200
        };

        var bookshelf1 = new Bookshelf
        {
            Number = 1,
            Category = "Novel",
            NumberOfBooks = 5,
            Book = book1
        };

        var employee1 = new Employee("Egor", "Bogachik", 19);

        var location1 = new Location("Ukraine", "Shevchenko");
        var lib1 = new Library
        {
            Name = "Royal library",
            Location = location1,
            Employee = employee1,
            Bookshelf = bookshelf1,
        };


        Console.WriteLine(Library.GetStatus());
        Console.WriteLine(book1);

    }
}