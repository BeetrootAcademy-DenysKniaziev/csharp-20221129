decimal m1 = 503m;
float f1 = 4.1f;
double d1 = 0.5d;
char c1 = 'c';
string s1 = "string";
int i1 = 31, i2 = -5;

Console.WriteLine(i1 * d1);
Console.WriteLine(i1 * 0);
Console.WriteLine(i1 + i2);
Console.WriteLine(i1 - i2);
Console.WriteLine(m1++ + (++m1));
Console.WriteLine(++f1 + f1++);
Console.WriteLine("============");
Console.WriteLine(m1);
Console.WriteLine((m1 + 3.5m) % 5);

int a1 = int.MaxValue, a2 = 1;
Console.WriteLine(a1 + a2);

Console.WriteLine(d1 * a1 * 50);

int x = 5, y = 3;

double result1 = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
double result2 = Math.Abs(x) * Math.Sin(x);
double result3 = 2 * Math.PI * x;
double result4 = Math.Max(x, y);

Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);
Console.WriteLine(result4);


DateTime now = DateTime.Now;
DateTime newYear = new DateTime(now.Year + 1, 1, 1);
Console.WriteLine($"{(newYear - now).Days} days left to New Year");
Console.WriteLine($"{now.DayOfYear} days passed from New Year");