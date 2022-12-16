//using System;

class Program
{

    //static int Factorial(int n)
    //{
    //    var result = 1;
    //    for (int i = 1; i <= n; i++)
    //    {
    //        result *= i;
    //    }
    //    return result;
    //}

    //static int FactorialRec(int n)
    //{
    //    if (n <= 1)
    //        return 1;

    //    return n * FactorialRec(n - 1);
    //}

    //static int Fibonachi(int n)
    //{
    //    if (n == 0 || n == 1) return n;

    //    return Fibonachi(n - 1) + Fibonachi(n - 2);
    //}

    //static int GreatestCommonDivisor(int x, int y)
    //{

    //    if (y == 0) return x;
    //    return GreatestCommonDivisor(y, x%y) ;
            
      
    //}

    static int PrimeNumSum(int z)
    {
        var result = 2;
        for (int i=3;i<=z;i++)
        {
            if (i>3&&(i % 2 == 0||i % 3 == 0)) continue;
            if (i > 5 && i % 5 == 0) continue;
            result +=i;
            Console.WriteLine($"{i} {result}");
        }
        
        return result;
     

    }


    static void Main()
    {

        //var n = 10;
        //var d = Fibonachi(n);

        //Console.WriteLine(d);


        //var x = 1342;
        //var y = 56588;

        //Console.WriteLine($"Greater common divisor {x} & {y} is {GreatestCommonDivisor(x, y)}");

        var z = 51;

        Console.WriteLine(PrimeNumSum(z));




    }













}