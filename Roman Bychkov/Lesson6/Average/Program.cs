int[,] arr = new int[5, 5];
for (int i = 0; i < arr.GetLength(0); i++)
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        arr[i, j] = new Random().Next(1, 10);
    }

Console.WriteLine("Array:");
for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        Console.Write($"{arr[i, j].ToString().PadLeft(1, '0')} ");
    }
    Console.WriteLine();
}
Console.WriteLine();

Console.WriteLine($"First:\nAvg Sum = {First(arr)}\n");
Console.WriteLine($"Second:\nAvg Sum = {Second(arr)}\n");
Console.WriteLine($"Third:\nAvg Sum = {Third(arr)}\n");


static double First(int[,] arr)
{
    int sum = 0, count = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < i + 1; j++)
        {
            sum += arr[i, j];
            count++;
            Console.Write($"{arr[i, j].ToString().PadLeft(1, '0')} ");
        }
        Console.WriteLine();
    }
    return (double)sum / count;
}
static double Second(int[,] arr)
{
    int sum = 0, count = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1) - i; j++)
        {
            sum += arr[i, j];
            count++;
            Console.Write($"{arr[i, j].ToString().PadLeft(1, '0')} ");
        }
        Console.WriteLine();
    }
    return (double)sum / count;
}

static double Third(int[,] arr)
{
    int sum = 0, count = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = i; j < arr.GetLength(1) - i; j++)
        {
            sum += arr[i, j];
            count++;
            Console.Write($"{arr[i, j].ToString().PadLeft(1, '0')} ");
        }
        Console.WriteLine();
        for (int j = arr.GetLength(1) - i - 1; j <= i; j++)
        {
            sum += arr[i, j];
            count++;
            Console.Write($"{arr[i, j].ToString().PadLeft(1, '0')} ");
        }
    }
    return (double)sum / count;
}