using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";

Console.WriteLine("Phone Book Aplications");

StartProgram();

void StartProgram()
{
    Console.WriteLine("Select Action:");
    Console.WriteLine("1 - Show Phone Book");
    Console.WriteLine("2 - Add Record");
    Console.WriteLine("3 - Update Record");
    Console.WriteLine("4 - Remove Record");
    Console.WriteLine("5 - Search Name");
    Console.WriteLine("0 - Exit");
}
    
    var records = ReadFromFile();


    while (true)
    {
        var action = Console.ReadKey();


        Console.WriteLine();

        switch (action.Key)
        {
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                Console.WriteLine("Phone Book:");
                ShowPhoneBook(records);
                StartProgram();
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                AddRecord();
                break;
        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            UpdateRecord();
            break;
        case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                RemoveRecord();
            break;
            case ConsoleKey.NumPad5:
            case ConsoleKey.D5:
                Search(records);
                break;
            case ConsoleKey.D0:
            case ConsoleKey.NumPad0:
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
    var index = 1;
    foreach (var record in records)
    {
        Console.WriteLine($"{index}".PadRight(4)+$"First Name: {record.firstName}, Last Name: {record.lastName}, Number: {record.number}");
        index += 1;
    }
    Console.WriteLine();
    //StartProgram();
}

void Search((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Input search type: \n1 - Search by FirstName \n2 - Search by LastName \n3 - Search by Number");

    var type= Console.ReadKey();

    switch(type.Key)
    {
        case ConsoleKey.NumPad1:
        case ConsoleKey.D1:
            Console.WriteLine("\nInput search argument - FirstName (fullname or some initial characters) :");
            string search = Console.ReadLine();
            SearchFistName(search, records);
            StartProgram();
            break;
        case ConsoleKey.NumPad2:
        case ConsoleKey.D2:
            Console.WriteLine("\nInput search argument - LastName (fullname or some initial characters) :");
            search = Console.ReadLine();
            SearchLastName(search, records);
            StartProgram();
            break;
        case ConsoleKey.NumPad3:
        case ConsoleKey.D3:
            Console.WriteLine("\nInput search argument - Number (fullnumber or some initial characters) :");
            search = Console.ReadLine();
            SearchNumber(search, records);
            StartProgram();
            break;
        default:
            Console.WriteLine("Incorrect Input!");
            StartProgram();
            break;

    }
    
    //string item ="Item1";
    void SearchFistName(string search, (string firstName, string lastName, string number)[] records)
    {
        if (search != null)
        {
            int counter = 0;
            for (int i = 0; i < records.Length; i++)
            {
                //var record = records[i];

                if (Regex.IsMatch(records[i].firstName, $"^{search}"))
                {
                    counter += 1;
                    Console.WriteLine($"First Name: {records[i].firstName}, Last Name: {records[i].lastName}, Number: {records[i].number}");
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No matches found, input <5> for another try");
            }
            Console.WriteLine();
        }       
    }

    void SearchLastName(string search, (string firstName, string lastName, string number)[] records)
    {
        if (search != null)
        {
            int counter = 0;
            for (int i = 0; i < records.Length; i++)
            {
                //var record = records[i];

                if (Regex.IsMatch(records[i].lastName, $"^{search}"))
                {
                    counter += 1;
                    Console.WriteLine($"First Name: {records[i].firstName}, Last Name: {records[i].lastName}, Number: {records[i].number}");
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No matches found, input <5> for another try");
            }
            Console.WriteLine();
        }
    }

    void SearchNumber(string search, (string firstName, string lastName, string number)[] records)
    {
        if (search != null)
        {
            int counter = 0;
            for (int i = 0; i < records.Length; i++)
            {
                //var record = records[i];

                if (Regex.IsMatch(records[i].number, $"^{search}"))
                {
                    counter += 1;
                    Console.WriteLine($"First Name: {records[i].firstName}, Last Name: {records[i].lastName}, Number: {records[i].number}");
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No matches found, input <5> for another try");
            }
            Console.WriteLine();
        }
    }
}

void AddRecord()
{
    Console.WriteLine("Input new record: (Firstname|Lastname|XXX-XXX-XXXX)");

    var newRecord = Console.ReadLine();

    var pattern =  "<word>|<word>|[0-9]{3}-[0-9]{3}-[0-9]{4}";

    bool match = Regex.IsMatch(newRecord, pattern);

    if (!match)
    {
        while (!match)
        {
            Console.WriteLine("Incorrect format, input newRecord:");
            newRecord = Console.ReadLine();
            match = Regex.IsMatch(newRecord, pattern);
        }
    }  
        
    var splited = newRecord.Split('|');

    var recordNew = new (string firstName, string lastName, string number)[records.Length+1];

    recordNew[0] = (splited[0], splited[1], splited[2]);

    for (int i=1;i<recordNew.Length;i++)
    {
        recordNew[i] = records[i - 1];
    }

    SaveToFile(recordNew);

    records = ReadFromFile();

    Console.WriteLine($"New Record {records[0]} was successfully added");
    Console.WriteLine();

    StartProgram();
}

void UpdateRecord()
{
    ShowPhoneBook(records);

    string d;
    int numb;
    bool b;
    do
    {
        Console.WriteLine($"Select number record for Update from 1 to {records.Length}");

        d = Console.ReadLine();

        b = Int32.TryParse(d, out numb);

    }
    while (!b || numb > records.Length || numb <= 0);

    Console.WriteLine($"Do you want Update record \n {records[numb - 1]}? \nyes - y / no - anykey");

    var record = records[numb - 1];

    if (Regex.IsMatch(Console.ReadLine(), "y"))
    {
        Console.WriteLine("Input new data of records: (Firstname|Lastname|XXX-XXX-XXXX)");

        var newRecord = Console.ReadLine();

        var pattern = "<word>|<word>|[0-9]{3}-[0-9]{3}-[0-9]{4}";

        bool match = Regex.IsMatch(newRecord, pattern);

        if (!match)
        {
            while (!match)
            {
                Console.WriteLine("Incorrect format, input newRecord:");
                newRecord = Console.ReadLine();
                match = Regex.IsMatch(newRecord, pattern);
            }
        }

        var splited = newRecord.Split('|');

        var recordNew = new (string firstName, string lastName, string number)[records.Length];

        if (numb > 1)
        {
            for (int i = 0; i < numb - 1; i++)
            {
                recordNew[i] = records[i];
            }

            recordNew[numb - 1] = (splited[0], splited[1], splited[2]);

            for (int i = numb; i < recordNew.Length; i++)
            {
                recordNew[i] = records[i];
            }
        }
        else if (numb == 1)
        {
            recordNew[0] = (splited[0], splited[1], splited[2]);

            for (int i = numb; i < records.Length; i++)
            {
                recordNew[i] = records[i];
            }
        }
        SaveToFile(recordNew);

        records = ReadFromFile();

        Console.WriteLine($"{record} was successfully updated to {records[numb - 1]}");
        Console.WriteLine();

        StartProgram();

    }
    else
    {
        StartProgram();
    }
}

void RemoveRecord()
{
    ShowPhoneBook(records);

    string d;
    int numb;
    bool b;
    do
    {
        Console.WriteLine($"Select number record for Remove from 1 to {records.Length}");

        d = Console.ReadLine();

        b = Int32.TryParse(d, out numb);

    }
    while (!b || numb > records.Length || numb <= 0);
    
        Console.WriteLine($"Do you want remove record \n {records[numb - 1]}? \nyes - y / no - anykey");
          
    if(Regex.IsMatch(Console.ReadLine(), "y"))
    {
        var record = records[numb - 1];
        var recordNew = new (string firstName, string lastName, string number)[records.Length - 1];

        if (numb > 1)
        {
            for (int i = 0; i < numb - 1; i++)
            {
                recordNew[i] = records[i];
            }
            for (int i = numb; i < records.Length; i++)
            {
                recordNew[i - 1] = records[i];
            }
        }
        else if(numb==1)
        {
            for (int i = numb; i < records.Length; i++)
            {
                recordNew[i - 1] = records[i];
            }
        }
        SaveToFile(recordNew);

        records = ReadFromFile();

        Console.WriteLine($"{record} was successfully removed");
        Console.WriteLine();

        StartProgram();
    }

    StartProgram();
} 


void SaveToFile((string firstName, string lastName, string number)[] records)
{
    var data = new string[records.Length];
    for(int i=0; i<records.Length; i++)
    {
        var record = records[i];
        data[i] = $"{record.firstName}|{record.lastName}|{record.number}";
    }
    
    
    File.WriteAllLines(FileName, data);
    
}


(string firstName, string lastName, string number)[] ReadFromFile()
{
  if(File.Exists(FileName))
    {
        var data = File.ReadAllLines(FileName);
        var records = new (string firstName, string lastName, string number)[data.Length];
        for (int i = 0; i<data.Length; i++) 
        {
            var splited = data[i].Split('|');
            records[i] = (splited[0], splited[1], splited[2]);
        }
        return records;
    }
  return Array.Empty<(string, string, string)>();
}