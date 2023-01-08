using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        IDataCustomer customer = new CustomerJSON("customer.json");
        IDataProduct products = new ProductJSON("accessory.json", "clothing.json");
        List<Customer> Customers = new List<Customer>();
        List<Product> Products = new List<Product>();
        List<Check> Checks = new List<Check>();
        UploadData(ref Products, ref Customers, customer, products);



        while (true)
        {
            try
            {
                Console.WriteLine("1 - Register customer");
                Console.WriteLine("2 - Register product");
                Console.WriteLine("3 - Add product");
                Console.WriteLine("4 - Add size to clothing");
                Console.WriteLine("5 - Show All Products");
                Console.WriteLine("6 - Show All Customers");
                Console.WriteLine("7 - Sale");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                Console.WriteLine();
                switch (consoleKey)
                {

                    case ConsoleKey.D1:
                        Customers.Add(RegistrationCustomer());
                        customer.SaveCustomer(Customers);
                        break;
                    case ConsoleKey.D2:
                        Products.Add(RegistrationProduct());
                        products.Save(Products);
                        break;
                    case ConsoleKey.D3:
                        AddProduct(Products);
                        products.Save(Products);
                        break;
                    case ConsoleKey.D4:
                        AddSize(Products);
                        products.Save(Products);
                        break;
                    case ConsoleKey.D5:
                        ShowProducts(Products);
                        break;
                    case ConsoleKey.D6:

                        Console.WriteLine($"{new string("Name"),10}\t{new string("LastName"),10}\t{new string("DateOfBorn"),19:D}\t{new string("PhoneNumber"),9}\n");
                        foreach (Customer item in Customers)
                            Console.WriteLine(item);
                        break;
                    case ConsoleKey.D7:
                        if (Sale(Products, Customers, Checks))
                            products.Save(Products);
                        break;
                    case ConsoleKey.D8:

                        break;
                }
            }

            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
            Console.WriteLine();

        }
    }
    public static void UploadData(ref List<Product> products, ref List<Customer> customers, IDataCustomer customer, IDataProduct clothing)
    {
        customer.LoadCustomer(ref customers);
        clothing.Load(ref products);

    }
    static Customer RegistrationCustomer()
    {
        var temp = InputCustomer();

        return new Customer(temp.Name, temp.LastName, temp.DateOfBorn, temp.PhoneNumber);
    }
    static Product RegistrationProduct()
    {
        string Name, Color;
        decimal Price;
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Color: ");
        Color = Console.ReadLine();
        Console.Write("Price: ");
        Price = Convert.ToDecimal(Console.ReadLine());
        while (true)
        {
            Console.WriteLine("1 - Accesory");
            Console.WriteLine("2 - Clothing");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    ushort Count;
                    Console.Write("Count: ");
                    Count = Convert.ToUInt16(Console.ReadLine());
                    return new Accessory(Name, Price, Color, null);
                case ConsoleKey.D2:
                    return new Clothing(Name, Price, Color, null);
            }
        }
    }
    static bool AddProduct(List<Product> Products)
    {

        var product = FindProduct(Products);
        if (product != null)
        {
            if (product is Accessory accessory)
            {
                Console.Write("Count: ");
                accessory.AddCountToSize(Convert.ToUInt16(Console.ReadLine()));

            }

            if (product is Clothing clothing)
            {
                Console.Write("Size: ");
                byte size = Convert.ToByte(Console.ReadLine());
                Console.Write("Count: ");
                ushort count = Convert.ToUInt16(Console.ReadLine());
                if (!clothing.AddCountToSize(count, size))
                {
                    Console.WriteLine("Can't add clothing");
                    return false;
                }
            }
            return true;
        }

        else
            Console.WriteLine("Product not exist");
        return false;

    }
    static void AddSize(List<Product> Products)
    {
        string Name, Color;
        decimal Price;
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Color: ");
        Color = Console.ReadLine();

        Product product = Products.FirstOrDefault(x => x.Name == Name && x.Color == Color);
        if (product is Clothing clothing)
        {
            Console.Write("Size: ");
            byte size = Convert.ToByte(Console.ReadLine());
            if (!clothing.AddSize(size))
                Console.WriteLine("Size already exist.");
        }
        else
            Console.WriteLine("Product not exist.");
    }
    public static void ShowProducts(List<Product> Products)
    {
        Console.WriteLine("\t===ACCESORY===");
        foreach (var item in Products.Where(x => x is Accessory))
        {
            Console.WriteLine(item.ToString());

            foreach (var size in item?.Items)
                Console.WriteLine($"SIZE: {size.Key,3}  COUNT: {size.Value,3}");
        }
        Console.WriteLine("\n\t===CLOTHING===");
        foreach (var item in Products.Where(x => x is Clothing))
        {
            Console.WriteLine(item.ToString());

            foreach (var size in item.Items)
                Console.WriteLine($"SIZE: {size.Key,3}  COUNT: {size.Value,3}");
        }

    }

    static bool Sale(List<Product> Products, List<Customer> Customers, List<Check> Checks)
    {
        Console.WriteLine("Customer Information: ");
        var temp = InputCustomer();
        var customer = Customers.FirstOrDefault(x => x.Name == temp.Name && x.LastName == temp.LastName && x.PhoneNumber == temp.PhoneNumber && x.DateOfBorn == temp.DateOfBorn);
        if (customer != null)
        {
            Checks.Add(new Check(customer));
            while (true)
            {
                Console.WriteLine("1 - Sell accesory");
                Console.WriteLine("2 - Sell clothing");
                Console.WriteLine("0 - Exit");

                ConsoleKey consoleKey = Console.ReadKey().Key;
                Console.WriteLine();
                switch (consoleKey)
                {
                    case ConsoleKey.D1:
                        var product = FindProduct(Products);
                        if (product != null)
                        {
                            Console.Write("Count of product: ");
                            ushort count = Convert.ToUInt16(Console.ReadLine());
                            if (Checks[Checks.Count - 1].AddPruduct(product, count))
                                continue;
                        }
                        break;
                    case ConsoleKey.D2:
                        var product2 = FindProduct(Products);
                        if (product2 != null)
                        {
                            Console.Write("Size of product: ");
                            byte size = Convert.ToByte(Console.ReadLine());
                            Console.Write("Count of product: ");
                            ushort count = Convert.ToUInt16(Console.ReadLine());
                            if (Checks[Checks.Count - 1].AddPruduct(product2, count, size))
                                continue;
                        }
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine(Checks[Checks.Count - 1].Print());
                        return true;

                }
            }
        }
        return false;

    }
    public static Product? FindProduct(List<Product> Products)
    {
        string Name, Color;
        decimal Price;
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Color: ");
        Color = Console.ReadLine();

        return Products.FirstOrDefault(x => x.Name == Name && x.Color == Color);
    }
    public static (string Name, string LastName, string PhoneNumber, DateTime DateOfBorn) InputCustomer()
    {

        DateTime DayOfBorn;
        string name, phoneNumber, lastname;
        while (true)
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
            if (!OnlyLetters(name))
            {
                Console.WriteLine("Invalid name.");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.Write("LastName: ");
            lastname = Console.ReadLine();
            if (!OnlyLetters(lastname))
            {
                Console.WriteLine("Invalid LastName.");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.Write("Phone number: ");
            phoneNumber = Console.ReadLine();
            if (!CurrectPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Invalid phone number.");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.Write("Day of born: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DayOfBorn) || DayOfBorn == DateTime.MinValue)
            {
                Console.WriteLine("Invalid Date.");
                continue;
            }
            break;
        }

        return (name, lastname, phoneNumber, DayOfBorn);
        bool OnlyLetters(string name)
        {
            if (Regex.IsMatch(name, @"^[A-Z]{1}[a-z]+$"))
                return true;
            return false;
        }
        bool CurrectPhoneNumber(string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, @"^[0-9]{9}$"))
                return true;
            return false;
        }
    }
}


enum Season : byte
{
    Winter = 1,
    Spring,
    Summer,
    Autumn,
}



