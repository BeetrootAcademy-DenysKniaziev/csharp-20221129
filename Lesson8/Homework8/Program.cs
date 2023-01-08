//Provide ability to search in phone book by any criteria (first/last name or phone number)
//Extra:
//Update phone number program that will store rows in alphabetical order (order by last name)
//Use binary search algorithm to search for row in phone book

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

//enum sortType { firstName,
//    secondName,
//    phoneNumber }
var records = ReadFromFile();
const string FileName = "PhoneBook.txt";
List<int> sorry = new List<int>();
mainMenu();

void mainMenu()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Phone Book Application");
        Console.WriteLine("Select Action:");
        Console.WriteLine("1 - Show Phone Book");
        Console.WriteLine("2 - Add Record");
        Console.WriteLine("3 - Update Record");
        Console.WriteLine("4 - Remove Record");
        Console.WriteLine("5 - Serch Record (by any part of record)");
        Console.WriteLine("6 - Binary Serch Record");//binary search algorithm
        Console.WriteLine("7 - Sort Records");//then choose criteria
        Console.WriteLine("0 - Exit");


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
                Console.WriteLine("AddRecord");
                if(AddRecord()) Console.WriteLine("Record was added, what to do next?"); 
                else Console.WriteLine("record was NOT add");

                break;
            case ConsoleKey.D3:
                Console.WriteLine("Update Record");
                UpdateRecord(records);
                break;
            case ConsoleKey.D4:
                ShowPhoneBook(records);
                Console.WriteLine("Select record to remove by entering record number");
                var input = Console.ReadLine();
                try {
                    int.TryParse(input.ToString(), out int Value);
                    RemoveRecord(records, Value);
                }
                catch (Exception ex)  {
                    Console.WriteLine("That was uexcepteble input\n" + ex.Message.ToString());
                }
                break;
            case ConsoleKey.D5:
                //Console.WriteLine("Serch Record");
                SerchRecord(records);
                break;
            case ConsoleKey.D7:
                //Console.WriteLine("Sort Records");
                SortRecords();
                break;
            case ConsoleKey.D6:
                BinarySerchRecord(records);
                break;

            default:
                Console.WriteLine("Incorrect Input!");
                break;

        }
        //Console.Clear();
    }
}

void BinarySerchRecord(List<(string firstName, string lastName, string number)> records)
{
    var temp = records;
    int correction = 0;
    int mid = records.Count / 2;
    int position = mid;
    List<(string firstName, string lastName, string number)> found = new List<(string firstName, string lastName, string number)>();
    Console.WriteLine("Input whole First name or Last name or Phone number");
    var input = Console.ReadLine();
    sort(1);
    for (int i = 0; i < records.Count; i++)
    {
        if (input.CompareTo(records[position-1].firstName) > 0) { correction = 1; mid = mid / 2; position = position + (mid * correction); }
        else if (input.CompareTo(records[position-1].firstName) < 0) { correction = -1; mid = mid / 2; position = position + (mid * correction); }
        else if (input.CompareTo(records[position-1].firstName) == 0) { correction = 0; found.Add(records[position-1]); break;  }
    }
    correction = 0;
    mid = records.Count / 2;
    position = mid;
    sort(2);
    for (int i = 0; i < records.Count; i++)
    {
        if (input.CompareTo(records[position - 1].lastName) > 0) { correction = 1; mid = mid / 2; position = position + (mid * correction); }
        else if (input.CompareTo(records[position - 1].lastName) < 0) { correction = -1; mid = mid / 2; position = position + (mid * correction); }
        else if (input.CompareTo(records[position - 1].lastName) == 0) { correction = 0; found.Add(records[position - 1]); break; }
    }
    correction = 0;
    mid = records.Count / 2;
    position = mid;
    sort(3);
    for (int i = 0; i < records.Count; i++)
    {
        if (input.CompareTo(records[position - 1].number) > 0) { correction = 1; mid = mid / 2; position = position + (mid * correction); }
        else if (input.CompareTo(records[position - 1].number) < 0) { correction = -1; mid = mid / 2; position = position + (mid * correction); }
        else if (input.CompareTo(records[position - 1].number) == 0) { correction = 0; found.Add(records[position - 1]); break; }
    }


    records = temp;
    if (found.Count > 0){
        Console.WriteLine("Here is records, that include " + input);
        for (int item = 0; item < found.Count; item++)
            Console.WriteLine($"{item}. First Name: {found[item].firstName}, Last Name: {found[item].lastName}, Number: {found[item].number}");
    }
    else Console.WriteLine("No records same to your entery");
}

void SortRecords()
{
    Console.WriteLine("Sort record by:\n1 - First name\n2 - Second name\n3 - Phone number\n0 - Exit to previus menu");
    var action = Console.ReadKey();
    switch (action.Key)
    {
        case ConsoleKey.D0:
            Console.WriteLine("Exit");
            return;
        case ConsoleKey.D1:
            Console.WriteLine("First name");
            sort(1);
            break;
        case ConsoleKey.D2:
            Console.WriteLine("Last name");
            sort(2);
            break;
        case ConsoleKey.D3:
            Console.WriteLine("Phone number");
            sort(3);
            break;

        default:
            Console.WriteLine("Incorrect Input!");
            break;
    }
    ShowPhoneBook(ReadFromFile()); //refresh records
}

