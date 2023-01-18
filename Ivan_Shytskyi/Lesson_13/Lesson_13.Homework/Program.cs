class Entity
{
    public string ShopName = "Good Tomatoes";
    public int ID = 0;
    public virtual void Register() { }
}
abstract class Person : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
class Customer : Person
{
    public string Address { get; set; }
    public string MobileNumber { get; set; }
    public Customer(string firstName, string lastName, string address, string mobileNumber, int id) : base(firstName, lastName)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        MobileNumber = mobileNumber;
    }
}
class Maneger : Person
{
    public string Profesion { get; set; }
    public Maneger(string firstName, string lastName, string profesion, int id) : base(firstName, lastName)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Profesion = profesion;
    }
}
class Product : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string MadeIn { get; set; }
    public Product(string name, decimal price, int quantity, string country, int id)
    {
        ID = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        MadeIn = country;
    }
}
class ProductColection : Entity, IPrintteble
{
    public Product[] Products { get; set; }
    public ProductColection()
    {
        Products = new Product[0];
    }
    public override void Register()
    {
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter price");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter quantity in stok");
        int quantity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Made in .. enter country");
        string madeIn = Console.ReadLine();
        Console.WriteLine("Enter ID");
        int id = Convert.ToInt32(Console.ReadLine());
        Product newProduct = new Product(name, price, quantity, madeIn, id);
        Product[] newProducts = new Product[Products.Length + 1];
        for (int i = 0; i < Products.Length; i++)
        {
            newProducts[i] = Products[i];
        }
        newProducts[newProducts.Length - 1] = newProduct;
        Products = newProducts;
    }
    public void AddQuantity()
    {
        Console.WriteLine("To which product to add quantity. Enter name");
        string name = Console.ReadLine();
        Console.WriteLine("How many");
        int a = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < Products.Length; i++)
        {
            if (name == Products[i].Name)
            {
                Products[i].Quantity += a;
            }
        }
    }
    public void Print()
    {
        if (Products.Length >= 1)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                Console.WriteLine($"ID - {Products[i].ID} | {Products[i].Name} | price - {Products[i].Price} | Made in {Products[i].MadeIn}");
            }
        }
        else
            Console.WriteLine("not available");
    }
}
class CustomerColection : Entity, IPrintteble
{
    public Customer[] Customers { get; set; }
    public CustomerColection()
    {
        Customers = new Customer[0];
    }
    public override void Register()
    {
        Console.WriteLine("Enter First Name");
        string firstNmae = Console.ReadLine();
        Console.WriteLine("Enter Last Name");
        string lastNmae = Console.ReadLine();
        Console.WriteLine("Enter Address");
        string address = Console.ReadLine();
        Console.WriteLine("Enter Mobile Number");
        string mobileNumber = Console.ReadLine();
        Console.WriteLine("Enter ID");
        int id = Convert.ToInt32(Console.ReadLine());
        Customer newCustomer = new Customer(firstNmae, lastNmae, address, mobileNumber, id);
        Customer[] newCustomers = new Customer[Customers.Length + 1];
        for (int i = 0; i < Customers.Length; i++)
        {
            newCustomers[i] = Customers[i];
        }
        newCustomers[newCustomers.Length - 1] = newCustomer;
        Customers = newCustomers;
    }
    public void Print()
    {
        if (Customers.Length >= 1)
        {
            for (int i = 0; i < Customers.Length; i++)
            {
                Console.WriteLine($"ID - {Customers[i].ID} | {Customers[i].FullName} | addres - {Customers[i].Address} | customer ID - {Customers[i].ID}");
            }
        }
        else
            Console.WriteLine("not available");
    }
}
class Receipts : Entity, IPrintteble
{
    DateTime dateTime => DateTime.Now;
    Maneger Maneger { get; set; }
    List<Product> Products { get; set; }
    decimal Sum { get; set; }
    public Receipts(List<Product> products, Maneger maneger, decimal sum)
    {
        Products = new List<Product>();
        Products = products;
        Maneger = maneger;
        Sum = sum;
    }
    public void Print()
    {
        Console.WriteLine(ShopName);
        Console.WriteLine(new string('*', 30));
        Console.WriteLine(dateTime);
        Console.WriteLine($"Your maneger {Maneger.FullName}");
        Console.WriteLine(new string('*', 30));
        Console.WriteLine("You bought");
        foreach (var product in Products)
        {
            Console.WriteLine(product.Name);
        }
        Console.WriteLine($"You have to pay - {Sum:C2}");
        Console.WriteLine(new string('*', 30));
        Console.WriteLine("Have a good day\n;)");
    }
}
interface IPrintteble
{
    void Print();
}
internal class Program
{
    static void Main(string[] args)
    {
        Entity shopName = new Entity();
        Console.WriteLine(shopName.ShopName);
        Maneger maneger1 = new Maneger("Jakob", "Kowalski", "maneger", 1);
        ProductColection productColection = new ProductColection();
        CustomerColection customerColection = new CustomerColection();
        Console.WriteLine("Who are you?\n1. - Maneger \n2.- Customer");
        int person = Convert.ToInt32(Console.ReadLine());
        if (person == 1)
        {
            Console.WriteLine("1. - What is in the store");
            Console.WriteLine("2. - Register new product");
            Console.WriteLine("3. - Add quantity to existent");
            Console.WriteLine("4. - Register buyer");
            Console.WriteLine("5. - Show all client");
            Console.WriteLine("6. - Exit");
            bool x = true;
            while (x)
            {
                var actions = Console.ReadKey();
                Console.WriteLine();
                switch (actions.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("All products:");
                        productColection.Print();
                        Console.WriteLine(new string('*', 30));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("New product");
                        productColection.Register();
                        Console.WriteLine(new string('*', 30));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Add quantity");
                        productColection.AddQuantity();
                        Console.WriteLine(new string('*', 30));
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("New customer");
                        customerColection.Register();
                        Console.WriteLine(new string('*', 30));
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("All customers");
                        customerColection.Print();
                        Console.WriteLine(new string('*', 30));
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("Exit");
                        x = false;
                        break;
                    default:
                        Console.WriteLine("Incorect input!");
                        Console.WriteLine(new string('*', 30));
                        break;
                }
            }
        }
        else
        {
            string end = "";
            decimal sum = 0;
            var productColectionForCustomer = new List<Product>();
            do
            {
                productColection.Print();
                Console.WriteLine("select a product by ID:");
                int index = Convert.ToInt32(Console.ReadLine());
                productColectionForCustomer.Add(productColection.Products[index]);
                sum += productColection.Products[index].Price;
                Console.WriteLine("that's all?\n1. - Yes \n2. - No");
                int y = Convert.ToInt32(Console.ReadLine());
                if (y == 1)
                    end = "end";
            }
            while (end != "end");
            Receipts receipts = new Receipts(productColectionForCustomer, maneger1, sum);
            receipts.Print();
        }
    }
}