class User
{
    public int Id;
    public string Name;

    public void Create()
    {
        Console.WriteLine("User created.");
    }

    public void Delete()
    {
        Console.WriteLine("User deleted.");
    }
}

class Librarian
{
    public int Login;
    public string Password;
    public User UserId;

    public void LogIn()
    {
        Console.WriteLine("Нou are logged in.");
    }

    public void LogOff()
    {
        Console.WriteLine("Нou are logged off.");
    }
}

class Client
{
    public int Phone;
    public int BooksAmount;
    public User UserId;
    public Order Order;

    public void GetBook()
    {
        BooksAmount++;
    }
}

class Order
{
    public int OrderId;
    public Client Orderer;
    public string DateStart;
    public string DateEnd;
    public Book BookName;

    public void Create()
    {
        Console.WriteLine("The order has been created");
    }

    public void Update()
    {
        Console.WriteLine("The order has been updated");
    }
}

class Book
{
    public int BookId;
    public string BookName;
    public string Author;
    public string Publisher;

    public void CreateBook()
    {
        Console.WriteLine("The book has been created");
    }

    public void UpdateBook()
    {
        Console.WriteLine("The book has been updated");
    }

    public void DeleteBook()
    {
        Console.WriteLine("The book has been deleted");
    }
}

class Program
{
    static void Main()
    {
        var l1 = new Librarian
        {
            Login = 0000,
            Password = "pass1",
            UserId = new User
            {
                Id = 0001,
                Name = "Lib1",
            }
        };

        var c1 = new Client
        {
            Phone = 0501112233,
            BooksAmount = 0,
            UserId = new User
            {
                Id = 0002,
                Name = "Client1",
            }   
        };

        l1.LogIn();
    }
}

