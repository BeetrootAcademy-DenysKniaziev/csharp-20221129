/* Lesson 2
 Homework */

//byte b1 = 20;
//byte b2 = 173;
//Console.WriteLine(b1+b2);

//short s1 = -17000;
//short s2 = 3800;
//Console.WriteLine(s1-s2);

//int i1 = 154000000;
//int i2 = 56;
//Console.WriteLine(i1/i2);

//long l1 = -158456;
//long l2 = 72;
//Console.WriteLine(l1*l2);

//bool bl1 = true;
//bool bl2 = true;
//bool bl3 = false;
//bool bl4 = false;

//Console.WriteLine(bl1&&bl2);
//Console.WriteLine(bl1 && bl3);
//Console.WriteLine(bl4 || bl3);
//Console.WriteLine(!bl1);


//char ch = '#';
//Console.WriteLine(ch);

//float f1 = 18.9f;
//double d1 = 27.3;
//decimal dc = 5.3m;

//Console.WriteLine(f1+d1);
//Console.WriteLine(f1/d1);

//string str1 = "Beetroot";
//Console.WriteLine(str1);

//int x1 = 5;

//Console.WriteLine(x1++); // виводить 5, потім інкрементує +1 / 5
//Console.WriteLine(x1); // виводить інкрементоване значення 6

//int x2 = 5;

//Console.WriteLine(++x2); // інкрементує а потім виводить 6

//Console.WriteLine(x1--); // виводить 5, потім інкрементує -1 / 4
//Console.WriteLine(x1); // виводить інкрементоване значення 4


//Console.WriteLine(--x2); // інкрементує а потім виводить 4

//bool x3 = true;
//Console.WriteLine(!x3);

//int x4 = -1;
//Console.WriteLine(!x4);

//int x4 = 14;
//int x5 = 3;
//Console.WriteLine(x4*x5);
//Console.WriteLine(x4 / x5);
//Console.WriteLine(x4 % x5);

//float x6 = 14f;
//decimal x7 = 3m;

//Console.WriteLine(x6 / x7);

//byte x8 = 14;
//byte x9 = 3;
//Console.WriteLine(x8/x9);



/* MATH */

//int x = -15;
//int a = Math.Abs(x);
//Console.WriteLine(a);

//int b = Math.Max(1, 10);
//Console.WriteLine(b);

//double c = Math.Sqrt(9);
//Console.WriteLine(c);

//double d = Math.Cbrt(27);
//Console.WriteLine(d);



/*task #2*/


// -6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15

int x = 2;
//double pow1 = Math.Pow(x, 3);
//double pow2 = Math.Pow(x, 2);
//Console.WriteLine(-6 * pow1 + 5 * pow2 - 10 * x + 15);
//Console.WriteLine(-6*Math.Pow(x,3)+5*Math.Pow(x,2)-10*x+15);


//abs(x)*sin(x)

//int a = Math.Abs(x);
//double b = Math.Sin(x);
//Console.WriteLine(a*b);
//Console.WriteLine(Math.Abs(x)*Math.Sin(x));


//2*pi*x

//Console.WriteLine(2*Math.PI*x);


//max(x, y)

//int y = 6;
//Console.WriteLine(Math.Max(x,y));



/* DateTime */

//DateTime dt = new DateTime(1988, 3, 26);
//dt = DateTime.Now;
//Console.WriteLine(dt);

//DateTime t = new();
//t = DateTime.Now;

////t = t.AddDays(2);


//TimeSpan ts = new TimeSpan(-5, 3, 0);

//t = t.Add(ts);
//Console.WriteLine(t);


/*task #3 */

DateTime date = DateTime.Today;
int daysInYear = DateTime.IsLeapYear(date.Year) ? 366 : 365;
int daysLeftInYear = daysInYear - date.DayOfYear;
Console.WriteLine($"{daysLeftInYear} days left to New Year");
Console.WriteLine($"{date.DayOfYear} days passed from New Year");
