//using System.Text.RegularExpressions;

//var regex = new Regex(@"^\d+$");

//var str1 = "6789029";
//var str2 = "4544urjjj";

//Console.WriteLine(regex.IsMatch(str1));
//Console.WriteLine(regex.IsMatch(str2));

//Console.WriteLine(Regex.IsMatch("456-435-2311", @"^\d{3}-\d{3}-\d{4}$"));

//var res = Regex.Match("456-4567-234", @"^\d{3}-\d{3}-\d{4}$");
//Console.WriteLine(res.Value);

//var resCol = Regex.Matches("656-435-2356, 656-456-9891, 111-222-3333", @"^\\d{3}-\d{3}-\d{4}$");

//foreach(var item in resCol)
//{
//    Console.WriteLine(item);
//}

//var str3 = "656-454-9900, 656-456-9891, 111-222-3333, tytytyt";
//var str4 = Regex.Replace(str3, @"^\\d{3}-\d{3}-\d{4} | (\w+)", "");
//Console.WriteLine(str4);

//using System.IO;

//foreach (var drive in DriveInfo.GetDrives())
//{
//    Console.WriteLine(drive.Name);
//    Console.WriteLine(drive.TotalSize);
//    Console.WriteLine(drive.AvailableFreeSpace);
//}

//string root = @"C:\";
//if(Directory.Exists(root + "Repos"))
//{
//    foreach (var subDirs in Directory.GetDirectories(root+ "Repos"))
//    {
//        Console.WriteLine(subDirs);
//    }

//    foreach (var files in Directory.GetFiles(root + "Repos"))
//    {
//        Console.WriteLine(files);
//    }
//}

//var dir = new DirectoryInfo(@"C:\Repos");
//if(dir.Exists)
//{
//    foreach (var subDirs in dir.GetDirectories())
//    {
//        Console.WriteLine(subDirs);
//    }

//    foreach (var file in dir.GetFiles())
//    {
//        Console.WriteLine(file);
//    }
//}


//var fileName = "testfile.txt";
//if(File.Exists(fileName))
//{
//    Console.WriteLine(File.ReadAllText(fileName));
//    File.AppendAllText(fileName,"some more text");
//}
//else
//{
//    File.WriteAllText(fileName, "some text");
//}

using static System.Runtime.InteropServices.JavaScript.JSType;

const string FileName = "PhoneBook.txt";

Console.WriteLine("Phone Book: ");
Console.WriteLine("1- Show Phone Book");
Console.WriteLine("2- Add Record");
Console.WriteLine("3- Update Record");
Console.WriteLine("4- Remove Record");
Console.WriteLine("0- Exit");

var records = new(string firstName, string lastName, string number)[1000];
records[0] = ("Denys", "Kniazev", "555-777-9898");

void ShowPhoneBook()
{

}

void ReadFromFile()
{
    if(File.Exists(FileName))
    {
        var records = File.ReadAllLines(FileName);
    }

}

void AddRecord()
{

}

void UpdateRecord()
{

}

void RemoveRecord()
{

}

void SaveToFile((string firstName, string lastName, string number)[] records)
{
    var [] data = new string[records.Length];
    for (int i = 0; i < records.Length; i++)
    {
        var record = records[i];
        data[i] =  $"{record.firstName}|{record.lastName}|{record.number}";
    }

    File.WriteAllLines(FileName, data);
}