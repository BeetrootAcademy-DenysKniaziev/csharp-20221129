//The greatest common divisor

while (true)
{
    Console.Clear();
    Console.Write("Enter first value: ");
    var x = uint.Parse(Console.ReadLine());
    Console.Write("Enter second value: ");
    var y = uint.Parse(Console.ReadLine());

    var z = 0;
    for (int i = 1; i <= Math.Min(x, y); i++)
    {
        if (x % i == 0 && y % i == 0)
        {
            z = i;
        }
    }
    Console.WriteLine($"The greatest common divisor is {z}!");

    //The sum of the primes
    int z1 = 0;
    int res = 0;
    Console.Write("\nEnter your value: ");
    uint num = uint.Parse(Console.ReadLine());

    for (int i = 2; i <= num; i++)
    {
        for (int k = 2; k < i; k++)
        {
            if (i % k != 0)
            {
                z1 = i;
            }
            else
            {
                z1 = 0;
                break;
            }
        }
        res += z1;
    }
    Console.WriteLine($"The sum of the primes below or equal to {num} is {res + 2}!");
    Console.ReadLine();
}






