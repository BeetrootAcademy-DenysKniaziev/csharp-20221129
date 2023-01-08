// Main Task --------------------------------------
Console.Write("Enter X number: ");
double x = double.Parse(Console.ReadLine());

Console.Write("Enter Y number: ");
double y = double.Parse(Console.ReadLine());
Console.WriteLine();

double first = (-6 * Math.Pow(x, 3)) + (5 * Math.Pow(x, 2)) - (10 * x) + 15;
double second = Math.Abs(x) * Math.Sin(x);
double third = 2 * Math.PI * x;
double fourth = Math.Max(x, y);

Console.WriteLine("First result: " + Math.Round(first, 2));
Console.WriteLine("Second result: " + Math.Round(second, 2));
Console.WriteLine("Third result: " + Math.Round(third, 2));
Console.WriteLine("Fourth result: " + Math.Round(fourth, 2));
Console.WriteLine();

// DateTime Task -----------------------------------
DateTime now = DateTime.Now;
DateTime previusNY = new DateTime(2022, 1, 1);
DateTime nextNY = new DateTime(2022, 12, 31);

int leftDays = (nextNY - now).Days;
int passedDays = (now - previusNY).Days;

Console.WriteLine($"{leftDays} days left to New Year");
Console.WriteLine($"{passedDays} days passed from New Year");