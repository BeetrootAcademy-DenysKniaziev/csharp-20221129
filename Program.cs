int x = -2;
double y;
double w;
double s;
double p;

double toNY;
double fromNY;
DateTime now = DateTime.Now;

//TODO:
//-6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15
//abs(x) * sin(x)
//2 * pi * x
//max(x, y)

w = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
Console.WriteLine(w); //103 must be

y = Math.Abs(x) * Math.Sin(x);
Console.WriteLine(y); //-1.81859485365 must be

s = 2 * Math.PI * x;
Console.WriteLine(s); //-12.56 must be

p = Math.Max(x, y);
Console.WriteLine(p); //y must be

//TODO:
//X days left to New Year
//Y days passed from New Year

var NY22 = new DateTime(2022, 1, 1, 0, 0, 0);
var NY23 = new DateTime(2023, 1, 1, 0, 0, 0);

toNY = (NY23 - now).Days;
Console.WriteLine(toNY.ToString("0")+ " days left to New Year");

fromNY = (now - NY22).Days;
Console.WriteLine(fromNY.ToString("0") + " days passed from New Year");