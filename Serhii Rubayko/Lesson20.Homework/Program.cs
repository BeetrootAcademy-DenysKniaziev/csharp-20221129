using System;
using System.Reflection;

namespace Lesson20.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Assembly a = Assembly.LoadFrom("Lesson11.School.dll");

            Type[] types= a.GetTypes();

            foreach(Type t in types) 
            {
                Console.WriteLine($"{t.FullName}:");

                FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                    BindingFlags.Public | BindingFlags.Static);

                Console.WriteLine($"Fields:");

                foreach (var field in fields)
                {
                    Console.Write(field.Name + ", ");
                }
                Console.WriteLine("\n");


                PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                    BindingFlags.Public | BindingFlags.Static);

                Console.WriteLine($"Properties:");

                foreach (var property in properties)
                {
                    Console.Write(property.Name+", ");
                }
                Console.WriteLine("\n");


                MethodInfo[] methods = t.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic|
                    BindingFlags.Public|BindingFlags.Static);

                Console.WriteLine($"Methods:");

                foreach (var method in methods)
                {
                    Console.Write(method.Name + ", ");
                }
                Console.WriteLine("\n");
            }           
        }
    }
}