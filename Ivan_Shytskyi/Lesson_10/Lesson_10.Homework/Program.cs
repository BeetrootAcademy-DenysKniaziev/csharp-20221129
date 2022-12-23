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
    private int _booksAvailable;
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
    public int NumberOfBooks
    {
        get { return _numberOfAllBooks; }
        set { _numberOfAllBooks = value; }
    }
    public int BooksAvailable
    {
        get { return _booksAvailable; }
        set { _booksAvailable = value; }
    }
    
    public Libraries (string Country, string City, string Street, string NumberOfHouse, int libraryNumber, int numberOfAllBooks, int booksAvailable)
    {
        Location a = new Location(Country, City, Street, NumberOfHouse);
        Location = a._address;
        LibraryNumber = libraryNumber;
        NumberOfBooks = numberOfAllBooks;
        BooksAvailable = booksAvailable;
    }
    public void Info()
    {
       Console.WriteLine($"Location library: {_location}" +
           $"\nLibrary number - {_libraryNumber}\nNumber Of books - {_numberOfAllBooks}\nBooks available - {_booksAvailable}"); 
    }
    public void OpenClose()
    {
        DateTime dt = new DateTime();
        DateTime dt1 = new DateTime();
        DateTime dt2 = new DateTime();
        dt = DateTime.Now;
        dt1 = dt1.AddHours(9);
        dt2 = dt2.AddHours(17);
        Console.WriteLine($"Time work librarie: {dt1.ToString("HH:mm")} - {dt2.ToString("HH:mm")}");
        if (dt > dt1 && dt < dt2)
            Console.WriteLine("Libraries is open");
        else
            Console.WriteLine("Libraries is close");
    }
}
class Author
{

}
class Book
{
    private string _name;
    private Author _author;
    private int _year;
    private int _numberOfBooks;
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
}

class User
{

}

class Program
{
    public static void Main()
    {
        var l1= new Libraries("uk", "london", "streat_1", "12", 1, 100, 55);
        Console.WriteLine(l1.LibraryNumber);
        l1.OpenClose();
        l1.Info();

    }
}

