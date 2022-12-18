using System.Text.RegularExpressions;
using System.IO;

var regex = new Regex(@"\d+");
//var regex = new Regex(@"^\d+");
//var regex = new Regex(@"^\d+$");
//var regex = new Regex(@"\d+$");
var str1 = "1564312";
var str2 = "46546554ffswef654";
Console.WriteLine(regex.IsMatch(str1));
Console.WriteLine(regex.IsMatch(str2));

Console.WriteLine(Regex.IsMatch("0143-555-1234", "^[0-9]{4}-[0-9]{3}-[0-9]{4}$"));
Console.WriteLine(Regex.IsMatch("1436-789-12344", @"^\d{4}-\d{3}-\d{5}$"));

var res = Regex.Match("1436-789-12344", @"^\d{4}-\d{3}-\d{5}$");
Console.WriteLine(res.Value);
var res1 = Regex.Match("1436-789-12344, 1436-789-12344, 1436-789-12344", @"^\d{4}-\d{3}-\d{5}$");
Console.WriteLine(res1.Value);
var res2 = Regex.Matches("1436-789-44444, 1436-789-55555, 1436-789-66666", @"\d{4}-\d{3}-\d{5}");
//Console.WriteLine(res2[1]);
foreach (var i in res2)
    Console.WriteLine(i);

var str3 = "1436-789-44444, 1436-789-55555, 1436-789-66666";
var str4 = Regex.Replace(str3, @"\d{4}-\d{3}-\d{5}", "------ ");
Console.WriteLine(str4);

var str5 = "1436-789-44444, 1436-789-55555, 1436-789-66666, aertgasd";
var str6 = Regex.Replace(str5, @"\d{4}-\d{3}-\d{5}|\w+", "*********");
Console.WriteLine(str6);

foreach (var i in DriveInfo.GetDrives())
{
    Console.WriteLine(i.Name);
    Console.WriteLine(i.TotalSize);
    Console.WriteLine(i.AvailableFreeSpace);
}

string root = @"D:\Academia_BeetRoot\";
if (Directory.Exists(root + "csharp-20221129"))
{
    foreach (var subDirs in Directory.GetDirectories(root + "csharp-20221129"))
    {
        Console.WriteLine(subDirs);
    }
    foreach (var files in Directory.GetDirectories(root + "csharp-20221129"))
    {
        Console.WriteLine(files);
    }
}

var dir = new DirectoryInfo(@"D:\Academia_BeetRoot");
if (dir.Exists)
{
    foreach (var subDir in dir.GetDirectories())
    {
        Console.WriteLine(subDir);
    }
    foreach (var file in dir.GetFiles())
    {
        Console.WriteLine(file);
    }
}
var fileName = "testfile.txt";
if (File.Exists(fileName))
{
    Console.WriteLine(File.ReadAllText(fileName));
    File.AppendAllText(fileName, "some more text");
}
else
{
    File.WriteAllText(fileName, "some text");
}


