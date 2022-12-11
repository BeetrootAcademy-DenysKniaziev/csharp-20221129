//int x1 = 4;
//int y1 = 5;
//int z1;
//Console.WriteLine(x1 - (z1 = y1 += x1));

//float x2 = 4, y2 = 9;
//Console.WriteLine(y2 / x2);

//bool b1 = false;
//Console.WriteLine(!b1);
//bool b2 = true;

//string str = "hello ", str2 = "world";
//string str3 = str + str2;
//Console.WriteLine(str3);

//int x4 = y1 % x1;

//int y4 = 2 ^ 4;
//Console.WriteLine(x4);
//Console.WriteLine(y4);

//short x5 = -5;
//short y5 = 6;
//Console.WriteLine(x5 > y5);
//Console.WriteLine(x5 | y5);
//Console.WriteLine(x5 & y5);
//Console.WriteLine(Math.Abs(x5));


//Console.WriteLine((b1 == b2) && b2);
//Console.WriteLine((b1 == b2) || b2);

//float x6 = y5 / x5;
//Console.WriteLine(x6);
//Console.WriteLine(x6++);
//Console.WriteLine(x6);
//Console.WriteLine(++x6);

//float x7 = 1.5f;
//float y7 = x7++ / 2;
//double d1 = y7 / x7;
//Console.WriteLine(d1);


//        HOMETASK*

int x = -4;
int y = 5;


// 1 task
int z1 = (int)(6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15);
Console.WriteLine("-6*x^3+5*x^2-10*x+15 = " + z1);
// 2 task
double z2 = Math.Abs(x) * Math.Sin(x);
Console.WriteLine("abs(x)*sin(x) = " + z2);
// 3 task
double z3 = 2 * Math.PI * x;
Console.WriteLine("2*pi*x = " + z3);
// 4 task
int z4 = Math.Max(x, y);
Console.WriteLine("MAX VALUE = " + z4);

//        HOMETASK**

DateTime now = DateTime.UtcNow;
DateTime NewYear = new DateTime(2022, 12, 31, 23, 59, 59);
int today = now.DayOfYear;
Console.WriteLine($"{(NewYear.Subtract(now).Days)} days left to New Year");
Console.WriteLine($"{today} days passed from New Year");
