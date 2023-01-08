using System.Text.Json;
using System.Text.RegularExpressions;

internal class ProductJSON : IDataProduct
{
    public readonly string AccessoryFile;
    public readonly string ClothingFile;

    public void Load(ref List<Product> Products)
    {
        List<Accessory> accessories = new List<Accessory>();
        List<Clothing> clothing = new List<Clothing>();
        try
        {
            using (FileStream fs = new FileStream(ClothingFile, FileMode.OpenOrCreate))
            {
                clothing = JsonSerializer.Deserialize<List<Clothing>>(fs);
            }
        }
        catch (System.Text.Json.JsonException)
        {
            Console.WriteLine(ClothingFile + " does't contain JSON");
        }
        try
        {
            using (FileStream fs = new FileStream(AccessoryFile, FileMode.OpenOrCreate))
            {
                accessories = JsonSerializer.Deserialize<List<Accessory>>(fs);
            }
        }
        catch (System.Text.Json.JsonException)
        {
            Console.WriteLine(ClothingFile + " does't contain JSON");
        }
        foreach (Accessory item in accessories)
            Products.Add(item);
        foreach (Clothing item in clothing)
            Products.Add(item);
    }

    public void Save(List<Product> Clothings)
    {
        List<Accessory> accessories = new List<Accessory>();
        List<Clothing> clothing = new List<Clothing>();
        foreach (Product product in Clothings)
        {
            if (product is Accessory)
                accessories.Add((Accessory)product);
            else
                clothing.Add((Clothing)product);
        }
        using (FileStream fs = new FileStream(AccessoryFile, FileMode.OpenOrCreate))
        {

            JsonSerializer.Serialize(fs, accessories);

        }
        using (FileStream fs = new FileStream(ClothingFile, FileMode.OpenOrCreate))
        {

            JsonSerializer.Serialize(fs, clothing);

        }
        Console.WriteLine("Data has been saved to file");
    }

    public ProductJSON(string file1, string file2)
    {
        if (Regex.IsMatch(file1, @"^\w{1,15}\.json$"))
        {
            AccessoryFile = file1;
        }
        else
        {
            throw new ArgumentException(nameof(file1), "Invalid JSON file.");
        }
        if (Regex.IsMatch(file2, @"^\w{1,15}\.json$"))
        {
            ClothingFile = file2;
        }
        else
        {
            throw new ArgumentException(nameof(file2), "Invalid JSON file.");
        }
    }

}

