Console.OutputEncoding = System.Text.Encoding.Unicode;

Console.Write("Введіть значення х:");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("Введіть значення y:");
int y = Convert.ToInt32(Console.ReadLine());

int sum = Math.Min(x, y);
int i = Math.Min(x, y);

while (i != Math.Max(x, y))
{
    i++;
    sum += i;
} ;

Console.Write($"Сумма= {sum}");