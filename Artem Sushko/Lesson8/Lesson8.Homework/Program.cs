using System.Text.RegularExpressions;
const string FileName = "PhoneBook.txt";

Console.Write("Enter the amount of strings in your PhoneBook: ");
var length = int.Parse(Console.ReadLine());
var records = new (string firstname, string lastname, string number)[length];
for (int i = 0; i < records.Length; i++)
{
    Console.WriteLine($"\nEnter {i + 1} string in your PhoneBook: ");
    Console.Write("First Name: ");
    records[i].firstname = Console.ReadLine();
    Console.Write("Last Name: ");
    records[i].lastname = Console.ReadLine();
    Console.Write("Phone Number(xxx-xxx-xxxx): ");
    records[i].number = Console.ReadLine();
}
SaveToFile(records);

while (true)
{
    records = ReadFromFile();

    Console.Clear();
    Console.WriteLine("Phone Book Application");
    Console.WriteLine("Select Action:");
    Console.WriteLine("1 - Show Phone Book");
    Console.WriteLine("2 - Find a Record");
    Console.WriteLine("3 - Binary Search");
    Console.WriteLine("0 - Exit");

    var action = Console.ReadKey();
    Console.WriteLine();

    switch (action.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine("Phone Book:");
            ShowPhoneBook(records);
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Finding a Record");
            Search(records);
            break;
        case ConsoleKey.D3:
            Console.WriteLine("Binary Search:");
            SearchId(records);
            break;
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Incorrect Input!");
            break;
    }
    Console.ReadLine();
}
void ShowPhoneBook((string firstName, string lastName, string number)[] records)
{
    for (int i = 0; i < records.Length; i++)
    {
        if (records[i].firstName != "")
        {
            Console.WriteLine($"First Name: {records[i].firstName}, Last Name: {records[i].lastName}, Number: {records[i].number}");
        }
    }
}

int SearchId((string firstName, string lastName, string number)[] records)
{
    AlphabeticSort(records);
    string name, lastName, phoneNumber;
    Console.Write("Name: ");
    name = Console.ReadLine();
    Console.Write("LastName: ");
    lastName = Console.ReadLine();
    Console.Write("Phone Number: ");
    phoneNumber = Console.ReadLine();
    int id = BinarySearch(records, (firstName: name, lastName: lastName, phoneNumber: phoneNumber));
    Console.WriteLine("Id in book: " + id);
    return id;
}

void AlphabeticSort((string firstName, string lastName, string number)[] records)
{
    Array.Sort(records);
    SaveToFile(records);
}

void Search((string firstName, string lastName, string number)[] records)
{
    AlphabeticSort(records );
    bool IsFinish = false;
    while (!IsFinish)
    {
        Console.WriteLine("Enter the Phone Number that you want to search:");
        var SearchNumber = Console.ReadLine();
        for (int i = 0; i < length; i++)
        {
            if (Regex.IsMatch(records[i].number, SearchNumber))
            {
                for (int j = 0; j < records.Length; j++)
                {
                    if (Regex.IsMatch(records[i].number, SearchNumber))
                    {
                        Console.Write("Your Record: ");
                        Console.WriteLine(records[i]);
                        IsFinish = true;
                        break;
                    }
                }
                break;
            }
        }
    }
}

int BinarySearch((string firstName, string lastName, string number)[] records, (string firstName, string lastName, string number) element)
{
    AlphabeticSort(records);
    string find = element.firstName + element.lastName + element.number;
    string[] array = new string[records.Length];
    for (int i = 0; i < records.Length; i++)
    {
        array[i] = records[i].firstName + records[i].lastName + records[i].number;
    }

    int low = 0, high = array.Length;
    while (low <= high)
    {
        if (array[(low + high) / 2] == find)
            return (low + high) / 2;

        else if (string.Compare(find, array[(high - low) / 2 + low]) == -1)
            high = (high + low) / 2 - 1;

        else
            low = (high + low) / 2 + 1;
    }
    return -1;
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