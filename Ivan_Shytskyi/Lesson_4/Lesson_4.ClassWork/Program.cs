using System.Diagnostics;
using System.Runtime.Serialization.Formatters;

class Program
{
    static void PrinterHello()
    {
        Console.WriteLine("Hello");
    }

    static void PrinterHello(string name)
    {
        Console.WriteLine($"Hello,{name}");
    }

    static int Squere(int x)
    {
        return x * x;
    }

    static int SquereLamda(int x) => x * x;

    static void DoubleNumber(ref int number)
    {
        number *= 2;
    }

    static bool ParseInt(string str, out int value)
    {
        return int.TryParse(str, out value);
    }

    static bool ParseInteger(string str, out int value) =>
        int.TryParse(str, out value);

    static bool ParseIntOrDefault(string str, out int value, int defaultvalue)
    {
        if (int.TryParse(str, out value))
            return true;

        value = defaultvalue;
        return false;
    }

    static int Factorial (int n)
    {
        int result = 1;
        for (int i = 1; i <= n  ; i++)
        {
            result *= i;
        }
        return result;
    }
    static int FactorialRec (int n)
    {
        if (n <= 1)
            return 1;
        return n*FactorialRec(n - 1);
    }

    static int Fibanachi(int n)
    {
        if (n == 0 || n == 1)
            return n;
        return  Fibanachi(n - 1) + Fibanachi (n - 2);
    }

    static void Main()
    {
        //PrinterHello();
        //PrinterHello("Nadia");

        //var x = 5;
        //var y = Squere(x);

        //Console.WriteLine(y);
        //Console.WriteLine(Squere(8));

        //var number = 100;
        //DoubleNumber(ref number);
        //Console.WriteLine(number);

        //var imput = Console.ReadLine();
        //var intValue = int.Parse(imput);
        //Console.WriteLine(intValue);

        //var imput1 = Console.ReadLine();

        ////var isParsed = int.TryParse(imput1, out var intValue1);
        //var isParsed = ParseIntOrDefault(imput1, out var intValue1, -1);

        //Console.WriteLine($"Parsed:{isParsed}, value:{intValue1}");
        //Console.WriteLine(intValue1);

        var timer = new Stopwatch();
        timer.Start();

        for (int j = 0; j < 20; j++)
        {
            Console.WriteLine($"Factorial ({j}) = {Factorial(j)}");
            //var tmp = Factorial(j); 
        }
        timer.Stop();
        Console.WriteLine($"Time: {timer.Elapsed}");

        var timer2 = new Stopwatch();
        timer2.Start();

        for (int j = 0; j < 20; j++)
        {
            Console.WriteLine($"Factorial ({j}) = {FactorialRec(j)}");
            
        }
        timer2.Stop();
        Console.WriteLine($"Time: {timer2.Elapsed}");

        for (int j = 0; j < 20; j++)
        {
            Console.WriteLine($"Fibanachi ({j}) = {Fibanachi(j)}");
        }

        Console.ReadKey();  
    }
}