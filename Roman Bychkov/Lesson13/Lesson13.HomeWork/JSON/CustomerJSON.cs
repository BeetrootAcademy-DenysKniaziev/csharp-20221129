using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

internal class CustomerJSON : IDataCustomer
{
    public readonly string FileName;

    public void LoadCustomer(ref List<Customer> Customers)
    {
        using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
        {
            Customers = JsonSerializer.Deserialize<List<Customer>>(fs);
        }  
    }

    public void SaveCustomer(List<Customer> Customers)
    {
        using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Customer>>(fs, Customers);
            Console.WriteLine("Data has been saved to file");
        }
    }

    public CustomerJSON(string file)
    {
        if (Regex.IsMatch(file, @"^\w{1,15}\.json$"))
        {
            FileName = file;
        }
        else
        {
            throw new ArgumentException(nameof(file), "Invalid JSON file.");
        }
    }

}
