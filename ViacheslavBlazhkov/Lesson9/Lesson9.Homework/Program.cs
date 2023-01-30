using System;
using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";


Console.WriteLine("1 - Show Phone Book");
Console.WriteLine("2 - Add Record");
Console.WriteLine("3 - Update Record");
Console.WriteLine("4 - Remove Record");
Console.WriteLine("5 - Search Record");
Console.WriteLine("6 - Sort Records");
Console.WriteLine("0 - Exit");

while (true)
{
    Console.Write("\nSelect Action: ");
    var records = ReadFromFile();
    var action = Console.ReadKey(); Console.WriteLine();

    switch (action.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Phone Book");
            ShowPhoneBook(records);
            break;

        case ConsoleKey.D2:
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Adding Record");
            AddRecord(records);
            break;
        case ConsoleKey.D3:
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Updating Record");
            UpdateRecord(records);
            break;
        case ConsoleKey.D4:
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Removing Record");
            RemoveRecord(records);
            break;

        case ConsoleKey.D5:
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Searching Record");
            SearchRecord(records);
            break;
        case ConsoleKey.D6:
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Sorting Records");
            SortRecords(records);
            break;

        case ConsoleKey.D0:
            Console.WriteLine("\n-----------------------------");
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
    Console.Write("Enter First Name: ");
    string firstName = Console.ReadLine();
    Console.Write("Enter Last Name: ");
    string lastName = Console.ReadLine();
    Console.Write("Enter Number: ");
    string number = Console.ReadLine();

    if (number == "" || firstName == "" || lastName == "")
    {
        Console.WriteLine("All of fields must be filled!");
        return;
    }

    Regex numberRegex = new Regex(@"\d{3}-\d{3}-\d{4}");
    MatchCollection matches = numberRegex.Matches(number);
    if (matches.Count > 0)
    {
        foreach (Match match in matches) Console.WriteLine("Correct number!");
    }
    else
    { 
        Console.WriteLine("Invalid number!"); 
        return; 
    }

    var record = (firstName, lastName, number);

    int newLength = records.Length + 1;
    Array.Resize(ref records, newLength);
    records[newLength - 1] = record;

    Console.WriteLine("Number was added!");
    SaveToFile(records);
}

void UpdateRecord((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Enter Last Name: "); string edit = Console.ReadLine();
    string matchS = "";
    
    for (int item = 0; item < records.Length; item++)
    {
        if (records[item].lastName == edit)
        {
            Console.WriteLine("This record?(Y/N)");
            Console.WriteLine($"First Name: {records[item].firstName}, Last Name: {records[item].lastName}, Number: {records[item].number}");
            int index = item;
            var input = Console.ReadLine();
            matchS = "S";

            if (input.ToUpper() == "Y")
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter Number: ");
                string number = Console.ReadLine();

                if (number == "" || firstName == "" || lastName == "")
                {
                    Console.WriteLine("All of fields must be filled!");
                    return;
                }

                Regex numberRegex = new Regex(@"\d{3}-\d{3}-\d{4}");
                MatchCollection matches = numberRegex.Matches(number);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches) Console.WriteLine("Correct number!");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }

                records[item].firstName = firstName; records[item].lastName = lastName; records[item].number = number;
                Console.WriteLine("Number was updated!");

                SaveToFile(records);
            }
            else if (input.ToUpper() == "N")
            {
                continue;
            }
        }
    }
    if (matchS == "") Console.WriteLine("Record doesn't exists!");
}

void RemoveRecord((string firstName, string lastName, string number)[] records)
{
    Console.Write("Enter Last Name: ");
    string delete = Console.ReadLine();
    string matchS = "";

    for (int item = 0; item < records.Length; item++)
    {
        if (records[item].lastName == delete)
        {
            Console.WriteLine("This record?(Y/N)");
            Console.WriteLine($"First Name: {records[item].firstName}, Last Name: {records[item].lastName}, Number: {records[item].number}");
            int index = item;
            var input = Console.ReadLine();
            matchS = "S";

            if (input.ToUpper() == "Y")
            {
                var newRecords = new (string, string, string)[records.Length - 1];
                for (int i = 0; i < records.Length; i++)
                {
                    if (i < index)
                    {
                        newRecords[i] = records[i];
                    }
                    else if (i > index)
                    {
                        newRecords[i - 1] = records[i];
                    }
                }
                Console.WriteLine("Record is deleted!");
                SaveToFile(newRecords);
            }
            else if (input.ToUpper() == "N")
            {
                continue;
            }
        }
    }
    if (matchS == "") Console.WriteLine("Record doesn't exists!");
}

