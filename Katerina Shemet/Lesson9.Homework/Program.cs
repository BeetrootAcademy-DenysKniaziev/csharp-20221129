using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";

Console.WriteLine("Phone Book Application");
Console.WriteLine("Select Action:");
Console.WriteLine("1 - Show Phone Book");
Console.WriteLine("2 - Add Record");
Console.WriteLine("3 - Search");
Console.WriteLine("0 - Exit");

var records = ReadFromFile();


while (true)
{
    var action = Console.ReadKey();
    Console.WriteLine();

    switch (action.Key)
    {
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            Environment.Exit(0);
            break;
        case ConsoleKey.D1:
            Console.WriteLine("Phone Book:");
            try
            {
                ShowPhoneBook(records);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Add records:");
            try
            {
                AddRecord();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            break;
        case ConsoleKey.D3:
            Console.WriteLine("Search:");
            SearchByNumber(records);
            break;


        default:
            Console.WriteLine("Incorrect Input!");
            break;
    }
}

void ShowPhoneBook((string firstName, string lastName, string number)[] records)
{
    if(records.Length==0)
    {
        throw new Exception("Phone Book is empty!");
    }

    foreach (var record in records)
    {
        Console.WriteLine($"First Name: {record.firstName}, Last Name: {record.lastName}, Number: {record.number}");
    }
}

void AddRecord()
{
    Console.Write("Enter the number of records: ");
    var length = Convert.ToInt32(Console.ReadLine());

    if(length<1 || length>10)
    {
        throw new Exception("Your number of records must be greater than 0 and not greater than 10!");
    }

    var records = new (string firstname, string lastname, string number)[length];
    for (int i = 0; i < records.Length; i++)
    {
        Console.Write("First Name: ");
        records[i].firstname = Console.ReadLine();
        Console.Write("Last Name: ");
        records[i].lastname = Console.ReadLine();
        Console.Write("Phone Number(xxx-xxx-xxxx): ");
        var Numb =  Console.ReadLine();
        try
        {
            if (Regex.IsMatch(Numb, @"^\\d{3}-\d{3}-\d{4}$"))
            {
                records[i].number = Numb;
            }
            else
            {
                throw new Exception("Incorrect number format.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            records[i].number = Numb;
        }
        
    }
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

void SearchByNumber((string firstName, string lastName, string number)[] records)
{
    bool toggle = false;
    while (!toggle)
    {
        Console.WriteLine("Enter the Phone Number that you want to search:");
        var Number = Console.ReadLine();
        try
        {
            for (int i = 0; i < records.Length; i++)
            {
                if (Regex.IsMatch(records[i].number, Number))
                {
                    for (int j = 0; j < records.Length; j++)
                    {
                        if (Regex.IsMatch(records[i].number, Number))
                        {
                            Console.WriteLine("Record: ");
                            Console.WriteLine(records[i]);
                            toggle = true;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something bed happend..");
        }
        
    }
}


