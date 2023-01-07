 // See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int x = 5;
int y = 10;

if (x < y)
{
    int sum = 0;
    for (int i = x; i <= y; i++)
    {
        sum += i;
        Console.WriteLine(sum);
    }
}
if (x > y)
{
    int sum = 0;
    for (int i = y; i <= x; i++)
    {
        sum += i;
        Console.WriteLine(sum);
    }
}