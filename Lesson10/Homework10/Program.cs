//Install StarUML
//Describe ‘book library’ domain with C# classes
//Extra:
//Create UML diagram for this domain
using System.Collections.Generic;

using System.Runtime.Intrinsics.X86;

namespace Homework10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("Stepan", "Rudanskyi");
            Author author2 = new Author("Ivan", "Kotlyarevskyi");
            Author author3 = new Author("Taras", "Shevchenko");

            Librery Varnadskogo = new Librery(5);

            var u1 = Varnadskogo.AddUser("Dmytro", "Bonislavskyi");
            var u2 = Varnadskogo.AddUser("Maksim", "Pryima");
            var u3 = Varnadskogo.AddUser("Oleksii", "Prymak");
            Varnadskogo.AddBook("Sbirnyk Humoresok vol 1", author1);
            Varnadskogo.AddBook("Sbirnyk Humoresok vol 2", author1);
            Book b1 = Varnadskogo.AddBook("Sbirnyk Humoresok vol 3", author1);
            Varnadskogo.AddBook("Eneida", author2);
            Varnadskogo.AddBook("Kobzar", author3);

            Varnadskogo.DescribeLibrery();//Show library

            Varnadskogo.ReplaceBook(b1, u1);//replace book from Bookcase where it wos and giving to User

            Varnadskogo.DescribeLibrery();//Show library after User took book
        }
    }

    class Book {
        string _title;
        User _user;
        internal Bookcase BookCase { get; set; }
        public string Title { 
            get  {return _title; }
            set  {_title = value;} 
        }

        public User User        {
            get { return _user; }
            set { _user = value;}
        }
        public Author Author { get; init ; }
        public Book(string title, Author author)        {
            Title = title;
            Author = author;
        }

        public void ShowPosition()        {
            if (BookCase.RoomNumber >= 0)
                Console.WriteLine($"Room number {BookCase.RoomNumber + 1}, Bookcase at positin {BookCase.CasePosition.Item1 + 1} level {BookCase.CasePosition.Item2 + 1}");
            else Console.WriteLine($"Now this book was taken by {User.FullName()}");
        }
    }
    class Bookcase {
        int defoult = 0;
        int _roomnumber;
        (int, int) _caseposition;
        public int RoomNumber        {
            get { return _roomnumber; }
            set { _roomnumber = value; }
        }
        public (int,int) CasePosition        {
            get { return _caseposition; }
            set { _caseposition = value; }
        }
        public Bookcase()        {
            RoomNumber = defoult;
            CasePosition= (defoult,defoult);    
        }
        public Bookcase(int rn, (int,int) cp)        {
            RoomNumber = rn;
            CasePosition = cp;
        }


    }
    class Orders {//No orders placed yet :)
        LinkedList<Book> BooksToOrder;
        User user;//Who placed the Order for new books
    }

    class Librery {
        public Book[,,] _cases;
        List<Bookcase> _bookcases = new List<Bookcase>();
        List<Book> _book = new List<Book>();
        public int _currentFreePlace;
        public Book AddBook(string title, Author author) {
            Book tempB = new Book(title, author);
            tempB.BookCase = Bookcases[_currentFreePlace];
            _book.Add(tempB);//Alternative 1
            _cases[tempB.BookCase.RoomNumber, tempB.BookCase.CasePosition.Item1, tempB.BookCase.CasePosition.Item2] = tempB;//Alternative 2
            if (_currentFreePlace < Bookcases.Count) _currentFreePlace++;
            else { Console.WriteLine("All bookcases full, to add another one book you need to build another Librery, goodbay"); Environment.Exit(1); }
            return tempB;
        }
        public Book ReplaceBook(Book book,Bookcase bookcase) {
            book.BookCase.RoomNumber = bookcase.RoomNumber;
            book.BookCase.CasePosition = bookcase.CasePosition;
            return book;

        }
        public Book ReplaceBook(Book book, User user)  {
            book.BookCase.RoomNumber = -1;
            book.BookCase.CasePosition = (0, 0);
            book.User = user;
            return book;
        }

        public User AddUser(string firstName, string lastName) {
            var user = new User(firstName, lastName);
            return user;
        }
        public List<Bookcase> Bookcases { get; init; }

        public Librery(int rooms) {
            InitiateFacilities(rooms);
            Bookcases = _bookcases;
        }
        void InitiateFacilities(int rooms)        {
            switch (rooms) {
                case 0: { Console.WriteLine("No place for books here, goodbay."); Environment.Exit(1); break; }
                case int n when (n > 30): { Console.WriteLine("It`s too many rooms needed, so we need to build new Librery before, goodbay."); Environment.Exit(1); break; }

            }
            for (int r = 0; r < rooms; r++)            {
                for (int x = 0; x <6; x++)                {
                    for (int y = 0; y <5; y++)                    {
                        _bookcases.Add(new Bookcase(r, (x, y)));
                    }
                }
            }
            _cases = new Book[rooms, 6, 5];
        }
        public void DescribeLibrery()        {
            Console.WriteLine($"Our wanderfull librery have {Bookcases[Bookcases.Count-1].RoomNumber} rooms");
            Console.WriteLine($"That totally have {_book.Count} books now\n");
            for (int i = 0; i < _book.Count; i++)            {
                Console.WriteLine($"Book title: {_book[i].Title}, Wroten by {_book[i].Author.FullName()} is placed in:");
                _book[i].ShowPosition();
                Console.WriteLine("\n");
            }
        }
    }
    class Person    {
        string FirstName { get; set; }
        string LastName { get; set; }
        public Person(string firstName, string lastName)        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FullName() { return $"{FirstName} {LastName}"; }
    }
    class Author: Person    {
        public Author(string firstName, string lastName) : base(firstName, lastName) {
        }


    }
    class User : Person    {
        static int _userIterator;
        int _userNumber;
        int UserNumber { get; set; }
        internal User(string firstName, string lastName) : base(firstName, lastName) {
            UserIterate(); 
        }
        void UserIterate()        {
            _userNumber = _userIterator; 
            _userIterator++; 
        }
    }
}