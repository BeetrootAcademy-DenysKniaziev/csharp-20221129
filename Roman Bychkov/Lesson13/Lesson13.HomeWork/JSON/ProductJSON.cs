using System.Text.Json;
using System.Text.RegularExpressions;

internal class ProductJSON : IDataProduct
{
    public readonly string FileName;

    public void Load(ref List<Product> Clothings)
    {
        using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
        {
            Clothings = JsonSerializer.Deserialize<List<Product>>(fs);
        }
    }

    public void Save(List<Product> Clothings)
    {
        using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
        {

            JsonSerializer.Serialize(fs, Clothings);
            Console.WriteLine("Data has been saved to file");
        }
    }

    public ProductJSON(string file)
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

//// сохранение данных
//using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
//{
//    Person tom = new Person("Tom", 37);
//    await JsonSerializer.SerializeAsync<Person>(fs, tom);
//    Console.WriteLine("Data has been saved to file");
//}