﻿using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";

var records = new (string firstName, string lastName, string number)[1];
records[0] = ("Egor", "Bogachik", "546-634-4564");
try
{
    SaveToFile(records);
}
catch (IOException)
{
    Console.WriteLine("Save to file error");
}
try
{
    records = ReadFromFile();
}
catch (FileNotFoundException)
{
    Console.WriteLine("File PhoneBook.txt is not found");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//ShowPhoneBook(records);

while (true)
{
    Console.WriteLine("\nPhone Book Application");
    Console.WriteLine("Select Action:");
    Console.WriteLine("1 - Show Phone Book");
    Console.WriteLine("2 - Search Record");
    Console.WriteLine("3 - Add Record");
    Console.WriteLine("4 - Update Record");
    Console.WriteLine("5 - Remove Record");
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
            Console.WriteLine("Search:");
            Search(records);
            break;
        case ConsoleKey.D3:
            Console.WriteLine("Add:");
            AddRecord(ref records);
            break;
        case ConsoleKey.D4:
            Console.WriteLine("Update:");
            UpdateRecord(records);
            break;
        case ConsoleKey.D5:
            Console.WriteLine("Remove:");
            RemoveRecord(ref records);
            break;
        case ConsoleKey.D0:
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


void Search((string firstName, string lastName, string number)[] records)
{
    int res = 0;
    int reg = 0;
    string phoneNumber = "";
    Console.WriteLine("Enter the number to be found:");
    try
    {
        do
        {
            if (reg > 0)
            {
                //Console.WriteLine("\nIncorrect input, try again:");
                throw new FormatException("Incorrect input");
            }
            phoneNumber = Console.ReadLine();
            reg++;
        } while (!Regex.IsMatch(phoneNumber, @"^\d{3}-\d{3}-\d{4}$"));
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine(ex.Message);
        // чи можна просот прописати - phoneNumber = Console.ReadLine()!;
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message + "\n"+ ex.StackTrace);
    }


    do
    {
        for (int i = 0; i < records.Length; i++)
        {
            if (Regex.IsMatch(records[i].number, phoneNumber))
            {
                Console.WriteLine("Yours result:");
                Console.WriteLine($"First Name: {records[i].firstName}, Last Name: {records[i].lastName}, Number: {records[i].number}");
                res++;
            }
        }
        if (res == 0)
        {
            Console.WriteLine("Your result was not found");
            res++;
        }
    } while (res == 0);

}


void AddRecord(ref (string firstName, string lastName, string number)[] records)
{
    string number = "";
    string firstName = "";
    string lastName = "";

    int reg = 0;
    Console.WriteLine("Enter first name:");
    try
    {
        do
        {
            if (reg > 0)
            {
                //Console.WriteLine("\nIncorrect input, try again:");
                throw new FormatException("Incorrect input");
            }
            firstName = Console.ReadLine();
            reg++;
        } while (!Regex.IsMatch(firstName, @"[A-Za-z]"));

        reg = 0;
        Console.WriteLine("Enter last name:");
        do
        {
            if (reg > 0)
            {
                //Console.WriteLine("\nIncorrect input, try again:");
                throw new FormatException("Incorrect input");
            }
            lastName = Console.ReadLine();
            reg++;
        } while (!Regex.IsMatch(firstName, @"[A-Za-z]"));

        reg = 0;
        Console.WriteLine("Enter number:");
        do
        {
            if (reg > 0)
            {
                //Console.WriteLine("\nIncorrect input, try again:");
                throw new FormatException("Incorrect input");
            }
            number = Console.ReadLine();
            reg++;
        } while (!Regex.IsMatch(number, @"^\d{3}-\d{3}-\d{4}$"));

        Array.Resize(ref records, records.Length + 1);
        records[^1] = (firstName, lastName, number);
        SaveToFile(records);
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
    }
    
}


void UpdateRecord((string firstName, string lastName, string number)[] records)
{
    string number = "";
    string firstName = "";
    string lastName = "";
    int reg = 0;

    Console.WriteLine("Enter the number of the person you want to replace:");// за номером просто логічніше
    try
    {
        do
        {
            if (reg > 0)
            {
                throw new FormatException("Incorrect input");
                //Console.WriteLine("\nIncorrect input, try again:");
            }
            number = Console.ReadLine();
            reg++;
        } while (!Regex.IsMatch(number, @"^\d{3}-\d{3}-\d{4}$"));

        int temp = Check(number, records);
        if (temp == records.Length)
        {
            Console.WriteLine("Your result was not found");
        }
        else
        {
            reg = 0;
            Console.WriteLine("Update");
            Console.WriteLine("Enter first name:");
            do
            {
                if (reg > 0)
                {
                    throw new FormatException("Incorrect input");
                    //Console.WriteLine("\nIncorrect input, try again:");
                }
                firstName = Console.ReadLine();
            } while (!Regex.IsMatch(firstName, @"[A-Za-z]"));

            reg = 0;
            Console.WriteLine("Enter last name:");
            do
            {
                if (reg > 0)
                {
                    throw new FormatException("Incorrect input");
                    //Console.WriteLine("\nIncorrect input, try again:");
                }
                lastName = Console.ReadLine();
                reg++;
            } while (!Regex.IsMatch(firstName, @"[A-Za-z]"));

            reg = 0;
            Console.WriteLine("Enter number:");
            do
            {
                if (reg > 0)
                {
                    throw new FormatException("Incorrect input");
                    //Console.WriteLine("\nIncorrect input, try again:");
                }
                number = Console.ReadLine();
                reg++;
            } while (!Regex.IsMatch(number, @"^\d{3}-\d{3}-\d{4}$"));
            records[temp] = (firstName, lastName, number);
        }
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
    }

    try
    {
        SaveToFile(records);
    }
    catch (IOException ex)
    {
        Console.WriteLine("Save to file error");
    }
    
}


void RemoveRecord(ref (string firstName, string lastName, string number)[] records)
{
    string number;
    int reg = 0;

    Console.WriteLine("Enter the number of the person you want to remove:");
    try
    {
        do
        {
            if (reg > 0)
            {
                throw new FormatException("Incorrect input");
                //Console.WriteLine("\nIncorrect input, try again:");
            }
            number = Console.ReadLine();
            reg++;
        } while (!Regex.IsMatch(number, @"^\d{3}-\d{3}-\d{4}$"));
        int temp = Check(number, records);
        if (temp == records.Length)
        {
            Console.WriteLine("Your result was not found");
        }
        else
        {
            //Array.Clear(records, temp, 1);
            //records[temp] = ("", "", "");
            if (temp != records.Length - 1)
            {
                records[temp] = records[^1];
                Array.Resize(ref records, records.Length - 1);
            }
            else
            {
                Array.Resize(ref records, records.Length - 1);
            }
            Console.WriteLine("\nContact removed");
        }
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
    }

    try
    {
        SaveToFile(records);
    }
    catch (IOException)
    {
        Console.WriteLine("Save to file error");
    }
}

int Check(string number, (string firstName, string lastName, string number)[] records)
{
    for (int i = 0; i < records.Length; i++)
    {
        if (Regex.IsMatch(records[i].number, number))
        {
            return i;
        }
    }
    return records.Length;
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