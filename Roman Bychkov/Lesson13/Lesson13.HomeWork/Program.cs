class Program
{
    static void Main()
    {
        IDataCustomer customer = new CustomerJSON("customer.json");
        IDataProduct products = new ProductJSON("clothing.json");
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
                        foreach (Customer item in Customers)
                            Console.WriteLine(item);
                        break;
                    case ConsoleKey.D7:
                        Sale(Products,Customers,Checks);
                        break;
                }


            }

            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }


        }
    }
    public static void UploadData(ref List<Product> products, ref List<Customer> customers, IDataCustomer customer, IDataProduct clothing)
    {
        customer.LoadCustomer(ref customers);
        var clothings = new List<Product>();
        clothing.Load(ref clothings);
    }
    static Customer RegistrationCustomer()
    {
        var temp = WriteCustomer();

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
                    return new Accessory(Name, Price, Color, Count);
                case ConsoleKey.D2:
                    return new Clothing(Name, Price, Color);
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
        Console.WriteLine("Accesory:");
        foreach (var item in Products.Where(x => x is Accessory))
            Console.WriteLine(item.ToString());
        Console.WriteLine("Clothing:");
        foreach (var item in Products.Where(x => x is Clothing))
            Console.WriteLine(item.ToString());

    }

    static void Sale(List<Product> Products, List<Customer> Customers, List<Check> Checks)
    {
        var temp = WriteCustomer();
        var customer = Customers.FirstOrDefault(x => x.Name == temp.Name && x.LastName == temp.LastName && x.PhoneNumber == temp.PhoneNumber && x.DateOfBorn == temp.DateOfBorn);
        if (customer!=null)
        {
            Checks.Add(new Check(customer));
            while(true)
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
                            Checks[Checks.Count - 1].AddPruduct(product,count);
                        }
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine(Checks[Checks.Count - 1].Print());
                        return;

                }
            }
        }
       
    }
    public static Product? FindProduct(List<Product> Products)
    {
        string Name, Color;
        decimal Price;
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Color: ");
        Color = Console.ReadLine();
        
        return Products.FirstOrDefault(x => x.Name == Name &&   x.Color == Color);
    }
    public static (string Name, string LastName, string PhoneNumber, DateTime DateOfBorn) WriteCustomer()
    {
        string Name, LastName, PhoneNumber;
        DateTime DayOfBorn;
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("LastName: ");
        LastName = Console.ReadLine();
        Console.Write("Phone Number format [0-9]{9}: ");
        PhoneNumber = Console.ReadLine();
        Console.Write("Day of born: ");
        DayOfBorn = Convert.ToDateTime(Console.ReadLine());
        return(Name, LastName, PhoneNumber, DayOfBorn);
    }
}


enum Season : byte
{
    Winter = 1,
    Spring,
    Summer,
    Autumn,
}



