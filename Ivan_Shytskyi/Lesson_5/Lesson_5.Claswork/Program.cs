
using System.Runtime.Serialization.Formatters;

class Program
{

    static int Factorial(int n)
    {
        int result = 1;
        for (int i = 1; i <= n; i++)
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

    static int Fibanachi(int n)
    {
        if (n == 0 || n == 1)
            return n;
        return Fibanachi(n - 1) + Fibanachi(n - 2);
    }

    static void Main()
    {
        Console.WriteLine("Lesson_5.Classwork");
        Console.WriteLine("Debuging");

        Console.Write("Factorial number:\nm = ");
        int k = int.Parse(Console.ReadLine());
        for (int j = 0; j < k; j++)
        {
            Console.WriteLine($"Factorial ({j}) = {Factorial(j)}");
        }

        Console.Write("FactorialRec number:\nm = ");
        int m = int.Parse(Console.ReadLine());
        for (int j = 0; j < m; j++)
        {
            Console.WriteLine($"Factorial ({j}) = {FactorialRec(j)}");
        }

        Console.Write("the length of the Fibanacci range:\nn = ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        Console.Write($"{Fibanachi(i)} ");
    }
}