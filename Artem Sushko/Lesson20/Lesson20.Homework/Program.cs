using System.Reflection;

namespace Lesson20.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("MyApp.dll");
            Type[] type = asm.GetTypes();

            Console.WriteLine(asm.FullName);

            Console.WriteLine("\n\tMETHODS");
            foreach (var item in type)
            {
                var methods = item.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var method in methods)
                {
                    string modificator = "";
                    if (method.IsStatic) modificator += "static ";
                    if (method.IsVirtual) modificator += "virtual ";
                    if (method.IsPrivate) modificator += "private ";
                    if (method.IsPublic) modificator += "public ";
                    Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
                }
            }

            Console.WriteLine("\n\tPROPERTIES");
            foreach (var item in type)
            {
                var properties = item.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var property in properties)
                {
                    string modificator = "";
                    if (property.CanRead) modificator += "get; ";
                    if (property.CanWrite) modificator += "set;";
                    Console.WriteLine($"{property.Name} {modificator}");
                }
            }
            Console.WriteLine("\n\tFIELDS");
            foreach (var item in type)
            {
                var fields = item.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var field in fields)
                {
                    string modificator = "";
                    if (field.IsPublic) modificator += "public ";
                    if (field.IsPrivate) modificator += "private ";
                    if (field.IsStatic) modificator += "static ";
                    Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name};");
                }
            }
            Console.WriteLine("\n\tEVENTS");
            foreach (var item in type)
            {
                var events = item.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                foreach (var field in events)
                {
                    string modificator = "";
                    if (field.IsMulticast) modificator += "multicast ";
                    if (field.IsCollectible) modificator += "collectible ";
                    Console.WriteLine($"{modificator}{field.EventHandlerType.Name} {field.Name};");
                }
            }

        }
    }
}