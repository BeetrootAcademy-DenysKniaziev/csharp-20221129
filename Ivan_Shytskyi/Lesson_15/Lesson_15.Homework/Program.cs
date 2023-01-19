class Stack<T>
{
    private int _length = 1;
    private int _count = 0;
    private T[] Array { get; set; }
    public Stack()
    {
        Array = new T[_length];
    }
    public void Push(T a)
    {
        if (Array.Length == _count)
        {
            T[] newArr = new T[_length + 1];
            for (int i = 0; i < Array.Length; i++)
            {
                newArr[i] = Array[i];
            }
            Array = newArr;
        }
        Array[_count] = a;
        _count++;
    }
    public T Pop()
    {
        T x = Array[Array.Length - 1];
        T[] newArr = new T[Array.Length - 1];
        for (int i = 0; i < newArr.Length; i++)
        {
            newArr[i] = Array[i];
        }
        Array = newArr;
        _count--;
        return x;
    }
    public T[] Clear()
    {
        T[] newArray = new T[_length];
        Array = newArray;
        _count = 0;
        return Array;
    }
    public int Count()
    {
        return _count;
    }
    public T Peek()
    {
        T y = Array[Array.Length - 1];
        return y;
    }
    public void CopyTo(T[] newArray)
    {
        bool t = true;
        while (t)
        {
            if (newArray.Length < Array.Length)
                Console.WriteLine($"your array is smaller than stack\nstack length - {_count}");
            else if (newArray.Length > Array.Length)
                Console.WriteLine($"your array is bigger  than stack\nstack length - {_count}");
            else
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    newArray[i] = Array[i];
                }
                t = false;
            }
        }
    }
}