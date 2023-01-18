const string FileName = "PhoneBook.txt";
while (true)
{
    try
    {
        Console.WriteLine("Phone Book Application");
        Console.WriteLine("Select Action:");
        Console.WriteLine("1 - Show Phone Book");
        Console.WriteLine("2 - Add Record");
        Console.WriteLine("3 - Update Record");
        Console.WriteLine("4 - Remove Record");
        Console.WriteLine("5 - Search by number");
        Console.WriteLine("0 - Exit");

        var records = ReadFromFile();


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
                ShowPhoneBook(records);
                break;

            case ConsoleKey.D2:
                Console.WriteLine("Add record");
                AddRecord(records);
                break;

            case ConsoleKey.D3:
                break;

            case ConsoleKey.D4:
                Console.WriteLine("Remove by number");
                RemoveRecordByNumber(records);
                break;

            case ConsoleKey.D5:
                Console.WriteLine("Search record");
                SearchRecordByNumber(records);
                break;

            default:
                Console.WriteLine("Incorrect Input!");
                break;
        }
    }


    catch (Exception)
    {

        Console.WriteLine("Try again");
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
        try
        {
            Console.Write("Input  first Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Input last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Input number: ");
            string number = Console.ReadLine();

            var record = (firstName, lastName, number);

            int newLenght = records.Length + 1;
            Array.Resize(ref records, newLenght);
            records[newLenght - 1] = record;

            Console.WriteLine("you have successfully added a record");

            SaveToFile(records);
        }
        catch (Exception)
        {

            Console.WriteLine("Exception, try again");
        }

    }


    void RemoveRecordByNumber((string firstName, string lastName, string number)[] records)
    {
        try
        {
            Console.WriteLine("Input the number you want to delete");
            string delNumber = Console.ReadLine();

            for (int i = 0; i < records.Length; i++)
            {

                if (delNumber == records[i].number)
                {
                    Console.WriteLine($"{records[i].firstName} {records[i].lastName} {records[i].number}");
                    Console.WriteLine("You want delete this record ? ");
                    Console.WriteLine("For exemple \" Y or N \" ");
                    string YesOrNo = Console.ReadLine();
                    if (YesOrNo == "Y")
                    {

                    }
                    else if (YesOrNo == "N")
                    {
                        continue;
                    }
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("exception, please try again");
        }


    }

    void SearchRecordByNumber((string firstName, string lastName, string number)[] records)
    {
        try
        {
            Console.WriteLine("Please input the number oyu want to search! ");
            Console.WriteLine("For exemple xxx-xxx-xxxx");
            string search = Console.ReadLine();

            for (int i = 0; i < records.Length; i++)
            {
                if (records[i].number == search)
                {
                    Console.WriteLine($"{records[i].firstName} {records[i].lastName} {records[i].number}");
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Exception,  try again :)");
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
}