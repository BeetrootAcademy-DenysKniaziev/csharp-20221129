class Person
{
    private string name;

    public string Name 
    { 
        get { return $"Mr.{name}"; }
        set { name = value; } 
    }

    public string LastName { get; set; }

    public string FullName { get { return Name + " " + LastName; } }

    public void SayHello()
    {
        Console.WriteLine("Hello");
    }
    public void Say(string text)
    {
        Console.WriteLine(text);
    }
}

class Program
{
    static void Main ()
    {
        Console.WriteLine("Lesson 10");

        var p1 = new Person();
        p1.Name = "Ivan";
        p1.LastName = "Shytskyi";
        Console.WriteLine(p1.Name);
        Console.WriteLine(p1.LastName);
        Console.WriteLine(p1.FullName);
        p1.SayHello();
        p1.Say("Hi!!");
        var p2  = new Person();
        {
            
        }
    }
}
