using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

const string FileName = "Phonebook.txt";

Console.WriteLine("Phone book Application");
Console.WriteLine("select actions:");
Console.WriteLine("1 - Show phone book");
Console.WriteLine("2 - Add record");
Console.WriteLine("3 - UpdateRecord");
Console.WriteLine("4 - RemoveRecord");
Console.WriteLine("5 - SearchRecord");
Console.WriteLine("6 - Sort");
Console.WriteLine("0 - Exit");

var records = ReadFromFile();

static (string, string, string)[] copyArr ((string FirstName, string LastName, string number)[] records)
{
    var newData = new (string FirstName, string LastName, string number)[records.Length + 1];
    for (int i = 0; i < records.Length; i++)
    {
        newData[i] = records[i];
    }
    return newData;
}
while (true)
{
    var actions = Console.ReadKey();
    Console.WriteLine();
    switch (actions.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("Phone book:");
            Console.WriteLine();
            ShowPhonebook(records);
            Console.WriteLine(new string ('*',30));
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Add record:");
            Console.WriteLine();
            AddRecord(records);
            Console.WriteLine(new string('*', 30));
            break;
        case ConsoleKey.D3:
            Console.WriteLine("UpdateRecord:");
            Console.WriteLine();
            UpdateRecord(records);
            Console.WriteLine(new string('*', 30));
            break;
        case ConsoleKey.D4:
            Console.WriteLine("RemoveRecord:");
            Console.WriteLine();
            RemoveRecord(records);
            Console.WriteLine(new string('*', 30));
            break;
        case ConsoleKey.D5:
            Console.WriteLine("SearchRecord:");
            Console.WriteLine();
            SearchRecord(records);
            Console.WriteLine(new string('*', 30));
            break;
        case ConsoleKey.D6:
            Console.WriteLine("Sort:");
            Console.WriteLine();
            Sort(records);
            Console.WriteLine(new string('*', 30));
            break;
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            Console.WriteLine();
            Environment.Exit(0);
            Console.WriteLine(new string('*', 30));
            break;
        default:
            Console.WriteLine("Incorect input!");
            Console.WriteLine(new string('*', 30));
            break;

    }
}
void ShowPhonebook((string FirstName, string LastName, string number)[] records)
{
    foreach (var record in records)
    {
        Console.WriteLine($"First name:{record.FirstName} \nLast name: {record.LastName} \nnumber:    {record.number}");
        Console.WriteLine(new string('-', 30));
    }
}
void Sort ((string FirstName, string LastName, string number)[] records)
{
    Array.Sort(records);
    SaveToFile(records);
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
    
    records1[records1.Length- 1].Item1 = record.FirstName;
    records1[records1.Length - 1].Item2 = record.LastName;
    records1[records1.Length - 1].Item3 = record.number;

    SaveToFile(records1);
}
void SearchRecord((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Enter number to find a person:\n1. First name\n2. Last name\n3. number");
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
void UpdateRecord((string FirstName, string LastName, string number)[] records)
{
    Console.WriteLine("Find the person: ");
    Console.Write("Enter First name:");
    string FirstName = Console.ReadLine();
    Console.Write("Enter Last name:");
    string LastName = Console.ReadLine();
    Console.Write("Enter number:");
    string number = Console.ReadLine();

    var record = (FirstName, LastName, number);
    Console.WriteLine(record);

    int count;
    Console.WriteLine("What do you want to change:\n1 - Firstname\n2 - Lastname\n3 - number");
    count = Convert.ToInt32(Console.ReadLine());
    if (count == 1)
    {
        for (int i = 0; i < records.Length; i++)
        {
            if (Regex.IsMatch(records[i].FirstName, FirstName, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Enter a new Firstname");
                records[i].FirstName = Console.ReadLine();
            }
        }
    }
    else if (count == 2)
    {
        for (int i = 0; i < records.Length; i++)
        {
            if (Regex.IsMatch(records[i].LastName, LastName, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Enter a new Lastname");
                records[i].LastName = Console.ReadLine();
            }
        }
    }
    else
    {
        for (int i = 0; i < records.Length; i++)
        {
            if (Regex.IsMatch(records[i].number, number, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Enter a new number");
                records[i].number = Console.ReadLine();
            }
        }
    }
    SaveToFile(records);
}
void RemoveRecord((string FirstName, string LastName, string number)[] records)
{
    Console.WriteLine("Enter the number to delete");
    string num = Console.ReadLine();
    int count = 0;
    for (int i = 0; i < records.Length; i++)
    {
        if (Regex.IsMatch(records[i].number, num, RegexOptions.IgnoreCase))
        {
            count = i;
            break;
        }
    }
    var records2 = new (string FirstName, string LastName, string number)[records.Length - 1];
        for (int i = 0; i < records.Length; i++)
        {
            if (i < count)
                records2[i] = records[i];
            else if (i > count)
                records2[i-1] = records[i];
        }
    SaveToFile(records2);
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