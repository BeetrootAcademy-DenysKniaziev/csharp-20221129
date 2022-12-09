using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Xml.Schema;
using System.Xml.Serialization;

Console.WriteLine("Hello, Denys!");


int sum = 0;


Console.WriteLine("Insert X value");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Insert Y value");
int y = Convert.ToInt32(Console.ReadLine());

if (x < y)
{
    for (int i = x; i <= y; i++)
    {
        sum += i;
        Console.WriteLine(sum);
    }
}
if (x > y)
{
    for (int i = y; i <= x; i++)
    {
        sum += i;
        Console.WriteLine(sum);
    }
}






