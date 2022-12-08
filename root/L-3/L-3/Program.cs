#region Math & DateTime

//int x = -5;

//int a = Math.Abs(x);
//int b = Math.Max(1,5);
//double c = Math.Sqrt(9);

////Console.WriteLine(b);

//DateTime dt = new DateTime(1993, 7, 12);
//dt = DateTime.Now;
//dt = dt.AddDays(-5);

//TimeSpan ts = new TimeSpan(5, 3,0);
//dt = dt.Add(ts);
//Console.WriteLine(dt);

#endregion
#region ifelseswitch
////прикольний світч)
//int a = 5;
//int b = 0;
//b = a switch
//{
//    5 => a * 2,
//    7=>a*3,
//    _=> 1
//};

////тернарка
//b = a == 5 ? a * 2 : 1;

//int c = 1;
//int d = 2;
//int e = 3;
#endregion

#region input
//string input = Console.ReadLine();
//Console.WriteLine(input);
#endregion

for (int i = 0; i < 100; i++)
{
    if(i%3 != 0)
    {
        continue;
    }
    Console.WriteLine(i);
}