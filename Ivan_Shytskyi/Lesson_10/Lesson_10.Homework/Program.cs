class Location
{
    public string _address;
    public Location(string Country, string City, string Street, string NumberOfHouse)
    {
        _address = $"{Country} {City} {Street} {NumberOfHouse}";
    }
}
class Libraries
{
    public int _libraryNumber;
    private int _numberOfAllBooks;
    private string _location;
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }
    public int LibraryNumber 
    {
        get { return _libraryNumber; } 
        set { _libraryNumber = value; } 
    }
    public int NumberOfAllBooks
    {
        get { return _numberOfAllBooks; }
        set { _numberOfAllBooks = value; }
    }

    
    public Libraries (string Country, string City, string Street, string NumberOfHouse, int libraryNumber, int numberOfAllBooks)
    {
        Location a = new Location(Country, City, Street, NumberOfHouse);
        Location = a._address;
        LibraryNumber = libraryNumber;
        NumberOfAllBooks = numberOfAllBooks;
    }
    public void Info()
    {
       Console.WriteLine($"Location library: {Location}" +
           $"\nLibrary number - {LibraryNumber}\nNumber Of all books - {NumberOfAllBooks}"); 
    }
    public void OpenClose()
    {
        DateTime dt = new DateTime();
        dt = DateTime.Now;
        TimeOnly t = new TimeOnly(9, 0);
        TimeOnly t1 = new TimeOnly(17, 0);
        TimeOnly t0 = new TimeOnly();
        t0 = TimeOnly.FromDateTime(dt);

        Console.WriteLine($"Time work librarie: {t} - {t1}");
        if (t0 > t && t0 < t1)
            Console.WriteLine("Libraries is open");
        else
            Console.WriteLine("Libraries is close");
    }
}
class Author
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string DateOfBorn { get; set; }
    public string DateOfDie { get; set; }
    public string FullName => LastName + " " + FirstName;
    public string DateOfBornAndDie => DateOfBorn + " - " + DateOfDie;
}
class Book
{
    public string Name { get; set; }
    public Author Author { get; set; }
    public int Year { get; set; }
    public int NumberOfBooks { get; set; }
    public Book (string name, Author author, int year, int numberOfBooks)
    {
        Name = name;
        Author = author;
        Year = year;
        NumberOfBooks = numberOfBooks;
    }
    public void Available()
    {
        if (NumberOfBooks > 1)
            Console.WriteLine($"{Name} is available");
        else
            Console.WriteLine($"{Name} is not available");
    }
    public void BookInfo()
    {
        Console.WriteLine($"Information of book: {Name}" +
            $"\nAuthor - {Author.FullName} ({Author.DateOfBornAndDie})\nNumber Of books - {NumberOfBooks}\nYear - {Year}");
    }
}
class Program
{
    public static void Main()
    {
        Author author1 = new Author
        {
            LastName = "King",
            FirstName = "Stephen",
            DateOfBorn = "21.09.1947",
            DateOfDie = "_"
        };
        Book book1 = new Book("The Green Mile", author1, 1996, 0);
        var l1 = new Libraries("uk", "london", "streat_1", "12", 1, 100);
        l1.OpenClose();
        Console.WriteLine(new string ('*',20));
        l1.Info();
        Console.WriteLine(new string('*', 20));
        book1.BookInfo();
        Console.WriteLine(new string('*', 20));
        book1.Available();
        Console.WriteLine(new string('*', 20));
    }
}

