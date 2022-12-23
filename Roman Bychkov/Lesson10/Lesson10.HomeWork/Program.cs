class Program
{
    static void Main()
    {

    }
}
public class PublishingHouse
{
    public string Name { get; set; }
    public int YearOfFoundation { get; set; }
    public Country Country { get; set; }

}
public class Country
{
    public string Name { get; set; }

    public double Square { get; set; }

    public string Language { get; set; };
}

public class Genre
{
    public string Name { get; set; }
    public string Description { get; set; }
}
public class Book
{
    public string Name { get; set; }
    public int CountOfPages { get; set; }
    public Author Author { get; set; }
    public PublishingHouse PubHouse { get; set; }
}
public class Author
{
    public string Name { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBorn { get; set; } = DateTime.Now;

    public int Age
    {
        get => DateTime.Now.Year - DateOfBorn.Year;
    }
    public Country CountryOfBorn { get; set; }
}