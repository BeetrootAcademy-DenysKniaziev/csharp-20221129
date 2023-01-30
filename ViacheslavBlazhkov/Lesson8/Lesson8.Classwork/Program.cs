//using System.Text.RegularExpressions;

//var regex = new Regex(@"^\d+$");

//var str1 = "6252562";
//var str2 = "3728dh82";

//Console.WriteLine(regex.IsMatch(str1));
//Console.WriteLine(regex.IsMatch(str2));

//Console.WriteLine(Regex.IsMatch("2622-435-2318", "^[0-9]{3}-[0-9]{3}-[0-9]{4}$"));
//var resCol = Regex.Matches("122-435-2318, 222-435-2318, 322-435-2318", @"[0-9]{3}-[0-9]{3}-[0-9]{4}");

//foreach(var m in resCol)
//{
//    Console.WriteLine(m);
//}
//var str3 = "122-435-2318, 222-435-2318, 322-435-2318, hdwjdwj";
//var str4 = Regex.Replace(str3, @"([0-9]{3}-[0-9]{3}-[0-9]{4})|(\w+)", "");
//Console.WriteLine(str4);

using System.IO;

//foreach (var drive in DriveInfo.GetDrives())
//{
//    Console.WriteLine(drive.Name);
//    Console.WriteLine(drive.TotalSize / 1000000000 + " GB");
//    Console.WriteLine(drive.AvailableFreeSpace / 1000000000 + " GB");
//}

//string root = @"C:\";
//if (Directory.Exists(root + "QWERTY"))
//{
//    foreach (var subDirs in Directory.GetDirectories(root + "QWERTY"))
//    {
//        Console.WriteLine(subDirs);
//    }

//    foreach (var files in Directory.GetFiles(root + "QWERTY"))
//    {
//        Console.WriteLine(files);
//    }
//}

//Console.WriteLine();

//var dir = new DirectoryInfo(@"C:\QWERTY\Download");
//if (dir.Exists)
//{
//    foreach (var subDir in dir.GetDirectories())
//    {
//        Console.WriteLine(subDir);
//    }

//    foreach (var file in dir.GetFiles())
//    {
//        Console.WriteLine(file);
//    }
//}

var fileName = "testfile.txt";
if(File.Exists(fileName))
{
    Console.WriteLine(File.ReadAllText(fileName));
    File.AppendAllText(fileName, " some more text");
}
else
{
    File.WriteAllText(fileName, "some text");
}