void SearchRecord((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Choose parameter to search: (1 - First Name, 2 - Last Name, 3 - Number)");
    var input = Console.ReadKey(); Console.WriteLine();

    switch (input.Key)
    {
        case ConsoleKey.D1:
            Console.Write("Enter First Name: ");
            string fn = Console.ReadLine();
            for (int item = 0; item < records.Length; item++)
            {
                if (records[item].firstName == fn)
                {
                    Console.WriteLine("\nThis record? If it isn't this record press N key. If it's this record press ENTER.");
                    Console.WriteLine($"First Name: {records[item].firstName}, Last Name: {records[item].lastName}, Number: {records[item].number}");

                    if (Console.ReadLine().ToUpper() == "N")
                    {
                        continue;
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.Enter) return;
                }
            }
            Console.WriteLine("Incorrect input or Record doesn't exist");
            break;

        case ConsoleKey.D2:
            Console.Write("Enter Last Name: ");
            string ln = Console.ReadLine();
            for (int item = 0; item < records.Length; item++)
            {
                if (records[item].lastName == ln)
                {
                    Console.WriteLine("\nThis record? If it isn't this record press N key. If it's this record press ENTER.");
                    Console.WriteLine($"First Name: {records[item].firstName}, Last Name: {records[item].lastName}, Number: {records[item].number}");

                    if (Console.ReadLine().ToUpper() == "N")
                    {
                        continue;
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.Enter) return;
                }
            }
            Console.WriteLine("Incorrect input or Record doesn't exist");
            break;

        case ConsoleKey.D3:
            Console.Write("Enter Number: ");
            string numb = Console.ReadLine();
            for (int item = 0; item < records.Length; item++)
            {
                if (records[item].number == numb)
                {
                    Console.WriteLine("\nThis record? If it isn't this record press N key. If it's this record press ENTER.");
                    Console.WriteLine($"First Name: {records[item].firstName}, Last Name: {records[item].lastName}, Number: {records[item].number}");

                    if (Console.ReadLine().ToUpper() == "N")
                    {
                        continue;
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.Enter) return;
                }
            }
            Console.WriteLine("Incorrect input or Record doesn't exist");
            break;
         default:
            Console.WriteLine("Incorrect input!");
            break;
    }
}

void SortRecords((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Choose parameter to sort records: (1 - First Name, 2 - Last Name, 3 - Number)");
    var param = Console.ReadKey();
    if (param.Key != ConsoleKey.D1 && param.Key != ConsoleKey.D2 && param.Key != ConsoleKey.D3)
    {
        Console.WriteLine("\nIncorrect input!");
        return;
    }

    Console.WriteLine("\nChoose sort direction: (1 - Ascending, 2 - Descending)");
    var dir = Console.ReadKey(); Console.WriteLine();
    if (dir.Key != ConsoleKey.D1 && dir.Key != ConsoleKey.D2)
    {
        Console.WriteLine("\nIncorrect input!");
        return;
    }

    var sorted = records;

    switch (param.Key)
    {
        case ConsoleKey.D1:
            switch (dir.Key)
            {
                case ConsoleKey.D1:
                    sorted = records.OrderBy(x => x.firstName).ToArray();
                    break;
                case ConsoleKey.D2:
                    sorted = records.OrderByDescending(x => x.firstName).ToArray();
                    break;
            }
            break;
        case ConsoleKey.D2:
            switch (dir.Key)
            {
                case ConsoleKey.D1:
                    sorted = records.OrderBy(x => x.lastName).ToArray();
                    break;
                case ConsoleKey.D2:
                    sorted = records.OrderByDescending(x => x.lastName).ToArray();
                    break;
            }
            break;
        case ConsoleKey.D3:
            switch (dir.Key)
            {
                case ConsoleKey.D1:
                    sorted = records.OrderBy(x => x.number).ToArray();
                    break;
                case ConsoleKey.D2:
                    sorted = records.OrderByDescending(x => x.number).ToArray();
                    break;
            }
            break;
        default:
            break;
    }

    Console.WriteLine("Records were sorted.");
    SaveToFile(sorted);
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