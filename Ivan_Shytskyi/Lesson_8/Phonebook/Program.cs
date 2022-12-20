using System.Collections.Generic;

const string FileName = "Phonebook.txt";

Console.WriteLine("Phone book Application");
Console.WriteLine("select actions:");
Console.WriteLine("1 - Show phone book");
Console.WriteLine("2 - Add record");
Console.WriteLine("3 - UpdateRecord");
Console.WriteLine("4 - RemoveRecord");
Console.WriteLine("8 - Exit");

var records = ReadFromFile();

while (true)
{
    var actions = Console.ReadKey();
    Console.WriteLine();
    switch (actions.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("Phone book:");
            ShowPhonebook(records);
            break;
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Incorect input!");
            break;

    }
}

ShowPhonebook(records);

void ShowPhonebook((string FirstName, string LastName, string number)[] records)
{
    foreach (var record in records)
        Console.WriteLine($"First name:{record.FirstName}, Last name: {record.LastName}, number: {record.number}");
}
(string FirstName, string LastName, string number)[] AddRecord((string FirstName, string LastName, string number)[] records)
{
    var newData = new (string FirstName, string LastName, string number)[records.Length+1];
    string FirstName = "";
    string LastName = "";
    string number = "";
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Enter First name, Last name, number");
        newData[i] = $"{FirstName=Console.ReadLine()}|{LastName=Console.ReadLine()}|{number=Console.ReadLine()}";
    }
    var records = SaveToFile(newData);
    return records;
}
void UpdateRecord()
{

}
void RemoveRecord()
{

}
void SaveToFile((string FirstName, string LastName, string number)[] records)
{
    string[] data = new string[records.Length];
    for (int i = 0; i<records.Length; i++)
    {
        var record = records[i];
        data[i] = $"{record.FirstName}|{record.LastName}|{record.number}";
    }
    File.WriteAllLines(FileName, data);
}
(string FirstName, string LastName, string number)[] ReadFromFile()
{
    if (File.Exists(FileName))
    {
        var data = File.ReadAllLines(FileName);

        var records = new (string FirstName, string LastName, string number)[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            var splited = data[i].Split('|');
            records[i] = (splited[0], splited[1], splited[2]); 
        }
        return records;
    }
    return Array.Empty<(string,string,string)>();
}