using Lesson11.BusinessLogic;

namespace Lesson11.Classwork;

public class A
{
    private int PrivateProperty { get; set; }

    public int PublicProperty { get; set; }

    public int PublicPropertyNoSet { get; set; } = 10;

    private int _field1 = 5;

    public A()
    {
        PublicPropertyNoSet = 10;
    }

    public void PublicMethod()
    {
        PublicPropertyNoSet = 20;
    }
}

class Program
{
    static void Main()
    {
        //var a = new A();
        //a.PublicProperty = 5;
        //Console.WriteLine(a.PublicProperty);

        ////a.PublicPropertyNoSet = 10;
        //Console.WriteLine(a.PublicPropertyNoSet);

        //var c1 = new Class1();
        ////Console.WriteLine(c1.MyProperty);
        ////c1.MyProperty = 1;

        ////var c2 = new Class2();

        var s1 = Singleton.Instance;
        s1.Method();
        
        var s2 = Singleton.Instance;
        s2.Method();

        Console.WriteLine(ReferenceEquals(s1, s2));
        Console.WriteLine((s1.GetHashCode(), s2.GetHashCode()));


        var c1 = new Class1();
        var c2 = new Class1();

        Console.WriteLine(ReferenceEquals(c1, c2));
        Console.WriteLine((c1.GetHashCode(), c2.GetHashCode()));
    }
}

