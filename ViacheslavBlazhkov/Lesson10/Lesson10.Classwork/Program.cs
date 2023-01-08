class Person
{
    public const string DefaultName = "Noname";
    public const string DefaultLastName = "Somebody";


    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string LastName { get; set; }

    public string FullName => Name + " " + LastName;

    public static int MaxAge = 100;

    static Person()
    {
        Console.WriteLine("Static ctor of Person");
    }

    public void SayHello()
    {
        Console.WriteLine("Hello!");
    }
    public void Say(string text) 
    {
        Console.WriteLine(text);
    }
    private string ConvertToString()
    {
        return $"{FullName}, MaxAge={MaxAge}";
    }
    public override string ToString()
    {
        return ConvertToString();
    }

    public Person() 
    {
        Name = DefaultName;
        LastName = DefaultLastName;
    }
    public Person(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }
    public Person(Person person)
    {
        Name = person.Name;
        LastName = person.LastName;
    }

    public static string GetDefaultValues()
    {
        return $"{DefaultName} {DefaultLastName}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        //var p1 = new Person();
        //p1.Name = "Denys";
        //p1.LastName = "Kniaziev";
        //Console.WriteLine(p1.FullName);

        //p1.SayHello();
        //p1.Say("Hey!");

        //var p2 = new Person
        //{
        //    Name = "Roman",
        //    LastName = "Bychkov"
        //};
        //Console.WriteLine(p2.FullName);

        var p3 = new Person();
        Console.WriteLine(p3.FullName);

        var p4 = new Person("Marian", "Zhyganov"); ;
        Console.WriteLine(p4.FullName);

        var p5 = new Person(p4);
        Console.WriteLine(p5.FullName);

        Console.WriteLine(Person.MaxAge);
        Console.WriteLine(Person.DefaultLastName);
        Person.MaxAge = 120;
        Console.WriteLine(Person.MaxAge);

        Console.WriteLine(p3);
        Console.WriteLine(p4);
        Console.WriteLine(p5);
        Person.MaxAge = 150;
        Console.WriteLine(p3);
        Console.WriteLine(p4);
        Console.WriteLine(p5);

        Console.WriteLine(Person.GetDefaultValues());
    }
}