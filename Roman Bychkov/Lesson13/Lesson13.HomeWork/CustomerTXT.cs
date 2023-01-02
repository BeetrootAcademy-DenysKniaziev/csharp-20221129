using System.Text;
using System.Text.RegularExpressions;

internal class CustomerTXT : IDataCustomer
{
    public readonly string TxtFileName;
   
    public void LoadCustomer(ref List<Customer> Customers)
    {
        if (File.Exists(TxtFileName))
        {
            var data = File.ReadAllLines(TxtFileName);
            for (int i = 0; i < data.Length; i++)
            {
                var splited = data[i].Split('|');
                Customers.Add(new Customer(splited[0], splited[1], Convert.ToDateTime(splited[2]), splited[3]));
            }
        }
    }

   public void SaveCustomer(List<Customer> Customers)
    {
        var data = new StringBuilder();
        for (int i = 0; i < Customers.Count; i++)
        {
           data.AppendLine(Customers[i].ToString());
        }
        File.WriteAllText(TxtFileName, data.ToString());
    }

    public CustomerTXT(string file)
    {
        if (Regex.IsMatch(file, @"^\w{1,15}\.txt$"))
        {
            TxtFileName = file;
        }
        else
        {
            throw new ArgumentException(nameof(file), "Invalid txt file.");
        }
    }

}

//// сохранение данных
//using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
//{
//    Person tom = new Person("Tom", 37);
//    await JsonSerializer.SerializeAsync<Person>(fs, tom);
//    Console.WriteLine("Data has been saved to file");
//}