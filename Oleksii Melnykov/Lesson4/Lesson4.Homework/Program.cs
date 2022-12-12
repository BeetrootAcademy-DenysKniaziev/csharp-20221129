#region Lesson 4

class Program
{
    static void PrintHello()
    {
        Console.WriteLine("Hello!");
    }

    static void PrintHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }

    static int Square(int x)
    {
        return x * x;
    }

    static int Square1(int x) => x * x;

    static void DoubleN(ref int number)
    {
        number *= 2;
    }

    //static void DoubleN(ref int number)
    //{
    //    number *= 2;
    //}

    //static bool ParceInt(string str, out int value) =>
    //    int.TryParse(str, out value);

    static bool ParceIntOrDefault(string str, out int value, int defaultValue)
    {
        if (int.TryParse(str, out value))
            return true;

        value = defaultValue;
        return false;
    }


    static void Main()
    {

        PrintHello();
        PrintHello("Alex");

        var x = 5;
        var y = Square(x);

        Console.WriteLine(y);
        Console.WriteLine(Square(25));
        Console.WriteLine(Square1(3));

        var number = 100;
        DoubleN(ref number);
        Console.WriteLine(number);

        //var input = Console.ReadLine();
        //var intValue = int.Parse(input);
        //Console.WriteLine(intValue);
        //якщо вводимо не число - видає "помилку"

        var input = Console.ReadLine();

        //int intValue;
        //int.TryParse(input, out intValue);

        //Console.WriteLine(intValue);

        //int.TryParse(input, out var intValue);
        //Console.WriteLine(intValue);

        var isParsed = ParceIntOrDefault(input, out var intValue, -1);
        Console.WriteLine($"Parsed: {isParsed}, Value: {intValue}");






    }

}







#endregion
