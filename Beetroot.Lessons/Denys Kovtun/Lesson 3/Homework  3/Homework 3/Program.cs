#region Count the sum of all numbers between

Console.WriteLine("Count the sum of all numbers between your values");

int x = int.Parse(Console.ReadLine());

int y = int.Parse(Console.ReadLine());

int maxValue = Math.Max(x, y);

int minValue = Math.Min(x, y);

int sum = 0

while (minValue + 1 < maxValue)
{
    sum = sum + minValue;

    minValue++
}

Console.WriteLine("Sum of all numbers between your values:" + sum);

Console.ReadLine();    
#endregion