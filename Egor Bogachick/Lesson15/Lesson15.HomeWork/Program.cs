using System.Collections;

namespace Lesson15.HomeWork
{
    public class Stack<T>
    {
        private const int Value = 10;
        public int Item { get; private set; }
        public T[] Arr { get; private set; }    

        public Stack() 
        {
            Arr = new T[Value];
            Item = 0;
        }
        public Stack(int lenth)
        {
            Arr = new T[lenth];
            Item = 0;
        }

        public bool IsEmpty()
        {
            return Item == 0;
        }

        public T Pop()
        {
            if (IsEmpty() || Item < 0)
            {
                Console.WriteLine("Array is empty");
                throw new IndexOutOfRangeException("Array is empty");
            }
            Item--;
            return Arr[Item];
        }
        public void Push(T item)
        {
            if (Item == Arr.Length)
            {
                T[] tempArr = new T[Arr.Length*2];
                Array.Copy(Arr, tempArr, Arr.Length);
                Arr = tempArr;
            }

            Arr[Item] = item;
            Item++;
        }

        public T Peek()
        {
            if (IsEmpty() || Item < 0)
            {
                Console.WriteLine("Array is empty");
                throw new IndexOutOfRangeException("Array is empty");
            }
            return Arr[Item - 1];
        }

        public int Count()
        {
            return Item;
        }

        public void Clear()
        {
            Item = 0;
        }

        public void CopyTo(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Arr[i];
            }
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