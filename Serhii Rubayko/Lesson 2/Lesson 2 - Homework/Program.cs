#region integer numbers

byte b1 = 30;
byte b2 = 4;

Console.WriteLine(b1 / b2);

short s1 = -300;
short s2 = 105;

short s3 = short.MaxValue;
short s4 = short.MinValue;

double Result = s4 / s3;

Console.WriteLine("{0}/{1}={2}", short.MinValue, short.MaxValue, Result);

Console.WriteLine(s1 * s2);
Console.WriteLine(s1 % s2);

int i1 = 20000000;
int i2 = -3200000;

Console.WriteLine(i1 + (i2-s2));

long l1=i1*i2;
long L = long.MaxValue;

Console.WriteLine(l1^b2);
Console.WriteLine(L);

#endregion

#region Floating-point
float f1 = 1.5e4f;

bool bo1 = f1 == b1;

Console.WriteLine(bo1);

double d = (double)b1 / (double)b2;

Console.WriteLine((double)b1 / (double)b2);


decimal D = decimal.MaxValue;

Console.WriteLine("{0},{1},{2}", D, decimal.MinValue, 
    (double)decimal.MaxValue/double.MinValue);

#endregion

#region Char String
string a = "hello";
string b = "h";
// Append to contents of 'b'
b += "ello";
Console.WriteLine(a == b);
Console.WriteLine(object.ReferenceEquals(a, b));

string str = "bullsHit";

char ch = str[5];

Console.WriteLine(ch);

for (int i=0;i<str.Length; i++)
{
    Console.Write(str[i] + " ");
}

Console.WriteLine();

Console.WriteLine(Math.Abs(-4.7));

int x = 5;
int y = 10;
Console.WriteLine($"Max of betwin {x} and {y} is {Math.Max(x, y)}," +
    $" Min of betwin {x} and {y} is {Math.Min(x, y)}");
#endregion


double X = -2.71828;

double Y = -6 * Math.Pow(X, 3) + 5 * Math.Pow(X, 2) - 10 * X + 15;

Console.WriteLine(Y);

Console.WriteLine(Math.Abs(X)*Math.Sin(X));

Console.WriteLine(2*Math.PI *X);

Console.WriteLine($"Max of betwin {X} and {Y} is {Math.Max(X, Y)}");

var date1 = new DateTime (2022, 1, 1, 0, 0, 0);
var date2 = new DateTime (2023, 1, 1, 0, 0, 0);

var dateN = DateTime.Now;

TimeSpan passed = dateN - date1;
TimeSpan left = date2 - dateN;

Console.WriteLine("{0} days left to New Year", left.Days);
Console.WriteLine("{0} days left to New Year", passed.Days);

Console.ReadKey();