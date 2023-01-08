namespace Lesson11.BusinessLogic;

public class Class1
{
    public int MyProperty { get; init; }

    public Class1()
    {
        MyProperty = 10;
    }

    void M2()
    {
       // MyProperty = 5;
    }
}

internal class Class2
{
    void M()
    {
        var x = new Class1
        {
            MyProperty = 10
        };

        var y = new Class1
        {
            MyProperty = 20
        };

        //x.MyProperty = 10;
    }
}

//public class Pupil
//{
//    public static Pupil[] All { get; } = new Pupil[1000];
//    public static int Count { get; private set; } = 0;

//    public Pupil()
//    {
//        All[Count++] = new Pupil();

//    }
// }