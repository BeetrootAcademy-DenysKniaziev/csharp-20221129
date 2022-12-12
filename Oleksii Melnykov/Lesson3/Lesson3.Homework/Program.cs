#region Lesson 3

#region IF ELSE SWITCH
using System;

//int a = 2;

//if (a == 5)
//{
//    Console.WriteLine("a = 5");
//}
//else if (a == 7)
//{
//    Console.WriteLine("a = 7");
//}
//else
//{
//    Console.WriteLine("a = else");
//}

//switch (a)
//{
//    case 5:
//        Console.WriteLine("a = case 5");
//        break;
//    case 7:
//        Console.WriteLine("a = case 7");
//        break;
//    default:
//        Console.WriteLine("a = case default");
//        break;
//}

//int b = 0;

//if (a == 5)
//{
//    b = a * 2;
//}
//else if (a == 7)
//{
//    b = a * 3;
//}
//else
//{
//    b = 1;
//}

//Console.WriteLine($"b = {b}");

//b = 0;

//switch (a)
//{
//    case 5:
//        b = a * 2;
//        break;
//    case 7:
//        b = a * 3;
//        break;
//    default:
//        b = 1;
//        break;
//}
//Console.WriteLine($"b = {b}");

//b = 0;

//b = a switch
//{
//    5 => a * 2,
//    7 => a * 3,
//    _ => 1,
//};

//Console.WriteLine($"b = {b}");

//if (a == 5)
//{
//    b = a * 2;
//}
//else
//{
//    b = 1;
//}
//Console.WriteLine($"b = {b}");

//b = a == 5 ? a * 2 : a = 1;

//Console.WriteLine($"b = {b}");

//int c = 1;
//int d = 2;
//int e = 3;

//if (c == 1)
//{
//    Console.WriteLine("c == 1");
//}
//else if (d == 2)
//{
//    Console.WriteLine("d == 2");
//}

//if (c == 1)
//{
//    Console.WriteLine("c == 1");
//}
//if (d == 2)
//{
//    Console.WriteLine("d == 2");
//}

//if (c == 1) Console.WriteLine("c == 1");
//if (d == 2)
//Console.WriteLine("d == 2");

//if (c == 1)
//{
//    Console.WriteLine("c == 1");
//    if (d == 2)
//    {
//        Console.WriteLine("c == 1 && d == 2");
//    }
//}

//if (c == 1 && d == 2 && e == 3)
//{
//    Console.WriteLine("c == 1 && d == 2");
//}

//if (c == 1 && d == 3 || e == 5)
//{
//    Console.WriteLine("c == 1 && d == 2 || e == 5");
//}

//if (c != 10)
//{
//    Console.WriteLine("c != 10");
//}

//if (!(c != 10))
//{
//    Console.WriteLine("c != 10");
//}
#endregion

#region INPUT
//Console.WriteLine("What is your name?");
//string input = Console.ReadLine();
//Console.WriteLine($"Hello, {input}!");

//Console.WriteLine("Want an apple? (Y/N)");
//input = Console.ReadLine();

//if (input == "Y")
//{
//    Console.WriteLine("Here you are");
//}
//else
//{
//    Console.WriteLine("Stay hungry!");
//}



//Console.WriteLine("Fight with dragon? (Y/N)");
//input = Console.ReadLine();

//if (input == "Y")
//{
//    Console.WriteLine("Choose the weapon");
//    input = Console.ReadLine();
//    switch (input)
//    {
//        case "S":
//            break;
//        case "B":
//        default:
//            break;
//    }
//}
//else
//{
//    Console.WriteLine("Ok!");
//}

#endregion

//int a = 0;

//while (a<10)
//{
//    Console.WriteLine(a);
//    a++;
//}

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i);
//}

//do
//{
//    Console.WriteLine(a);
//    a++;
//} while (a<10);

//for (int index = 0; index < 100; index++)
//{
//    if (index % 2 == 0)
//    {
//        Console.WriteLine(index);
//    }
//}

//for (int index = 0; index < 100; index++)
//{
//    if (index % 2 != 0)
//        continue;

//    Console.WriteLine(index);
//}

//for (int index = 0; index < 100; index+=2)
//    Console.WriteLine(index);

//for (int index = 0; index < 100; index += 2)
//{
//  if (index >=51)
//  {
//      Console.WriteLine("break");
//      break;
//  }
//  Console.WriteLine(index);
//  }

//string input;
//bool sucsess = false;
//Console.WriteLine("Want an apple? (Y/N)");

//while (!sucsess)
//{
//    input = Console.ReadLine();

//    if (input == "Y")
//    {
//        Console.WriteLine("Here you are");
//        sucsess = true;
//    }
//    else if (input == "N")
//    {
//        Console.WriteLine("Stay hungry!");
//        sucsess = true;
//        break;
//    }
//    else
//    {        
//    }
//    Console.WriteLine("Wrong input, repeat");
//}

#endregion

// HOMEWORK

Console.WriteLine("Choose first number");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Choose second number");
int y = Convert.ToInt32(Console.ReadLine());
int a = x;
for (int i = x; i < y; i++)
{
    x++;
    a += x;
}
Console.WriteLine($"The sum of all numbers between them is {a}");

