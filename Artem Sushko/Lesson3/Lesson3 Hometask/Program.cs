Console.WriteLine("Enter first value");
int x = int.Parse(Console.ReadLine());
Console.WriteLine("Enter second value");
int y = int.Parse(Console.ReadLine());

int min, max;
int sum = 0;

if (x!=y)
{
    if (x > y)
    {
        min = y;
        max = x;
    }
    else
    {
        min = x;
        max = y;
    }
    for(int i = min; i <= max; i++)
    {
        sum += i;
    }
    Console.WriteLine("Sum of numbers: " + sum);
}
else
{
    Console.WriteLine("Sum: " + x);
}