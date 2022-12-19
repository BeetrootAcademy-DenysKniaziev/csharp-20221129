using System;

class Program
{
    static int Get(string text)
    {
        bool IsItANumber = false;
        int x = 0;
        Console.WriteLine(text);

        do
        {
            IsItANumber = int.TryParse(Console.ReadLine(), out x);

        } while (!IsItANumber);

        return x;
    }

    static bool checkPrime(int numberToCheck)
    {
        if (numberToCheck == 1)
        {
            return false;
        }
        for (int i = 2;
                 i * i <= numberToCheck; i++)
        {
            if (numberToCheck % i == 0)
            {
                return false;
            }
        }
        return true;
    }


    static int primeSum(int l, int r)
    {
        int sum = 0;
        for (int i = r; i >= l; i--)
        {

            bool isPrime = checkPrime(i);
            if (isPrime)
            {
                sum = sum + i;
            }
        }
        return sum;
    }

    static void Main()
    {
        string text = "Enter number:";
        int x = Get(text);

        Console.WriteLine($"The sum of the primes below or equal {x} is: {primeSum(0, x)}");
    }
}

