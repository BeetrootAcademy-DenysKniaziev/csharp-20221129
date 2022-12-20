using System;

namespace Lesson_5.Homework
{
    class Program
    {
        static int GCD (int x, int y)
        {
            int a = 0;

           
            if (x > y)
            {
                while (y != 0)
                {
                    int c = x % y;
                    x = y;
                    y = c;
                    a = x;
                }
            }
            else
            {
                while (x != 0)
                {
                    int c = y % x;
                    y = x;
                    x = c; ;
                    a = y;
                }
            }
           return a;
        }
        static int Suma(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i;
            }
            return sum;
        }
        static void Main()
        {
            Console.WriteLine("Lesson_5.Homework");

            //Task 1

            Console.WriteLine(" Find the greatest common divisor of two positive integers.\r\nThe inputs x and y are always greater or equal to 1," +
                                                       " so the greatest common divisor will always be an integer that is also greater or equal to 1.");
            Console.Write("Enter two positive integers:\nx = ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("y = ");
            int y = int.Parse(Console.ReadLine());
            int gcd = GCD(x, y);
            Console.WriteLine($"greatest common divisor is - {gcd}");

            //Task 2

            //Console.WriteLine(" The sum of the primes below or equal to 10 is 2 + 3 + 5 + 7 = 17. Find the sum of all the primes below or equal to the number passed in.");
            //Console.Write("Enter number\nn = ");
            //int n = int.Parse(Console.ReadLine());
            //int sum = Suma(n);
            //Console.WriteLine($"Suma = {sum}");
        }
    }
}