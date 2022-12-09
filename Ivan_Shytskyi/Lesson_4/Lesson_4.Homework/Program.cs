using System.ComponentModel;

namespace Lesson_4.Homework
{
    internal class Program
    {
        static int MaxValue (int a, int b, int c) =>
            Math.Max(a, Math.Max(b, c));
        static int MinValue (int a,int b, int c, int d) =>
            Math.Min(a,Math.Min(b,Math.Min(c,d)));
        static bool TrySumIFOdd (int a, int b, out int sum)
        { 
            sum = a + b;
            if (sum%2!=0)
                return true;    
            else
                return false;   
        }
        static string Repeat(string str, int x)
        {
            if (x <= 1) return str; 
            return str + Repeat(str, x-1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson_4.Homework");

            Console.WriteLine("MAX + Overload (3 parameters)");
            Console.Write("num_1 = ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("num_2 = ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("num_3 = ");
            int p = int.Parse(Console.ReadLine());
            int x = MaxValue(m, k, p);
            Console.WriteLine($"MaxVlue = {x}");

            Console.WriteLine("MIN + Overload (4 parameters)");
            Console.Write("num_1 = ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("num_2 = ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("num_3 = ");
            int e = int.Parse(Console.ReadLine());
            Console.Write("num_4 = ");
            int r = int.Parse(Console.ReadLine());
            int y = MinValue(c, d, e, r);
            Console.WriteLine($"MinValue = {y}");

            Console.WriteLine("Odd");
            Console.WriteLine("Enter two number:");
            Console.Write("num_1 = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("num_2 = ");
            int b = int.Parse(Console.ReadLine());
            bool n = TrySumIFOdd(a, b, out int sum);
            Console.Write("Is Odd: ");
            Console.WriteLine(n == true ? true : false);
            Console.WriteLine($"Sum = {sum}");

            string u = Repeat("str", 4);
            Console.WriteLine(u);
        }
    }
}