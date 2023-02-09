using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace LinqLesson
{
    class Program
    {
        record class Customer(string Name, DateTime Birthday, List<string> PhoneNumbers);

        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer("Alice", new DateTime(1992, 8, 2), new List<string> {"671954099", "671786544", "675098430"}),
                new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
                new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
                new Customer("Sarah", new DateTime(1990, 6, 6), new List<string> {"671675380", "672135768", "672121655"})
            };

            //SELECT
            //Завдання 1: Вивести імена та вік клієнтів
            var task1 = from c in customers
                         select (c.Name, DateTime.Now.Year - c.Birthday.Year);
            var task1M = customers.Select(i => new { i.Name, i.Birthday });

            //Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380
            var task2 = from c in customers
                         from n in c.PhoneNumbers
                         where n.StartsWith("671")
                         select (c.Name, n);
            var task2M = customers.SelectMany(n => n.PhoneNumbers).Where(n => n.StartsWith("672"));

            //Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру
            var task3 = from c in customers
                         from n in c.PhoneNumbers
                         select (n, c.Name, c.Birthday.ToString("dd-MM-yyyy"));
            var task3M = customers.SelectMany(c => c.PhoneNumbers,
                            (c, p) => new { Customer = c, Phone = p })
                            .Select(c=>c.Customer);
            //foreach (var item in task3M)
            //{
            //    foreach (var numb in item.PhoneNumbers)
            //    {
            //        Console.WriteLine(numb + " | " + item.Name);
            //    }
            //}

            //WHERE:
            //Завдання 1: Вивести інформацією про клієнтів, хто народився у січні
            var task4 = from c in customers
                         where c.Birthday.Month == 12 || c.Birthday.Month == 1 || c.Birthday.Month == 2
                         select (c.Name, c.Birthday.ToString("MMMM"));
            var task4M = customers.Where(n => int.Parse(n.Birthday.ToString("MM")) == 1);

            //Завдання 2: Вивести інформацією про клієнтів, імена яких мають непарну довжину
            var task5 = from c in customers
                        where c.Name.Length % 2 != 0
                        select c.Name;
            var task5M = customers.Where(n => n.Name.Length % 2 != 0);

            //Завдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з "671"
            var task6 = (from c in customers
                        from n in c.PhoneNumbers
                        where int.Parse(c.Birthday.ToString("MM")) % 2 == 0 && n.StartsWith("671")
                        select (c.Name, c.Birthday.ToString("dd-MM-yyyy"))).Distinct();
            var task6M = customers.Select(c => c).Where(c => c.Birthday.Month % 2 == 0).Distinct();
              
            
            // ----- JSON TASKS -----
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            //find out who is located farthest north/south/west/east using latitude/longitude data
            var north = persons.Max(x => x.Longitude);
            var personN = persons.First(x => x.Longitude == north);
            var south = persons.Min(x => x.Longitude);
            var personS = persons.First(x => x.Longitude == south);

            var east = persons.Max(x => x.Latitude);
            var personE = persons.First(x => x.Latitude == east);
            var west = persons.Min(x => x.Latitude);
            var personW = persons.First(x => x.Latitude == west);

            //find max and min distance between 2 persons


            //find 2 persons whos ‘about’ have the most same words


            //find persons with same friends(compare by friend’s name)
            
        }
    }
}