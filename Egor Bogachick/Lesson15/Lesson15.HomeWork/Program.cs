namespace Lesson15.HomeWork
{
    public class Stack<T>
    {
        private const int Value = 10;
        public int Count { get; private set; }
        public T[] Arr { get; private set; }    

        public Stack() 
        {
            Arr = new T[Value];
            Count = 0;
        }
        public Stack(int lenth)
        {
            Arr = new T[lenth];
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Array is empty");
            }
        }
        public void Push(T item)
        {
            if (Count == Arr.Length)
            {
                T[] tempArr = new T[Arr.Length*2];
                Array.Copy(Arr, tempArr, Arr.Length);
                Arr = tempArr;
            }

            Arr[Count] = item;
            Count++;
        }

        public void Clear()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}