using System.Reflection;

namespace Lesson20.HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("C:\\Users\\bogac\\source\\repos\\csharp-20221129\\Egor Bogachick\\Lesson20\\Lesson20.FromLesson13\\bin\\Debug\\net6.0\\Lesson20.FromLesson13.dll");
            Type[] type = asm.GetTypes();

            Console.WriteLine(asm.FullName);
        }
    }
}