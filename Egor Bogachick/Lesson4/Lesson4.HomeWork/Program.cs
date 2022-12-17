using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static int MaxValue(int first, int second)
    {
        return Math.Max(first, second);
    }

    static int MaxValue(int first, int second, int third)
    {
        return Math.Max(Math.Max(first, second), third);
    }
    static int MaxValue(int first, int second, int third, int fourth)
    {
        return Math.Max(Math.Max(first, second), Math.Max(third, fourth));
    }

    static int MinValue(int first, int second)
    {
        return Math.Min(first, second);
    }
    static int MinValue(int first, int second, int third)
    {
        return Math.Min(Math.Min(first, second), third);
    }

    static int MinValue(int first, int second, int third, int fourth)
    {
        return Math.Min(Math.Min(first, second), Math.Min(third, fourth));
    }

    static void TrySumIfOdd(int first, int second)
    {
        if ((first + second) % 2 != 0)
        {
            return true;
        }
        return false;
    }

    static string Repeat(int value, string str)
    {
        string text;
        for (int i = 0; i < value; i++)
        {

            text += str;
        }
        return text;
    }

    static void Main()
    {
        Console.WriteLine(MaxValue(3, 5));
        Console.WriteLine(MinValue(3, 4));
        Console.WriteLine(TrySumIfOdd(4, 5));
        Repeat(4, "Да");
    }
}