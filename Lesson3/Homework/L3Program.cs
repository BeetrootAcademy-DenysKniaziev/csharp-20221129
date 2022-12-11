cd .// See https://aka.ms/new-console-template for more information
using System;

//const
int X = 0, Y = 0;
try
{
    Console.WriteLine("Please enter INT number for X: ");
    X = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Please enter INT number for Y: ");
    Y = Int32.Parse(Console.ReadLine());
    //Console.WriteLine();
}
catch (FormatException)
{
    Console.WriteLine($"Number that you entered is not INT type, so GOODBAY!");
    Environment.Exit(0);
}

int sum = 0;
if (X == Y) Console.WriteLine("X and Y equal, so lets pretend that SUM = " + X);
else
{
    for (int i = Math.Min(X, Y); i <= Math.Max(X, Y); i++)
    {
        sum += i;
    }
    Console.WriteLine("Sum = " + sum);
}

