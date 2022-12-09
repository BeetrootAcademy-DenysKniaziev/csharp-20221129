using System.Collections.Generic;

class program
{

    static int ValueMax(int frist, int second)
    {
        return Math.Max(frist, second);
    }

    static int ValueMax(int frist, int second, int third)
    {
        return Math.Max(frist, Math.Max(second, third));
    }

    static int ValueMin(int frist, int second)
    {
        return Math.Min(frist, second);
    }

    static bool TrySumIfOdd(int first, int second, out int sum)
    {
        sum = first + second;
        if (sum % 2 != 0)
        {
            sum = first + second;
            return true;
        }
        sum = first + second;
        return false;
    }

    static void Main()
    {
        while (true)
        {

            Console.Clear();
            Console.Write("Enter first value: ");
            var first = int.Parse(Console.ReadLine());
            Console.Write("\nEnter second value: ");
            var second = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nMax value: {ValueMax(first, second)}");
            Console.WriteLine($"\nMin value: {ValueMin(first, second)}");

            var ODD = TrySumIfOdd(first, second, out var sum);
            Console.WriteLine($"\nOdd: {ODD}, SUM: {sum}");

            Console.Write("\nEnter third value: ");
            var third = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nMax of all: {ValueMax(first, second, third)}");
            Console.ReadLine();
        }
        
    }
}