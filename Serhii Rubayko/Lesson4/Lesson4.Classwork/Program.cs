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

    //static int Square(int x)
    //{
    //    return x * x;
    //}
    static int Square(int x) => x * x;

    static void DoubleNumber(ref int number)
    {
        number *= 2;
    }

    static bool ParseInt(string str, out int value)
        => int.TryParse(str, out value);

    static bool ParseIntOrDefault(string str, out int value, int defaultValue)
    {
        if (int.TryParse(str, out value))
            return true;

        value = defaultValue;
        return false;
    }
    //n!=1*2*...*n

    static int Factorial(int n)
    {
        var result = 1;
        for (int i = 1; i<=n; i++)
        {
         result *= i;
        }
        return result;
    }

    static int FactorialRec(int n)
    {
        if (n <= 1)
            return 1;

        return n * FactorialRec(n - 1);
    }

    static int Fibonachi(int n)
    {
        if (n == 0 || n == 1) return n;

        return Fibonachi(n - 1) + Fibonachi(n - 2);
    }

    static void Main()
    {
        PrintHello();
        PrintHello("Petro");

        //var x = 5;
        //var y=Square(x);

        //Console.WriteLine(y);
        //Console.WriteLine(Square(x));

        //var number = 255;
        //DoubleNumber(ref number);

        //Console.WriteLine(number);

        var input = Console.ReadLine();

        //var isParsed = int.TryParse(input, out var intValue);

        var isParsed = ParseIntOrDefault(input, out var intValue, -86);
        Console.WriteLine($"Parsed: {isParsed}, Value: {intValue}");

        //for (int i=0; i<10; i++)
        //{
        //    Console.WriteLine($"Fact({i})={Factorial(i)}");
        //}

        //Console.WriteLine();

        //for (int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine($"Fact({i})={FactorialRec(i)}");
        //}

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine($"Fact({i})={Fibonachi(i)}");
        }


    }



}





