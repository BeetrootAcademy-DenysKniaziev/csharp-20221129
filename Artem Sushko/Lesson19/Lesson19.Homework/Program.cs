using Demo.Models;
using System.Text;
using LinqLesson;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Lesson19.Homework
{
    public class FriendComparer : IEqualityComparer<Friend>
    {
        public bool Equals(Friend? p1, Friend? p2)
        {
            if (p1 is null || p2 is null) return false;
            return p1.Name == p2.Name;
        }
        public int GetHashCode([DisallowNull] Friend obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    internal class Program
    {
        static void Print(IEnumerable<Customer> values)
        {
            foreach (var item in values)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Birtday: {item.Birthday.ToShortDateString()}");
                Console.Write("Phone Numbers: ");
                for (int i = 0; i < item.PhoneNumbers.Count; i++)
                {
                    Console.Write(item.PhoneNumbers[i] + "  ");
                }
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var customers = new List<Customer>
            {
                new Customer("Alice", new DateTime(1992, 2, 2), new List<string> {"671954099", "671786544", "675098430"}),
                new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
                new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
                new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
            };

            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));


            //Console.WriteLine("Завдання 1: Вивести імена та вік клієнтів\n");
            //var s = customers.Select(x=> new {Name = x.Name, Age = DateTime.Now.Year - x.Birthday.Year});
            //foreach (var item in s)
            //{
            //    Console.WriteLine($"{item.Name} {item.Age} years old");
            //}
            //var s1 = from c in customers
            //         select new
            //         {
            //             Name = c.Name,
            //             Age = DateTime.Now.Year - c.Birthday.Year
            //         };

            //foreach (var item in s1)
            //{
            //    Console.WriteLine($"{item.Name} {item.Age} years old");
            //}


            //Console.WriteLine("\nЗавдання 2: Вивести всі телефонні номери клієнтів з кодом + 380\n");
            //var s2 = from c in customers
            //         select c;

            //foreach (var item in s2)
            //{
            //    for (int i = 0; i < item.PhoneNumbers.Count; i++)
            //    {
            //        Console.Write($"+380{item.PhoneNumbers[i]} ");
            //    }
            //    Console.WriteLine();
            //}


            //Console.WriteLine("\nЗавдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру\n");
            //var s3_ = customers.Select(x => x);

            //foreach (var item in s3_)
            //{
            //    for (int i = 0; i < item.PhoneNumbers.Count; i++)
            //    {
            //        Console.WriteLine($"+380{item.PhoneNumbers[i]}");
            //        Console.WriteLine($"Name: {item.Name}");
            //        Console.WriteLine($"Birtday: {item.Birthday.ToLongDateString()}");
            //    }
            //    Console.WriteLine();
            //}

            //var s3 = from c in customers
            //         select c;

            //foreach (var item in s3)
            //{
            //    for (int i = 0; i < item.PhoneNumbers.Count; i++)
            //    {
            //        Console.WriteLine($"+380{item.PhoneNumbers[i]}");
            //        Console.WriteLine($"Name: {item.Name}");
            //        Console.WriteLine($"Birtday: {item.Birthday.ToLongDateString()}");
            //    }
            //    Console.WriteLine();
            //}


            //Console.WriteLine("\nЗавдання 4: Вивести інформацією про клієнтів, хто народився у січні\n");
            //var customersWhere1 = customers.Where(i => i.Birthday.Month == 1);
            //Console.WriteLine("\tPeople which born in January");
            //Print(customersWhere1);


            //var customersQuery1 = from i in customers
            //                      where i.Birthday.Month == 1
            //                      select i;
            //Print(customersQuery1);


            //Console.WriteLine("\nЗавдання 5: Вивести інформацією про клієнтів, імена яких мають непарну довжину\n");
            //var customersWhere2 = customers.Where(i => i.Name.Length % 2 != 0);
            //Print(customersWhere2);

            //var customersQuery2 = from customer in customers
            //                      where customer.Name.Length % 2 != 0
            //                      select customer;
            //Print(customersQuery2);

            //Console.WriteLine("\nЗавдання 6: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з \"671\"\n");
            //var customersWhere3 = customers.Where(x => x.Birthday.Month % 2 == 0 && x.PhoneNumbers.Any(x => x.StartsWith("671")));
            //Print(customersWhere3);


            //var customersQuery3 = from customer in customers
            //                      where customer.Birthday.Month % 2 == 0 && customer.PhoneNumbers.Any(x => x.StartsWith("671"))
            //                      select customer;
            //Print(customersQuery3);


            //find out who is located farthest north/south/west/east using latitude/longitude data

            var minLatitude = persons.Min(x => x.Latitude);
            var maxLatitude = persons.Max(x => x.Latitude);
            var minLongitude = persons.Min(x => x.Longitude);
            var maxLongitude = persons.Max(x => x.Longitude);

            foreach (var item in persons)
            {
                if (item.Longitude == minLongitude)
                    Console.WriteLine($"{item.Name} is located farthest {Direction.West}, with coordinates: {item.Latitude}  {item.Longitude}");

                if (item.Longitude == maxLongitude)
                    Console.WriteLine($"{item.Name} is located farthest {Direction.East}, with coordinates: {item.Latitude}  {item.Longitude}");

                if (item.Latitude == minLatitude)
                    Console.WriteLine($"{item.Name} is located farthest {Direction.South}, with coordinates: {item.Latitude}  {item.Longitude}");

                if (item.Latitude == maxLatitude)
                    Console.WriteLine($"{item.Name} is located farthest {Direction.North}, with coordinates: {item.Latitude}  {item.Longitude}");

            }
            Console.WriteLine();

            //find max and min distance between 2 persons
            double maxDistance = 0;
            double minDistance = double.MaxValue;
            string Name1 = null;
            string Name2 = null;
            string Name3 = null;
            string Name4 = null;

            foreach (var item1 in persons)
            {
                foreach (var item2 in persons.SkipWhile(x => x != item1).Skip(1))
                {
                    if (Math.Sqrt(Math.Pow(item2.Longitude - item1.Longitude, 2) + Math.Pow(item2.Latitude - item1.Latitude, 2)) > maxDistance)
                    {
                        maxDistance = Math.Sqrt(Math.Pow(item2.Longitude - item1.Longitude, 2) + Math.Pow(item2.Latitude - item1.Latitude, 2));
                        Name1 = item1.Name;
                        Name2 = item2.Name;
                    }
                    else if (Math.Sqrt(Math.Pow(item2.Longitude - item1.Longitude, 2) + Math.Pow(item2.Latitude - item1.Latitude, 2)) < minDistance)
                    {
                        minDistance = Math.Sqrt(Math.Pow(item2.Longitude - item1.Longitude, 2) + Math.Pow(item2.Latitude - item1.Latitude, 2));
                        Name3 = item1.Name;
                        Name4 = item2.Name;
                    }
                }
            }
            Console.WriteLine($"Max distance is {maxDistance} between {Name1} and {Name2}");
            Console.WriteLine($"Min distance is {minDistance} between {Name3} and {Name4}");
            Console.WriteLine();

            //find 2 persons whos ‘about’ have the most same words

            int amount = 0;
            foreach (var item1 in persons)
            {
                foreach (var item2 in persons.SkipWhile(x => x != item1).Skip(1))
                {
                    if (item1.About.ToLower().Intersect(item2.About.ToLower()).Count() > 0)
                    {
                        if (item1.About.Intersect(item2.About).Count() > amount)
                        {
                            amount = item1.About.Intersect(item1.About).Count();
                            Name1 = item1.Name;
                            Name2 = item2.Name;
                        }
                    }
                }
            }
            Console.WriteLine($"{Name1} and {Name2} have {amount} same words in \"about\"");
            Console.WriteLine();
            //find persons with same friends(compare by friend’s name) 



            foreach (var item in persons)
            {
                foreach (var item1 in persons.SkipWhile(x => x != item).Skip(1))
                {
                    if (item.Friends.Intersect(item1.Friends, new FriendComparer()).Count() > 0)
                    {
                        Console.WriteLine(item.Name + " and " + item1.Name + " have same friends");
                    }
                }
            }
        }
        enum Direction
        {
            North,
            West,
            South,
            East
        }
    }
}