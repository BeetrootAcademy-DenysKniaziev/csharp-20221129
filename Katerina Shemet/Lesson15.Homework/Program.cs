class Stack<T>
{
    public T[] arr = new T[10];

    private int amount = 0;

    public void Push(T value)
    {
        if (amount == arr.Length)
        {
            T[] tmp = new T[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                tmp[i] = arr[i];
            }
            arr = tmp;

        }
        arr[amount] = value;
        amount++;
    }

    public T Pop()
    {
        if (amount < 0)
        {
            Console.WriteLine("Empty");
        }

        amount--;
        return arr[amount];
    }

    public T Peek()
    {
        if (amount < 0)
        {
            Console.WriteLine("Empty");
        }

        return arr[amount - 1];
    }

    public int Amount()
    {
        return amount;
    }

    public void Clear()
    {
        amount = 0;
    }

    public void CopyTo(T[] newArr)
    {
        for (int i = 0; i < Math.Min(amount, newArr.Length); i++)
        {
            newArr[i] = arr[i];
        }
    }
}

internal class Program
{
    public static void Main()
    {
        Stack<int> numbers = new Stack<int>();
        numbers.Push(1);
        numbers.Push(2);
        numbers.Push(3);
        numbers.Push(4);
        numbers.Push(5);

        Console.WriteLine($"Amount:{numbers.Amount()}");


        Console.WriteLine($"Peek: {numbers.Peek()}\n");

        int[] newArray = new int[5];
        numbers.CopyTo(newArray);

        foreach (var item in newArray)
        {
            Console.WriteLine(item);
        }

        numbers.Pop();

        Console.WriteLine($"Peek: {numbers.Peek()}\n");

        numbers.Clear();
    }

}