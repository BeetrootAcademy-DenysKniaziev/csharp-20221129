using System.Reflection;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("Input path:");
        string path = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(path))
            path = @"C:\Users\roman\source\repos\csharp-20221129\Roman Bychkov\Lesson20\Lesson17.HomeWork\bin\Debug\net6.0\Lesson17.HomeWork.dll";
        Assembly asm = Assembly.LoadFrom(path);
        Type[] types = asm.GetTypes();
        foreach (Type t in types)
        {
            Console.WriteLine(t.Name);
            Console.WriteLine("\tMethods:");
            foreach (MethodInfo mi in t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine("\t\t" + MyReflection.GetMethodBaseInfo(mi));
            }
            Console.WriteLine("\tConstructor:");
            foreach (ConstructorInfo mi in t.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine("\t\t" + MyReflection.GetMethodBaseInfo(mi));
            }
            Console.WriteLine("\tFields:");
            foreach (FieldInfo mi in t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine("\t\t" + MyReflection.GetFieldInfo(mi));
            }
            Console.WriteLine("\tProperties:");
            foreach (PropertyInfo mi in t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine("\t\t" + MyReflection.GetPropertyInfo(mi));
            }
            Console.WriteLine("\tEvents:");
            foreach (EventInfo mi in t.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine("\t\t" + MyReflection.GetEventInfo(mi));
            }
          

        }

    }

}