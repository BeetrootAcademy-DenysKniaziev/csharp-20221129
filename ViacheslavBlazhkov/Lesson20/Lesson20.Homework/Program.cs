using System.Reflection;

Assembly formsDll = Assembly.LoadFrom("Microsoft.EntityFrameworkCore.dll");

Type[] types = formsDll.GetTypes().Where(t => t.IsNotPublic && t.IsClass).ToArray();
Console.WriteLine("NonPublic classes: ");
foreach (Type type in types)
{
    Console.WriteLine(type.FullName);
}

var choosedClass = types.Single(x => x.FullName == "System.SharedTypeExtensions");

var fields = choosedClass.GetFields();

Console.WriteLine("\nFields: ");
if (fields.Length > 0)
{
    foreach (var field in fields)
    {
        Console.WriteLine(field.Name);
    }
}
else Console.Write("Class doesn't have fields");

var methods = choosedClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

Console.WriteLine("\n\nNon public Methods: ");
foreach (var method in methods)
{
    Console.WriteLine(method.Name);
}