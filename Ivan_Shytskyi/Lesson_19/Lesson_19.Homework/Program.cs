using Newtonsoft.Json;

namespace Lesson_19.Homework
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
            {
                //SELECT
                //Завдання 1: Вивести імена та вік клієнтів
                var nameAndAge = from c in customers
                                 let name = c.Name
                                 let age = DateTime.UtcNow.Year - c.Birthday.Year
                                 select new
                                 {
                                     Name = name,
                                     Age = age
                                 };
                foreach (var i in nameAndAge)
                    Console.WriteLine($"Customer name: {i.Name}\tage - {i.Age}");

                var nameAndAge1 = customers.Select(c => new
                {
                    name1 = c.Name,
                    age1 = DateTime.UtcNow.Year - c.Birthday.Year
                });
                foreach (var i in nameAndAge1)
                    //Console.WriteLine(i);
                    Console.WriteLine($"Name: {i.name1}\tage - {i.age1}");
                Console.WriteLine();

                //Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380
                var customerNumber = from cm in customers
                                     select cm.PhoneNumbers;
                foreach (var cn in customerNumber)
                {
                    Console.Write($"Phone Numbers: ");
                    for (int i = 0; i < cn.Count; i++)
                        Console.Write($"+380{cn[i]} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                var customerNumber1 = customers.Select(cn => cn.PhoneNumbers);
                foreach (var n in customerNumber1)
                {
                    Console.Write($"Phone Numbers: ");
                    for (int i = 0; i < n.Count; i++)
                        Console.Write($"+380{n[i]} ");
                    Console.WriteLine();
                }
                Console.WriteLine();

                //Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру
                var inform = from info in customers
                             let name = info.Name
                             let age = DateOnly.FromDateTime(info.Birthday)
                             let number = info.PhoneNumbers
                             select new
                             {
                                 Number = number,
                                 Name = name,
                                 Age = age
                             };
                foreach (var i in inform)
                    foreach (var j in i.Number)
                        Console.WriteLine($"Number +380{j}\n{i.Name}\t{i.Age}\n");
                Console.WriteLine();
                var inform1 = customers.Select(inf => new
                {
                    Number1 = inf.PhoneNumbers,
                    Name1 = inf.Name,
                    Age1 = DateOnly.FromDateTime(inf.Birthday)
                });
                foreach (var i in inform1)
                    foreach (var j in i.Number1)
                        Console.WriteLine($"Number +380{j}\n{i.Name1}\t{i.Age1}\n");

                //WHERE:
                //Завдання 1: Вивести інформацією про клієнтів, хто народився у січні
                var jc = from c in customers
                         where c.Birthday.Month == 1
                         select c;
                foreach (var i in jc)
                {
                    Console.Write($"{i.Name} {DateOnly.FromDateTime(i.Birthday)}\nnumbers: ");
                    foreach (var j in i.PhoneNumbers)
                        Console.Write($"{j} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                var jc1 = customers.Where(c => c.Birthday.Month == 1);
                foreach (var i in jc1)
                {
                    Console.Write($"{i.Name} {DateOnly.FromDateTime(i.Birthday)}\nnumbers: ");
                    foreach (var j in i.PhoneNumbers)
                        Console.Write($"{j} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                //Завдання 2: Вивести інформацією про клієнтів, імена яких мають непарну довжину
                var np = from x in customers
                         where x.Name.Length % 2 != 0
                         select x;
                foreach (var i in np)
                {
                    Console.Write($"{i.Name} {DateOnly.FromDateTime(i.Birthday)} ");
                    foreach (var j in i.PhoneNumbers)
                        Console.Write($"{j} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                var np1 = customers.Where(y => y.Name.Length % 2 != 0);
                foreach (var i in np1)
                {
                    Console.Write($"{i.Name} {DateOnly.FromDateTime(i.Birthday)} ");
                    foreach (var j in i.PhoneNumbers)
                        Console.Write($"{j} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                //Завдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та
                //хоча б один номер яких починається з "671"
                var pm = from a in customers
                         from num in a.PhoneNumbers
                         where a.Birthday.Month % 2 == 0 && num.StartsWith("671")
                         select a;
                foreach (var i in pm)
                {
                    Console.Write($"{i.Name} {DateOnly.FromDateTime(i.Birthday)} ");
                    foreach (var j in i.PhoneNumbers)
                        Console.Write($"{j} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                var pm1 = customers.SelectMany(n1 => n1.PhoneNumbers,
                                                (a1, n1) => new { cus = a1, num1 = n1 })
                                                .Where(x => x.cus.Birthday.Month % 2 == 0 && x.num1.StartsWith("671"))
                                                .Select(x => x.cus);
                foreach (var i in pm1)
                {
                    Console.Write($"{i.Name} {DateOnly.FromDateTime(i.Birthday)} ");
                    foreach (var j in i.PhoneNumbers)
                        Console.Write($"{j} ");
                    Console.WriteLine();
                }
            }

            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            //find out who is located farthest north/south/west/east using latitude/longitude data
            var farthestNorth = persons.Where(p => p.Latitude == persons.Max(p => p.Latitude));
            foreach (var i in farthestNorth)
                Console.WriteLine($"Farthest north: {i.Name}");

            var farthestSouth = persons.Where(p => p.Latitude == persons.Min(p => p.Latitude));
            foreach (var i in farthestSouth)
                Console.WriteLine($"Farthest south: {i.Name}");

            var farthestWest = from p in persons
                               where p.Longitude == persons.Max(p => p.Longitude)
                               select (p);
            foreach (var i in farthestWest)
                Console.WriteLine($"Farthest west: {i.Name}");

            var farthestEast = from p in persons
                               where p.Longitude == persons.Min(p => p.Longitude)
                               select (p);
            foreach (var i in farthestEast)
                Console.WriteLine($"Farthest east: {i.Name}");
            Console.WriteLine();

            //find max and min distance between 2 persons -> I don't undersud
            //find distance between 2 persons

            var dis = from d in persons
                      from d1 in persons
                      where d != d1
                      let theta = d.Longitude - d1.Longitude
                      let distant = 60 * 1.1515 * (180 / Math.PI) *
                      Math.Acos(Math.Sin(d.Latitude * (Math.PI / 180)) * Math.Sin(d1.Latitude * (Math.PI / 180)) +
                                Math.Cos(d.Latitude * (Math.PI / 180)) * Math.Cos(d1.Latitude * (Math.PI / 180)) * Math.Cos(theta * (Math.PI / 180)))
                      select Math.Round(distant * 1.609344, 2);
            //attention a lot of results

            //foreach (var i in dis)
            //    Console.WriteLine($"Distance {i} km");
            //Console.WriteLine();


            //find 2 persons whos ‘about’ have the most same words
            //find persons with same friends(compare by friend’s name)               
        }
    }
}
