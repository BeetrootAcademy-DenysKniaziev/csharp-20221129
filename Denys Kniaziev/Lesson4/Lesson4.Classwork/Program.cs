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

    static int Square(int x) => x * x;

    static void DoubleNumber(ref int number)
    {
        number *= 2;
    }

    static bool ParseInt(string str, out int value) => int.TryParse(str, out value);

    static bool ParseIntOrDefault(string str, out int value, int defaultValue)
    {
        if (int.TryParse(str, out value))
            return true;

        value = defaultValue;
        return false;
    }

    static void Main()
    {
        PrintHello();
        PrintHello("Denys");

        var x = 5;
        var y = Square(x);

        Console.WriteLine(y);
        Console.WriteLine(Square(5));

        var number = 100;
        DoubleNumber(ref number);
        Console.WriteLine(number);

        var input = Console.ReadLine();

        var isParsed = ParseIntOrDefault(input, out var intValue, -1);
        Console.WriteLine($"Parsed: {isParsed}, Value: {intValue}");
    }
}