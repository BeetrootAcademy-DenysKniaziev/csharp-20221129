const string FileName = "Phonebook.txt";

Console.WriteLine("Phone book:");
Console.WriteLine("1 - Show phone book");
Console.WriteLine("2 - Add record");
Console.WriteLine("3 - UpdateRecord");
Console.WriteLine("4 - RemoveRecord");
Console.WriteLine("8 - Exit");

var records = ReadFromFile();

while (true)
{
    var actions = Console.ReadKey();
    Console.WriteLine();
    switch (actions.Key)
    {
        case ConsoleKey.D1:
            ShowPhonebook(records);
            break;
        default:
            Console.WriteLine("Incorect input!");
            break;

    }
}

ShowPhonebook(records);

void ShowPhonebook((string FirstName, string LastName, string number)[] records)
{
    foreach (var record in records)
        Console.WriteLine($"First name:{record.FirstName}, Last name: {record.LastName}, number: {record.number}");
}
void AddRecord()
{

}
void UpdateRecord()
{

}
void RemoveRecord()
{

}
void SaveToFile((string FirstName, string LastName, string number)[] records)
{
    string[] data = new string[records.Length];
    for (int i = 0; i<records.Length; i++)
    {
        var record = records[i];
        data[i] = $"{record.FirstName}|{record.LastName}|{record.number}";
    }
    File.WriteAllLines(FileName, data);
}
(string FirstName, string LastName, string number)[] ReadFromFile()
{
    if (File.Exists(FileName))
    {
        var data = File.ReadAllLines(FileName);

        var records = new (string FirstName, string LastName, string number)[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            var splited = data[i].Split('|');
            records[i] = (splited[0], splited[1], splited[2]); 
        }
        return records;
    }
    return Array.Empty<(string,string,string)>();
}