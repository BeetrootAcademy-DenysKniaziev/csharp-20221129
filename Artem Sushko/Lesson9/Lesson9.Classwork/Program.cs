using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";
while (true)
{

    Console.Clear();
    try
    {
        Console.Write("Enter the amount of strings in your PhoneBook: ");
        var length = int.Parse(Console.ReadLine());
        var records = new (string firstname, string lastname, string number)[length];
        for (int i = 0; i < records.Length; i++)
        {
            Console.WriteLine($"\nEnter {i + 1} string in your PhoneBook: ");
            Console.Write("First Name: ");
            records[i].firstname = Console.ReadLine();
            char[] test = records[i].firstname.ToCharArray();
            for (int j = 0; j < test.Length; j++)
            {
                if (char.IsDigit(test[j]))
                {
                    Console.WriteLine("Incorect Input");
                    Environment.Exit(0);
                }
            }
            Console.Write("Last Name: ");
            records[i].lastname = Console.ReadLine();
            test = records[i].lastname.ToCharArray();
            for (int j = 0; j < test.Length; j++)
            {
                if (char.IsDigit(test[j]))
                {
                    Console.WriteLine("Incorect Input");
                    Environment.Exit(0);
                }
            }
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
            Console.WriteLine("2 - Add Record");
            Console.WriteLine("3 - Update Record");
            Console.WriteLine("4 - Remove Record");
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
                    Console.WriteLine("Adding Record:");
                    AddRecord(records);
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Updating Record:");
                    UpdateRecord(records);
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Removing Record:");
                    RemoveRecord(records);
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
    }

    catch (FormatException)
    {
        Console.WriteLine("Format Exeption. Try again!");
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

void AddRecord((string firstName, string lastName, string number)[] records)
{
    try
    {
        Console.WriteLine("How many Records do you want to add?");
        var tmp = int.Parse(Console.ReadLine());
        var records2 = new (string firstName, string lastName, string number)[records.Length + tmp];
        for (int i = 0; i < records.Length; i++)
        {
            records2[i] = records[i];
        }
        for (int i = 0; i < tmp; i++)
        {
            Console.WriteLine("Add a NEW Record:");
            Console.Write("First Name: ");
            records2[records.Length + i].firstName = Console.ReadLine();
            
            Console.Write("Last Name: ");
            records2[records.Length + i].lastName = Console.ReadLine();
            
            Console.Write("Phone Number(xxx-xxx-xxxx): ");
            records2[records.Length + i].number = Console.ReadLine();
        }
        SaveToFile(records2);
        Console.WriteLine($"{tmp} Records added!");
    }
    catch (FormatException)
    {
        Console.WriteLine("Format Exception. Try again!");
    }

}

void UpdateRecord((string firstName, string lastName, string number)[] records)
{
    try
    {
        bool finish = false;
        while (!finish)
        {
            Console.Clear();
            Console.WriteLine("What do you want to update?\nSellect: 1-First Name\n\t 2-Last Name\n\t 3-Phone Number");
            var select = int.Parse(Console.ReadLine());


            if (select > 0 && select < 4)
            {
                Console.Write("Enter your Phone Number(xxx-xxx-xxxx): ");
                var number = Console.ReadLine();
                switch (select)
                {
                    case 1:
                        for (int i = 0; i < records.Length; i++)
                        {
                            if (Regex.IsMatch(records[i].number, number))
                            {
                                Console.Write("Enter a NEW First Name: ");
                                var testnumber = Console.ReadLine();
                                char[] testarr = testnumber.ToCharArray();
                                for (int j = 0; j < testarr.Length; j++)
                                {
                                    if (char.IsDigit(testarr[j]))
                                    {
                                        Console.WriteLine("Incorect Input");
                                        Environment.Exit(0);
                                    }
                                }
                                records[i].firstName = testnumber;
                                finish = true;
                                break;
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < records.Length; i++)
                        {
                            if (Regex.IsMatch(records[i].number, number))
                            {
                                Console.Write("Enter a NEW Last Name: ");
                                var testnumber = Console.ReadLine();
                                char[] testarr = testnumber.ToCharArray();
                                for (int j = 0; j < testarr.Length; j++)
                                {
                                    if (char.IsDigit(testarr[j]))
                                    {
                                        Console.WriteLine("Incorect Input");
                                        Environment.Exit(0);
                                    }
                                }
                                records[i].lastName = testnumber;
                                finish = true;
                                break;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < records.Length; i++)
                        {
                            if (Regex.IsMatch(records[i].number, number))
                            {
                                Console.Write("Enter a NEW Phone Number: ");
                                var testnumber = Console.ReadLine();
                                char[] testarr = testnumber.ToCharArray();
                                for (int j = 0; j < testarr.Length; j++)
                                {
                                    if (char.IsLetter(testarr[j]))
                                    {
                                        Console.WriteLine("Incorect Input");
                                        Environment.Exit(0);
                                    }
                                }
                                records[i].number = testnumber;
                                finish = true;
                                break;
                            }
                        }
                        break;
                }
                Console.WriteLine("Your Record has updated!");

            }
            else Console.WriteLine("Incorect Input");

        }
        SaveToFile(records);
    }
    catch (FormatException)
    {
        Console.WriteLine("Format Exception. Try again!");
    }
}

void RemoveRecord((string firstName, string lastName, string number)[] records)
{
    bool finish = false;
    while (!finish)
    {
        Console.Clear();

        Console.WriteLine("Enter the Phone Number that you want to delete:");
        var numbers = Console.ReadLine();
        char[] testarr = numbers.ToCharArray();
        for (int i = 0; i < testarr.Length; i++)
        {
            if (char.IsLetter(testarr[i]))
            {
                Console.WriteLine("Incorect Input");
                Environment.Exit(0);
            }
        }
        
        for (int i = 0; i < records.Length; i++)
        {
            if (Regex.IsMatch(records[i].number, numbers))
            {
                records[i].number = null;
                records[i].lastName = null;
                records[i].firstName = null;
                SaveToFile(records);
                Console.WriteLine("Your Phone number has deleted");
                finish = true;
                break;
            }
        }
    }
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