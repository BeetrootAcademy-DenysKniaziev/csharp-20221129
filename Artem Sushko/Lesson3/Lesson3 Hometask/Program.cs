Console.WriteLine("Enter values");

if (!int.TryParse(Console.ReadLine(), out var x) || !int.TryParse(Console.ReadLine(), out var y))
{
    Console.WriteLine("Invalid input");
}
else
{

    int min, max;
    int sum = 0;

    if (x != y)
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
        for (int i = min; i <= max; i++)
        {
            sum += i;
        }
        Console.WriteLine("Sum of numbers: " + sum);
    }
    else
    {
        Console.WriteLine("Sum: " + x);
    }
}