using Microsoft.VisualBasic;
using System.Xml.Linq;

class Program
{
    class Adresess
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public Adresess(string city, string street, int houseNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
         public override string ToString()
        {
            return "Cyty:"+City+" "+ Street+"street"+$" {HouseNumber} ";
        }
    }

    class Person 
    {
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        
        public int YearOfBirth { get; set; }
     
        public string FullName
        {
            get {return FirstName + " " + LastName; }
        }

        public int Age
        {
            get { return DateTime.Now.Year- YearOfBirth; }
        }

        public Person(string firstName, string lastName, int yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
        }

        public Person()
        {

        }
        
        public override string ToString()
        {
            if (YearOfBirth!=0)
                return  $"Author:{this.FullName}\nYears of birth:{this.YearOfBirth}";

            return $"Author:{this.FullName}";
        }
    }

    class Author:Person
    {
        
        public int YearsFromBirth
        {
            get { return base.Age; }
        }

        public string GetYearsFromBirth()
        {
           return $"Years from birh {this.FullName} - {this.YearsFromBirth}";
        }

        public Author()
        {
        }

        public Author (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
    class Book
    {
              
        public Author author = new Author();
        public string Title { get; set; }                    

        public Book(string firstName, string lastName, string title)
        {
           author = new Author(firstName, lastName);
            Title = title;
        }
        
        public override string ToString()
        {
            return
                "Author:" + author.FullName + "\n" + "Title:" + this.Title;
        }
    }

    class Lybrary
    {

        public List<Book> _listOfBooks;

        public string Title { get; set; }

        public Adresess Adresess { get; set; }
      

        Book ab = new Book("Beck", "Feiner", "Alfabet book");
         
        public int NumberOfBook 
        { 
            get {return _listOfBooks.Count; }
        }

        public Lybrary(string title, Adresess adresess)
        {
            Title = title;
            Adresess= adresess;
            _listOfBooks=new List<Book> { ab };
        }
                
        public override string ToString()
        {
            return "Lybrary:" + Title+"\n" + Adresess + "\n"+"Number of Books:"+$"{NumberOfBook}";
        }   
    }

    static void Main()
    {
        Person A = new Author();              

        A.FirstName = "Ivan";
        A.LastName = "Nechuy-Levytskiy";
        A.YearOfBirth = 1838;

        var d = new Book("Jules", "Verne", "Journey to the Center of the Earth");

        var a1 = d.author;

        Console.WriteLine(a1);

        var adr = new Adresess("Kharkiv","Sumska",15);

        var l = new Lybrary("Child Lybrary",adr);

        Console.WriteLine(l);

        l._listOfBooks.Add(d);

        Console.WriteLine(l);

        foreach (var book in l._listOfBooks) 
        {
            Console.WriteLine(book);
        }     
    }
}