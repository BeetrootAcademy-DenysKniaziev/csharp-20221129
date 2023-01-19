using System.Collections;

namespace Lesson18.Classwork
{
    static class StringExtensions
    {
        public static IEnumerable<char> GetDuplicates(this string str)
        {
            var uniq = new HashSet<char>();
            var duplicates = new HashSet<char>();

            foreach (var latter in str)
            {
                if (uniq.Contains(latter))
                {
                    if (!duplicates.Contains(latter))
                    {
                        duplicates.Add(latter);
                        yield return latter;
                    }
                }
                else
                {
                    uniq.Add(latter);
                }
            }
        }
    }

    static class NumericExtensions
    {
        public static int GetNumberFactorial(int number)
        {
            if (number < 1)
                return 1;

            return number * GetNumberFactorial(number - 1);
        }

        public static int GetFactorial(this int number)
        {
            if(number < 1)
                return 1;

            return number * GetFactorial(number - 1);
        }
    }

    static class EnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }
    }

    class OneDirLinkedList<T> : IEnumerable<T>
    {
       private class Element<T>
        {
            public T Value { get; set; }

            public Element<T> Next { get; set; }

            public Element(T value, Element<T> next)
            {
                Value = value;
                Next = next;
            }
        }

        private Element<T> _head;

        public void Add(T value)
        {
            var element = new Element<T>(value, null);

            if (_head == null)
            {
                _head = element;
                return;
            }

            var cur = _head;
            while (cur.Next != null)
            {
                cur = cur.Next;
            }
            cur.Next = element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cur = _head;
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var str = "Hello world!";
            //var result = str.GetDuplicates();
            //Console.WriteLine(result.ToArray());
            
            //int a = 6;
            //var b = a.GetFactorial()
            //         .GetFactorial()
            //         .GetFactorial();

            //var c = NumericExtensions.GetFactorial(NumericExtensions.GetFactorial(NumericExtensions.GetFactorial(a)));

            //Console.WriteLine(b);
            //var res = "Hello world!564564676575647568567867".Where(char.IsDigit).Take(10).Select(Convert.ToInt32);

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //} 

            var list = new OneDirLinkedList<int>();
            
            list.Add(16756);
            list.Add(2);
            list.Add(35445);
            list.Add(4);
            list.Add(5567);

            list.Print();
        }
    }
}