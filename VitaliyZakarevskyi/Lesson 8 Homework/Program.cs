using System.IO;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";

Console.WriteLine("Phone Book Application");
Console.WriteLine("Select Action:");
Console.WriteLine("1 - Show Phone Book");
Console.WriteLine("2 - Add Record");
Console.WriteLine("3 - Update Record");
Console.WriteLine("4 - Remove Record");
Console.WriteLine("5 - Search for already existing record");
Console.WriteLine("0 - Exit");

var records = ReadFromFile();

while (true)
{
    var action = Console.ReadKey();
    Console.WriteLine();

    switch (action.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("Phone Book:");
            ShowPhoneBook(records);
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Add Record");
            AddRecord(records);
            break;
        case ConsoleKey.D3:
            Console.WriteLine("Update Record");
            UpdateRecord(records);
            break;
        case ConsoleKey.D4:
            Console.WriteLine("Remove Record");
            RemoveRecord();
            break;
        case ConsoleKey.D5:
            Console.WriteLine("Find contact:");
            SearchForNumber();
            break;
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Incorrect Input!");
            break;
            
    }
}

void ShowPhoneBook((string firstName, string lastName, string number)[] records)
{
    foreach (var record in records)
    {
        Console.WriteLine($"First Name: {record.firstName}, Last Name: {record.lastName}, Number: {record.number}");
    } 
}

void AddRecord((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Insert name");
    string firstName = Console.ReadLine();
    Console.WriteLine("Insert surname");
    string lastName = Console.ReadLine();
    Console.WriteLine("Insert phone number");
    string number = Console.ReadLine();


    Array.Resize(ref records, records.Length + 1);
    records[^1] = (firstName, lastName, number);
    SaveToFile(records);
    Console.WriteLine("Record added successfully");
    ShowPhoneBook(records);
}

void UpdateRecord((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Which contact do you want to update? (Insert number)");
    int temp = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Insert new name");
    string firstName = Console.ReadLine();
    Console.WriteLine("Insert new surname");
    string lastName = Console.ReadLine();
    Console.WriteLine("Insert new phone number");
    string number = Console.ReadLine();
    records[temp - 1] = (firstName, lastName, number);
    SaveToFile(records);
}

void RemoveRecord()
{
    Console.WriteLine("Which contact do you want to remove? (Insert number)");
    int temp = Convert.ToInt32(Console.ReadLine());
    Array.Clear(records, temp - 1, 1);
    SaveToFile(records);
    ShowPhoneBook(records);
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

void SearchForNumber()
{
    Console.WriteLine("Insert number, name or surname");
    string temp = Console.ReadLine();
    Regex rg = new Regex(temp);
    foreach (var record in records)
    {
        if (rg.IsMatch(record.firstName))
            Console.WriteLine(record);
        else if (rg.IsMatch(record.lastName))
            Console.WriteLine(record);
        else if (rg.IsMatch(record.number))
            Console.WriteLine(record);
    }
    


}