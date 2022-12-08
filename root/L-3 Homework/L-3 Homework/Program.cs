using System.Text.RegularExpressions;

int d1;
int d2;
int sum = 0;

Console.WriteLine("Hi, bro!");
Console.WriteLine("You need to choose 2 positive integers, and I will calculate for you the sum of these numbers and all the numbers between them.If they are equal then sum should be one of them ");
Console.WriteLine("\nSo, what is your first number? ");


try
{
d1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nCool! What is your second number? ");
d2 = Convert.ToInt32(Console.ReadLine());


if (d1 == d2)
{
    sum = d1;
}
else
{
    for (int i = Math.Min(d1, d2); i <= Math.Max(d1, d2); i++)
    {
        sum += i;
    }
}

    Console.WriteLine("\nSum is: "+ sum);

}
catch (Exception ex)
{
    Console.WriteLine("\nIt's not a number, bro!");
}