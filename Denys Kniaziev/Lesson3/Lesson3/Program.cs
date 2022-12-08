#region Math & DateTime

//int x = -5;

//int a = Math.Abs(x);
//int b = Math.Max(1, 10);
//double c = Math.Sqrt(9);

////Console.WriteLine(c);

//DateTime dt = new DateTime(1900, 5, 10, 17, 39, 16);

//dt = DateTime.Now;

//dt = dt.AddDays(-5);

//TimeSpan ts = new TimeSpan(5, 3, 0, 0);

//dt = dt.Add(ts);

//Console.WriteLine(dt);

#endregion

#region IF ELSE SWITCH

//int a = 10;

//if (a == 5)
//{
//    Console.WriteLine("A = 5");
//}
//else if (a == 7)
//{
//    Console.WriteLine("A = 7");
//}
//else
//{
//    Console.WriteLine("A = else");
//}

//switch (a)
//{
//    case 5:
//        Console.WriteLine("A = case 5");
//        break;
//    case 7:
//        Console.WriteLine("A = case 7");
//        break;
//    default:
//        Console.WriteLine("A = case default");
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

//b = 0;

//int z = 10;
//switch (a)
//{
//    case 5 when z == 10: 
//        b = a * 2;
//        break;
//    case 7 when z == 7 || z == 5:
//        b = a * 3;
//        break;
//    default:
//        b = 1;
//        break;
//}

//b = 0;

//b = a switch
//{
//    5 => a * 2,
//    7 => a * 3,
//    _ => 1    
//};

//b = 0;

//if (a == 5)
//{
//    b = a * 2;
//}
//else
//{
//    b = 1;
//}

//b = a == 5 ? a * 2 : 1;

//Console.WriteLine($"B = {b}");

//int c = 1;
//int d = 2;
//int e = 3;

//if (c == 1)
//    Console.WriteLine("c == 1");
//else if (d == 2)
//    Console.WriteLine("d == 2");

//if (c == 1) Console.WriteLine("c == 1");
//if (d == 2) Console.WriteLine("d == 2");

//Console.WriteLine();

//if (c == 1)
//{
//    Console.WriteLine("c == 1");

//    if (d == 2)
//    {
//        Console.WriteLine("d == 2");

//        Console.WriteLine("c == 1 && d == 2");
//    }
//}

//Console.WriteLine();

//if (c == 1 && d == 2 && e == 3 )
//{
//    Console.WriteLine("c == 1 && d == 2 && e == 3");
//}

//Console.WriteLine();

//if (c == 1 && d == 2 || e == 5)
//{
//    Console.WriteLine("c == 1 && d == 2 || e == 5");
//}

//Console.WriteLine();

//if (c != 10)
//{
//    Console.WriteLine("c != 10");
//}

//Console.WriteLine();

//if (!(c != 10))
//{
//    Console.WriteLine("c == 10");
//}

//Console.WriteLine();

//if (c == 1 && (d == 2 || e == 5))
//{
//    Console.WriteLine("c == 1 && d == 2 || e == 5");
//}

#endregion

#region Input

//Console.WriteLine("What is your name?:");

//string input = Console.ReadLine();

//Console.WriteLine($"Hello, {input}");

//Console.WriteLine("Want an apple? (Y/N)");

//input = Console.ReadLine();

//if (input == "Y")
//    Console.WriteLine("Take it!");
//else
//    Console.WriteLine("Ok, Stay hungry");

//Console.WriteLine("Fight with dragon? (Y/N)");

//input = Console.ReadLine();

//if (input == "Y")
//{
//    Console.WriteLine("Ok, good luck");

//    Console.WriteLine("Choose the weapon: (S - Sword, B - Bow)");

//    input = Console.ReadLine();

//    switch (input)
//    {
//        case "S":
//            break;
//        case "B":
//            break;
//        default:
//            break;
//    }
//}
//else
//    Console.WriteLine("Ok, you are chicken");

#endregion

#region Loops

//int  a = 0;

//while (a < 10)
//{
//    Console.WriteLine(a);
//    a++;
//}

//for (int i = 0; i < 10; ++i)
//{
//    Console.WriteLine(i);
//}

//do
//{
//    Console.WriteLine(a);
//    a++;
//} while (a < 10);

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

//for (int index = 0; index < 100; index++)
//{
//    if (index % 2 != 0)
//        continue;

//    Console.WriteLine(index);
//}

//for (int index = 0; index < 100; index += 2)
//{
//    Console.WriteLine(index);
//}

//for (int index = 0; index < 100; index += 2)
//{
//    if (index >= 50)
//    {
//        Console.WriteLine("break");
//        break;
//    }

//    Console.WriteLine(index);
//}

//string input;
//bool success = false;

//Console.WriteLine("Choose the weapon: (S - Sword, B - Bow)");

//while (!success)
//{
//    input = Console.ReadLine();

//    switch (input)
//    {
//        case "S":
//            Console.WriteLine("Sword");
//            success = true;
//            break;
//        case "B":
//            Console.WriteLine("Bow");
//            success = true;
//            break;
//        default:
//            Console.WriteLine("Wrong input! Repeat:");
//            success = false;
//            break;
//    }
//}

string input;
bool finished = false;
Console.WriteLine("Want an apple? (Y/N)");

while (!finished)
{
    input = Console.ReadLine();

    if (input == "Y")
    {
        Console.WriteLine("Take it!");

        Console.WriteLine("Want a tomato? (Y/N)");

        while (!finished)
        {
            input = Console.ReadLine();

            if (input == "Y")
            {
                Console.WriteLine("Take it!");
                finished = true;
                break;
            }
            else if (input == "N")
            {
                Console.WriteLine("Ok, Stay hungry");
                finished = true;
                break;
            }
            else
                Console.WriteLine("Wrong input! Repeat:");
        }

    }
    else if (input == "N")
    {
        Console.WriteLine("Ok, Stay hungry");
        break;
    }
    else
        Console.WriteLine("Wrong input! Repeat:");
}

#endregion