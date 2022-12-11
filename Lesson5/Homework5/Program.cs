using System;
using System.Collections.Generic;


//HOMEWORK
//1.Find the greatest common divisor of two positive integers.
//The inputs x and y are always greater or equal to 1, so the greatest common divisor will always be an integer that is also greater or equal to 1.
//2. The sum of the primes below or equal to 10 is 2 + 3 + 5 + 7 = 17. Find the sum of all the primes below or equal to the number passed in.
//EXTRA:
//Do using recursion
namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 0, B = 0, C = 0;
            int d = 1;
            try {
                Console.WriteLine("Input A (Positive Inreger only)"); A = int.Parse(Console.ReadLine().ToString());
                Console.WriteLine("Input B (Positive Inreger only)"); B = int.Parse(Console.ReadLine().ToString());
                Console.WriteLine("Since we already here. Input, also, Number for primes selection (Positive Inreger only)"); C = int.Parse(Console.ReadLine().ToString());
            }
            catch (FormatException) {
                Console.WriteLine("Your value is unexceptable. GOODBAY!");
                Environment.Exit(0); }
            if (A == 0 || B == 0) { Console.WriteLine("Zero enter"); Environment.Exit(0); }

            //Vprava 1
            //Rekursiinyi poshuk naibilshogo spilnogo dilnyka
            Divsion(A, B);
            void Divsion(int x, int y)
            {
                if (x % 2 == 0 && y % 2 == 0) { d *= 2; Divsion(x / 2, y / 2); }
                else if (x % 3 == 0 && y % 3 == 0) { d *= 3; Divsion(x / 3, y / 3); }
                else if (x % 5 == 0 && y % 5 == 0) { d *= 5; Divsion(x / 5, y / 5); }
                else if (x % 7 == 0 && y % 7 == 0) { d *= 7; ; Divsion(x / 7, y / 7); }
            }
            Console.WriteLine("\nDivider =" + d);


            //Vprava 2
            List<int> L = new List<int>();
            for (int i = 2; i <= C; i++) L.Add(i);
            Primes(ref L, 2);
            int Sum = 0;

            //Rekusiinyi poshuk prostyh chysel
            void Primes(ref List<int> numbers, int d1)  {
                for(int i = numbers.Count-1; i >=2; i--)
                    if (numbers[i] % d1 == 0 && numbers[i] != d1) numbers.RemoveAt(i);
                d1 += 1;
                if (d1 <= C / 2) Primes (ref numbers, d1);//Rekursiya
            }

            foreach (var l in L) Sum += l;
            Console.WriteLine("Sum of primes =" + Sum);

        }
    }
}
