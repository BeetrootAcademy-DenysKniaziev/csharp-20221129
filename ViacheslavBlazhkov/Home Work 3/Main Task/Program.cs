int x = 0; int y = 0;

try
{
    Console.Write("Enter X value: ");
    x = int.Parse(Console.ReadLine());
    Console.Write("Enter Y value: ");
    y = int.Parse(Console.ReadLine());
}
catch
{
    Console.WriteLine("\nInvalid input !!!");
    return;
}

int sum = 0;
int min = Math.Min(x, y);

for (int i = min; i <= Math.Max(x, y); i++)
{
    sum += i;
    if (i > min) Console.Write(" + " + i);
    else if (i == min) Console.Write("\n" + i);
}

Console.WriteLine(" = " + sum);