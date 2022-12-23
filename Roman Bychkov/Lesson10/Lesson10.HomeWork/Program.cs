class Program
{
    static void Main()
    {

    }
}
public class PublishingHouse //Це Видання
{
    public string Name { get; set; }
    public int YearOfFoundation { get; set; }
    public Country Country { get; set; }

    public PublishingHouse(string name, int yearOfFoundation, Country country)
    {
        Name = name;
        YearOfFoundation = yearOfFoundation;
        Country = country;
    }

}
public class Country
{
    public string Name { get; set; }

    public double Square { get; set; }

    public string Language { get; set; }

    public Country(string name, double square, string language)
    {
        Name = name;
        Square = square;
        Language = language;
    }
}

public class Genre
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Genre(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
public class Book
{
    public string Name { get; set; }
    public int CountOfPages { get; set; }
    public Author Author { get; set; }
    public PublishingHouse PubHouse { get; set; }

    public Genre Genre { get; set; }

    public bool Available
    {
        get
        {
            if (CountInLibrary > 0)
                return true;
            return false;
        }
    }
    public int CountInLibrary { get; set; } = 0;


    public Book(string name, int countOfPages, Author author, PublishingHouse pubHouse, Genre genre)
    {
        Name = name;
        CountOfPages = countOfPages;
        Author = author;
        PubHouse = pubHouse;
        Genre = genre;
    }
}
public class Author
{
    public string Name { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBorn { get; set; }

    public DateTime? DateOfDie { get; set; }
    public int Age
    {
        get
        {
            if (DateOfDie.HasValue)
                return DateOfDie.Value.Year - DateOfBorn.Year;
            return DateTime.Now.Year - DateOfBorn.Year;
        }
    }
    public Country CountryOfBorn { get; set; }

    public Author(string name, string lastName, Country countryOfBorn, DateTime dateOfBorn, DateTime? dateOfDie = null)
    {
        Name = name;
        LastName = lastName;
        CountryOfBorn = countryOfBorn;
        DateOfBorn = dateOfBorn;
        DateOfDie = dateOfDie;
    }
}
public class User
{
    static int GlobalId = 0;
    public string Name { get; set; }
    public string LastName { get; set; }

    public bool HasBook { get; private set; } = false;
    public int Id { get; }

    public DateTime DateOfBorn { get; set; }

    public Book CurrentBook { get; private set; }

    public void GetBook(Book book)
    {
        if (book?.Available == true && HasBook == false)
        {
            CurrentBook = book;
            book.CountInLibrary--;
            HasBook = true;
            Console.WriteLine("User got a book.");
        }
        else
        {
            Console.WriteLine("Book is not exist or user already has a book.");
        }
    }
    public void ReturnBook()
    {
        if (HasBook == true)
        {
            HasBook = false;
            CurrentBook.CountInLibrary++;
            CurrentBook = null;
            Console.WriteLine("Book is returned.");
        }
        else
        {
            Console.WriteLine("User has not a book.");
        }
    }

    public User(string name, string lastName, DateTime dateOfborn)
    {
        Name = name;
        LastName = lastName;
        DateOfBorn = dateOfborn;
        Id = GlobalId;
        GlobalId++;
    }

}