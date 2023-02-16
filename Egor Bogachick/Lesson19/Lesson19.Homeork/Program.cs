using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System;
using System.Security.Cryptography;
using System.Linq;

namespace Lesson19.Homeork
{
    class Program
    {
        record class Customer(string Name, DateTime Birthday, List<string> PhoneNumbers);

        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
                new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
                new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
                new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
            };
            #region SELECT
            #region Завдання 1: Вивести імена та вік клієнтів
            ////var clients = from c in customers
            ////              select new
            ////              {
            ////                  Name = c.Name,
            ////                  Age = DateTime.Now.Year - c.Birthday.Year 
            ////              };

            //var clients = customers.Select(c => new
            //{
            //    Name = c.Name,
            //    Age = DateTime.Now.Year - c.Birthday.Year
            //} );

            ////clients.ToList().ForEach(Console.WriteLine);
            //foreach (var client in clients)
            //{
            //    Console.WriteLine(client.Name + " " + client.Age);
            //}
            #endregion

            #region Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380
            ////var numbers1 = from c in customers
            ////               from p in c.PhoneNumbers
            ////              select new
            ////              {
            ////                  Name = c.Name,
            ////                  Number = $"+360{p}"
            ////              };

            //var numbers1 = customers.SelectMany(c => c.PhoneNumbers, (c, p) => new
            //{
            //    Name = c.Name,
            //    Number = $"+360{p}"
            //});
            //foreach (var number in numbers1)
            //{
            //    Console.WriteLine(number.Name + " " + number.Number);
            //}

            #endregion

            #region Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру
            ////var numbers2 = from c in customers
            ////               from p in c.PhoneNumbers
            ////               select new
            ////               {
            ////                   Customer = c,
            ////                   Number = p
            ////               };

            //var numbers2 = customers.SelectMany(c => c.PhoneNumbers, (c, p) => new { Customer = c, Number = p});

            //foreach (var number in numbers2)
            //{
            //    Console.WriteLine($"{number.Number}: {number.Customer.Name}, {number.Customer.Birthday.Day}/{number.Customer.Birthday.Month}/{number.Customer.Birthday.Year}");
            //}

            #endregion

            #endregion

            #region WHERE
            #region Завдання 1: Вивести інформацією про клієнтів, хто народився у січні
            ////var clients = from c in customers
            ////              where c.Birthday.Month == 1
            ////              select c;

            //var clients = customers.Where(c => c.Birthday.Month == 1);

            //foreach (var client in clients)
            //{
            //    Console.Write(client.Name + " " + client.Birthday + " ");
            //    foreach (var phone in client.PhoneNumbers)
            //    {
            //        Console.Write(phone + " ");
            //    }
            //Console.WriteLine();
            //}

            #endregion

            #region Завдання 2: Вивести інформацією про клієнтів, імена яких мають непарну довжину
            ////var clients = from c in customers
            ////             where c.Name.Length % 2 == 1
            ////             select c;

            //var clients = customers.Where(c => c.Name.Length % 2 == 1);

            //foreach (var client in clients)
            //{
            //    Console.Write(client.Name + " " + client.Birthday + " ");
            //    foreach (var phone in client.PhoneNumbers)
            //    {
            //        Console.Write(phone + " ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region Завдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з "671"
            //var clients = from c in customers
            //              where c.Birthday.Month % 2 == 0 && c.PhoneNumbers.Any(x => x.StartsWith("671"))
            //              select c;

            //var clients = customers.Where(c => c.Birthday.Month % 2 == 0 && c.PhoneNumbers.Any(x => x.StartsWith("671")));

            //foreach (var client in clients)
            //{
            //    Console.Write(client.Name + " " + client.Birthday + " ");
            //    foreach (var phone in client.PhoneNumbers)
            //    {
            //        Console.Write(phone + " ");
            //    }
            //Console.WriteLine();
            //}

            #endregion

            #endregion


            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            #region third task

            #region find out who is located farthest north/south/west/east using latitude/longitude data
            //var north = persons.Max(x => x.Latitude);
            //var south = persons.Min(x => x.Latitude);
            //var west = persons.Max(x => x.Longitude);
            //var east = persons.Min(x => x.Longitude);

            //foreach (var person in persons)
            //{
            //    if (person.Latitude == north)
            //    {
            //        Console.WriteLine($"North: {person.Name}, {person.Age}, {person.Address}, {person.Phone}");
            //    }
            //    else if (person.Latitude == south)
            //    {
            //        Console.WriteLine($"South: {person.Name}, {person.Age}, {person.Address}, {person.Phone}");
            //    }
            //    else if (person.Longitude == west)
            //    {
            //        Console.WriteLine($"West: {person.Name}, {person.Age}, {person.Address}, {person.Phone}");
            //    }
            //    else if (person.Longitude == east)
            //    {
            //        Console.WriteLine($"East: {person.Name}, {person.Age}, {person.Address}, {person.Phone}");
            //    }
            //}
            #endregion

            #region find max and min distance between 2 persons
            //var distance = from p1 in persons
            //               from p2 in persons
            //               where p2 != p1
            //               select new
            //               {
            //                   Distance = Math.Sqrt(Math.Pow(p1.Longitude - p1.Latitude, 2) + Math.Pow(p2.Longitude - p2.Latitude, 2))
            //               };

            //Console.WriteLine("Max distance: " + distance.Max(x => x.Distance));
            //Console.WriteLine("Min distance: " + distance.Min(x => x.Distance));
            #endregion

            #region find 2 persons whos ‘about’ have the most same words
            //var people = from p1 in persons
            //             from p2 in persons
            //             where p2 != p1 
            //             select new 
            //             { 
            //                 Human1 = p1.Name,
            //                 Human2 = p2.Name, 
            //                 Count = p1.About.ToLower().Split(" ").Intersect(p2.About.ToLower().Split(" ")).Count()
            //             };

            //int c = people.Max(x => x.Count);
            //bool isFirst = true; // перші люди у яких більше слів 
            //foreach (var person in people)
            //{
            //    if (person.Count == c && isFirst == true)
            //    {
            //        Console.WriteLine($"Person - {person.Human1} and person - {person.Human2} have most same words: {person.Count}");
            //        isFirst = false;
            //    }
            //}

            #endregion

            #region find persons with same friends(compare by friend’s name)

            #endregion

            #endregion
        }
    }
}