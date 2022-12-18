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
    Console.WriteLine("7 - Binary Search");
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
        case ConsoleKey.D3:
            Console.WriteLine("Update Record: ");
            UpdateRecord(records);
            break;
        case ConsoleKey.D4:
            Console.WriteLine("Remove:");
            RemoveRecord(ref records);
            break;
        case ConsoleKey.D5:
            Console.WriteLine("Search:");
            Search(records);
            break;
        case ConsoleKey.D7:
            Console.WriteLine("Binary Search:");
            SearchId(records);
            break;
        default:
            Console.WriteLine("Incorrect Input!");
            break;
    }

}

int SearchId((string firstName, string lastName, string number)[] records)
{
    AlphabeticalSort(records);
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

void AlphabeticalSort((string firstName, string lastName, string number)[] records)
{
    Array.Sort(records);
    foreach (var record in records)
        Console.WriteLine($"{record.firstName,10}{record.lastName,15}\t{record.number,10}");
    SaveToFile(records);
}

int BinarySearch((string firstName, string lastName, string number)[] records, (string firstName, string lastName, string number) element)
{
    string find = element.firstName + element.lastName + element.number;
    string[] array = new string[records.Length];
    for (int i = 0; i < records.Length; i++)
    {
        array[i] = records[i].firstName + records[i].lastName + records[i].number;
    }

    int start = 0, end = array.Length;
    while (start <= end)
    {
        if (array[(start + end) / 2] == find)
            return (start + end) / 2;

        else if (string.Compare(find, array[(end - start) / 2 + start]) == -1)
            end = (end + start) / 2 - 1;

        else
            start = (end + start) / 2 + 1;
    }
    return -1;
}

void Search((string firstName, string lastName, string number)[] records)
{
    SearchField searchField = new SearchField();
    int choice = 0;

    while (true)
    {
        Console.WriteLine("First Name - 1\nLast Name - 2\nPhone Number - 3\nExit - 0");
        if (!int.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(SearchField), choice))
        {
            Console.WriteLine("Invalid input");
            continue;
        }
        searchField = (SearchField)choice;
        switch (searchField)
        {
            case SearchField.FirstName:
                SearchPerson(records, searchField);
                break;
            case SearchField.LastName:
                SearchPerson(records, searchField);
                break;
            case SearchField.PhoneNumber:
                SearchPerson(records, searchField);
                break;
            case SearchField.Skip:
                return;
        }
    }
}


void SearchPerson((string firstName, string lastName, string number)[] records, SearchField searchField)
{
    Console.Write($"Enter a {searchField}: ");
    string patternNumber = "", pattern = "";
    if (searchField != SearchField.PhoneNumber)
        pattern = @"^" + Console.ReadLine() + "[a-z]*$";
    else
    {
        Console.WriteLine("Format AAA-BBB-CCCC");
        patternNumber = @"^" + Console.ReadLine() + "";
    }

    foreach (var item in records)
        if (Regex.IsMatch(item.firstName, pattern, RegexOptions.IgnoreCase) && searchField == SearchField.FirstName || Regex.IsMatch(item.lastName, pattern, RegexOptions.IgnoreCase) && searchField == SearchField.LastName || Regex.IsMatch(item.number, patternNumber) && searchField == SearchField.PhoneNumber)
        {
            Console.WriteLine($"First Name: {item.firstName,10},     Last Name: {item.lastName,10},     Number: {item.number}");
        }
}



void ShowPhoneBook((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine($"First Name\tLast Name\tNumber");
    foreach (var record in records)
    {
        Console.WriteLine($"{record.firstName,10}{record.lastName,15}\t{record.number,10}");
    }
}

void AddRecord(ref (string firstName, string lastName, string number)[] records)
{

    //Якщо масив повний, то створюємо новий, у якого довжина на 1 раз більше від основного
    if (records[records.Length - 1].firstName != "")
    {
        var newRecords = new (string firstName, string lastName, string number)[records.Length + 1];
        Array.Copy(records, newRecords, records.Length);
        records = newRecords;
    }
    var newRecord = CurrentInputData();
    records[records.Length - 1].firstName = newRecord.firstName;
    records[records.Length - 1].lastName = newRecord.lastName;
    records[records.Length - 1].number = newRecord.number;

    SaveToFile(records.ToArray());

}
(string firstName, string lastName, string number) CurrentInputData()
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
        if (CurrectPhoneNumber(phoneNumber))
        {
            Console.WriteLine("Invalid phone number.");
            continue;
        }
        break;
    }
    return (name, surname, phoneNumber);

    bool OnlyLetters(string name)
    {
        if (Regex.IsMatch(name, @"^[A-Z]{1}[a-z]+$"))
            return false;
        return true;
    }
    bool CurrectPhoneNumber(string phoneNumber)
    {
        if (Regex.IsMatch(phoneNumber, @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$"))
            return false;
        return true;
    }
}

void UpdateRecord((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Enter the person you want to change the information for: ");
    int id = SearchId(records);
    if (id == -1)
    {
        Console.WriteLine("Person Not Found");
        return;
    }
    var updateRecord = CurrentInputData();

    records[id].firstName = updateRecord.firstName;
    records[id].lastName = updateRecord.lastName;
    records[id].number = updateRecord.number;
    SaveToFile(records);

}

void RemoveRecord(ref (string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Enter the person you want to delete the information for: ");
    int id = SearchId(records);
    if (id == -1)
    {
        Console.WriteLine("Person Not Found");
        return;
    }
    var newRecords = new (string firstName, string lastName, string number)[records.Length - 1];
    Array.Copy(records, 0, newRecords, 0, id);
    Array.Copy(records, id + 1, newRecords, id, records.Length - id - 1);

    records = newRecords;
    SaveToFile(records);
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
    Skip = 0,
    FirstName = 1,
    LastName,
    PhoneNumber
}