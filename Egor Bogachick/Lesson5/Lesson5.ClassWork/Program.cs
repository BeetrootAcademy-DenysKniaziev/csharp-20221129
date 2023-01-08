sbyte b = 100;
int i = 1000;
ushort s = checked((ushort)i);

long ul = long.MaxValue - 512;
double d = ul;
ul = (long)d;

char c = 'h';
d = (int)c;

Console.WriteLine(d);
