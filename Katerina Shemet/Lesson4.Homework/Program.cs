using System;
using System.Diagnostics;

class Program
{
    static int Maximum(int a, int b)
    {
        return Math.Max(a, b);
    }

    static int Minimum(int a, int b)
    {
        return Math.Min(a, b);
    }

    static bool ParseIntOrDefault(string str, out int value, int defaultValue)
    {
        if (int.TryParse(str, out value))
            return true;

        value = defaultValue;
        return false;
    }

    static bool TrySumIfOdd(int num1, int num2, out int sum)
    {
        if ((num1 + num2) % 2 != 0)
        {
            sum = num1 + num2;
            return true;
        }
        else
        {
            sum = num1 + num2;
            return false;
        }
    }
        static int Maximum(int a, int b, int c)
        {
            return Math.Max(c, Math.Max(a, b));
        }

        static int Minimum(int a, int b, int c)
        {
            return Math.Min(c, Math.Min(a, b));
        }

    static void Maximum(int f, int g, int h, out int d)
    {
        d= Math.Max(h, Math.Max(f, g));
    }

    static void Minimum(int f, int g, int h, out int d)
    {
        d= Math.Min(h, Math.Min(f, g));
    }

    static void Main()
    {
        Console.WriteLine("Enter first number: ");
        string input1 = Console.ReadLine();

        ParseIntOrDefault(input1, out var intValue1, 0);

        Console.WriteLine("Enter second number: ");
        string input2 = Console.ReadLine();

        ParseIntOrDefault(input2, out var intValue2, 0);

        var max = Maximum(intValue1, intValue2);
        Console.WriteLine($"Мaximum: {max}");

        var min = Minimum(intValue1, intValue2);
        Console.WriteLine($"Мinimum: {min}");

        //TODO: Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd, otherwise false, sum return as out parameter

        Console.WriteLine("\nEnter first number for sum: ");
        var n1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number for sum: ");
        var n2 = Convert.ToInt32(Console.ReadLine());

        var isOdd = TrySumIfOdd(n1, n2, out var Summa);

        Console.WriteLine($"Sum: {Summa} ");
        if(isOdd)
        {
            Console.Write("is Odd.");
        }
        else
        {
            Console.WriteLine("isn't Odd.");
        }

        //TODO:Overload first two methods with 3 and 4 parameters
        Console.WriteLine("\nEnter 1st number: ");
        int a1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter 2nd number: ");
        int b1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter 3rd number: ");
        int c1 = Convert.ToInt32(Console.ReadLine());

        var max1 = Maximum (a1, b1, c1);
        Console.WriteLine($"Мaximum: {max1}");

        var min1 = Minimum (a1, b1, c1);
        Console.WriteLine($"Мinimum: {min1}");

        //4 parametrs

        Console.WriteLine("\nEnter 1st number: ");
        int a2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter 2nd number: ");
        int b2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter 3rd number: ");
        int c2 = Convert.ToInt32(Console.ReadLine());


        Maximum(a2, b2, c2, out int d2);
        Console.WriteLine($"Мaximum: {d2}");

        Minimum(a2, b2, c2, out int d3);
        Console.WriteLine($"Мinimum: {d3}");

    }
}