Console.Write("Введіть значення х:");
int x = int.Parse(Console.ReadLine());

Console.Write("Введіть значення y:");
int y = int.Parse(Console.ReadLine());

int sum = Math.Min(x, y);
int i = Math.Min(x, y);

while (i != Math.Max(x, y))
{
    i++;
    sum += i;
};

Console.Write($"Сумма= {sum}");
