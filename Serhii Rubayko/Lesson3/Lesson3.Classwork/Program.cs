int x = -5;

int a = Math.Abs(x);
int b = Math.Max(1, 10);
double c = Math.Sqrt(9);

//Console.WriteLine(c);


DateTime dt = new DateTime(1900, 5, 10, 17, 39, 16);

dt = dt.AddDays(-5);

dt = DateTime.Now;

TimeSpan ts = new TimeSpan(5, 3, 0, 0);

dt = dt.Add(ts);


Console.WriteLine(dt);


#region IF ELSE SWITCH

//int a = 10;

//if(a==5) 
//{
//    Console.WriteLine("A=5");
//}
//else if (a == 7)
//{
//    Console.WriteLine("A=7");
//}
//else
//{
//    Console.WriteLine("A=else");
//}

//switch(a)
//{ 
//    case 5: 
//        Console.WriteLine("A=case 5"); 
//        break;
//    case 7:
//        Console.WriteLine("A=case 7");
//        break;
//    default:
//        Console.WriteLine("A=case defaul");
//        break;
//}

//int b=0;

//b = 0;

//b = a switch
//{
//    5 => a * 2,
//    7 => a * 3,
//    _ => 1


//};

//Console.WriteLine($"B = {b}");


//int 

#endregion







Console.ReadKey();