class Program
{
    static void Main()
    {
        var stack = new Stack<int>();
        stack.Push(2);
        stack.Push(5);
        stack.Push(6);
        stack.Push(10);
        stack.Push(8);
        stack.Push(25);


        int[] a = new int[stack.Count()];
        stack.CopyTo(a);

        Console.WriteLine("Stack A:");
        foreach (var item in a)
            Console.WriteLine(item);
        Console.WriteLine("Pops");
        while (stack.Count() > 0)
            Console.WriteLine(stack.Pop());
    }
}
class Stack<T>
{
    private T[] _array;
    private int _count = 0;
    public Stack(int capacity = 1)
    {
        _array = new T[capacity];
    }
    public int Count()
    {
        return _count;
    }

    public void Push(T item)
    {
        if (_array.Length == _count)
        {
            T[] array = _array[0..^0];
            _array = new T[_count * 2];
            array.CopyTo(_array, 0);
        }
        _array[_count] = item;
        _count++;
    }
    public T Pop()
    {
        if (_count == 0)
            throw new IndexOutOfRangeException();
        _count--;
        return _array[_count];
    }
    public void Clear()
    {
        _count = 0;
    }
    public T Peek()
    {
        if (_count == 0)
            throw new IndexOutOfRangeException();
        return _array[_count - 1];
    }
    public void CopyTo(T[] array)
    {

        for (int i = 0; i < Math.Min(_count, array.Length); i++)
        {
            array[i] = _array[i];
        }
    }

}