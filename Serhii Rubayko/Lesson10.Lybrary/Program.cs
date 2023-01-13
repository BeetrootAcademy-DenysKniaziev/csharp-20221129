using System.Xml.Linq;

class Program
{
    class Person 
    {
        protected string _firstName ="_";
        protected string _lastName ="_";
        protected int _yearOfBirth=1950;

        public string FirstName
        { 
            get { return _firstName; }
            set { _firstName = value; }               
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }

        public string FullName
        {
            get {return FirstName + " " + LastName; }
        }

        public int Age
        {
            get { return DateTime.Now.Year- _yearOfBirth; }

        }

        public Person(string firstName, string lastName, int yearOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _yearOfBirth = yearOfBirth;
        }


        public Person()
        {

        }
        
        public override string ToString()
        {
            return
                $"Fullname:{this.FullName}\nYears of birth:{this.YearOfBirth}";

        }
    }

    class Author:Person
    {
        public List<Book>[] books;

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
            _firstName = firstName;
            _lastName = lastName;

        }

    }
    class Book
    {
        
        public Author _author = new Author();
        string _title = "_";

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author.FullName; }
            set { _author = new Author(); }
        }
        
        public Book(string firstName, string lastName, string title)
        {
            _author = new Author(firstName, lastName);
            _title = title;
        }

        public Book(string title) => _title = title;
        
        public override string ToString()
        {
            return
                "Author:"+_author.FullName+"\n"+"Title:"+this.Title;

        }
    }



        static void Main()
    {

        Person A = new Author();

        var a = A.ToString;

        A.FirstName = "Ivan";
        A.LastName = "Nechuy-Levytskiy";
        A.YearOfBirth = 1838;

        var d = new Book("Jules","Verne","Journey to the Center of the Earth");



        Console.WriteLine(d);

        //A.GetYearsFromBirth();

        //Console.WriteLine(A.FirstName+A.LastName+$"{A.YearOfBirth}");

        //Console.WriteLine($"{A.Age}");

    }

}