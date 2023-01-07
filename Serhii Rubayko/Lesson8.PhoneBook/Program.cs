using System.Text.RegularExpressions;

const string FileName = "PhoneBook.txt";

 Console.WriteLine("Phone Book Aplications");
Console.WriteLine("Select Action:");
Console.WriteLine("1 - Show Phone Book");
Console.WriteLine("2 - Add Record");
Console.WriteLine("3 - Update Record");
Console.WriteLine("4 - Remove Record");
Console.WriteLine("5 - Search Name");
Console.WriteLine("0 - Exit");

//var records = new(string firstName, string lastName, string number)[1000];
//records[0] = ("Serhii", "Rubayko", "343-958-4231");
//SaveToFile(records);
    
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
            break;
        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            AddRecord();
            break;
        case ConsoleKey.NumPad5:
        case ConsoleKey.D5:
            //Console.WriteLine("Found name:");
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



//ShowPhoneBook(records);

void ShowPhoneBook((string firstName, string lastName, string number)[] records)
{
    foreach (var record in records)
    {
        Console.WriteLine($"First Name: {record.firstName}, Last Name: {record.lastName}, Number: {record.number}");
    }
}

void Search((string firstName, string lastName, string number)[] records)
{
    Console.WriteLine("Input FirstName:");

    var search= Console.ReadLine();

    var people = new string[records.Length / 2];

    for (int i=0; i<records.Length; i++)
    {
        var record = records[i];
        
        if (search == record.firstName)
        {
            //var found = records[i];
            int j = 0;
            people[j] = $"First Name: {record.firstName}, Last Name: {record.lastName}, Number: {record.number}";
            j++;
        }

        //Console.WriteLine("Incorrect Input!");
    }

    foreach (var man in people)
    {
        Console.WriteLine(man);
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