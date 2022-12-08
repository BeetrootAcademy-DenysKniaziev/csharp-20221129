using System.Globalization;
using System.Runtime.InteropServices;

Console.WriteLine("lesson_3");
#region DateTime
//DateTime dt = new DateTime();
//dt = DateTime.Now;
//dt = dt.AddDays(2);
//TimeSpan ts = new TimeSpan(12, 2, 0, 0);
//dt = dt.Add(ts); 
//Console.WriteLine(dt);
#endregion

#region if else
//int a = 7;
//if (a == 5)
//    Console.WriteLine("a=5");
//else if (a == 7)
//    Console.WriteLine("a=7");
//else
//    Console.WriteLine("a=else");
//int b = 0;
//b = a switch
//{
//    5 => a * 2,
//    7 => a * 3,
//    _ => 1
//};
//b = a == 5 ? a * 2 : 1;
//Console.WriteLine($"b = {b}");

//int c = 1;
//int d = 2;
//int e = 3;
//if (c==1 )
//{
//    Console.WriteLine("c==1");
//}
//else if (d ==2) Console.WriteLine("d==2");
//Console.WriteLine();

//if (c==1)
//{
//    Console.WriteLine("c");
//    if (d==2)
//    {
//        Console.WriteLine("d");
//        Console.WriteLine("c=1 && d=2");
//    }
//    Console.WriteLine(";)");
//}
//Console.WriteLine();
//if (c==1 && d==2 || c==5)
//{
//    Console.WriteLine("c=1 && d=2 && c=5");
//}
//Console.WriteLine();
#endregion

#region
//Console.WriteLine("what is your name?");
//string input = Console.ReadLine ();

//Console.WriteLine($"hello, {input}");

//Console.WriteLine("want an apple? Y/N");
//input = Console.ReadLine ();
//if (input == "Y")
//    Console.WriteLine("Take it");
//else
//    Console.WriteLine("Ok, stay hungry");
//int n = 0;
//while (n < 10)
//{
//    Console.WriteLine(n);
//    n++;
//}
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i);
//}
#endregion

// GAME

Console.WriteLine("GAME");
Console.WriteLine("HELLO, do you want to play? yes or no");
string yes_or_no = Console.ReadLine();
if (yes_or_no == "yes")
{
    Console.WriteLine("level_1");
    Console.WriteLine("what is your name?");
    string name = Console.ReadLine();
    Console.WriteLine($"OK {name} let's go\nThe 9-story building has an elevator. Only 2 people live on the first floor. The number of residents doubles from floor to floor." +
                      "\nOn which floor in this building is the elevator call button pressed more often than others?");
    Console.WriteLine("your answer must be one number (1-9)\nyou heve one chance to gess");
    int answer1 = Convert.ToInt32(Console.ReadLine());
    if (answer1 == 1)
    {
        Console.WriteLine("not bad, but you have chnce to lose in the next level");
        Console.WriteLine("level_2");
        Console.WriteLine("George Washington, Sherlock Holmes, William Shakespeare, Ludwig Van Beethoven, Napoleon Bonaparte." +
                          "\nWhich of them is fundamentally different from the others?\nyou heve two gesses");
        for (int i = 0; i < 2; i++)
        {
            string answer2 = Console.ReadLine();
            if (answer2 == "Sherlock Holmes")
            {
                Console.WriteLine("good, continue soon");
                break;
            }
            else if (i == 0)
            {
                Console.WriteLine("the last");

            }
            else
                Console.WriteLine("you lose. ha-ha");
        }
    }
    else
        Console.WriteLine("you lose. ha-ha");
}
else
    Console.WriteLine("Pff...");




