using System.Text.RegularExpressions;


const string FileName = "PhoneBook.txt";

var records = ReadFromFile();

while (true)
{
    Console.WriteLine("\nPhone Book Application");
    Console.WriteLine("Select Action:");
    Console.WriteLine("1 - Show Phone Book");
    Console.WriteLine("2 - Add Record");
    Console.WriteLine("3 - Update Record");
    Console.WriteLine("4 - Remove Record");
    Console.WriteLine("5 - Search");
    Console.WriteLine("0 - Exit");

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
            AddRecord(ref records);
            break;
        case ConsoleKey.D4:
            Console.WriteLine("Remove:");
            RemoveRecord(records);
            break;
        case ConsoleKey.D5:
            Console.WriteLine("Search:");
            Search(records);
            break;
        default:
            Console.WriteLine("Incorrect Input!");
            break;
    }

}

void Search((string firstName, string lastName, string number)[] records)
{
    
}

void ShowPhoneBook((string firstName, string lastName, string number)[] records)
{
    foreach (var record in records.Where(x => x.firstName != null))
    {
        Console.WriteLine($"First Name: {record.firstName,10},     Last Name: {record.lastName,10},     Number: {record.number}");
    }
}

void AddRecord(ref (string firstName, string lastName, string number)[] records)
{
    string name, phoneNumber, surname;
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
            Console.WriteLine("Invalid Surname.");
            continue;
        }
        break;
    }
    while (true)
    {
        Console.Write("Phone number: ");
        phoneNumber = Console.ReadLine();
        if (!Regex.IsMatch(phoneNumber, @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$"))
        {
            Console.WriteLine("Invalid phone number.");
            continue;
        }
        break;
    }
    //Якщо масив повний, то створюємо новий, у якого довжина в 2 рази більше від основного
    if (records[records.Length - 1].firstName != "")
    {
        var records2 = new (string firstName, string lastName, string number)[records.Length * 2];
        Array.Copy(records, records2, records.Length);
        records = records2;
    }

    //Знаходимо перший не зайнятий елемент масиву
    int freeCell = Array.IndexOf(records, records.FirstOrDefault(x => x.firstName == null));

    records[freeCell].firstName = name;
    records[freeCell].lastName = surname;
    records[freeCell].number = phoneNumber;

    SaveToFile(records.Where(x => x.lastName != null).ToArray());

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

void RemoveRecord((string firstName, string lastName, string number)[] records)
{
    //records.Del;
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
enum SearchField
{
    FirstName = 1,
    LastName,
    PhoneNumber
}