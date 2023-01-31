using System.Collections;
using System.Collections.Generic;

namespace Lesson16.ClassWork
{
    internal class Program
    {
        class Person : IEquatable<Person>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override bool Equals(object? obj)
            {
                if (obj is Person p)
                    return Equals(p);

                return false;
            }

            public bool Equals(Person? other)
            {
                if (other == null)
                    return false;

                return FirstName == other.FirstName && LastName == other.LastName;
            }

            public override int GetHashCode() => HashCode.Combine(FirstName, LastName);

            public override string ToString() => FirstName + " " + LastName;
        }

        static void PrintEnumerable<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        class PersonCollection
        {
            private List<Person> _items;

            public PersonCollection(IEnumerable<Person> items)
            {
                _items = items.ToList();
            }

            public IEnumerator GetEnumerator()
            {
                return new PersonCollectionEnumerator(_items);
            }

            public IEnumerable<int> Power(int number, int exponent)
            {
                int result = 1;

                for (int i = 0; i < exponent; i++)
                {
                    result = result * number;
                    yield return result;
                }
            }

            private class PersonCollectionEnumerator : IEnumerator
            {
                private List<Person> _items;
                private int _index = -1;

                public object Current => _items[_index];

                public PersonCollectionEnumerator(List<Person> items)
                {
                    _items = items;
                }

                public bool MoveNext()
                {
                    if (_index < _items.Count - 1)
                    {
                        _index++;
                        return true;
                    }
                    return false;
                }

                public void Reset()
                {
                    _index = -1;
                }
            }
        }

        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }

        public static IEnumerable<int> Power2(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }

        static void PrintEnumerable<K, V>(IEnumerable<KeyValuePair<K, V>> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        static void Main(string[] args)
        {
            //var l1 = new List<int> { 1, 2, 3, 4, 5 };
            //l1.Add(6);
            //l1.Remove(3);
            //l1.RemoveAt(0);
            //l1.IndexOf(6);

            //for (int i = 0; i < 100; i++)
            //{
            //    l1.Add(i);
            //}

            //Console.WriteLine(l1.Count + " " + l1.Capacity);

            //Console.WriteLine(l1.Contains(2));

            var l2 = new List<Person>
            {
                new Person { FirstName = "A", LastName = "A" },
                new Person { FirstName = "B", LastName = "B" },
                new Person { FirstName = "C", LastName = "C" }
            };

            //var hs1 = new HashSet<Person>(l2);

            //PrintEnumerable(hs1);

            //hs1.Contains(new Person { FirstName = "B", LastName = "B" }); 

            //var d1 = new Dictionary<int, Person>
            //{
            //    { 1, new Person { FirstName = "A", LastName = "A" } },
            //    { 2, new Person { FirstName = "B", LastName = "B" } },
            //    { 3, new Person { FirstName = "C", LastName = "C" } },
            //};

            //PrintEnumerable(d1);

            //d1.Add(4, new Person());
            //var b = d1.TryGetValue(1, out Person person);
            //Console.WriteLine(person);

            ////d1.Add(1, new Person());
            //d1[8] = new Person();

            //PrintEnumerable(d1);

            ////UPDATE
            //if (d1.ContainsKey(1))
            //{
            //    d1[1] = new Person();
            //}

            //Console.WriteLine(d1[1]);

            //PrintEnumerable(d1.Keys);
            //PrintEnumerable(d1.Values);

            //var d2 = new Dictionary<Person, List<string>>();

            var pc1 = new PersonCollection(l2);

            //var enumerator = pc1.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}
            //enumerator.Reset();

            foreach (var item in pc1.Power(2, 10))
            {
                Console.WriteLine(item);
            }

        }
    }
}