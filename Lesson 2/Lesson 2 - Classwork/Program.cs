// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Integral numeric types (C# reference)

sbyte sb = -1; //-128 to 127	Signed 8-bit integer	
short s = -1; //-32,768 to 32,767	Signed 16-bit integer
int i = -2; //-2,147,483,648 to 2,147,483,647	Signed 32-bit integer
long l = -3; //-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807	Signed 64-bit integer

byte b = 1; //0 to 255	Unsigned 8-bit integer
ushort us = 2; //0 to 65,535  Unsigned 16 - bit integer
uint ui = 3; //0 to 4,294,967,295	Unsigned 32-bit integer	
ulong ul = 4; //0 to 18,446,744,073,709,551,615	Unsigned 64-bit integer

//floating-point types 

float f = 1.1f; //±1.5 x 10−45 to ±3.4 x 1038	~6-9 digits	4 bytes
double d = 2.2; //±5.0 × 10−324 to ±1.7 × 10308	~15-17 digits	8 bytes
decimal m = 3.3m; //±1.0 x 10-28 to ±7.9228 x 1028	28-29 digits	16 bytes	 

bool b1 = true;
bool b2 = false;

Console.WriteLine(b);
Console.WriteLine(s);
Console.WriteLine(m);

Console.WriteLine(b1);
Console.WriteLine(b2);

//Operations

//unary

int x1 = 1;
int y1 = -x1;

Console.WriteLine(y1);

int x2 = 1;

Console.WriteLine(++x2);
Console.WriteLine(x2--);
Console.WriteLine(x2);

bool x3 = true;

int x4 = 7;
int x5 = 3;

Console.WriteLine("{0} {1} {2}", x4 * x5, x4 / x5, x4 % x5);

Console.WriteLine("{0} {1} {2}", x4, 2<<x4, x4>>3);

Console.WriteLine("{0} {1} {2} {3}", 3<4, 3==4, 3!=4, 3>=4);

Console.WriteLine("{0} {1} {2} {3}", 3&4, 3|4, 3^4, 4^4);

Console.WriteLine("{0} {1} {2}", b1 && b2, b1 || b2, (b1 || b2) && b2);

int y4 = x4;
x4 += y4;

Console.WriteLine(x4);

x4 <<= y4;

Console.WriteLine(x4);

Console.ReadKey();