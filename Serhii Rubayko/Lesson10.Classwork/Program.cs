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
    public Person()
    {
        Name = "Noname";
        LastName = "Somebody";
    }

    public Person(string name, string lastName)
    {
        Name = name;
        LastName= lastName;
    }
    public Person(Person person)
    {
        Name = person.Name;
        LastName = person.LastName;
    }


    private string ConvertToString()

    {
        return $"{FullName}, MaxAge={MaxAge}";

    }

    public override string ToString()
    {
        return ConvertToString();
    }

    public static string GetDefaultName()

    {
        return DefaultName + " " + DefaultLastName;

    }



}


class Program
{
    static void Main()
    {
        var p1 = new Person();
        p1.Name = "Denys";
        p1.LastName = "Kniaziev";
        Console.WriteLine(p1.LastName);

        p1.ToString;

        //var p3 = new Person();
        //Console.WriteLine(p3.FullName);

        //var p5 = new Person();
        //Console.WriteLine(p5.FullName);

        //Console.WriteLine(Person.MaxAge);

    }

}