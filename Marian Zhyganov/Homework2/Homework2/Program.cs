System.

Console.WriteLine("int\n");
int a = 7;
int b = 8;
int c = a + b;
Console.WriteLine(c);

Console.WriteLine("decimal\n");
decimal d = 18m;
decimal e = 14m;
decimal f = (e + d) / 2;
Console.WriteLine(f);

Console.WriteLine("string\n");
string name = "Marian";
string lastName = "Zhyganov";
Console.WriteLine($"My name is {name} {lastName}");
Console.WriteLine(name + "\t" + lastName);

Console.WriteLine("float\n");
float n = 14;
float n1 = -198;
float n2 = (n * n1) % 2 ;
Console.WriteLine(n2);

Console.WriteLine("short\n");

short s = 12;
short s1 = -11;
Console.WriteLine(s > s1);
Console.WriteLine(s1 >= s);
Console.WriteLine(s1 == s);



/*
 * Task 1
 * -6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15 
 */
Console.WriteLine("Task 1");
int x = 0;
int a1 = (int)(-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15);
Console.WriteLine($"-6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15 = {a1} \n");

/*
 * Task 2
 * abs(x)*sin(x)
 */
Console.WriteLine("Task 2");
double a2 = Math.Abs(x) * Math.Sin(x);
Console.WriteLine($"abs(x)*sin(x) = {a2}\n");

/*
 * Task 3
 * 2*pi*x
 */
Console.WriteLine("Task 3");
double a3 = 2 * Math.PI * x;
Console.WriteLine($"2*pi*x = {a3}\n");

/*
 * Task 4
 * max(x, y)
 */
Console.WriteLine("Task 3");
int y = 10000;
int a4 = Math.Max(x, y);
Console.WriteLine($"max(x, y) = {a4}\n");

/*
 * Task Extra
 * 
 */
Console.WriteLine("Task Extra ");
DateTime data0 = new DateTime(2022, 01, 01);
DateTime date1 = new DateTime(2023,01,01);
DateTime date2; date2 = DateTime.Now;
TimeSpan date3 = date1 - date2;
TimeSpan data4 = date2 - data0;
Console.WriteLine($"time afte  the new year: {data4}");
Console.WriteLine($"time for the new year: {date3}");