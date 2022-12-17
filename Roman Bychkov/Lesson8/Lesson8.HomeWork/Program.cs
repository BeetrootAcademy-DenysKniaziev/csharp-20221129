using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";

Console.WriteLine("Phone Book Application");
Console.WriteLine("Select Action:");
Console.WriteLine("1 - Show Phone Book");
Console.WriteLine("2 - Add Record");
Console.WriteLine("3 - Update Record");
Console.WriteLine("4 - Remove Record");
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
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            Environment.Exit(0);
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Add Record:");
            AddRecord(records);
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
    string name, phone, surname;
    while (true)
    {
        Console.Write("Name: ");
        name = Console.ReadLine();
        if (OnlyLetters(name))
        {
            Console.WriteLine("Invalid name.");
            continue;
        }
        break;
    }
    while (true)
    {
        Console.Write("Surname: ");
        surname = Console.ReadLine();
        if (OnlyLetters(surname))
        {
            Console.WriteLine("Invalid name.");
            continue;
        }
        break;
    }
    while (true)
    {
        Console.Write("Phone: ");
        phone = Console.ReadLine();
        if (!Regex.IsMatch(phone, @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$"))
        {
            Console.WriteLine("Invalid name.");
            continue;
        }
        break;
    }
    //Console.WriteLine(name + "|" + surname + "|" + phone);


    //if (File.Exists(FileName))
    //{
    //    File.AppendAllText(FileName, name + "|" + surname + "|" + phone);
    //}
    if (records[records.Length - 1].firstName == "")
    {
        var records2 = new (string firstName, string lastName, string number)[];

    }



    bool OnlyLetters(string name)
    {
        if (Regex.IsMatch(name, @"^[A-Z]{1}[a-z]+$"))
        {
            return false;
        }
        return true;
    }
}

void UpdateRecord()
{

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