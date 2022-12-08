byte b = 1;
short s = 34;
int i = 9;
long l = 678;

sbyte sb = -5;
ushort us = 5;
uint ui = 5;
ulong ul = 6;

float f = 1.1f;
double d = 2.3;
decimal m = 2.4m;

bool b1 = false;
bool b2 = true;

int x1 = -b;

b++;
++b;

Console.WriteLine(b);

int x2 = 5;
int x3 = 10;
Console.WriteLine(x2 * x3);
Console.WriteLine(x2 / x3);
Console.WriteLine(x2 % x3);

Console.WriteLine(x2 << 2);
Console.WriteLine(x2 >> 2);

Console.WriteLine(x2 > x3);
Console.WriteLine(x2 < x3); 
Console.WriteLine(x2 == x3);
Console.WriteLine(x2 != x3);

Console.WriteLine(x2 & x3);
Console.WriteLine(x2 ^ x3);

Console.WriteLine(b1 && b2);