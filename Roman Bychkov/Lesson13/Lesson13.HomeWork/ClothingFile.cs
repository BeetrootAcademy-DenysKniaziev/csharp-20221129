//using System.Text;
//using System.Text.RegularExpressions;

//internal class ClothingFile : IDataClothing
//{
//    public readonly string TxtFileName;

//    public void LoadClothing(List<Clothing> Clothings)
//    {
//        if (File.Exists(TxtFileName))
//        {
//            var data = File.ReadAllLines(TxtFileName);
//            for (int i = 0; i < data.Length; i++)
//            {
//                var splited = data[i].Split('|');
//                Customers.Add(new Customer(splited[0], splited[1], Convert.ToDateTime(splited[2]), splited[3]));
//            }
//        }
//    }

//    public void SaveClothing(List<Clothing> Clothings)
//    {
//        var data = new StringBuilder();
//        for (int i = 0; i < Customers.Count; i++)
//        {
//            data.AppendLine(Customers[i].ToString());
//        }
//        File.WriteAllText(TxtFileName, data.ToString());
//    }

//    public ClothingFile(string file)
//    {
//        if (Regex.IsMatch(file, @"^\w{1,15}\.txt$"))
//        {
//            TxtFileName = file;
//        }
//        else
//        {
//            throw new ArgumentException(nameof(file), "Invalid txt file.");
//        }
//    }

//}

