using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";

Console.WriteLine("Phone book Application");
Console.WriteLine("Select Action:");
Console.WriteLine("1-Show Phone Book");
Console.WriteLine("2-AddRecord");
Console.WriteLine("3-Search");
Console.WriteLine("0-Exit");

var records = ReadFromFile();

static (string, string, string)[] copyArr((string FirstName, string LastName, string number)[] records)
{
    var newData = new (string FirstName, string LastName, string number)[records.Length + 0];
    for (int i = 0; i < records.Length; i++)
    {
        newData[i] = records[i];
    }
    return newData;
}

while (true)
{
    var action = Console.ReadKey();
    Console.WriteLine();
    switch (action.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("Phone Book:");
            ShowPhonrBook(records);
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Add record:");
            AddRecord(records);
            break;
        case ConsoleKey.D3:
            Console.WriteLine("SearchRecord:");
            SearchRecord(records);
            Console.WriteLine();
            break;
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Incorrect Input!!!");
            break;
    }

}

void ShowPhonrBook((string firstName, string lastName, string number)[] records)
{
    foreach (var record in records)
    {
        Console.WriteLine($"First Name:{record.firstName},Last Name:{record.lastName},Number:{record.number}");
    }
}
void AddRecord((string FirstName, string LastName, string number)[] records)
{
    Console.Write("Enter First name:");
    string FirstName = Console.ReadLine();
    Console.Write("Enter Last name:");
    string LastName = Console.ReadLine();
    Console.Write("Enter number:");
    string number = Console.ReadLine();

    var record = (FirstName, LastName, number);

    var records1 = copyArr(records);

    records1[records1.Length - 1].Item1 = record.FirstName;
    records1[records1.Length - 1].Item2 = record.LastName;
    records1[records1.Length - 1].Item3 = record.number;

    SaveToFile(records1);
}
void UpdateRecord()
{

}
void SearchRecord((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Enter number to find a person:\n1. First name\n2. Last name\n3. number");
    Console.WriteLine();
    var actions = Console.ReadKey();
    switch (actions.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("Enter First name");
            string firstName = Console.ReadLine();
            bool q = false;
            while (!q)
            {
                for (int i = 0; i < records.Length; i++)
                {
                    if (Regex.IsMatch(records[i].firstName, firstName, RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine("Record: ");
                        Console.WriteLine(records[i]);
                        q = true;
                    }
                }
            }
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Enter Last name");
            string lastName = Console.ReadLine();
            bool q1 = false;
            while (!q1)
            {
                for (int i = 0; i < records.Length; i++)
                {
                    if (Regex.IsMatch(records[i].lastName, lastName, RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine("Record: ");
                        Console.WriteLine(records[i]);
                        q1 = true;
                    }
                }
            }
            break;
        case ConsoleKey.D3:
            Console.WriteLine("Enter number");
            string num = Console.ReadLine();
            bool q2 = false;
            while (!q2)
            {
                for (int i = 0; i < records.Length; i++)
                {
                    if (Regex.IsMatch(records[i].number, num, RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine("Record: ");
                        Console.WriteLine(records[i]);
                        q2 = true;
                    }
                }
            }
            break;
    }
}
void RemoveRecord()
{

}
void SaveToFile((string firstName, string lastName, string number)[] records)
{
    var data = new string[records.Length];

    for (int i = 0; i < records.Length; i++)
    {
        var record = records[i];
        data[i] = $"{record.firstName}|{record.lastName}|{record.number}";
    }

    File.WriteAllLines(FileName, data);

}
(string firstName, string lastName, string number)[] ReadFromFile()
{
    if (File.Exists(FileName))
    {
        var data = File.ReadAllLines(FileName);
        var records = new (string firstName, string lastName, string number)[data.Length];
        for (int i = 0; i < data.Length; i++)
        {

            var splited = data[i].Split('|');
            records[i] = (splited[0], splited[1], splited[2]);
        }
        return records;
    }
    return Array.Empty<(string, string, string)>();
}