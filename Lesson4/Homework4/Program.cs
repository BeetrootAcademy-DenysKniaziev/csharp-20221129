// See https://aka.ms/new-console-template for more information
//using System.Threading;

//Define and call with different parameters next methods:

//Method that will return max value among all the parameters
//… min value …
//Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd, otherwise false, sum return as out parameter
//Overload first two methods with 3 and 4 parameters
//Extra:

//Define and call with different parameters next methods:

//Method Repeat that will accept string X and number N and return X repeated N times (e.g. Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)

using System;
//using static Data_Structures_Console.AbstractAndInterface;
//using static Data_Structures_Console.AbstractAndInterface;

namespace functions
{

    class Program
    {
        public static class OneGoodClass
        {

            public static decimal Pmax(decimal[] numb)
            { return numb.Max(); }

            public static decimal Pmin(decimal[] numb)
            { return numb.Min(); }

            public static decimal Pmax(decimal a, decimal b, decimal c)
            { return Math.Max(Math.Max(a, b), c); }

            public static decimal Pmax(decimal a, decimal b, decimal c, decimal d)
            { return Math.Max(Math.Max(Math.Max(a, b), c),d); }

            public static decimal Pmin(decimal a, decimal b, decimal c)
            { return Math.Min(Math.Min(a, b), c); }

            public static decimal Pmin(decimal a, decimal b, decimal c, decimal d)
            { return Math.Min(Math.Min(Math.Min(a, b), c), d); }

            public static bool TrySumIfOdd(out int aa,out int bb) {
                aa = 3; bb = 2;
                if ((aa + bb )% 2 != 0) return true;
                else return false;
            }

            public static string Repeat(string text, int reps)  {
                string newtext ="";
                for(int i = 1; i <= reps; i++)
                { newtext += text; }
                return newtext;
            }
        }

        public static void Main(string[] args)
        {
            decimal[] numb = { 4, 7, 10 };
            //decimal Pmax = takeMax(decimal a, decimal b) => Math.Max(a,b)
            //.Aggregate(1, (int interim, int next) => interim * next);

            Console.WriteLine(OneGoodClass.Pmax(numb));
            Console.WriteLine(OneGoodClass.Pmax(2, 3, 5));
            Console.WriteLine(OneGoodClass.Pmax(2, 7, 5, 3));
            Console.WriteLine(OneGoodClass.TrySumIfOdd(out int a, out int b));
            Console.WriteLine(OneGoodClass.Repeat("_BeetRoot",3));

        }
    }
}

