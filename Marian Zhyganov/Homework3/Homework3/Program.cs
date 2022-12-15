Console.Write("please enter first number: ");
int x = int.Parse(Console.ReadLine());
Console.Write("please enter second number: ");
int y = int.Parse(Console.ReadLine());

int min, max, sum = 0; ;


if (x != y)
{
    if (x > y)
    {
        max = x;
        min = y;

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
}

Console.WriteLine($"Your of numbers: {sum}");
