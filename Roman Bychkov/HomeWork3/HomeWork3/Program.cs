int sum=0, x=0, y=0;
Console.WriteLine("Enter the values of X and Y in enters");
if (!int.TryParse(Console.ReadLine(), out x) || !int.TryParse(Console.ReadLine(), out y))
{ 
    Console.WriteLine("Invalid input");
    return;
}

int min = Math.Min(x, y);
int max = Math.Max(x, y);

while(min<=max)
{
    sum += min;
    min++;
}
Console.WriteLine($"X={x}\tY={y}\nSum={sum}");
