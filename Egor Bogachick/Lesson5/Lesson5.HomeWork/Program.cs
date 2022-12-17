//greatest common divisor

Console.Write("Enter first value: ");
var first = int.Parse(Console.ReadLine());
Console.Write("Enter second value: ");
var second = int.Parse(Console.ReadLine());
int temp = 0;
for (int i = Math.Min(first, second); i > 0; i--)
{
    if (first % i == 0 && second % i == 0)
    {
        temp = i;
        break;
    }
}
Console.WriteLine($"Answer: {temp}\n");


//sum of the primes

Console.Write("Enter value: ");
var value = int.Parse(Console.ReadLine());
int res = 2;
int temp2 = 0;
Console.Write($"Answer: {res}");
for (int i = 3; i <= value; i++)
{
    for (int j = 2; j < i; j++)
    {
        if (i % j == 0)
        {
            temp2 = 0;
            break;
        }
        else
        {
            temp2 = i;
        }
    }
    if (temp2 != 0)
    {
        Console.Write($" + {temp2}");
    } 
    res += temp2;
}

Console.Write($" = {res} \n");