using System.Diagnostics;

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

    //n! = 1 * 2 * … * n
    static int Factorial(int n)
    {
        var result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    //n! = 1 * 2 * … * n
    //fact(5) = 120 = fact(4) * 5 = 24 * 5
    static int FactorialRec(int n)
    {
        if (n <= 1)
            return 1;

        return n * FactorialRec(n - 1);
    }
    //0, 1, 2, 3, 4, 5, 6
    //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
    static int Fibonachi(int n)
    {
        if (n == 0 || n == 1) return n;
        return Fibonachi(n - 1) + Fibonachi(n - 2);
    }

    static void Main()
    {
        //PrintHello();
        //PrintHello("Denys");

        //var x = 5;
        //var y = Square(x);

        //Console.WriteLine(y);
        //Console.WriteLine(Square(5));

        //var number = 100;
        //DoubleNumber(ref number);
        //Console.WriteLine(number);

        //var input = Console.ReadLine();

        //var isParsed = ParseIntOrDefault(input, out var intValue, -1);
        //Console.WriteLine($"Parsed: {isParsed}, Value: {intValue}");

        //var timer = new Stopwatch();
        //timer.Start();
        //int tmp;

        //for (int k = 0; k < 100000; k++)
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Console.WriteLine($"Fact({i}) = {Factorial(i)}");
        //        tmp = Factorial(i);
        //    }
        //}

        //timer.Stop();

        //Console.WriteLine($"Time: {timer.Elapsed}");

        //timer.Reset();
        //timer.Start();

        //for (int k = 0; k < 100000; k++)
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        //Console.WriteLine($"Fact({i}) = {FactorialRec(i)}");
        //        tmp = FactorialRec(i);
        //    }
        //}

        //timer.Stop();

        //Console.WriteLine($"Time: {timer.Elapsed}");
        //
        //for (int i = 0; i < 20; i++)
        //{
        //    Console.WriteLine($"Fibonachi({i}) = {Fibonachi(i)}");
        //}

        //while (true)
        //{
        //    var array = new int[1000000, 1000];
        //    for (int i = 0; i < array.GetLength(0); i++)
        //    {
        //        array[i, 0] = i;
        //    }
        //}

        //for (int k = 0; k < 100000; k++)
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Console.WriteLine($"Fact({i}) = {FactorialRec(i)}");
        //        //tmp = FactorialRec(i);
        //    }
        //}

        //Fibonachi(10);

        sbyte b = 100;
        int i = 1000;
        ushort s = checked((ushort)i);

        long ul = long.MaxValue - 512;
        double d = ul;
        ul = (long)d;

        char c = 'h';
        d = (int)c;

        Console.WriteLine(d);
    }
}