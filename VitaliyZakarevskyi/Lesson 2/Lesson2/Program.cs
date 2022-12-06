Console.WriteLine("Hello, Denys! :)");


byte by = 128;
short sh = 1024;
int i = -256000000;
int s = 200;
int x = 15;
uint longNumber = 3200000000;
long lo = -20323232;
ulong ulo = 2032032052;
float number = 2.14f;
decimal money = 5.1535367m;
short secondNumber = sh;

bool isAlive = false;
bool hasNoCar = true;
char l = 'l';

Console.WriteLine(!isAlive);
Console.WriteLine(by++);
Console.WriteLine(secondNumber);
Console.WriteLine(x - i);
Console.WriteLine(x * 2);
Console.WriteLine(x / 3);
Console.WriteLine(++by);
Console.WriteLine(x < i);
Console.WriteLine(x > i);
Console.WriteLine(by % 10);
Console.WriteLine(x^i);
Console.WriteLine(isAlive && hasNoCar);
Console.WriteLine(isAlive || hasNoCar);
isAlive = true;
Console.WriteLine(isAlive == hasNoCar);


//Math Homework
Console.WriteLine(-6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15);
Console.WriteLine(Math.Abs(x) * Math.Sin(x));
Console.WriteLine(2 * Math.PI * x);
Console.WriteLine(Math.Max(x, s));

DateTime now = DateTime.Now;
DateTime newYearDate = new DateTime(2023, 1, 1);
TimeSpan newYearCount = newYearDate - now;
Console.WriteLine("Today's date is " + now);
Console.WriteLine("It is only " + newYearCount.Days + " days left until New Year!");