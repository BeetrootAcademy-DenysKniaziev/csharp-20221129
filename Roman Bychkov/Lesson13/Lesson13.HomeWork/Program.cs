class Program
{
    static void Main()
    {
        Product product = new Accessory("Glases", 25m, "Black");
        Console.WriteLine(product.GetType());
        List<Customer> Customers = new List<Customer>();
        List<Product> Products = new List<Product>();
        while (true)
        {
            try
            {
                Console.WriteLine("1 - Register customer");
                Console.WriteLine("2 - Register product");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Customers.Add(RegistrationCustomer());
                    break;
                    case ConsoleKey.D2:
                        Products.Add(RegistrationProduct());
                    break;
                }
                

            }

            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }


        }
    }
    static Customer RegistrationCustomer()
    {
        string Name, LastName, PhoneNumber;
        DateTime DayOfBorn;
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("LastName: ");
        LastName = Console.ReadLine();
        Console.WriteLine("Phone Number format AAA-BBB-CCCC: ");
        PhoneNumber = Console.ReadLine();
        Console.Write("Day of born: ");
        DayOfBorn = Convert.ToDateTime(Console.ReadLine());

        return new Customer(Name,LastName,DayOfBorn,PhoneNumber);
    }
    static Product RegistrationProduct()
    {
        string Name, Color;
        decimal Price;
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Color: ");
         = Console.ReadLine();
        Console.WriteLine("1 - Accesory");
        Console.WriteLine("2 - Clothing");
        switch(Console.ReadKey().Key)
        {
            case ConsoleKey.D1:

                break;
            case ConsoleKey.D2:

                break;
        }

    }
}


enum Season : short
{
    Winter = 1,
    Spring,
    Summer,
    Autumn
}



