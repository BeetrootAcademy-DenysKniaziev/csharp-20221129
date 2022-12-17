
class Program
{

    static int GreComDiv(int x, int y)
    {
        if (x==0) return y;
        while (y != 0)
        {
            int tmp1;
            if (x > y)
            {
                tmp1 = x % y;
            }
            else
            {
                tmp1 = y % x;
            }
            x = y;
            y = tmp1;
        }
        return x;

    }






    static int GreComDivRec(int x, int y)
    {
        if (y == 0) return x;
        return GreComDivRec(y, x % y);
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

            //Console.WriteLine($"{tmp} {result}");
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

        Console.WriteLine("Input 2 integers for")
       
        var x = 59;
        var y = 81;

        Console.WriteLine($"Greater common divisor {x} & {y} is {GreComDiv(x, y)}  ({GreComDivRec(x, y)})");

        var z = 10;

        Console.WriteLine(PrimeNumSum(z));

        var number = z;

        Console.WriteLine(); 

        Console.WriteLine(PrimeSumRec(number));



    }



}