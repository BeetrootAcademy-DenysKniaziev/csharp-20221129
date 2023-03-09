using System.Reflection;

namespace Lesson20.HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("C:\\Users\\bogac\\source\\repos\\csharp-20221129\\Egor Bogachick\\Lesson20\\Lesson20.FromLesson13\\bin\\Debug\\net6.0\\Lesson20.FromLesson13.dll");
            Type[] types = asm.GetTypes();

            Console.WriteLine("\n" + asm.FullName);

            Console.WriteLine();
            Console.WriteLine("\n ==================INTERFACES==================");
            foreach (var type in types)
            {
                Console.WriteLine();
                Console.WriteLine("CLASS: " + type.Name);
                var interfaces = type.GetInterfaces();
                if (!interfaces.Any())
                {
                    Console.WriteLine("Has no interfaces");
                }
                else
                {
                    Console.WriteLine("Interface name");
                }
                foreach (var inter in interfaces)
                {
                    Console.WriteLine(inter.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine("\n ==================METHODS==================");
            foreach (var type in types)
            {
                Console.WriteLine();
                Console.WriteLine("CLASS: " + type.Name);
                Console.WriteLine("Method name \t Return param " );
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    Console.WriteLine(method.Name  + "\t " + method.ReturnParameter);
                }
            }

            Console.WriteLine("\n ==================FIELDS==================");
            foreach (var type in types)
            {
                Console.WriteLine();
                Console.WriteLine("CLASS: " + type.Name);
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                if (!fields.Any())
                {
                    Console.WriteLine("Has no feilds");
                }
                else
                {
                    Console.WriteLine("Field name ");
                }
                foreach (var field in fields)
                {
                    Console.WriteLine(field.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine("\n ==================PROPERTIES==================");
            foreach (var type in types)
            {
                Console.WriteLine();
                Console.WriteLine("CLASS: " + type.Name);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                if (!properties.Any())
                {
                    Console.WriteLine("Has no properties");
                }
                else
                {
                    Console.WriteLine("Propersty name \t Return type ");
                }
                foreach (var property in properties)
                {
                    Console.WriteLine(property.Name + "\t " + property.PropertyType.Name);
                }
            }
        }
    }
}