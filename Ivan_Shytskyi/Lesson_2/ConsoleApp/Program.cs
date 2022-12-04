Console.WriteLine("Lesson 2 homework");

// Tyapes

// Integral numeric types

sbyte num1 = -1; // -128 to 127  1 byte
byte num2 = 1; // 0 to 255   1 byte
short num3 = -2; // -32768 to 32767  2 bytes
ushort num4 = 2; // 0 to 65,535  2 bytes
int num5 = -3; // -2,147,483,648 to 2,147,483,647  4 bytes
uint num6 = 3; // 0 to 4,294,967,295  4 bytes
long num7 = -4; // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807  4 bytes
ulong num8 = 4; // 0 to 18,446,744,073,709,551,615   4 bytes
Console.WriteLine($"\nIntegral numeric types\n\nsbyte ({num1}) - diapason -128 to 127\nbyte ({num2})   - diapason 0 to 255\nshort ({num3}) - diapason -32768 to 32767\nushort ({num4}) - diapason  0 to 65,535" +
                  $"\nint ({num5})   - diapason -2,147,483,648 to 2,147,483,647\nuint ({num6})   - diapason 0 to 4,294,967,295\nlong ({num7})  - diapason -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807" +
                  $"\nulong ({num8})  - diapason 0 to 18,446,744,073,709,551,615");
Console.WriteLine("---------------------------------------------------------------------------------------");

//Floating-point numeric types

float num9 = 1.1f; // ±1.5 x 10^−45 to ±3.4 x 10^38  4 bytes
double num10 = 2.2; // ±5.0 × 10^−324 to ±1.7 × 10^308  8 bytes
decimal num11 = 3.3m; // ±1.0 x 10^-28 to ±7.9228 x 10^28  16 bytes
Console.WriteLine($"\nFloating-point numeric types\n\nfolat({num9})    - diapason ±1.5 x 10^−45 to ±3.4 x 10^38\ndouble ({num10})  - diapason ±5.0 × 10^−324 to ±1.7 × 10^308" +
                  $"\ndecimal ({num11}) - diapason ±1.0 x 10^-28 to ±7.9228 x 10^28");
Console.WriteLine("---------------------------------------------------------------------------------------");

//symbol type

char s = 'a'; //2 bytes
Console.WriteLine($"\nsymbol type\n\nchar ({s}) - only one symbol");
Console.WriteLine("---------------------------------------------------------------------------------------");

//Boolean type

bool b = true;
bool b1 = false;
Console.WriteLine($"\nBoolean type\n\nb = {b}\nb1 = {b1}");
Console.WriteLine("---------------------------------------------------------------------------------------");

//Math operations

int x = 3;
int y1 = x;
x++;
int y2 = x;
x--;
++x;
int y3 = x;
--x;
int y4 = x;
int q = x + y4;
int w = x - y4;
int e = q * q;
int t = e / q;
int u = 20;
int i = u % t;
Console.WriteLine($"\nMath operations\n\nx = {x}" +
                  $"\ny = x++ = {y1} after that x++    -> x = 4" +
                  $"\ny = x-- = {y2} after that x--    -> x = 3" +
                  $"\ny = ++x = {y3} before that ++x   -> x = 4" +
                  $"\ny = --x = {y4} before that --x   -> x = 3" +
                  $"\nx + y = q    -> {x} + {y4} = {q}" +
                  $"\nx - y = w    -> {x} - {y4} = {w}" +
                  $"\nq * q = e    -> {q} * {q} = {e}" +
                  $"\ne / q = t    -> {e} / {q} = {t}" +
                  $"\ni = u % t    -> i = {u} % {t} -> i = {i}");
bool a = e > t;
bool f = e / q == t;
bool g = e < q * w;
bool h = e >= e;
bool j = w <= e;
bool k = q != q;
Console.WriteLine($"{e} > {t} - {a}" +
                  $"\n{e} / {q} == {t} - {f}" +
                  $"\n{e} < {q} * {w} - {g}" +
                  $"\n{e} >= {e} - {h}" +
                  $"\n{w} <= {e} - {j}" +
                  $"\n{q} != {q} - {k}");
int c = 5;
Console.WriteLine($"c = {c}");
Console.WriteLine($"c << 1, c = {c<<1}");
Console.WriteLine($"c >> 1, c = {c>>1}");
Console.WriteLine($"6 & 4     -> {6 & 4}");
Console.WriteLine($"6 | 4     -> {6 | 4}");
Console.WriteLine($"6 ^ 4     -> {6 ^ 4}");
Console.WriteLine($"2 > 1 && 2 < 1     -> {2 > 1 && 2 < 1}");
Console.WriteLine($"2 > 1 || 2 < 1     -> {2 > 1 && 2 < 1}");
Console.WriteLine($"(2 > 1 || 2 < 1) && 2 < 1     -> {(2 > 1 || 2 < 1) && 2 > 1}");

int n = 3;
Console.WriteLine($"n = {n}");
n += 5;
Console.WriteLine($"n += 5    -> n = {n}");
int m = n;
Console.WriteLine($"m = {m}");
m -= 5;
Console.WriteLine($"m -= 5    -> m = {m}");
m *= 2;
Console.WriteLine($"m *= 2    -> m = {m}");
m /= 3;
Console.WriteLine($"m /= 3    -> m = {m}");
Console.WriteLine("---------------------------------------------------------------------------------------");


//Task
double l = 60;
Console.WriteLine($"l = {l}");
double p = Math.Abs(l) * Math.Sin(l);
Console.WriteLine($"y = Abs(l) * Sin(l), y = {p}");
Console.WriteLine("---------------------------------------------------------------------------------------");
double o = 2 * Math.PI * l;
Console.WriteLine($"o = 2 * PI * l, o = {o}");
Console.WriteLine("---------------------------------------------------------------------------------------");
double q1 = Math.Max(p, o);
Console.WriteLine($"Max value is {p}? or Max value is {o}? \nMax value is {q1}");
Console.WriteLine("---------------------------------------------------------------------------------------");
Console.WriteLine("how many days left to New Year?");
int X = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("how many days passed from New Year");
//int Y = Convert.ToInt32(Console.ReadLine());
int Y = 365 - X;
Console.WriteLine($"{X} - days left to New Year\n{Y} - days passed from New Year");


Console.ReadKey();