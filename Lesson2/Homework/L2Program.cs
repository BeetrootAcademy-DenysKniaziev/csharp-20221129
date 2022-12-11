// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using static System.Console;
using static System.Math;
using System.Security.Cryptography.X509Certificates;

using System;

WriteLine("Hello, Beetroot!");
byte B = 127;
short S = 32676;
int I = 2000000000;
long L = -99999999999;
bool Boo = true;
char C = 'c';
float F = 1234567890;
double D = 34567899999999;
decimal Dc = -50000000000000000;
string St = "up";

//git

WriteLine((B + S + I / B / (S * S * S * S * S) - L / I - F / 100).ToString());
string CSt = C + St;
WriteLine(C + "+" + St + "=" + CSt);


WriteLine("Which 'X' do you like?  (just int numbers excepted)");
int X;
//object SomeX;

try
{
    X = Int32.Parse(ReadLine());
    //Console.WriteLine();
}
catch (FormatException)
{
    Console.WriteLine($"'X', that you entered is not INT type, so 'X' will be seted randomly");
    Random x = new Random();
    X = x.Next(1, 10);
}


WriteLine("if X=" + X + " Y=" + (-6 * Math.Pow(X, 3) + 5 * Math.Pow(X, 2) - 10 * X + 15));
WriteLine("abs(x) * sin(x) = " + (Math.Abs(X) + Math.Sin(X)));
WriteLine("2 * pi * x = " + (2 * Math.PI * X));
int Y = 5;
WriteLine(Math.Max(X, Y));

//for (int i = 1; i < 3; i++) {
//   Func<int, int> r = x => x * x; }
//int[] numbers = { 2, 3, 4, 5, 7 };
//var squaredNumbers = numbers.Select(x => x * x);
//Console.WriteLine(string.Join(" ", squaredNumbers));

DateTime DT = DateTime.UtcNow;
double DaysInThisYear = 365;// Just in case 
if (DT.DayOfYear % 4 == 0) DaysInThisYear = 366;
double ProcentsOfCurrentDay = ((100 / 24 * (24 - Convert.ToDouble(DT.Hour))) / 100);
WriteLine((DaysInThisYear - DT.DayOfYear + 1 - ProcentsOfCurrentDay) + " days left to New Year" + "\n" + (DT.DayOfYear - 1 + ProcentsOfCurrentDay) + " days passed from New Year");
WriteLine((DaysInThisYear - DT.DayOfYear + 1 - ProcentsOfCurrentDay) + (DT.DayOfYear - 1 + ProcentsOfCurrentDay) + " days in this year");