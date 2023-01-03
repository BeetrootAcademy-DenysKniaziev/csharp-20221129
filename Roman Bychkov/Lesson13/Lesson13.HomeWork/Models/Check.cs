using System.Text;

class Check
{
    (string customer, List<(string name, ushort count, decimal sum)>) _items;

    Customer Customer { get; }
    public Check(Customer customer)
    {
        if (customer is null)
            throw new ArgumentNullException("Customer is null");
        Customer = customer;
        _items = (customer.ToString(), new List<(string name, ushort count, decimal sum)>());

    }
    public bool AddPruduct(Product product, ushort count, byte size = 1)
    {
        string prod = product.ToString();
        if (product!=null)
        {
            prod = product.ToString() + " | " + size;
            if (!product.DeleteCountFromSize(count, size))
            {
                Console.WriteLine("Not enough products.");
                return false;
            }
        }
        
        _items.Item2.Add((prod, count, count * ((Product)product).Price));
        return true;
    }
    public void CancelPruduct(Product product, ushort count, byte size)
    {
        string prod = product.ToString();

        prod = product is Clothing ? (product.ToString() + " | " + size) : prod;

        _items.Item2.Remove((prod, count, count * product.Price));
    }
    public StringBuilder Print()
    {
        StringBuilder print = new StringBuilder();
        print.AppendLine(_items.customer);
        foreach (var item in _items.Item2)
            print.AppendLine($"{item.name} | {item.count} | {item.sum}");
        return print;
    }

}