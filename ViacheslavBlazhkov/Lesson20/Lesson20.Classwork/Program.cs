﻿using System.ComponentModel;
using System.Reflection;
using System;

namespace Lesson20.Classwork
{
    public class Entity
    {
        ~Entity() { }
    }

    public class Person : Entity
    {
        private static int _type;
        private int _age;

        public int Id { private get; set; }
        public string Name { get; set; }

        public Person(int age, int id, string name)
        {
            _age = age;
            Id = id;
            Name = name;
        }

        public int GetAge()
        {
            return _age;
        }

        private static void StaticMethod(string extra)
        {
            System.Console.WriteLine("Static void");
        }

        private void PrintPrivateInfo(string extra)
        {
            Console.WriteLine("SOME PRIVATE INFO: " + extra);
        }

        ~Person()
        {
            System.Console.WriteLine("~Person");
        }
    }

    class RGBColorAttribute : Attribute
    {
        public RGBColorAttribute(string colorCode)
        {
            ColorCode = colorCode;
        }

        public string ColorCode { get; }
    }

    enum Color
    {
        [RGBColor("#641E16")]
        Red,

        [RGBColor("#23FF00")]
        Green,

        [RGBColor("#004DFF")]
        Blue,

        [RGBColor("#FF00FF")]
        Purple
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> set = new HashSet<string>();
            var type1 = set.GetType();
            var type2 = typeof(HashSet<string>);

            var person = new Person(20, 1, "John");
            var type = person.GetType();

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
            }

            System.Console.WriteLine();

            var fieldAge = type.GetField("_age", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldAge.SetValue(person, 50);

            System.Console.WriteLine(person.GetAge());

            System.Console.WriteLine();

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }

            System.Console.WriteLine();

            var methodFinalize = type.GetMethod("Finalize", BindingFlags.NonPublic | BindingFlags.Instance);
            methodFinalize.Invoke(person, null);

            var methodPrivate = type.GetMethod("PrintPrivateInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            methodPrivate.Invoke(person, new object[] {"dw"});

            var staticMethod = type.GetMethod("StaticMethod", BindingFlags.NonPublic | BindingFlags.Static);
            staticMethod.Invoke(null, new object[] { null });

            System.Console.WriteLine(GetRGBCodeReflection(Color.Green));

            var neededType = Assembly.GetExecutingAssembly().GetTypes().Single(x => x.Name == "Person");
            var personReflection = Activator.CreateInstance(neededType, 30, 2, "Stive") as Person;
            System.Console.WriteLine(personReflection.Name);
        }

        static string GetRGBCode(Color color)
        {
            return color switch
            {
                Color.Red => "#641E16",
                Color.Green => "#23FF00",
                Color.Blue => "#004DFF",
                Color.Purple => "#FF00FF",
                _ => "NOT FOUND"
            };
        }

        static string GetRGBCodeReflection(Color color)
        {
            var type = color.GetType();
            var memInfo = type.GetMember(color.ToString());
            var attribute = memInfo[0].GetCustomAttribute<RGBColorAttribute>();
            return attribute.ColorCode;
        }
    }
}
