//#region Lesson 4

//class Program
//{
//    static void PrintHello()
//    {
//        Console.WriteLine("Hello!");
//    }

//    static void PrintHello(string name)
//    {
//        Console.WriteLine($"Hello, {name}!");
//    }

//    static int Square(int x)
//    {
//        return x * x;
//    }

//    static int Square1(int x) => x * x;

//    static void DoubleN(ref int number)
//    {
//        number *= 2;
//    }

//    //static void DoubleN(ref int number)
//    //{
//    //    number *= 2;
//    //}

//    //static bool ParceInt(string str, out int value) =>
//    //    int.TryParse(str, out value);

//    static bool ParceIntOrDefault(string str, out int value, int defaultValue)
//    {
//        if (int.TryParse(str, out value))
//            return true;

//        value = defaultValue;
//        return false;
//    }

//    static int Factorial(int n)
//    {
//        var result = 1;
//        for (int i = 1; i <= n; i++)
//        {
//            result *= i;
//        }
//        return result;
//    }


//    static int FactorialRec(int n)
//    {
//        if (n <= 1)
//            return 1;

//     return n * FactorialRec(n-1);
//    }


//    static int Fibonachi(int n)
//    {
//        if (n == 0 || n == 1) return n;

//        return Fibonachi(n - 1) + Fibonachi(n - 2);

//    }



//    static void Main()
//    {

//        //PrintHello();
//        //PrintHello("Alex");

//        //var x = 5;
//        //var y = Square(x);

//        //Console.WriteLine(y);
//        //Console.WriteLine(Square(25));
//        //Console.WriteLine(Square1(3));

//        //var number = 100;
//        //DoubleN(ref number);
//        //Console.WriteLine(number);

//        //var input = Console.ReadLine();
//        //var intValue = int.Parse(input);
//        //Console.WriteLine(intValue);
//        //якщо вводимо не число - видає "помилку"

//        //var input = Console.ReadLine();

//        //int intValue;
//        //int.TryParse(input, out intValue);

//        //Console.WriteLine(intValue);

//        //int.TryParse(input, out var intValue);
//        //Console.WriteLine(intValue);

//        //var isParsed = ParceIntOrDefault(input, out var intValue, -1);
//        //Console.WriteLine($"Parsed: {isParsed}, Value: {intValue}");

//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine($"Factorial({i}) = {Factorial(i)}");
//        }

//        Console.WriteLine();

//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine($"Factorial({i}) = {FactorialRec(i)}");
//        }
//        Console.WriteLine();

//        for (int i = 0; i < 20; i++)
//        {
//            Console.WriteLine($"Fibonachi({i}) = {Fibonachi(i)}");
//        }
//    }

//#endregion



/*Homework*/

class Program
{
    //1
    static int MaxV(int a, int b) => Math.Max(a, b);

    static int MaxV(int a, int b, int c) => Math.Max(c, Math.Max(a, b));

    static int MaxV(int a, int b, int c, int d) => Math.Max(d, (Math.Max(c, Math.Max(a, b))));

    //2
    static int MinV(int a, int b) => Math.Min(a, b);

    static int MinV(int a, int b, int c) => Math.Min(c, Math.Min(a, b));

    static int MinV(int a, int b, int c, int d) => Math.Min(d, (Math.Min(c, Math.Min(a, b))));

    //3
    static bool TrySumIfOdd(int a, int b, out int sum)
    {
        sum = 0;
        for (int i = a; i < b; i++)
        {
            sum += a++;
        }
        return sum % 2 != 0;
    }

    //Extra:
    static string Repeat(string x, int n)
    {
        if (n == 1)
        {
            return x;
        }
        return x + Repeat(x, n - 1);
    }


    static void Main()
    {
    //1 
     Console.WriteLine(MaxV(19, 6));

     Console.WriteLine(MaxV(4, 16, 40));

     Console.WriteLine(MaxV(7, 37, 152, 451));

     //2
     Console.WriteLine(MinV(35, 9));

     Console.WriteLine(MinV(3, 17, 46));

     Console.WriteLine(MinV(54, 182, 365, 2001));

     //3
     bool TrueOrFalse = TrySumIfOdd(5, 87, out int sum);
     Console.WriteLine(TrueOrFalse);
     Console.WriteLine(sum);

     //Extra:
     int n;
     Console.WriteLine(Repeat("Hi ", 9));
    }
}
