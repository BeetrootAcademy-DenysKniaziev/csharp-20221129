//using System.Text.RegularExpressions;

////var regex = new Regex(@"^\d+$");

////var srt1 = "65675746";

////var str2 = "545grtg678";

////Console.WriteLine(regex.IsMatch(srt1));
////Console.WriteLine(regex.IsMatch(str2));

//Console.WriteLine(Regex.IsMatch("458-435-2318", "[0-9]{3}-[0-9]{3}-[0-9]{4}"));
//var res = Regex.Match("458-435-2318", "[0-9]{3}-[0-9]{3}-[0-9]{4}");

//Console.WriteLine(res.Value);


//var resCol = Regex.Matches("458-435-2318, 785-114-2244, 987-654-7785", @"\d{3}-\d{3}-\d{4}");

//Console.WriteLine(resCol[1]);

//foreach (var col in resCol)
//{
//    Console.WriteLine(col);
//}

//var str3 = "458-435-2318, 785-114-2244, 987-654-7785, tijhyfutdyt";
//var str4 = Regex.Replace(str3, @"\d{3}-\d{3}-\d{4}|\w+", "");
//Console.WriteLine(str4);

using System.IO;

foreach (var drive in DriveInfo.GetDrives())
{
    Console.WriteLine(drive.Name);
    Console.WriteLine(drive.TotalSize);
    Console.WriteLine(drive.AvailableFreeSpace);
}

//string root = @"D:\";
//if(Directory.Exists(root+"BeetRoot"))
//{
//    foreach (var subDirs in Directory.GetDirectories(root+ "BeetRoot"))
//    {
//        Console.WriteLine(subDirs);
//    }

//    foreach (var files in Directory.GetDirectories(root + "BeetRoot"))
//    {
//        Console.WriteLine(files);
//    }
//}
    var dir = new DirectoryInfo(@"D:\BeetRoot");
    if (dir.Exists)
    {
    foreach (var subDir in dir.GetDirectories())
        {
            Console.WriteLine(subDir);
        }

    }


