using System.Runtime.CompilerServices;

class CountryLocation
{
    public int CountryCode { get; set; }

}

class Country
{
    public string Name { get; set; }

    public CountryLocation CountryLocation { get; set; }

    public void Closed()
    {
        Console.WriteLine($"Country {Name} has no librarys!");
    }

}

class CityLocation
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }
}

class City
{
    public string Name { get; set; }

    public int CityCode { get; set; }
    public CityLocation CityLocation { get; set; }
    public void Closed()
    {
        Console.WriteLine($"Country {Name} has no librarys!");
    }

}

class LibraryLocation
{
    public int NumberOfStreet { get; set; }

    public int NumberOfBuilding { get; set; }

    public int NumberOfDoor { get; set; }
}


class Library
{
    public string Name { get; set; }

    public LibraryLocation LibraryLocation { get; set; }

    public void Closed()
    {
        Console.WriteLine($"Library {Name} closed for repairs!");
    }

}

class Books
{
    public string Name { get; set; }
    public string Author { get; set; }
    public Country Country { get; set; }
    public City City { get; set; }

    public Library Library { get; set; }
    public bool HasImages { get; set; }

}

class Program
{
    static void Main()
    {
        var l1 = new Library
        {
            Name = "L1",
            LibraryLocation = new LibraryLocation
            {
                NumberOfBuilding = 1,
                NumberOfDoor = 32,
                NumberOfStreet = 6,
            }
        };

        var b1 = new Books
        {
            Name = "Kobzar",
            Library = l1,
            Author = "Taras Shevchenko",
            Country = new Country
            {
                Name = "Ukraine",
                CountryLocation = new CountryLocation
                {
                    CountryCode = 482
                }
            },
            City = new City
            {
                Name = "Kyiv",
                CityCode = 01001,
                CityLocation = new CityLocation
                {
                    Latitude = 50.4546600,
                    Longitude = 30.5238000,
                }
            },
            HasImages = true,
        };

        var b2 = new Books
        {
            Name = "Tom Sawyer",
            Library = b1.Library,
            Author = "Mark Tven",
            Country = new Country
            {
                Name = "U.S.",
                CountryLocation = new CountryLocation
                {
                    CountryCode = 00
                }
            },
            City = new City
            {
                Name = "Florida",
                CityCode = 1602,
                CityLocation = new CityLocation
                {
                    Latitude = 27.6648,
                    Longitude = 81.5158,
                }
            },
            HasImages = true,
        };

        var b3 = new Books
        {
            Name = "The Book with No Pictures",
            Library = b2.Library,
            Author = "B.J. Novak",
            Country = b2.Country,
            City = new City
            {
                Name = "Newton",
                CityCode = 02458,
                CityLocation = new CityLocation
                {
                    Latitude = 42.337,
                    Longitude = -71.2092
                }
            },
            HasImages = false,
        };
    }
}