void sort(int v)
{
    //var line = records;
    string rec = "";
    string nextRec = "";
    for (int i = 0; i < records.Count - 1; i++)
    {
        for (int j = 0; j < records.Count - 1 - i; j++)
        {
            if (v == 1) {
                if ((records[j].firstName).CompareTo((records[j + 1].firstName)) > 0)
                    (records[j], records[j + 1]) = (records[j + 1], records[j]);
            }
            else if (v == 2) {
                if ((records[j].lastName).CompareTo((records[j + 1].lastName)) > 0)
                    (records[j], records[j + 1]) = (records[j + 1], records[j]);
            }
            else if (v == 3)  {
                if (((records[j].number).CompareTo((records[j + 1].number)) > 0)) 
                    (records[j], records[j + 1]) = (records[j + 1], records[j]);
            }
        }
    }
    SaveToFile(records); 
}

List<(string firstName, string lastName, string number)> SerchRecord(List<(string firstName, string lastName, string number)> records)
{
    Console.WriteLine("Serch record by entering firstname, second name or phone number (partial input permited)\n");
    var input = Console.ReadLine();
    List<(string firstName, string lastName, string number)> found = new List<(string firstName, string lastName, string number)>();
    int i = -1;
    for (int item = 0; item < records.Count; item++)
    {
        i++;
        if (Regex.IsMatch(records[item].lastName, @"(?i)" + input + "")) 
            { found.Add(records[item]); sorry.Add(i); }
        else if (Regex.IsMatch(records[item].firstName, @"(?i)" + input + "")) 
            { found.Add(records[item]); sorry.Add(i); }
        else if (Regex.IsMatch(records[item].number, @"(?i)" + input + "")) 
            { found.Add(records[item]); sorry.Add(i); }
            //else break;

        }
    Console.WriteLine("Here is records, that include " + input);
    for(int item = 0; item< found.Count; item++) 
        Console.WriteLine($"{item}. First Name: {found[item].firstName}, Last Name: {found[item].lastName}, Number: {found[item].number}");
    return found;

//else return Array.Empty<(string, string, string)>();
}

void UpdateRecord(List<(string firstName, string lastName, string number)> records)
{
    //Console.WriteLine("To Update\n");
    var rec = SerchRecord(records);
    if (rec.Count > 1) { 
        Console.WriteLine("There are more then one record that fit serching input\nplease select witch of them you want to update:");
        var input = Console.ReadLine();
            try
            {
                int.TryParse(input.ToString(), out int Value);
                Console.WriteLine("Record to update:\n");
                Console.WriteLine($" First Name: {rec[Value].firstName}, Last Name: {rec[Value].lastName}, Number: {rec[Value].number}");
                bool ifAdd = AddRecord();
                if(ifAdd) RemoveRecord(records,  sorry[Value]);//..Remove();
            }
            catch (Exception ex)
            {
                Console.WriteLine("That was uexcepteble input\n" + ex.Message.ToString());
            }
        
    }
    else if (rec.Count == 1) {
        bool ifAdd = AddRecord();
        if (ifAdd) RemoveRecord(records, sorry[0]);
    }
    else Console.WriteLine("No records that suit your input");
        
}

void RemoveRecord(List<(string firstName, string lastName, string number)> records, int n)
{
    records.RemoveAt(n);
    SaveToFile(records);
}

void ShowPhoneBook(List<(string firstName, string lastName, string number)> records)
{
    int i = 0;
    foreach (var record in records)
    {
        Console.WriteLine($"{i.ToString()}. First Name: {record.firstName}, Last Name: {record.lastName}, Number: {record.number}");
        i++;
    }
}

bool AddRecord()
{
    Console.WriteLine("Please enter firstname (A-Za-z letters)");
    var firstName = Console.ReadLine();
    if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$") == false)
    {   Console.WriteLine("Unexpected input");
        return false; }

Console.WriteLine("Please enter lastname (A-Za-z letters)");
    var lastName = Console.ReadLine();
    if (Regex.IsMatch(lastName, @"^[a-zA-Z]+$") == false)
    {   Console.WriteLine("Unexpected input");
        return false; }
    
    Console.WriteLine("Please enter phone number (format: xxx-xxx-xxxx)");
    var phoneNumber = Console.ReadLine();
    if (Regex.IsMatch(phoneNumber, @"^\d{3}-[0-9]{3}-[0-9]{4}") == false) 
    {   Console.WriteLine("Unexpected input"); 
        return false; }

    records.Add((firstName, lastName, phoneNumber));
   // using (StreamWriter text = File.AppendText(FileName))
    //{
        SaveToFile(records);
    //}
    return true;

}

void SaveToFile(List<(string firstName, string lastName, string number)> records)
{
    var data = new string[records.Count];
    for (int i = 0; i < records.Count; i++)
    {
        var record = records[i];
        data[i] = $"{record.firstName}|{record.lastName}|{record.number}";
    }

    File.WriteAllLines(FileName, data);
}

List < (string firstName, string lastName, string number)>ReadFromFile()
{
    if (File.Exists(FileName))
    {
        var data = File.ReadAllLines(FileName);
        var records = new List<(string firstName, string lastName, string number)>();
        for (int i = 0; i < data.Length; i++)
        {
            var splited = data[i].Split('|');
            records.Add((splited[0], splited[1], splited[2]));
        }
        return records;
    }
    return new List<(string,string,string)>();
}