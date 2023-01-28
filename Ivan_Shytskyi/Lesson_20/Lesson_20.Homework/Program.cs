using System.Reflection;

namespace Lesson_20.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly a = Assembly.LoadFile(@"D:\Academia_BeetRoot\csharp-20221129\Ivan Shytskyi\Ivan_Shytskyi\Lesson_13\Lesson_13.Homework\bin\Debug\net6.0\Lesson_13.Homework.dll");
            Type[] types = a.GetTypes();

            foreach (Type t in types)
            {
                var fields = t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var field in fields)
                {
                    Console.WriteLine($"{field.Name}");
                }
                Console.WriteLine();
            }
            foreach (Type t in types)
            {
                var methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var method in methods)
                {
                    Console.WriteLine($"{method.Name}");
                }
                Console.WriteLine();
            }
            foreach (Type t in types)
            {
                var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var propertie in properties)
                {
                    Console.WriteLine($"{propertie.Name}");
                }
                Console.WriteLine();
            }
        }
    }
}