
class Program
{







    static int GreatestCommonDivisorRec(int x, int y)
    {
        if (y == 0) return x;
        return GreatestCommonDivisorRec(y, x % y);
    }


    static bool IsPrime(int number)
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }


    static int PrimeNumSum(int z)
    {
        int result = 2;
        /*var tmp = 3*/;
        for (int tmp = 3; tmp <= z; tmp++)
        {
           if (!IsPrime(tmp)) continue;
               result += tmp;

            Console.WriteLine($"{tmp} {result}");
        }

        return result;
    }



    static int PrimeSumRec(int number)
    {
        if (number<=2) return number;
        for (int i=2; i<number; i++)
        {
          if (number % i == 0)
             return PrimeSumRec(number - 1);
        }
        return number+PrimeSumRec(number-1);
    }






   


    static void Main()
    {

       
        var x = 1342;
        var y = 56588;

        Console.WriteLine($"Greater common divisor {x} & {y} is {GreatestCommonDivisorRec(x, y)}");

        var z = 1000;

        Console.WriteLine(PrimeNumSum(z));

        var number = z;

        Console.WriteLine(); 

        Console.WriteLine(IsPrimeSum(number));



    }



}