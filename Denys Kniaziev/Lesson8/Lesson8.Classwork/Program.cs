//using System.Text.RegularExpressions;

//var regex = new Regex(@"^\d+$");

//var str1 = "65675746";
//var str2 = "545grtg43";

////Console.WriteLine(regex.IsMatch(str1));
////Console.WriteLine(regex.IsMatch(str2));
////
////Console.WriteLine(Regex.IsMatch("656-435-2386, 656-435-2396, 656-436-2046", @"^\d{3}-\d{3}-\d{4}$"));
//var res = Regex.Match("656-435-2386, 656-435-2396, 656-436-2046", @"\d{3}-\d{3}-\d{4}");
//Console.WriteLine(res.Value);

//var resCol = Regex.Matches("656-435-2386, 656-435-2396, 656-436-2046", @"\d{3}-\d{3}-\d{4}");

//foreach (var item in resCol)
//{
//    Console.WriteLine(item);
//}

//var str3 = "656-435-2386, 656-435-2396, 656-436-2046, tytrytry";
//var str4 = Regex.Replace(str3, @"(\d{3}-\d{3}-\d{4})|(\w+)", "");
//Console.WriteLine(str4);

using System.IO;

//foreach (var drive in DriveInfo.GetDrives())
//{
//    Console.WriteLine(drive.Name);
//    Console.WriteLine(drive.TotalSize);
//    Console.WriteLine(drive.AvailableFreeSpace);
//}

//string root = @"C:\";
//if (Directory.Exists(root + "Repos"))
//{
//    foreach (var subDirs in Directory.GetDirectories(root + "Repos"))
//    {
//        Console.WriteLine(subDirs);
//    }

//    foreach (var files in Directory.GetFiles(root + "Repos"))
//    {
//        Console.WriteLine(files);
//    }
//}

//var dir = new DirectoryInfo(@"C:\Repos");
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
    File.AppendAllText(fileName, "some more text");
}
else
{
    File.WriteAllText(fileName, "some text");
}


