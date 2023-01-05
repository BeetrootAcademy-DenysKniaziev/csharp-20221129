using System.ComponentModel;

public abstract class WebUser
{
    protected string LoginId;
    public string Password;

    public WebUser(string LoginId)
    {
        this.LoginId = LoginId;
    }

    public abstract void Add(WebUser wu);
    public abstract void Remove(WebUser wu);
}

public class ShoppingCart
{
    public DateTime DateCreation;
    public Customer Customer;
    public Product Product;

    public void Clear()
    {
        Console.WriteLine("Shopping cart cleared");
    }
}

public class Customer : WebUser
{
    List<WebUser> children = new List<WebUser>();

    public Customer(string LoginId) : base(LoginId)
    {
    }

    public int Phone;
    public string Email;
    public string Addres;
    public Order Order;
    public ShoppingCart ShoppingCart;

    public override void Add(WebUser webUser)
    {
        children.Add(webUser);
    }
    public override void Remove(WebUser webUser)
    {
        children.Remove(webUser);
    }
}


public class Product
{
    public string ProductId;
    public string Name;
    public float Price;

    public void ChangePrice()
    {
        Console.WriteLine("Price Changed");
    }

    public void AddProduct()
    {
        Console.WriteLine("Product added");
    }

    public void RemoveProduct()
    {
        Console.WriteLine("Product removed");
    }
}

public class Order
{
    public string OrderId;
    public DateTime Date;
    public IOrderStatus OrderStatus;
    public Product Product;

    public void Validate()
    {
        Console.WriteLine("Validated");
    }
}

public interface IOrderStatus
{
    void New();
    void Hold();
    void Deliver();
    void Close();
    void Pay();
}